using AutoUpload.Controllers;
using AutoUpload.Controls;
using AutoUpload.Models.Viralstyle;
using AutoUpload.Properties;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoUpload
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {

        #region props


        #endregion

        #region main logics

        public MainForm()
        {
            InitializeComponent();

            XmlConfigurator.Configure();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            
            Init();
           
        }

        #endregion


        #region public methods


        #endregion

        #region private methods


        private void Init()
        {
            // load products data from json
            ViralStyleDataController.Instance.LoadProductJson();

            // get mockup names
            List<string> names = new List<string>();
            for (int i = 0; i < viralMockupImageList.Images.Keys.Count; i++)
            {
                names.Add(viralMockupImageList.Images.Keys[i]);
            }

            // init mockup list         
            var products = ViralStyleDataController.Instance.ViralStyleProduct;
            if (products != null)
            {
                flowLayoutMokcup.Controls.Clear();
                string rootPath = Directory.GetCurrentDirectory() + "\\";
                for (int i = 0; i < products.ProductData.Length; i++)
                {
                    var product = products.ProductData[i];
                    for (int k = 0; k < product.category_products.Count; k++)
                    {
                        var proc = product.category_products[k].products;
                        MockupInfo mockupInfo = new MockupInfo
                        {
                            ImagePath = rootPath + Settings.Default.ViralStyle_Mockup_Path + "\\"
                                + proc.front_base,
                            Name = proc.name,
                            Colors = proc.product_colors.Select(p => p.hex).ToList(),
                            Product = proc
                        };
                        Mockup mockup = new Mockup(mockupInfo);
                        flowLayoutMokcup.Controls.Add(mockup);                        
                    }
                }
            }

            //var pairs = ViralStyleDataController.Instance.GetMockupImagesbyNames(names);

            // load list view items
            //if(pairs.Count > 0)
            //{
            //    vsListView.Items.Clear();
            //    foreach (var key in pairs.Keys)
            //    {
            //        vsListView.Items.Add(new ListViewItem(pairs[key], key));
            //    }
            //}

        }




        #endregion

        #region events


        #endregion

        private void metroButton1_Click(object sender, EventArgs e)
        {
            //var items = vsListView.SelectedIndices;
            //foreach (int item in items)
            //{
            //    var test = vsListView.Items[item];
            //    Console.WriteLine(test);
            //    Console.WriteLine(test.ImageKey);
            //}
            
        }

    }
}
