using ChangePassword.Controller;
using ChangePassword.Models;
using log4net;
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

namespace ChangePassword
{
    public partial class GmailTool : Form
    {
        private static readonly ILog logger =
                 LogManager.GetLogger(typeof(GmailTool));


        #region logic
        public GmailTool()
        {
            InitializeComponent();

            XmlConfigurator.Configure();
        }

        private void ProcessChangePassword(Gmail gmail)
        {
            //DriverController.Instance.Login(gmail);
            //DriverController.Instance.ChangePassword(gmail);
            PhantomController.Instance.Login(gmail);
            PhantomController.Instance.ChangePassword(gmail);
        }


        private bool ProcessTurnOnLessSecureApp(Gmail gmail)
        {
            //PhantomController.Instance.Login(gmail);
            DriverController.Instance.Login(gmail);
            return DriverController.Instance.TurnOnLessSecureApp(gmail);
        }


        private void ProccessLessSecureApp()
        {
            var lines = File.ReadAllLines(t2TbAccList.Text.Trim()).ToList();
            if (lines != null && lines.Count > 0)
            {
                string accFile = Directory.GetCurrentDirectory() + "\\error_accounts.txt";
                string successFile = Directory.GetCurrentDirectory() + "success_accounts.txt";

                List<string> accs = new List<string>();
                if (File.Exists(accFile))
                {
                    accs = File.ReadAllLines(accFile).ToList();
                }

                List<string> success = new List<string>();
                if (File.Exists(successFile))
                {
                    success = File.ReadAllLines(successFile).ToList();
                }

                List<Gmail> gmails = new List<Gmail>();
                for (int i = 0; i < lines.Count; i++)
                {
                    Gmail gmail = new Gmail(lines[i]);
                    gmails.Add(gmail);
                }

                int failedCount = 0;
                int k = 0;
                if (gmails.Count > 0)
                {
                    if (accs != null && accs.Count > 0)
                    {
                        failedCount = accs.Count;
                        for (int i = 0; i < accs.Count; i++)
                        {
                            gmails.RemoveAll(p => p.ID == accs[i]);
                        }
                    }

                    if (success != null && success.Count > 0)
                    {
                        k = failedCount + success.Count +1;
                    }

                    for (; k < gmails.Count; k++)
                    {
                        bool result = false;
                        try
                        {
                            result = ProcessTurnOnLessSecureApp(gmails[k]);
                            if(result)
                            {
                                File.AppendAllLines(Directory.GetCurrentDirectory() + "\\success_accounts.txt", new string[] { gmails[k].ID });
                            }
                            else
                            {

                                File.AppendAllLines(Directory.GetCurrentDirectory() + "\\error_accounts.txt", new string[] { gmails[k].ID });
                            }
                        }
                        catch (Exception ex)
                        {
                            logger.ErrorFormat("{0}, stacktrace: {1}", ex.Message, ex.StackTrace);
                        }

                        this.Invoke(new Action(()=> {
                            if (!result)
                            {
                                failedCount++;
                                lblFailed.Text = failedCount.ToString();
                            }
                            else
                            {
                                lblSuccess.Text = (k + 1) + "/" + gmails.Count;
                            }
                        }));
                        
                        bgWorker.ReportProgress((k + 1) * 100 / gmails.Count);
                    }
                }
            }
        }
        #endregion

        #region bg worker
        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if(e.Argument.ToString().Equals("Run"))
            {
                var lines = File.ReadAllLines(tbAccList.Text.Trim()).ToList();
                if (lines != null && lines.Count > 0)
                {
                    string accFile = Directory.GetCurrentDirectory() + "\\error_accounts.txt";
                    List<string> accs = new List<string>();
                    if(File.Exists(accFile))
                    {
                        accs = File.ReadAllLines(accFile).ToList();
                    }

                    List<Gmail> gmails = new List<Gmail>();
                    for (int i = 0; i < lines.Count; i++)
                    {
                        Gmail gmail = new Gmail(lines[i]);
                        gmails.Add(gmail);
                    }

                    if(gmails.Count > 0)
                    {
                        if(accs != null && accs.Count > 0)
                        {
                            for (int i = 0; i < accs.Count; i++)
                            {
                                gmails.RemoveAll(p => p.ID == accs[i]);
                            }
                        }
                        
                        for (int i = 0; i < gmails.Count; i++)
                        {
                            try
                            {
                                ProcessChangePassword(gmails[i]);
                            }
                            catch (Exception ex)
                            {
                                logger.ErrorFormat("{0}, stacktrace: {1}", ex.Message, ex.StackTrace);
                            }
                            bgWorker.ReportProgress((i + 1) * 100 / gmails.Count);
                        }
                    }
                }
                e.Result = "Run";
            }else if(e.Argument.ToString().ToString().Equals("LessSecureApp"))
            {
                ProccessLessSecureApp();
                e.Result = "LessSecureApp";
            }
        }




        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Result.ToString().Equals("Run"))
            {
                MessageBox.Show("Xong!");
                btnRun.Enabled = true;
            }else if(e.Result.ToString().Equals("LessSecureApp"))
            {
                MessageBox.Show("Xong!");
                t2BtnRun.Enabled = true;
            }
        }




        #endregion

        private void btnRun_Click(object sender, EventArgs e)
        {
            if(tbAccList.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please copy file's account list path!");
                return;
            }
            btnRun.Enabled = false;
            bgWorker.RunWorkerAsync("Run");
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            tsProgress.Value = e.ProgressPercentage;
        }

        private void t2BtnRun_Click(object sender, EventArgs e)
        {
            if (t2TbAccList.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please copy file's account list path!");
                return;
            }
            t2BtnRun.Enabled = false;
            bgWorker.RunWorkerAsync("LessSecureApp");
        }
    }
}
