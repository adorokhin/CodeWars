using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeWars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.RegularExpressions;

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
        public void ParseMoleculeTest_Driver()
        {
            //var received = Kata.ParseMolecule("(NH4)3PO4");
            var received = Kata.ParseMolecule("{((H)2)[O]}");
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

            expected = new Dictionary<string, int> { { "A", 126 }, { "B", 71 } };
            received = Kata.ParseMolecule("AB{[(A2B)3]4AB2}5");
            CollectionAssert.AreEquivalent(expected, received);

            expected = new Dictionary<string, int> { { "Mg", 1 }, { "O", 2 }, { "H", 2 }, };
            received = Kata.ParseMolecule("MgO2H2");
            CollectionAssert.AreEquivalent(expected, received);



            //"CH3NH3"
            //"C17H21NO4"

            //CollectionAssert.AreEquivalent(new Dictionary<string, int> { { "Mg", 1 }, { "O", 2 }, { "H", 2 } }, Kata.ParseMolecule("Mg(OH)2"));
            //CollectionAssert.AreEquivalent(new Dictionary<string, int> { { "K", 4 }, { "O", 14 }, { "N", 2 }, { "S", 4 } }, Kata.ParseMolecule("K4[ON(SO3)2]2"));

        }

        [TestMethod()]
        public void ParseMoleculeTest_RealLife()
        {
            Console.WriteLine("Real-life examples");
            CollectionAssert.AreEquivalent(new Dictionary<string, int> { { "B", 2 }, { "H", 6 } }, Kata.ParseMolecule("B2H6"), "Your function should correctly parse diborane");
            CollectionAssert.AreEquivalent(new Dictionary<string, int> { { "C", 6 }, { "H", 12 }, { "O", 6 } }, Kata.ParseMolecule("C6H12O6"), "Your function should correctly parse glucose");
            CollectionAssert.AreEquivalent(new Dictionary<string, int> { { "Mo", 1 }, { "C", 6 }, { "O", 6 } }, Kata.ParseMolecule("Mo(CO)6"), "Your function should also work for molybdenum hexacarbonyl");
            CollectionAssert.AreEquivalent(new Dictionary<string, int> { { "Fe", 1 }, { "C", 10 }, { "H", 10 } }, Kata.ParseMolecule("Fe(C5H5)2"), "Your function should also work for ferrocene");
            CollectionAssert.AreEquivalent(new Dictionary<string, int> { { "C", 8 }, { "H", 8 }, { "Fe", 1 }, { "O", 2 } }, Kata.ParseMolecule("(C5H5)Fe(CO)2CH3"), "Your function should correctly parse cyclopentadienyliron dicarbonyl dimer");
            CollectionAssert.AreEquivalent(new Dictionary<string, int> { { "Pd", 1 }, { "P", 4 }, { "C", 72 }, { "H", 60 } }, Kata.ParseMolecule("Pd[P(C6H5)3]4"), "Your function should correctly parse tetrakis(triphenylphosphine)palladium(0)");
            CollectionAssert.AreEquivalent(new Dictionary<string, int> { { "As", 2 }, { "Be", 16 }, { "C", 44 }, { "B", 8 }, { "Co", 24 }, { "O", 48 }, { "Cu", 5 } }, Kata.ParseMolecule("As2{Be4C5[BCo3(CO2)3]2}4Cu5"), "Your function should also correctly parse As2{Be4C5[BCo3(CO2)3]2}4Cu5");
            CollectionAssert.AreEquivalent(new Dictionary<string, int> { { "Co", 4 }, { "N", 12 }, { "H", 42 }, { "O", 18 }, { "S", 3 } }, Kata.ParseMolecule("{[Co(NH3)4(OH)2]3Co}(SO4)3"), "Your function should correctly parse hexol sulphate");
            CollectionAssert.AreEquivalent(new Dictionary<string, int> { { "C", 4 }, { "H", 4 }, { "O", 4 } }, Kata.ParseMolecule("C2H2(COOH)2"), "Your function should correctly parse maleic acid");
        }

        [TestMethod()]
        public void ParseMoleculeTest_EdgeTests()
        {
            Console.WriteLine("Syntactically valid (but not necessarily chemically correct) \"chemical formulae\" ;)");
            CollectionAssert.AreEquivalent(new Dictionary<string, int> { { "H", 2 }, { "O", 1 } }, Kata.ParseMolecule("{((H)2)[O]}"), "Should work for an \"evilized\" version of a water molecule");
            CollectionAssert.AreEquivalent(new Dictionary<string, int> { { "Uun", 42 }, { "Uuu", 103 }, { "Uub", 103 }, { "Uut", 103 }, { "Uuq", 1442 }, { "Uup", 33166 }, { "Uuh", 33166 }, { "Ts", 1442 }, { "Og", 1442 }, { "Uue", 1442 }, { "Ubn", 1442 } }, Kata.ParseMolecule("Uun42((UuuUubUut)(Uuq(UupUuh)23Ts(OgUue)Ubn)14)103"), "Your function should correctly parse a \"chemical formula\" from Dante's seventh circle of hell ;)");
            CollectionAssert.AreEquivalent(new Dictionary<string, int> { { "Ubn", 46 }, { "Ubu", 46 }, { "Ubb", 46 }, { "Ubt", 805 }, { "Ubq", 805 }, { "Ubp", 391 }, { "Ubh", 8602 }, { "Ubs", 25806 }, { "Ubo", 25806 }, { "Ube", 8602 }, { "Utn", 391 } }, Kata.ParseMolecule("((UbnUbuUbb)2((Ubt)(Ubq))35((Ubp(Ubh(UbsUbo)3Ube)22Utn)17))23"), "Your function should correctly parse a \"chemical formula\" from the bottomless pit of the Book of Revelation ;)");
        }


        protected static Dictionary<string, int> Solution(string s)
        {
            string r = new Regex("\\)([^\\d])").Replace(new Regex("\\)$").Replace(new Regex("\\]|\\}").Replace(new Regex("\\[|\\{").Replace(s, "("), ")"), ")1"), new MatchEvaluator(m => ")1" + m.Groups[1].Value));
            Regex repeatPattern = new Regex("\\(([^()]+)\\)(\\d+)");
            MatchEvaluator unroll = new MatchEvaluator(m => String.Join("", Enumerable.Repeat(m.Groups[1].Value, Int32.Parse(m.Groups[2].Value)).ToArray()));
            while (repeatPattern.IsMatch(r))
                r = repeatPattern.Replace(r, unroll);
            r = new Regex("([A-Z][a-z]*)(\\d+)").Replace(r, unroll);
            string[] a = new Regex("[A-Z][a-z]*").Matches(r).OfType<Match>().Select(m => m.Value).ToArray();
            string[] elements = new HashSet<string>(a).ToArray();
            Dictionary<string, int> result = new Dictionary<string, int>();
            for (int i = 0; i < elements.Length; i++) result.Add(elements[i], a.Where(e => e == elements[i]).Count());
            return result;
        }

        protected const int RANDOM_MOLECULE_MAX_NESTING = 4;
        protected static readonly string[] Elements = new string[] { "H", "He", "Li", "Be", "B", "C", "O", "N", "F", "Ne", "Na", "Mg", "Al", "Si", "P", "S", "Cl", "Ar", "K", "Ca", "Fe", "U", "Uun", "Uuu", "Uub", "Uup", "Uuo", "Ubn", "Utn", "Uqn" };
        protected static readonly Random Rng = new Random();
        protected static string RandomMolecule() => String.Join("", Enumerable.Range(1, Rng.Next(3, 8)).ToArray().Select(_ => Rng.NextDouble() < 0.5d ? "(" + RandomMolecule(RANDOM_MOLECULE_MAX_NESTING - 1) + ")" + Rng.Next(2, 14) : Elements[Rng.Next(0, Elements.Length)]).ToArray());
        protected static string RandomMolecule(int n) => String.Join("", Enumerable.Range(1, Rng.Next(3, 8)).ToArray().Select(_ => Rng.NextDouble() < 0.5d && n > 0 ? "(" + RandomMolecule(n - 1) + ")" + Rng.Next(2, 14) : Elements[Rng.Next(0, Elements.Length)]).ToArray());
        [TestMethod()]
        public void HugeRandomFictionalMoleculeTest()
        {
            Debug.WriteLine("One super-complex random \"chemical formula\" ;)");
            string s = RandomMolecule();
            Debug.WriteLine("Testing for chemical formula " + s);
            var sw = Stopwatch.StartNew();
            var expected = Solution(s);
            sw.Stop();
            Debug.WriteLine($"===>>> CodeWars Solution: {sw.ElapsedMilliseconds} ms."); 

            sw = Stopwatch.StartNew();
            var received = Kata.ParseMolecule(s);
            sw.Stop();
            Debug.WriteLine($"===>> My Solution: {sw.ElapsedMilliseconds} ms.");
            
            CollectionAssert.AreEquivalent(expected, received);
        }



        [TestMethod()]
        public void GetClosingBracketPositionTest()
        {
            var formula = "{((H)2)[O]}";
            var arr = formula.ToCharArray().ToList();
            var indx = Kata.GetClosingBracketPosition(arr, 0, '}', '{');
            Assert.AreEqual(indx, 10);

            indx = Kata.GetClosingBracketPosition(arr, 1, ')', '(');
            Assert.AreEqual(indx, 6);

            indx = Kata.GetClosingBracketPosition(arr, 2, ')', '(');
            Assert.AreEqual(indx, 4);

            indx = Kata.GetClosingBracketPosition(arr, 7, ']', '[');
            Assert.AreEqual(indx, 9);

        }
    }


}
