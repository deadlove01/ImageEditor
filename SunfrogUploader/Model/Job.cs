using log4net;
using Quartz;
using SunfrogUploader.Controller;
using SunfrogUploader.Util;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunfrogUploader.Model
{
    [DisallowConcurrentExecution]
    public class CheckingUploadJob : IJob
    {
        private static readonly ILog logger =
            LogManager.GetLogger(typeof(CheckingUploadJob));
        public void Execute(IJobExecutionContext context)
        {
            try
            {
                logger.Info("CheckingUploadJob is executed...");
                CustomWeb web = new CustomWeb();
                string url = "https://manager.sunfrogshirts.com/Login.cfm";
                NameValueCollection nvc = new NameValueCollection();
                nvc.Add("username", BackendController.Instance.SunfrogConfig.SFAcc);
                nvc.Add("password", BackendController.Instance.SunfrogConfig.SFPass);

                string result = web.SendRequest(url, "POST", nvc, true, "application/x-www-form-urlencoded");
                if (!string.IsNullOrEmpty(result))
                {
                    if (SunfrogUtil.IsLoggedIn(result))
                    {
                        string managerUrlResult = web.SendRequest("https://manager.sunfrogshirts.com/my-art.cfm", "GET", null);
                        string designerResult = web.SendRequest("https://manager.sunfrogshirts.com/Designer/", "GET", null);
                        if (managerUrlResult.Contains("Sorry, this service is currently unavailable.")
                            || designerResult.Contains("Temporarily Unavailable"))
                        {
                            BackendController.IsMaintain = true;
                        }
                        else
                            BackendController.IsMaintain = false;
                    }
                }

            }
            catch (Exception ex)
            {
                logger.ErrorFormat("CheckingUploadJob Error Message: {0}\nStacktrace: {1}", ex.Message, ex.StackTrace);
            }
        }
    }


    [DisallowConcurrentExecution]
    public class CheckingUploadJobListener : IJobListener
    {
        private static readonly ILog logger =
          LogManager.GetLogger(typeof(CheckingUploadJobListener));
        public CheckingUploadJobListener(string name)
        {
            this.Name = name;
        }
        public void JobExecutionVetoed(IJobExecutionContext context)
        {
            logger.Info("call JobExecutionVetoed");
        }

        public void JobToBeExecuted(IJobExecutionContext context)
        {
            logger.Info("call JobToBeExecuted");
        }

        public void JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException)
        {
            if (!BackendController.IsMaintain)
            {
                SchedulerController.Instance.Stop();
            }
            logger.Info("call JobWasExecuted");
        }

        public string Name
        {
            get;
            set;
        }
    }
}
