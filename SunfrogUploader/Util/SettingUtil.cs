using log4net;
using Newtonsoft.Json;
using SunfrogUploader.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunfrogUploader.Util
{
    public static class SettingUtil
    {
        private static readonly ILog logger =
              LogManager.GetLogger(typeof(SettingUtil));

        public static void SaveSunfrogInfo<T>(string path, T config)
        {
            try
            {
                string json = JsonConvert.SerializeObject(config);
                File.WriteAllText(path, json);
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("Error code: {0}, stacktrace: {1}", ex.Message, ex.StackTrace);
            }
        }

        public static T LoadSunfrogInfo<T>(string path)
        {
            try
            {
                string json = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("Error code: {0}, stacktrace: {1}", ex.Message, ex.StackTrace);
            }
            return default(T);
        }
    }
}
