﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.IO;
using imageeditor.Model;
using System.Drawing.Drawing2D;

namespace imageeditor
{
    public partial class SunfrogToolkit : Form
    {

        #region new props
        private LayerManager layerManager;
        private Color selectedColor;
        private Color outlineColor;
        #endregion

        #region old props
        Color paintcolor;
        bool choose = false;
        bool draw = false;
        int x, y, lx, ly = 0;
        Item currItem;

        #endregion

        #region old logic
        public SunfrogToolkit()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.ResizeRedraw |
                 ControlStyles.UserPaint |
                 ControlStyles.ResizeRedraw,
                 true);
            selectedColor = Color.Blue;
            outlineColor = Color.Yellow;
        }

        public enum Item
        {
            Rectangle, Ellipse, Line, Text, Brush, Pencil, eraser, ColorPicker
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            choose = true;
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            choose = false;
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (choose)
            {
                Bitmap bmp = (Bitmap)pictureBox2.Image.Clone();
                paintcolor = bmp.GetPixel(e.X, e.Y);
                red.Value = paintcolor.R;
                green.Value = paintcolor.G;
                blue.Value = paintcolor.B;
                alpha.Value = paintcolor.A;
                redval.Text = paintcolor.R.ToString();
                greenval.Text = paintcolor.G.ToString();
                blueval.Text = paintcolor.B.ToString();
                alphaval.Text = paintcolor.A.ToString();
                pictureBox3.BackColor = paintcolor;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            draw = true;
            x = e.X;
            y = e.Y;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            draw = false;
            lx = e.X;
            ly = e.Y;
            
            if (currItem == Item.Line)
            {
                Graphics g = pictureBox1.CreateGraphics();
                g.DrawLine(new Pen(new SolidBrush(paintcolor)), new Point(x, y), new Point(lx, ly));
                g.Dispose();

            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (draw)
            {
                //layerManager.UpdateCenterPosition(x, y);
                x = e.Location.X;
                y = e.Location.Y;

                
                var trans = layerManager.GetCurrentLayer();
                if(trans != null)
                {
                    tbPosX.Text = x.ToString();
                    tbPosY.Text = y.ToString();
                }else
                {
                    tbPosX.Text = "";
                    tbPosY.Text = "";
                }
                if (pictureBox1.Image != null)
                    pictureBox1.Image.Dispose();

                pictureBox1.Invalidate();
                //Graphics g = pictureBox1.CreateGraphics();
                //switch (currItem)
                //{
                //    case Item.Rectangle:
                //        g.FillRectangle(new SolidBrush(paintcolor), x, y, e.X - x, e.Y - y);
                //        break;
                //    case Item.Ellipse:
                //        g.FillEllipse(new SolidBrush(paintcolor), x, y, e.X - x, e.Y - y);
                //        break;
                //    case Item.Brush:
                //        g.FillEllipse(new SolidBrush(paintcolor), e.X - x + x, e.Y - y + y, Convert.ToInt32(tbBrushSize.Text), Convert.ToInt32(tbBrushSize.Text));
                //        break;
                //    case Item.Pencil:
                //        g.FillEllipse(new SolidBrush(paintcolor), e.X - x + x, e.Y - y + y, 5, 5);
                //        break;
                //    case Item.eraser:
                //        g.FillEllipse(new SolidBrush(pictureBox1.BackColor), e.X - x + x, e.Y - y + y, Convert.ToInt32(tbBrushSize.Text), Convert.ToInt32(tbBrushSize.Text));
                //        break;
                //}
                //g.Dispose();
            }
        }
        

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            currItem = Item.Brush;
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            currItem = Item.Rectangle;
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            currItem = Item.Ellipse;
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            currItem = Item.Pencil;
        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            currItem = Item.eraser;
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            currItem = Item.Line;
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            currItem = Item.ColorPicker;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (currItem == Item.ColorPicker)
            {
                Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                Graphics g = Graphics.FromImage(bmp);
                Rectangle rect = pictureBox1.RectangleToScreen(pictureBox1.ClientRectangle);
                g.CopyFromScreen(rect.Location, Point.Empty, pictureBox1.Size);
                g.Dispose();
                paintcolor = bmp.GetPixel(e.X, e.Y);
                pictureBox3.BackColor = paintcolor;
                red.Value = paintcolor.R;
                green.Value = paintcolor.G;
                blue.Value = paintcolor.B;
                alpha.Value = paintcolor.A;
                redval.Text = paintcolor.R.ToString();
                greenval.Text = paintcolor.G.ToString();
                blueval.Text = paintcolor.B.ToString();
                alphaval.Text = paintcolor.A.ToString();
                bmp.Dispose();
            }
        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {
            currItem = Item.Text;
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            if (currItem == Item.Text)
            {
                if (cbbFontStyle.Text == "Regular")
                {
                    g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Regular), new SolidBrush(paintcolor), new PointF(x, y));
                }
                else if (cbbFontStyle.Text == "Bold")
                {
                    g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Bold), new SolidBrush(paintcolor), new PointF(x, y));
                }
                else if (cbbFontStyle.Text == "Underline")
                {
                    g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Underline), new SolidBrush(paintcolor), new PointF(x, y));
                }
                else if (cbbFontStyle.Text == "Strikeout")
                {
                    g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Strikeout), new SolidBrush(paintcolor), new PointF(x, y));
                }
                else if (cbbFontStyle.Text == "Italic")
                {
                    g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Italic), new SolidBrush(paintcolor), new PointF(x, y));
                }
                if(cbbTextShadow.Text == "SE")
                {
                    if (cbbFontStyle.Text == "Regular")
                    {
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Regular), new SolidBrush(Color.Gray), new PointF(x + 5, y + 5));
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Regular), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (cbbFontStyle.Text == "Bold")
                    {
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Bold), new SolidBrush(Color.Gray), new PointF(x + 5, y + 5));
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Bold), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (cbbFontStyle.Text == "Underline")
                    {
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Underline), new SolidBrush(Color.Gray), new PointF(x + 5, y + 5));
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Underline), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (cbbFontStyle.Text == "Strikeout")
                    {
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Strikeout), new SolidBrush(Color.Gray), new PointF(x + 5, y + 5));
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Strikeout), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (cbbFontStyle.Text == "Italic")
                    {
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Italic), new SolidBrush(Color.Gray), new PointF(x + 5, y + 5));
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Italic), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                }
                else if (cbbTextShadow.Text == "SW")
                {
                    if (cbbFontStyle.Text == "Regular")
                    {
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Regular), new SolidBrush(Color.Gray), new PointF(x - 5, y + 5));
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Regular), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (cbbFontStyle.Text == "Bold")
                    {
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Bold), new SolidBrush(Color.Gray), new PointF(x - 5, y + 5));
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Bold), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (cbbFontStyle.Text == "Underline")
                    {
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Underline), new SolidBrush(Color.Gray), new PointF(x - 5, y + 5));
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Underline), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (cbbFontStyle.Text == "Strikeout")
                    {
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Strikeout), new SolidBrush(Color.Gray), new PointF(x - 5, y + 5));
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Strikeout), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (cbbFontStyle.Text == "Italic")
                    {
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Italic), new SolidBrush(Color.Gray), new PointF(x - 5, y + 5));
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Italic), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                }
                else if (cbbTextShadow.Text == "NE")
                {
                    if (cbbFontStyle.Text == "Regular")
                    {
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Regular), new SolidBrush(Color.Gray), new PointF(x + 5, y - 5));
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Regular), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (cbbFontStyle.Text == "Bold")
                    {
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Bold), new SolidBrush(Color.Gray), new PointF(x + 5, y - 5));
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Bold), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (cbbFontStyle.Text == "Underline")
                    {
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Underline), new SolidBrush(Color.Gray), new PointF(x + 5, y - 5));
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Underline), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (cbbFontStyle.Text == "Strikeout")
                    {
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Strikeout), new SolidBrush(Color.Gray), new PointF(x + 5, y - 5));
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Strikeout), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (cbbFontStyle.Text == "Italic")
                    {
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Italic), new SolidBrush(Color.Gray), new PointF(x + 5, y - 5));
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Italic), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                }
                else if (cbbTextShadow.Text == "NW")
                {
                    if (cbbFontStyle.Text == "Regular")
                    {
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Regular), new SolidBrush(Color.Gray), new PointF(x - 5, y - 5));
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Regular), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (cbbFontStyle.Text == "Bold")
                    {
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Bold), new SolidBrush(Color.Gray), new PointF(x - 5, y - 5));
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Bold), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (cbbFontStyle.Text == "Underline")
                    {
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Underline), new SolidBrush(Color.Gray), new PointF(x - 5, y - 5));
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Underline), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (cbbFontStyle.Text == "Strikeout")
                    {
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Strikeout), new SolidBrush(Color.Gray), new PointF(x - 5, y - 5));
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Strikeout), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (cbbFontStyle.Text == "Italic")
                    {
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Italic), new SolidBrush(Color.Gray), new PointF(x - 5, y - 5));
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Italic), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                }
                 else if (cbbTextShadow.Text == "S")
                {
                    if (cbbFontStyle.Text == "Regular")
                    {
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Regular), new SolidBrush(Color.Gray), new PointF(x, y + 5));
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Regular), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (cbbFontStyle.Text == "Bold")
                    {
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Bold), new SolidBrush(Color.Gray), new PointF(x, y + 5));
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Bold), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (cbbFontStyle.Text == "Underline")
                    {
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Underline), new SolidBrush(Color.Gray), new PointF(x, y + 5));
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Underline), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (cbbFontStyle.Text == "Strikeout")
                    {
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Strikeout), new SolidBrush(Color.Gray), new PointF(x, y + 5));
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Strikeout), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (cbbFontStyle.Text == "Italic")
                    {
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Italic), new SolidBrush(Color.Gray), new PointF(x, y + 5));
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Italic), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                }
                else if (cbbTextShadow.Text == "N")
                {
                    if (cbbFontStyle.Text == "Regular")
                    {
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Regular), new SolidBrush(Color.Gray), new PointF(x, y - 5));
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Regular), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (cbbFontStyle.Text == "Bold")
                    {
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Bold), new SolidBrush(Color.Gray), new PointF(x, y - 5));
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Bold), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (cbbFontStyle.Text == "Underline")
                    {
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Underline), new SolidBrush(Color.Gray), new PointF(x, y - 5));
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Underline), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (cbbFontStyle.Text == "Strikeout")
                    {
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Strikeout), new SolidBrush(Color.Gray), new PointF(x, y - 5));
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Strikeout), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (cbbFontStyle.Text == "Italic")
                    {
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Italic), new SolidBrush(Color.Gray), new PointF(x, y - 5));
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Italic), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                }
                else if (cbbTextShadow.Text == "W")
                {
                    if (cbbFontStyle.Text == "Regular")
                    {
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Regular), new SolidBrush(Color.Gray), new PointF(x - 5, y));
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Regular), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (cbbFontStyle.Text == "Bold")
                    {
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Bold), new SolidBrush(Color.Gray), new PointF(x - 5, y));
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Bold), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (cbbFontStyle.Text == "Underline")
                    {
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Underline), new SolidBrush(Color.Gray), new PointF(x - 5, y));
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Underline), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (cbbFontStyle.Text == "Strikeout")
                    {
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Strikeout), new SolidBrush(Color.Gray), new PointF(x - 5, y));
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Strikeout), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (cbbFontStyle.Text == "Italic")
                    {
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Italic), new SolidBrush(Color.Gray), new PointF(x - 5, y));
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Italic), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                }
                else if (cbbTextShadow.Text == "E")
                {
                    if (cbbFontStyle.Text == "Regular")
                    {
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Regular), new SolidBrush(Color.Gray), new PointF(x + 5, y));
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Regular), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (cbbFontStyle.Text == "Bold")
                    {
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Bold), new SolidBrush(Color.Gray), new PointF(x + 5, y));
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Bold), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (cbbFontStyle.Text == "Underline")
                    {
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Underline), new SolidBrush(Color.Gray), new PointF(x + 5, y));
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Underline), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (cbbFontStyle.Text == "Strikeout")
                    {
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Strikeout), new SolidBrush(Color.Gray), new PointF(x + 5, y));
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Strikeout), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                    else if (cbbFontStyle.Text == "Italic")
                    {
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Italic), new SolidBrush(Color.Gray), new PointF(x + 5, y));
                        g.DrawString(tbText.Text, new Font(cbbFontName.Text, Convert.ToInt32(cbbFontSize.Text), FontStyle.Italic), new SolidBrush(paintcolor), new PointF(x, y));
                    }
                }
                g.Dispose();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            layerManager.RemoveAllLayer();
            UpdateInfo();
            pictureBox1.Refresh();
            pictureBox1.Invalidate();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            layerManager.RemoveAllLayer();
            UpdateInfo();
            pictureBox1.Refresh();
            pictureBox1.Invalidate();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "Png files|*.png|jpeg files|*jpg|bitmaps|*.bmp";
            if (o.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //pictureBox1.Image = (Image)Image.FromFile(o.FileName).Clone();
                layerManager.AddLayer(o.FileName);
                UpdateInfo();
                pictureBox1.Invalidate();
               
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //Graphics g = Graphics.FromImage(bmp);
            //Rectangle rect = pictureBox1.RectangleToScreen(pictureBox1.ClientRectangle);
            //g.CopyFromScreen(rect.Location, Point.Empty, pictureBox1.Size);
            //g.Dispose();
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "Png files|*.png|jpeg files|*jpg|bitmaps|*.bmp";
            if (s.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (File.Exists(s.FileName))
                {
                    File.Delete(s.FileName);
                }

                layerManager.ExportImage(s.FileName, new Size(2400, 3200));
            }
        }

        private void toolStripComboBox2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FontFamily[] family = FontFamily.Families;
            foreach (FontFamily font in family)
            {
                cbbFontName.Items.Add(font.GetName(1).ToString());
            }

            layerManager = new LayerManager();
            layerManager.ZoomPercent = 0.15f;

            var LineJoinvalues = Enum.GetValues(typeof(LineJoin));
            cbbOutlineStyle.Items.Clear();
            foreach (var style in LineJoinvalues)
            {
                cbbOutlineStyle.Items.Add(style.ToString());
            }
            if (cbbOutlineStyle.Items.Count > 0)
                cbbOutlineStyle.SelectedIndex = 0;
        }

        private void red_Scroll(object sender, EventArgs e)
        {
            paintcolor = Color.FromArgb(alpha.Value, red.Value, green.Value, blue.Value);
            pictureBox3.BackColor = paintcolor;
            redval.Text = "R: " + paintcolor.R.ToString();
        }

        private void green_Scroll(object sender, EventArgs e)
        {
            paintcolor = Color.FromArgb(alpha.Value, red.Value, green.Value, blue.Value);
            pictureBox3.BackColor = paintcolor;
            greenval.Text = "G: " + paintcolor.G.ToString();
        }

        private void blue_Scroll(object sender, EventArgs e)
        {
            paintcolor = Color.FromArgb(alpha.Value, red.Value, green.Value, blue.Value);
            pictureBox3.BackColor = paintcolor;
            blueval.Text = "B: " + paintcolor.B.ToString();
        }

        private void alpha_Scroll(object sender, EventArgs e)
        {
            paintcolor = Color.FromArgb(alpha.Value, red.Value, green.Value, blue.Value);
            pictureBox3.BackColor = paintcolor;
            alphaval.Text = "A: " + paintcolor.A.ToString();
        }

        #endregion

      
        #region new logic
        private void UpdateInfo()
        {
            if(layerManager != null)
            {
                lbLayers.Items.Clear();
                if(layerManager.Layers.Count > 0)
                {
                    for (int i = 0; i < layerManager.Layers.Count; i++)
                    {
                        lbLayers.Items.Add(layerManager.Layers[i].LayerName);
                    }
                }
                if(lbLayers.Items.Count > 0)
                {
                    lbLayers.SelectedIndex = layerManager.SelectedIndex;
                }
            }
        }

        private FontFamily GetFontByName(string fontName)
        {
            FontFamily[] family = FontFamily.Families;
            foreach (FontFamily font in family)
            {
                if (fontName == font.GetName(1).ToString())
                {
                    return font;
                }
            }
            return null;
        }

        #endregion


        #region events
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (draw)
            {
                layerManager.UpdateCenterPosition(x, y);
            }

            layerManager.DrawLayers(e.Graphics);
        }

        private void btnDeleteLayer_Click(object sender, EventArgs e)
        {
            if(layerManager.Layers.Count > 0)
            {
                layerManager.RemoveLayer();
                UpdateInfo();
                pictureBox1.Invalidate();
            }
            
        }

        private void btnAddText_Click(object sender, EventArgs e)
        {            
            string strText = tbText.Text.Trim();
            if(strText.Length == 0)
            {
                MessageBox.Show("Please input text!");
                return;
            }
            FontFamily font = GetFontByName(cbbFontName.SelectedItem.ToString());
            if(font != null)
            {
                int outlineSize = int.Parse(tbOutlineSize.Text.Trim());
                LineJoin lineJoin = (LineJoin)(cbbOutlineStyle.SelectedIndex);

                Font ff = new Font(font, int.Parse(cbbFontSize.Text.ToString()), FontStyle.Regular, GraphicsUnit.Pixel);
                Layer layer = new Layer(new LayerText(strText, ff, selectedColor, outlineSize, outlineColor, lineJoin));
                layerManager.AddTextLayer(layer);
                UpdateInfo();
                pictureBox1.Invalidate();
            }else
            {
                MessageBox.Show("Cannot found font "+cbbFontName.SelectedItem.ToString());
            }
        }

        private void btnUpdateText_Click(object sender, EventArgs e)
        {
            string strText = tbText.Text.Trim();
            if(strText.Length == 0)
            {
                MessageBox.Show("Please input text!");
                return;
            }

            int posX = int.Parse(tbPosX.Text.Trim());
            int posY = int.Parse(tbPosY.Text.Trim());

            // UPDATE LAYER TEXT
            FontFamily font = GetFontByName(cbbFontName.SelectedItem.ToString());
            if (font != null)
            {
                int outlineSize = int.Parse(tbOutlineSize.Text.Trim());
                LineJoin lineJoin = (LineJoin)(cbbOutlineStyle.SelectedIndex);

                Layer currentLayer = layerManager.GetCurrentLayer();
                currentLayer.LayerText.Content = strText;
                currentLayer.LayerText.Font.Dispose();
                currentLayer.LayerText.Font = new Font(font, int.Parse(cbbFontSize.Text.ToString()), FontStyle.Regular, GraphicsUnit.Pixel);
                currentLayer.LayerText.TextColor = selectedColor;
                currentLayer.LayerText.OutlineSize = outlineSize;
                currentLayer.LayerText.OutlineColor = outlineColor;
                currentLayer.LayerText.OutlineStyle = lineJoin;
                //Layer layer = new Layer(new LayerText(strText, ff, selectedColor, outlineSize, outlineColor, lineJoin));
                //layerManager.AddTextLayer(layer);
                UpdateInfo();
            }
            else
            {
                MessageBox.Show("Cannot found font " + cbbFontName.SelectedItem.ToString());
            }
           
            layerManager.UpdateCenterPosition(posX, posY);
            pictureBox1.Invalidate();
        }

        private void btnTextColor_Click(object sender, EventArgs e)
        {
            var result = colorDialog1.ShowDialog();
            if(result == System.Windows.Forms.DialogResult.OK)
            {
                selectedColor = colorDialog1.Color;
                btnTextColor.BackColor = selectedColor;
            }
        }

        private void btnOutlineColor_Click(object sender, EventArgs e)
        {
            var result = colorDialog1.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                outlineColor = colorDialog1.Color;
                btnOutlineColor.BackColor = outlineColor;
            }
        }
        #endregion

 

  


     

    

       

    }
}
