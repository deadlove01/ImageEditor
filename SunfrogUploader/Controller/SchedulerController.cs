using AutoArtist.Model;
using log4net;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Matchers;
using SunfrogUploader.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunfrogUploader.Controller
{
    public class SchedulerController : Singleton<SchedulerController>
    {
        private IScheduler scheduler = null;
        private const string JOB_NAME = "uploadSunfrog";
        private const string GROUP_NAME = "uploadGroup";
        private const string TRIGGER_NAME = "uploadTrigger";
        private const string JOB_LISTENER_NAME = "uploadJobListener";
        private static readonly ILog logger =
         LogManager.GetLogger(typeof(SchedulerController));
        public SchedulerController()
        {

        }


        public void Start()
        {
            logger.Info("Scheduler is running...");
            if (scheduler == null || scheduler.IsShutdown)
            {
                scheduler = new StdSchedulerFactory().GetScheduler();
            }

            JobKey jobKey = new JobKey(JOB_NAME, GROUP_NAME);
            IJobDetail jobDetail = JobBuilder.Create<CheckingUploadJob>().WithIdentity(jobKey).Build();

            ITrigger trigger = TriggerBuilder.Create().WithIdentity(TRIGGER_NAME, GROUP_NAME).StartNow()
                .WithSimpleSchedule(a => a.WithIntervalInMinutes(10).RepeatForever()).Build();
            scheduler.ScheduleJob(jobDetail, trigger);

            CheckingUploadJobListener jobListener = new CheckingUploadJobListener(JOB_LISTENER_NAME);
            scheduler.ListenerManager.AddJobListener(jobListener, KeyMatcher<JobKey>.KeyEquals(jobKey));
            scheduler.Start();
        }


        public void Stop()
        {
            scheduler.Shutdown();
            logger.Info("Scheduler is shutdown!");
        }
    }
}
