using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeespringWebUploader.Controller;

namespace TeespringWebUploader
{
    public partial class TeespringWebUploader : Form
    {

        private static readonly ILog logger =
         LogManager.GetLogger(typeof(TeespringWebUploader));


        #region logics
        public TeespringWebUploader()
        {
            InitializeComponent();
        }

        private void TeespringWebUploader_Load(object sender, EventArgs e)
        {
            XmlConfigurator.Configure();
        }


        private void ProcessUpload()
        {
            try
            {
                HQController.Instance.Login(tbEmail.Text.Trim(), tbPass.Text.Trim());
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("Error: {0}, details: {1}", ex.Message, ex.StackTrace);
            }
        }


        #endregion

        #region bg worker
        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument.ToString().Equals("Upload"))
            {
                ProcessUpload();
                e.Result = "Upload";
            }
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Result.ToString().Equals("Upload"))
            {
                btnRun.Enabled = true;
                MessageBox.Show("Done!");
            }
        }


        #endregion


        #region events
        private void btnRun_Click(object sender, EventArgs e)
        {
            btnRun.Enabled = false;
            bgWorker.RunWorkerAsync("Upload");
        }

        #endregion
    }
}
