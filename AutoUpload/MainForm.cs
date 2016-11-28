using AutoUpload.Controllers;
using AutoUpload.Controls;
using AutoUpload.Models;
using AutoUpload.Models.Viralstyle;
using AutoUpload.Properties;
using log4net;
using log4net.Config;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViralStyleUploader.Utils;

namespace AutoUpload
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {

        #region props
        public Template CurrentTemplate { get; set; }
        private List<string> logoList;

        private static readonly ILog logger = LogManager.GetLogger(typeof(MainForm));
        #endregion

        #region main logics

        public MainForm()
        {
            InitializeComponent();

            XmlConfigurator.Configure();

            logoList = new List<string>();

            //string jsonData = File.ReadAllText(Directory.GetCurrentDirectory() + "\\data3.json");
            //jsonData = jsonData.Replace("\r\n", "");
            //var data = JsonConvert.DeserializeObject<ViralStyleRequestJsonData>(jsonData);
            //ViralStyleRequestData finalData = new ViralStyleRequestData();
            //finalData._token = data._token;
            //finalData.campaign_data = JsonConvert.DeserializeObject<Campaign>(data.campaign_data);
            //Console.WriteLine(finalData._token);

            //System.Drawing.Image img = System.Drawing.Image.FromFile(logoPath);
            //System.Drawing.Image resizeImg = Resize(@"C:\Users\RAVI\Desktop\Logo\BROWN.png", "", 0.5);
            //string base64String;
            //using (var ms = new MemoryStream())
            //{
            //    resizeImg.Save(ms, resizeImg.RawFormat);
            //    base64String = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
            //}
            ////img.Dispose();
            //resizeImg.Dispose();

        }
        public static Bitmap Resize(string imageFile, string outputFile, double scaleFactor)
        {
            using (var srcImage = System.Drawing.Image.FromFile(imageFile))
            {
                var newWidth = (int)(srcImage.Width * scaleFactor);
                var newHeight = (int)(srcImage.Height * scaleFactor);
                using (var newImage = new Bitmap(newWidth, newHeight))
                using (var graphics = Graphics.FromImage(newImage))
                {
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    graphics.DrawImage(srcImage, new Rectangle(0, 0, newWidth, newHeight));
                    return newImage;
                    
                }
            }
            return null;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
            Init();
           
        }

        #endregion


        #region public methods
        private void ProcessUpload(string logoPath)
        {
            if(!ViralStyleController.Instance.IsLogged)
            {
                ViralStyleController.Instance.GetCookieSession();
                Thread.Sleep(2000);
                ViralStyleController.Instance.GetToken();
                Thread.Sleep(2000);
                ViralStyleController.Instance.Login(Settings.Default.EMAIL, Settings.Default.PASSWORD);
            }
            
            ViralStyleController.Instance.Upload(logoPath);
            Thread.Sleep(1000);
            ViralStyleController.Instance.GetNewToken();
            ViralStyleController.Instance.UploadStore(CurrentTemplate, logoPath);
        }

        #endregion


        #region worker


        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (e.Argument.ToString().Equals("UploadViralStyle"))
                {
                    string completedPath = Directory.GetCurrentDirectory() + "\\" 
                        + Settings.Default.COMPLETED_PATH;
                    if (!Directory.Exists(completedPath))
                        Directory.CreateDirectory(completedPath);

                    for (int i = 0; i < logoList.Count; i++)
                    {
                        try
                        {
                            ProcessUpload(logoList[i]);
                            this.Invoke(new Action(()=>
                            {
                                string newPath = completedPath + Path.GetFileName(logoList[i]);
                                listViewLogo.Items.Remove(logoList[i]);
                                //File.Move(logoList[i], newPath);
                                if (listLogs.Items.Count > 50)
                                    listLogs.Items.Clear();
                                listLogs.Items.Add("Upload completed! Move file to new path: " + completedPath);
                            }));
                         
                        }
                        catch (Exception ex)
                        {
                            logger.ErrorFormat("Error: {0}, Details: {1}", ex.Message, ex.StackTrace);
                        }

                        this.Invoke(new Action(() => {
                            tsLblProgress.Text = (i + 1) + "/" + logoList.Count;
                        }));

                        bgWorker.ReportProgress((i + 1) * 100 / logoList.Count);
                       
                        break;

                    }
                    e.Result = "UploadViralStyle";
                }
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("Error: {0}, Details: {1}", ex.Message, ex.StackTrace);
            }
         
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            tsProgress.Value = e.ProgressPercentage;
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result.ToString().Equals("UploadViralStyle"))
            {
                btnUpload.Enabled = true;
                MessageBox.Show("Done!");
            }
        }

        #endregion

        #region private methods


        private void Init()
        {
            // load settings
            opTbEmail.Text = Settings.Default.EMAIL;
            opTbPass.Text = Settings.Default.PASSWORD;
            opChbShowMockup.Checked = Settings.Default.SHOW_MOCKUP == "true" ? true : false;

            // load products data from json
            ViralStyleDataController.Instance.LoadProductJson();

            // get mockup names
            List<string> names = new List<string>();
            for (int i = 0; i < viralMockupImageList.Images.Keys.Count; i++)
            {
                names.Add(viralMockupImageList.Images.Keys[i]);
            }

            // init mockup list         
            flowLayoutMokcup.Controls.Clear();
            if (opChbShowMockup.Checked)
            {
                var products = ViralStyleDataController.Instance.ViralStyleProduct;
                if (products != null)
                {
                    
                    string rootPath = Directory.GetCurrentDirectory() + "\\";
                    for (int i = 0; i < products.ProductData.Count; i++)
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
                            if(File.Exists(mockupInfo.ImagePath))
                            {
                                Mockup mockup = new Mockup(mockupInfo);
                                flowLayoutMokcup.Controls.Add(mockup);
                            }
                            
                        }
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


       

        private void metroButton1_Click(object sender, EventArgs e)
        {
            string title = tbTitle.Text.Trim();
            if(title.Length == 0)
            {
                MessageBox.Show("Fill title!");
                return;
            }
            
            string des = tbDescription.Text.Trim();
            if(des.Length == 0)
            {
                MessageBox.Show("Fill description!");
                return;
            }
            string campUrl = tbCampUrl.Text.Trim();
            if(campUrl.Length == 0)
            {
                MessageBox.Show("Fill campaign url!");
                return;
            }
            string tags = tbTags.Text.Trim();
            if(tags.Length == 0)
            {
                MessageBox.Show("Fill tags!");
                return;
            }

            string templateName = tbTemplateName.Text.Trim();
            if(templateName.Length == 0)
            {
                MessageBox.Show("Fill template name!");
                return;
            }

            CurrentTemplate = new Template
            {
                TemplateName = templateName,
                CampUrl = campUrl,
                Title = title,
                Description = des,
                Tags = tags,
                AutoRelaunch = chbAutoRelaunch.Checked,
                AutoExtend = chbAutoExtend.Checked,
                CampaignPageTimer = chbPageTimer.Checked,
                Goal = (int)numGoal.Value,
                HideMarketPlace = chbHideMarketPlace.Checked,
                ShowBackDefault = chbShowBack.Checked,
                ShowGoal = chbShowGoal.Checked
            };

            var saveDlg = new SaveFileDialog();
            saveDlg.Filter = "Json File|*.json";
            var result = saveDlg.ShowDialog();
            if(result == DialogResult.OK)
            {
                File.WriteAllText(saveDlg.FileName, JsonConvert.SerializeObject(CurrentTemplate));
                MessageBox.Show("Saved!");
            }
            
        }

        private void btnLoadTemplate_Click(object sender, EventArgs e)
        {
            var openDlg = new OpenFileDialog();
            openDlg.Filter = "Json File|*.json";
            var result = openDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                var jsonContent = File.ReadAllText(openDlg.FileName);
                CurrentTemplate = JsonConvert.DeserializeObject<Template>(jsonContent);
                tbTitle.Text = CurrentTemplate.Title;
                tbDescription.Text = CurrentTemplate.Description;
                tbCampUrl.Text = CurrentTemplate.CampUrl;
                tbTags.Text = CurrentTemplate.Tags;
                tbTemplateName.Text = CurrentTemplate.TemplateName;
                numGoal.Value = (CurrentTemplate.Goal);

                chbAutoRelaunch.Checked = CurrentTemplate.AutoRelaunch;
                chbAutoExtend.Checked = CurrentTemplate.AutoExtend;
                chbPageTimer.Checked = CurrentTemplate.CampaignPageTimer;
                chbShowBack.Checked = CurrentTemplate.ShowBackDefault;
                chbHideMarketPlace.Checked = CurrentTemplate.HideMarketPlace;
                chbShowGoal.Checked = CurrentTemplate.ShowGoal;
                MessageBox.Show("Loaded!");
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {

            if(CurrentTemplate == null)
            {
                MessageBox.Show("Please create or load template!");
                return;
            }

            string title = tbTitle.Text.Trim();
            if (title.Length == 0)
            {
                MessageBox.Show("Fill title!");
                return;
            }

            string des = tbDescription.Text.Trim();
            if (des.Length == 0)
            {
                MessageBox.Show("Fill description!");
                return;
            }
            string campUrl = tbCampUrl.Text.Trim();
            if (campUrl.Length == 0)
            {
                MessageBox.Show("Fill campaign url!");
                return;
            }
            string tags = tbTags.Text.Trim();
            if (tags.Length == 0)
            {
                MessageBox.Show("Fill tags!");
                return;
            }
            if(listViewLogo.Items.Count == 0)
            {
                MessageBox.Show("Please load list logo!");
                return;
            }


            string email = Settings.Default.EMAIL.Trim();
            string pass = Settings.Default.PASSWORD.Trim();
            if(email.Length == 0)
            {
                MessageBox.Show("Please fill  and save ViralStyle's email in Option Tab!");
                return;
            }

            if (email.Length == 0)
            {
                MessageBox.Show("Please fill and save ViralStyle's password in Option Tab!");
                return;
            }

            if(string.IsNullOrEmpty(Mockup.NameDefault))
            {
                MessageBox.Show("Choose one default mockup!");
                return;
            }else
            {
                if(Mockup.selectedMockup.Count == 0)
                {
                    MessageBox.Show("Choose one mockup to upload!");
                    return;
                }else
                {
                    bool error = false;
                    bool notFound = true;
                    foreach (var mockup in Mockup.selectedMockup)
                    {
                        if(Mockup.NameDefault == mockup.Name)
                        {
                            if(mockup.colorList.Count == 0)
                            {
                                error = true;                               
                                break;
                            }                           
                        }
                    }

                    foreach (var mockup in Mockup.selectedMockup)
                    {
                        if (Mockup.NameDefault == mockup.Name)
                        {
                            notFound = false;
                            break;
                        }
                    }

                    if (error || notFound)
                    {
                        MessageBox.Show("Default mockup require at least one color!");
                        return;
                    }
                }

                
            }



            bgWorker.RunWorkerAsync("UploadViralStyle");
            btnUpload.Enabled = false;
        }

        private void btnLoadLogo_Click(object sender, EventArgs e)
        {
            var folderDlg = new FolderBrowserDialog();
            var result = folderDlg.ShowDialog();
            if(result == DialogResult.OK)
            {
                logoList = Directory.GetFiles(folderDlg.SelectedPath, "*.png", 
                    SearchOption.AllDirectories).ToList();
                listViewLogo.Items.Clear();
                for (int i = 0; i < logoList.Count; i++)
                {
                    listViewLogo.Items.Add(Path.GetFileName(logoList[i]));
                }
            }
        }

        private void opBtnSave_Click(object sender, EventArgs e)
        {
            Settings.Default.EMAIL = opTbEmail.Text.Trim();
            Settings.Default.PASSWORD = opTbPass.Text.Trim();
            Settings.Default.SHOW_MOCKUP = opChbShowMockup.Checked ? "true" : "false";
            Settings.Default.Save();

            MessageBox.Show("Saved!");
        }

        #endregion


    }
}
