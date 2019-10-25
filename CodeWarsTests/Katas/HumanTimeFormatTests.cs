using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeWars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.Tests
{

    [TestClass()]
    public class HumanTimeFormatTests
    {
        [DataTestMethod]
        [DataRow("now", 0)]
        [DataRow("1 second", 1)]
        [DataRow("1 minute and 2 seconds", 62)]
        [DataRow("2 minutes", 120)]
        [DataRow("1 hour, 1 minute and 2 seconds", 3662)]
        [DataRow("7 years, 246 days, 15 hours, 32 minutes and 54 seconds", 7*31536000 + 246*86400 + 15*3600 + 32*60 + 54)]
        [DataRow("182 days, 1 hour, 44 minutes and 40 seconds", 182 * 86400 + 1 * 3600 + 44 * 60 + 40)]
        [DataRow("4 years, 68 days, 3 hours and 4 minutes", 4 * 31536000 + 68 * 86400 + 3 * 3600 + 4 * 60)]
        public void HumanTimeFormat_Tests(string s, int i)
        {
            var result = HumanTimeFormat.formatDuration(i);
            Assert.AreEqual(s, result);
        }
    }
}
