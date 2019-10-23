using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeWars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.Tests
{

    public class HumanTimeFormatTests
    {
        [DataTestMethod]
        [DataRow("now", 0)]
        [DataRow("1 second", 1)]
        [DataRow("1 minute and 2 seconds", 62)]
        [DataRow("2 minutes", 120)]
        [DataRow("1 hour, 1 minute and 2 seconds", 3662)]
        public void HumanTimeFormat_Tests(string s, int i)
        {
            Assert.AreEqual(s, HumanTimeFormat.formatDuration(i));
        }
    }
}
