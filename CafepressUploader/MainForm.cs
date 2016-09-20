using CafepressUploader.Controllers;
using CafepressUploader.Forms;
using CafepressUploader.Models;
using CafepressUploader.Properties;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafepressUploader
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {

        #region props
        private static readonly ILog logger = LogManager.GetLogger(typeof(MainForm));

        #endregion

        #region logics
        public MainForm()
        {
            InitializeComponent();

            string dir = Directory.GetCurrentDirectory() + "\\" + Settings.Default.TEMPLATE_PATH;
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            var files = Directory.GetFiles(dir, "*.json", SearchOption.AllDirectories);
            if (files != null)
            {
                cbbTemplates.Items.Clear();
                foreach (var file in files)
                {
                    cbbTemplates.Items.Add(Path.GetFileNameWithoutExtension(file));
                }

                if (cbbTemplates.Items.Count > 0)
                    cbbTemplates.SelectedIndex = 0;
            }
        }
        

        private void ActiveElements(bool value)
        {
            btnLogin.Enabled = value;
            btnUpload.Enabled = value;
        }

        private void UpdateLogs(string result)
        {
            tbLogs.Invoke(new Action(()=> {

                tbLogs.Text += result + "\r\n";
            }));
        }

        private void ProcessUpload()
        {
            try
            {
                string templatePath = string.Empty;
                string dir = Directory.GetCurrentDirectory() + "\\" + Settings.Default.TEMPLATE_PATH;
                cbbTemplates.Invoke(new Action(() =>{ templatePath = dir + cbbTemplates.SelectedItem.ToString() + ".json"; }));
                if(!string.IsNullOrEmpty(templatePath))
                {
                    Template template = JsonConvert.DeserializeObject<Template>(File.ReadAllText(templatePath));
                    foreach (var logoItem in listBoxLogo.Items)
                    {
                        bool imageResult, updateDesignResult, uploadProductResult;
                        imageResult = updateDesignResult = uploadProductResult = false;
                        string imageUrl = string.Empty;
                        string fileName = Path.GetFileName(logoItem.ToString());
                        try
                        {
                            string logoPath = logoItem.ToString();
                            imageResult = CafepressController.Instance.UploadImage(logoPath);
                            Thread.Sleep(2000);

                            updateDesignResult = CafepressController.Instance.UpdateDesign(logoPath, template.Name, template.Tags, template.About);
                            Thread.Sleep(2000);
                            uploadProductResult = CafepressController.Instance.UploadProducts(ref imageUrl);

                            CafepressController.Instance.Reset();
                            Thread.Sleep(2000);
                        }
                        catch
                        {
                        }

                        if (imageResult && updateDesignResult && uploadProductResult)
                        {
                            UpdateLogs(fileName + " is uploaded successfully!");
                            File.AppendAllLines(Directory.GetCurrentDirectory() + "\\" + Settings.Default.SUCCESS_FILE, new string[] { logoItem.ToString() });
                        }
                        else
                        {
                            UpdateLogs(fileName + " is failed to upload!");
                            File.AppendAllLines(Directory.GetCurrentDirectory() + "\\" + Settings.Default.FAILED_FILE, new string[] { logoItem.ToString() });
                        }
                    }
                }                
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("Login: {0}, stacktrace: {1}", ex.Message, ex.StackTrace);
            }
        }

        private void UpdateTemplatesList()
        {
            cbbTemplates.Items.Clear();
            string dir = Directory.GetCurrentDirectory() + "\\" + Settings.Default.TEMPLATE_PATH;
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            var files = Directory.GetFiles(dir, "*.json", SearchOption.AllDirectories);
            if(files != null)
            {
                cbbTemplates.Items.Clear();
                foreach (var file in files)
                {
                    cbbTemplates.Items.Add(Path.GetFileNameWithoutExtension(file));
                }

                if (cbbTemplates.Items.Count > 0)
                    cbbTemplates.SelectedIndex = 0;
            }
        }


        #endregion

        #region background worker

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            if(e.Argument.ToString().Equals("upload"))
            {
                ProcessUpload();
                e.Result = "upload";
            }
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            tsProgressBar.Value = e.ProgressPercentage;
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Result.ToString().Equals("upload"))
            {
                ActiveElements(true);
                MessageBox.Show("Upload action is completed!");
            }
        }

        #endregion

        #region events
        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            var result = loginForm.ShowDialog();
            if(result == DialogResult.OK)
            {
                bool loginResult = CafepressController.Instance.Login(Settings.Default.CAFEPRESS_EMAIL, Settings.Default.CAFEPRESS_PASS);
                if (loginResult)
                {
                    lblLoginStatus.Text = Settings.Default.LOGIN_SUCCESS;
                }
                else
                    lblLoginStatus.Text = Settings.Default.LOGIN_FAILED;
            }


        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if(lblLoginStatus.Text == Settings.Default.LOGIN_SUCCESS)
            {
                if(listBoxLogo.Items.Count <= 0)
                {
                    MessageBox.Show("Choose folder contain logos!");
                    return;
                }

                if(cbbTemplates.Items.Count <=0)
                {
                    MessageBox.Show("Choose template!");
                    return;
                }
                ActiveElements(false);
                bgWorker.RunWorkerAsync("upload");
            }else
            {
                MessageBox.Show(Settings.Default.LOGIN_FAILED);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var folderDlg = new FolderBrowserDialog();            
            var result = folderDlg.ShowDialog();
            if(result == DialogResult.OK)
            {
                listBoxLogo.Items.Clear();
                var files = Directory.GetFiles(folderDlg.SelectedPath, "*.png", SearchOption.AllDirectories);
                foreach (var filePath in files)
                {
                    listBoxLogo.Items.Add(filePath);
                }
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            listBoxLogo.Items.Clear();
        }


        private void btnSaveTemplate_Click(object sender, EventArgs e)
        {
            string name = tbName.Text.Trim();
            string tags = tbTags.Text.Trim();
            string about = tbAbout.Text.Trim();
            string templateName = tbTemplateName.Text.Trim();
            if (name.Length == 0)
            {
                MessageBox.Show("Name template is required!");
                return;
            }

            if (tags.Length == 0)
            {
                MessageBox.Show("Tags template is required!");
                return;
            }
            
            if (about.Length == 0)
            {
                MessageBox.Show("About template is required!");
                return;
            }

            if (templateName.Length == 0)
            {
                MessageBox.Show("Template name is required!");
                return;
            }

            string dir = Directory.GetCurrentDirectory() + "\\" + Settings.Default.TEMPLATE_PATH;
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            string fileNamePath = dir + templateName + ".json";

            // update combobox templates
            Template temp = new Template
            {
                Name = name,
                Tags = tags,
                About = about
            };
            File.WriteAllText(fileNamePath, JsonConvert.SerializeObject(temp));
            UpdateTemplatesList();

            MessageBox.Show("New template is saved!");
        }

        #endregion

        private void cbbTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbbTemplates.Items.Count > 0)
            {
                string dir = Directory.GetCurrentDirectory() + "\\" + Settings.Default.TEMPLATE_PATH;
                string templateName = cbbTemplates.SelectedItem.ToString() + ".json";
                string tempContent = File.ReadAllText(dir + templateName);
                Template template = JsonConvert.DeserializeObject<Template>(tempContent);
                if(template != null)
                {
                    tbName.Text = template.Name;
                    tbTags.Text = template.Tags;
                    tbAbout.Text = template.About;
                }
            }
          
        }
    }
}
