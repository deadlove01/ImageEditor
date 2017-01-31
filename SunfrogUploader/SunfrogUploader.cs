using log4net;
using log4net.Config;
using MetroFramework.Forms;
using SunfrogUploader.Controller;
using SunfrogUploader.Model;
using SunfrogUploader.Properties;
using SunfrogUploader.Util;
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

namespace SunfrogUploader
{
    public partial class SunfrogUploader : MetroForm
    {
        private static readonly ILog logger =
           LogManager.GetLogger(typeof(SunfrogUploader));
        #region Props

        private SunfrogConfig sunfrogConfig;
        #endregion

        #region Logics
        public SunfrogUploader()
        {
            InitializeComponent();
            XmlConfigurator.Configure();
        }


        private void SunfrogUploader_Load(object sender, EventArgs e)
        {
            string filePath = Directory.GetCurrentDirectory() + Settings.Default.SunfrogConfig;
            if (File.Exists(filePath))
            {
                SunfrogConfig config = SettingUtil.LoadSunfrogInfo<SunfrogConfig>(filePath);
                if(config != null)
                {
                    sunfrogConfig = config;
                    tbVpsName.Text = config.SFAcc;
                    tbPass.Text = FileUtil.Decrypt(config.SFPass);
                    numStart.Value = config.StartRange;
                    numEnd.Value = config.EndRange;
                    tbContent.Text = config.Content;
                    tbLogo.Text = config.Logo;
                }
            }
        }


        private void ProcessUpload()
        {
            try
            {
                // load sunfrog config
                BackendController.Instance.SunfrogConfig = sunfrogConfig;
                string rootPath = Directory.GetCurrentDirectory();
                string logoConfigPath = rootPath + Settings.Default.LogoConfig;
                string contentConfigPath = rootPath + Settings.Default.ContentConfig;
               
                BackendController.Instance.LogoConfig = SettingUtil.LoadSunfrogInfo<LogoConfig>(string.Format(logoConfigPath, sunfrogConfig.Logo));
                BackendController.Instance.ContentConfig = SettingUtil.LoadSunfrogInfo<ContentConfig>(string.Format(contentConfigPath, sunfrogConfig.Content));

                // load name list
                BackendController.Instance.LoadNameList(tbNameList.Text.Trim(), chbAutologo.Checked);

                // update ui
                lblTotalNames.Invoke(new Action(() => lblTotalNames.Text = BackendController.Instance.NameCount + ""));

                //step1: login
                bool result = BackendController.Instance.Step1();
                if (result)
                {
                    lblLogin.Invoke(new Action(() => lblLogin.Text = "Login sucessful!"));
                }
                else
                {
                    lblLogin.Invoke(new Action(() => lblLogin.Text = "Login failed!"));
                    return;
                }

                //step2: upload first logo
                Thread.Sleep(1000);
                BackendController.Instance.Step2(lbError, progCurrentName, lblCurName, lblNameIndex, false, chbAutologo.Checked, chbSaveDb.Checked, chbFastUpload.Checked);
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("Mess: {0},\nStacktrace: {1}", ex.Message, ex.StackTrace);
            }
        }

        #endregion

        #region Background worker
        private void bgWoker_DoWork(object sender, DoWorkEventArgs e)
        {
            if(e.Argument.ToString().Equals("AutoUpload"))
            {
                ProcessUpload();
                e.Result = "AutoUpload";
            }
        }

        private void bgWoker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progCurrentName.Value = e.ProgressPercentage;
        }

        private void bgWoker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Result.ToString().Equals("AutoUpload"))
            {
                btnStart.Enabled = true;
                MessageBox.Show("Upload completed!");
            }
        }


        #endregion

        #region Events
        private void btnSaveAcc_Click(object sender, EventArgs e)
        {
            btnSaveAcc.Enabled = false;
            try
            {

                string filePath = Directory.GetCurrentDirectory() + Settings.Default.SunfrogConfig;
                if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                }

                SunfrogConfig config = new SunfrogConfig(tbVpsName.Text.Trim(),
                    FileUtil.Encrypt(tbPass.Text.Trim()), (int)numStart.Value, (int)numEnd.Value, tbLogo.Text.Trim(),
                    tbContent.Text.Trim(), chbAutologo.Checked, chbSaveDb.Checked);
                SettingUtil.SaveSunfrogInfo(filePath, config);
                sunfrogConfig = config;
                MessageBox.Show("Saved!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            btnSaveAcc.Enabled = true;
          
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            if (tbNameList.Text.Trim().Length == 0)
            {
                MessageBox.Show("Choose folder that contains logo!");
                return;
            }
            btnStart.Enabled = false;
          
            bgWoker.RunWorkerAsync("AutoUpload");
        }
        private void tbNameList_Click(object sender, EventArgs e)
        {
            if(chbAutologo.Checked)
            {
                var fileDlg = new OpenFileDialog();
                var result = fileDlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    tbNameList.Text = fileDlg.FileName;
                }
            }
            else
            {
                var folderDlg = new FolderBrowserDialog();
                var result = folderDlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    tbNameList.Text = folderDlg.SelectedPath;
                }
            }
           
        }

        #endregion


    }
}
