﻿using System;
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
                result =  $"{part} {sPart}" + (part > 1 ? "s" : "");
            return result;
        }

        public static string formatDuration(int seconds)
        {
            string result = string.Empty;
            if (seconds == 0)
            {
                result = "now";
                return result;
            }

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

            result += $"{sY}{((years > 0 && days > 0) ? ", " : "")}";
            result += $"{sD}{((days > 0 && hours > 0) ? ", " : "")}";
            result += $"{sH}{((hours > 0 && minutes > 0) ? ", " : "")}";
            result += $"{sM}{((minutes > 0 && seconds > 0) ? ", " : "")}";
            result += sS;
            var index = result.LastIndexOf(", ");
            if(index != -1)
                result = result.Substring(0, index) + " and " + result.Substring(index + 2);
            return result;
           
        }
    }
}
