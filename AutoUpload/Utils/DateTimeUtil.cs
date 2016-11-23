using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViralStyleUploader.Utils
{
    public class DateTimeUtil
    {
        public static string DateToStrFormat(DateTime dt, string format)
        {
            return dt.ToString(format);
        }

        public static string DateToStrCampEndDate(DateTime dt)
        {
            return dt.ToString("ddd, MMM. dd yyyy - HH tt");
        }

        public static string DateToStrCampEndDateObj(DateTime dt)
        {
            return dt.ToString("s") + "Z";
        }

        public static long DateToCampUTC(DateTime dt)
        {
            DateTime unixStart = DateTime.SpecifyKind(new DateTime(1970, 1, 1), DateTimeKind.Utc);
            return (long)Math.Floor((dt.ToUniversalTime() - unixStart).TotalMilliseconds);
        }
    }
}
