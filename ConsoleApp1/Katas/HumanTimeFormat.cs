using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars
{
    public class HumanTimeFormat
    {
        private const int SECONDS_IN_YEAR = 31536000;
        private const int SECONDS_IN_DAY = 86400;
        private const int SECONDS_IN_HOUR = 3600;
        private const int SECONDS_IN_MINUTE = 60;

        private static string PluralizePart(int part, string sPart)
        {
            string result = string.Empty;
            if (part != 0)
                result =  $"{part} {sPart}" + (part > 0 ? "s" : "");
            return result;
        }

        public static string formatDuration(int seconds)
        {
            if (seconds == 0)
                return "now";

            //365 days and a day is 24 hours
            int years = seconds / SECONDS_IN_YEAR;
            seconds = seconds % SECONDS_IN_YEAR;
            int days = seconds / SECONDS_IN_DAY;
            seconds = seconds % SECONDS_IN_DAY;
            int hours = seconds / SECONDS_IN_HOUR;
            seconds = seconds % SECONDS_IN_HOUR;
            int minutes = seconds / SECONDS_IN_MINUTE;
            seconds = seconds % SECONDS_IN_MINUTE;

            var sY = PluralizePart(years, "year");
            var sD = PluralizePart(days, "day");
            var sH = PluralizePart(hours, "hour");
            var sM = PluralizePart(minutes, "minute");
            var sS = PluralizePart(seconds, "second");

            var time = sH;

            if(sD != string.Empty)
            var date = $"{sY}{(sY != "" ? ", " : "")}";
                

            return "";
        }
    }
}
