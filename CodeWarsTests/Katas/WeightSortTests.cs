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
    public class WeightSortTests
    {
        [TestMethod()]
        public void OrderWeightTest()
        {
            Assert.AreEqual("2000 103 123 4444 99", WeightSort.OrderWeight("103 123 4444 99 2000"));
            Assert.AreEqual("11 11 2000 10003 22 123 1234000 44444444 9999", WeightSort.OrderWeight("2000 10003 1234000 44444444 9999 11 11 22 123"));
        }
    }
}