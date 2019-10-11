using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeWars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CodeWars.Tests
{
    [TestClass()]
    public class KataTests
    {

        [TestMethod()]
        public void FriendOrFoeTest()
        {
            string[] expected = { "Ryan", "Mark" };
            string[] names = { "Ryan", "Kieran", "Mark", "Jimmy" };
            CollectionAssert.AreEqual(expected, Kata.FriendOrFoe(names).ToList<string>());
        }

        [TestMethod()]
        public void UniqueInOrderTest_EmptyTest()
        {
            Assert.AreEqual("", Kata.UniqueInOrder(""));
        }

        [TestMethod()]
        public void UniqueInOrderTest_Strings()
        {
            Assert.AreEqual("ABCDAB", Kata.UniqueInOrder("AAAABBBCCDAABBB"));
        }

        [TestMethod()]
        public void Persistence_Test()
        {
            Assert.AreEqual(3, Kata.Persistence(39));
            Assert.AreEqual(0, Kata.Persistence(4));
            Assert.AreEqual(2, Kata.Persistence(25));
            Assert.AreEqual(4, Kata.Persistence(999));
        }

        [TestMethod()]
        public void LongestTest()
        {
            Assert.AreEqual("aehrsty", Kata.Longest("aretheyhere", "yestheyarehere"));
            Assert.AreEqual("abcdefghilnoprstu", Kata.Longest("loopingisfunbutdangerous", "lessdangerousthancoding"));
            Assert.AreEqual("acefghilmnoprstuy", Kata.Longest("inmanylanguages", "theresapairoffunctions"));
        }

        [TestMethod()]
        public void FindMissingLetterTest()
        {
            Assert.AreEqual('e', Kata.FindMissingLetter(new[] { 'a', 'b', 'c', 'd', 'f' }));
            Assert.AreEqual('P', Kata.FindMissingLetter(new[] { 'O', 'Q', 'R', 'S' }));
        }

        [DataTestMethod]
        [DataRow(1, "I")]
        [DataRow(2, "II")]
        [DataRow(4, "IV")]
        [DataRow(500, "D")]
        [DataRow(1000, "M")]
        [DataRow(1954, "MCMLIV")]
        [DataRow(1990, "MCMXC")]
        [DataRow(2008, "MMVIII")]
        [DataRow(2014, "MMXIV")]
        public void RomanConvertTest(int i, string s)
        {
            Assert.AreEqual(s, Kata.RomanConvert(i));
        }

        [DataTestMethod]
        [DataRow(3, "2 4 7 8 10")]
        [DataRow(1, "1 2 2")]
        [DataRow(5, "2 4 6 8 10")]
        public void IQTestTest(int i, string s)
        {
            Assert.AreEqual(i, Kata.IQTest(s));
        }


        [DataTestMethod]
        //[DataRow(0, new int[0])]
        [DataRow(6, new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 })]
        //[DataRow(339, new int[] { -21, -12, -16, -14, 11, -16, 29, -2, -2, 1, -30, 26, -2, 28, -1, 4, -19, -28, -9, 4, -15, 15, -13, 13, -25, 11, 18, 16, -10, 12, -16, 17, 3, -21, 17, -20, 27, 22, -12, 22, -7, 13, 14, 7, 3, 25, 16, 9, -30, 25 })]

        public void MaxSequenceTest(int i, int[] a)
        {
            Assert.AreEqual(i, Kata.MaxSequence_0N(a));
        }


        public static Random randNum = new Random();
        public static int MaxSequence(int[] arr)
        {
            int m = 0;
            int a = 0;
            int s = 0;
            foreach (int e in arr)
            {
                s += e;
                m = s > m ? m : s;
                a = a > s - m ? a : s - m;
            }
            return a;
        }
        private int[] GetRandomArray()
        {
            var arr = new int[1000];
            for (int i = 0; i < 1000; i++)
            {
                arr[i] = randNum.Next(-99, 99);
            }
            return arr;
        }

        [TestMethod]
        public void MaxSequenceTest_RandomTests()
        {
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < 1000; ++i)
            {
                var arr = GetRandomArray();
                //Assert.AreEqual(MaxSequence(arr), Kata.MaxSequence_0N(arr));
                Assert.AreEqual(MaxSequence(arr), Kata.MaxSequence_Kagane(arr));
            }
            sw.Stop();
            Debug.WriteLine($"Total time took {sw.ElapsedMilliseconds} msec");
        }

        [DataTestMethod]
        //[DataRow("", @"After calling GroupBy, you get a series of groups IEnumerable<Grouping>, where each Grouping itself exposes the Key used to create the group and also is an IEnumerable<T> of whatever items are in your original data set. You just have to call Count() on that Grouping to get the subtotal.")]
        [DataRow("(((", "din")]
        [DataRow("()()()", "recede")]
        [DataRow(")())())", "Success")]
        [DataRow("))((", "(( @")]
        public void DuplicateEncodeTest(string i, string s)
        {
            Assert.AreEqual(i, Kata.DuplicateEncode(s));
        }



        [DataTestMethod]
        [DataRow("H2O", 0, 1)]
        [DataRow("H2O", 1, 2)]
        [DataRow("H2O", 2, 1)]
        [DataRow("Mg(OH)2", 6, 2)]
        [DataRow("K4[ON(SO3)2]2", 1, 4)]
        [DataRow("K4[ON(SO3)2]2", 8, 3)]
        [DataRow("K4[ON(SO3)2]2", 10, 2)]
        [DataRow("K4[ON(SO3)2]2", 12, 2)]
        public void GetMultiplierTest(string s, int i, int r)
        {
            var charArr = s.ToCharArray().ToList();
            var multiplier = Kata.GetMultiplier(charArr, ref i);
            Assert.AreEqual(r, multiplier);
        }


        [TestMethod()]
        public void ParseMoleculeTest()
        {
            var expected = new Dictionary<string, int> { { "H", 2 }, { "O", 1 } };
            var received = Kata.ParseMolecule("H2O");
            CollectionAssert.AreEquivalent(expected, received);

            expected = new Dictionary<string, int> { { "H", 2 }, { "O", 1 } };
            received = Kata.ParseMolecule("(H2O)");
            CollectionAssert.AreEquivalent(expected, received);

            expected = new Dictionary<string, int> { { "H", 6 }, { "O", 3 } };
            received = Kata.ParseMolecule("(H2O)3");
            CollectionAssert.AreEquivalent(expected, received);

            expected = new Dictionary<string, int> { { "N", 3 }, { "H", 12 }, { "P", 1 }, { "O", 4 } };
            received = Kata.ParseMolecule("(NH4)3PO4");
            CollectionAssert.AreEquivalent(expected, received);

            CollectionAssert.AreEquivalent(
                new Dictionary<string, int> { { "A", 126 }, { "B", 71 }}
                , Kata.ParseMolecule("AB{[(A2B)3]4AB2}5"));

            //"CH3NH3"
            //"C17H21NO4"

            //CollectionAssert.AreEquivalent(new Dictionary<string, int> { { "Mg", 1 }, { "O", 2 }, { "H", 2 } }, Kata.ParseMolecule("Mg(OH)2"));
            //CollectionAssert.AreEquivalent(new Dictionary<string, int> { { "K", 4 }, { "O", 14 }, { "N", 2 }, { "S", 4 } }, Kata.ParseMolecule("K4[ON(SO3)2]2"));

        }

    }
}
