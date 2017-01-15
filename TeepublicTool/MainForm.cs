using log4net;
using log4net.Config;
using Newtonsoft.Json;
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
using TeepublicTool.Controllers.RedBubbleUploader.Controllers;
using TeepublicTool.Controls;
using TeepublicTool.Models;
using TeepublicTool.Properties;

namespace TeepublicTool
{
    public partial class MainForm : Form
    {
        public ProductTemplate CurrentTemplate { get; set; }
        private List<string> logoList = new List<string>();

        private static readonly ILog logger = LogManager.GetLogger(typeof(MainForm));
        public MainForm()
        {
            InitializeComponent();

            XmlConfigurator.Configure();
        }

        private void ActiveElements(bool value)
        {
            btnLoadLogo.Enabled = value;
            btnSaveTemplate.Enabled = value;
            btnLoadTemplate.Enabled = value;
            btnStartUpload.Enabled = value;
        }

        private void chbListProductTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckedListBox checkList = (CheckedListBox)sender;
            string controlName = checkList.SelectedItem.ToString();
           
            if (checkList.CheckedItems.Contains(controlName))
            {
                ProductType productType = ProductType.OTHERS;
                if(controlName.ToUpper().Equals("APPAREL"))
                {
                    productType = ProductType.APPAREL;
                }else if(controlName.ToUpper().Equals("PRINT"))
                {
                    productType = ProductType.PRINTS;
                }
                var control = new SimpleControl(controlName, productType);
                SimpleControl.SimpleControlsList.Add(control);
                flowLayout.Controls.Add(control);
            }else
            {
                var control = SimpleControl.FindControl(controlName);
                flowLayout.Controls.Remove(control);
                SimpleControl.RemoveControl(controlName);
              
            }
        }

        private void btnSaveTemplate_Click(object sender, EventArgs e)
        {
            string title = tbTitle.Text.Trim();
            if(title.Length == 0)
            {
                MessageBox.Show("Chua nhap title!");
                return;
            }
            string mainTag = tbMainTag.Text.Trim();
            if (mainTag.Length == 0)
            {
                MessageBox.Show("Chua nhap main tag!");
                return;
            }
            //string tags = string.Empty;
            //string description = string.Empty;
            string tags = tbTags.Text.Trim();
            //if (tags.Length == 0)
            //{
            //    MessageBox.Show("Chua nhap tags!");
            //    return;
            //}
            string description = tbDescription.Text.Trim();
            //if (description.Length == 0)
            //{
            //    MessageBox.Show("Chua nhap description!");
            //    return;
            //}

            if (SimpleControl.SimpleControlsList.Count == 0)
            {
                MessageBox.Show("Chua chon san pham nao!");
                return;
            }
           List<ProductData> objList = new List<ProductData>();
            if(SimpleControl.SimpleControlsList.Count > 0)
            {
                bool error = false;

                foreach (var item in SimpleControl.SimpleControlsList)
                {
                    if(item.MyName != "APPAREL")
                    {
                        if(item.CurrentColor == null)
                        {
                            MessageBox.Show("Chua nhap mau cho product " + item.MyName);
                            error = true;
                            break;
                        }
                    }
                }

                if(error)
                {
                    return;
                }
                foreach (var item in SimpleControl.SimpleControlsList)
                {
                    objList.Add(item.ConvertToDynamicObj());
                }
            }
            ProductTemplate template = new ProductTemplate
            {
                Title = title,
                MainTag = mainTag,
                Tags = tags,
                Description = description,
                Products = objList
            };

            var saveDlg = new SaveFileDialog();
            saveDlg.Filter = "Json|*.json";
            var result = saveDlg.ShowDialog();
            if(result == DialogResult.OK)
            {
                File.WriteAllText(saveDlg.FileName, JsonConvert.SerializeObject(template));
                CurrentTemplate = template;
                MessageBox.Show("Saved!");
            }
        }

        private void btnLoadTemplate_Click(object sender, EventArgs e)
        {
            var openDlg = new OpenFileDialog();
            openDlg.Filter = "Json|*.json";
            var result = openDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                string json = File.ReadAllText(openDlg.FileName);
                CurrentTemplate = JsonConvert.DeserializeObject<ProductTemplate>(json);
                MessageBox.Show("Loaded!");
            }
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string rootPath = Directory.GetCurrentDirectory() + "\\";
                string successPath = rootPath + "success\\";
                string successFile = rootPath + "uploaded.txt";

                if(!Directory.Exists(successPath))
                {
                    Directory.CreateDirectory(successPath);
                }
                PhantomController.Instance.Login(Settings.Default.EMAIL, Settings.Default.PASSWORD);
                int failed = 0;
                for (int i = 0; i < logoList.Count; i++)
                {
                    string logoPath = logoList[i];
                    string logoName = Path.GetFileName(logoPath);
                    bool error = false;
                    try
                    {
                        PhantomController.Instance.UploadArt(logoPath);
                        string saleUrl = PhantomController.Instance.UploadDesign(CurrentTemplate, Path.GetFileNameWithoutExtension(logoPath));
                        File.Move(logoPath, successPath + logoName);

                        this.Invoke(new Action(() => {
                            listBox1.Items.Remove(Path.GetFileName(logoPath));
                        }));

                        if(!string.IsNullOrEmpty(saleUrl))
                            File.AppendAllLines(successFile, new string[] { saleUrl });
                    }
                    catch (Exception ex)
                    {
                        logger.ErrorFormat("Error: {0}, stacktrace: {1}", ex.Message, ex.StackTrace);
                        error = true;
                    }

                    bgWorker.ReportProgress((i + 1) * 100 / logoList.Count);
                    this.Invoke(new Action(()=> {
                        tsLblProgress.Text = (i + 1) + "/" + logoList.Count;
                        if(error)
                        {
                            failed++;
                            tsLblFailed.Text = failed.ToString();
                        }
                    }));



                }
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("Error: {0}, stacktrace: {1}", ex.Message, ex.StackTrace);
            }
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            tsProgress.Value = e.ProgressPercentage;
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Xong");
            ActiveElements(true);


        }

        private void btnLoadLogo_Click(object sender, EventArgs e)
        {
            var folderDlg = new FolderBrowserDialog();
            var result = folderDlg.ShowDialog();
            if(result == DialogResult.OK)
            {
                logoList = Directory.GetFiles(folderDlg.SelectedPath, "*.png", 
                    SearchOption.AllDirectories).ToList();
                listBox1.Items.Clear();
                for (int i = 0; i < logoList.Count; i++)
                {
                    listBox1.Items.Add(Path.GetFileName(logoList[i]));
                }
            }
        }

        private void btnStartUpload_Click(object sender, EventArgs e)
        {
            if(CurrentTemplate == null)
            {
                MessageBox.Show("Chua co template!");
                return;
            }

            if(logoList.Count == 0)
            {
                MessageBox.Show("Chua chon thu muc chua logo!");
                return;
            }

            bgWorker.RunWorkerAsync();
            ActiveElements(false);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Settings.Default.EMAIL = tbEmails.Text.Trim();
            Settings.Default.PASSWORD = tbPass.Text.Trim();
            Settings.Default.Save();
            MessageBox.Show("Updated!");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            tbEmails.Text = Settings.Default.EMAIL;
            tbPass.Text = Settings.Default.PASSWORD;

        }
    }
}
