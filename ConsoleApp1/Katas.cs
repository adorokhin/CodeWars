using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars
{
    public static class Kata
    {
        #region MoveZeroes
        public static int[] MoveZeroes_ILike(int[] arr)
        {
            return arr.OrderBy(x => x == 0).ToArray();
        }

        public static int[] MoveZeroes(int[] arr)
        {
            if (arr == null)
                return null;
            var result = new int[arr.Length];
            var j = 0;
            foreach (var i in arr)
            {
                if(i != 0)
                    result[j++] = i;
            }
            return result;
        }
        #endregion

        #region StripComments
        public static string StripComments(string text, string[] commentSymbols)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            var lines = text.Split(new char[] { '\n' });
            var results = new List<string>();
            foreach (var line in lines)
            {
                var buff = line.TrimEnd();
                foreach (var commentSymbol in commentSymbols)
                {
                    var index = line.IndexOf(commentSymbol);
                    if( index != -1 )
                        buff = buff.Substring(0, index);
                }
                results.Add($"{buff.TrimEnd()}");
            }
            return string.Join("\n", results.ToArray());
        }
        #endregion

        #region ParseMolecule

        public static Dictionary<string, string> elements => new Dictionary<string, string>()
            {{ "H", "Hydrogen"},
                {"He",  "Helium"},
                {"Li",  "Lithium"},
                {"Be",  "Beryllium"},
                {"B",   "Boron"},
                {"C",   "Carbon"},
                {"N",   "Nitrogen"},
                {"O",   "Oxygen"},
                {"F",   "Fluorine"},
                {"Ne",  "Neon"},
                {"Na",  "Sodium"},
                {"Mg",  "Magnesium"},
                {"Al",  "Aluminium"},
                {"Si",  "Silicon"},
                {"P",   "Phosphorus"},
                {"S",   "Sulfur"},
                {"Cl",  "Chlorine"},
                {"Ar",  "Argon"},
                {"K",   "Potassium"},
                {"Ca",  "Calcium"},
                {"Sc",  "Scandium"},
                {"Ti",  "Titanium"},
                {"V",   "Vanadium"},
                {"Cr",  "Chromium"},
                {"Mn",  "Manganese"},
                {"Fe",  "Iron"},
                {"Co",  "Cobalt"},
                {"Ni",  "Nickel"},
                {"Cu",  "Copper"},
                {"Zn",  "Zinc"},
                {"Ga",  "Gallium"},
                {"Ge",  "Germanium"},
                {"As",  "Arsenic"},
                {"Se",  "Selenium"},
                {"Br",  "Bromine"},
                {"Kr",  "Krypton"},
                {"Rb",  "Rubidium"},
                {"Sr",  "Strontium"},
                {"Y",   "Yttrium"},
                {"Zr",  "Zirconium"},
                {"Nb",  "Niobium"},
                {"Mo",  "Molybdenum"},
                {"Tc",  "Technetium"},
                {"Ru",  "Ruthenium"},
                {"Rh",  "Rhodium"},
                {"Pd",  "Palladium"},
                {"Ag",  "Silver"},
                {"Cd",  "Cadmium"},
                {"In",  "Indium"},
                {"Sn",  "Tin"},
                {"Sb",  "Antimony"},
                {"Te",  "Tellurium"},
                {"I",   "Iodine"},
                {"Xe",  "Xenon"},
                {"Cs",  "Caesium"},
                {"Ba",  "Barium"},
                {"La",  "Lanthanum"},
                {"Ce",  "Cerium"},
                {"Pr",  "Praseodymium"},
                {"Nd",  "Neodymium"},
                {"Pm",  "Promethium"},
                {"Sm",  "Samarium"},
                {"Eu",  "Europium"},
                {"Gd",  "Gadolinium"},
                {"Tb",  "Terbium"},
                {"Dy",  "Dysprosium"},
                {"Ho",  "Holmium"},
                {"Er",  "Erbium"},
                {"Tm",  "Thulium"},
                {"Yb",  "Ytterbium"},
                {"Lu",  "Lutetium"},
                {"Hf",  "Hafnium"},
                {"Ta",  "Tantalum"},
                {"W",   "Tungsten"},
                {"Re",  "Rhenium"},
                {"Os",  "Osmium"},
                {"Ir",  "Iridium"},
                {"Pt",  "Platinum"},
                {"Au",  "Gold"},
                {"Hg",  "Mercury"},
                {"Tl",  "Thallium"},
                {"Pb",  "Lead"},
                {"Bi",  "Bismuth"},
                {"Po",  "Polonium"},
                {"At",  "Astatine"},
                {"Rn",  "Radon"},
                {"Fr",  "Francium"},
                {"Ra",  "Radium"},
                {"Ac",  "Actinium"},
                {"Th",  "Thorium"},
                {"Pa",  "Protactinium"},
                {"U",   "Uranium"},
                {"Np",  "Neptunium"},
                {"Pu",  "Plutonium"},
                {"Am",  "Americium"},
                {"Cm",  "Curium"},
                {"Bk",  "Berkelium"},
                {"Cf",  "Californium"},
                {"Es",  "Einsteinium"},
                {"Fm",  "Fermium"},
                {"Md",  "Mendelevium"},
                {"No",  "Nobelium"},
                {"Lr",  "Lawrencium"},
                {"Rf",  "Rutherfordium"},
                {"Db",  "Dubnium"},
                {"Sg",  "Seaborgium"},
                {"Bh",  "Bohrium"},
                {"Hs",  "Hassium"},
                {"Mt",  "Meitnerium"},
                {"Ds",  "Darmstadtium"},
                {"Rg",  "Roentgenium"},
                {"Cn",  "Copernicium"},
                {"Nh",  "Nihonium"},
                {"Fl",  "Flerovium"},
                {"Mc",  "Moscovium"},
                {"Lv",  "Livermorium"},
                {"Ts",  "Tennessine"},
                { "Og", "Oganesson"}};

        public static Dictionary<string, int> ParseMolecule(string formula)
        {
            var elements = new Dictionary<string, int>();
            var outerMultiplier = 1;
            var arr = formula.ToCharArray().ToList();
            char c;

            formula = formula.Replace("{", "(").Replace("[", "(").Replace("}", ")").Replace("]", ")");
            //Debug.WriteLine($"Formula {formula}");

            for (int i = 0; i < arr.Count; i++)
            {
                c = arr[i];
                if (IsBracket(c))
                {
                    ParseBracketedGroup(c, elements, arr, outerMultiplier, ref i);
                }
                else
                {
                    ParseSingleElement(elements, arr, outerMultiplier, ref i);
                }
            }
            /*
            Debug.WriteLine("========>");
            elements.ToList().ForEach(x => {Debug.Write($"{x.Key}-{x.Value} "); });
            Debug.WriteLine("<========");
            */
            return elements;
        }

        public static void ParseBracketedGroup(char openingBracket, Dictionary<string, int> elements, List<char> arr, int outerMultiplier, ref int endPosition, bool recursing = false)
        {
            if (arr == null || !arr.Any())
                return;

            int multiplier = 1;
            char closingBracket = GetClosingBracket(openingBracket);
            int closingBracketIndex = GetClosingBracketPosition(arr, endPosition, closingBracket, openingBracket);
            if (closingBracketIndex <= 0)
                throw new Exception($"Closing Bracket {closingBracket} not found in {string.Join("", arr)}.");

            var groupArr = arr.Skip(endPosition + 1).Take((closingBracketIndex - endPosition) - 1).ToList();
            endPosition = closingBracketIndex;
            multiplier = GetMultiplier(arr, ref endPosition);
            outerMultiplier *= multiplier;

            //Debug.WriteLine($@"-- {string.Join("", groupArr)}");

            for (int i = 0; i < groupArr.Count; i++)
            {
                var c = groupArr[i];
                if (IsBracket(c))
                {
                    ParseBracketedGroup(c, elements, groupArr, outerMultiplier, ref i, recursing: true);
                }
                else
                {
                    ParseSingleElement(elements, groupArr, outerMultiplier, ref i);
                }
            }
        }

        public static int GetClosingBracketPosition(List<char> arr, int endPosition, char closingBracket, char openingBracket)
        {
            int openingBracketCount = 0;
            int i = endPosition;
            for (i = endPosition; i < arr.Count; i++)
            {
                var c = arr[i];
                if (c == openingBracket)
                    openingBracketCount++;
                if (c == closingBracket)
                    openingBracketCount--;
                if (openingBracketCount == 0)
                    break;
            }
            return i;
        }

        private static void ParseSingleElement(Dictionary<string, int> elements, List<char> arr, int outerMultiplier, ref int i)
        {
            var element = GetElement(arr, ref i);
            var multiplier = GetMultiplier(arr, ref i) * outerMultiplier;
            //Debug.WriteLine($"{element}{multiplier}");
            ModifyElement(elements, element, multiplier);
        }

        private static void ModifyElement(Dictionary<string, int> dictResults, string element, int multiplier)
        {
            if (dictResults.ContainsKey(element))
                dictResults[element] += multiplier;
            else
                dictResults[element] = multiplier;
        }

        public static string GetElement(List<char> arr, ref int i)
        {
            string element = arr[i].ToString();
            i++;
            while (i < arr.Count)
            {
                if (Char.IsLower(arr[i]))
                {
                    element += arr[i].ToString();
                    i++;
                }
                else
                {
                    i--;
                    break;
                }
            }
            return element;
        }

        public static int GetMultiplier(List<char> arr, ref int i)
        {
            int multiplier = 1;

            var chunk = arr.Skip(i+1).TakeWhile(x => Char.IsDigit(x));
            if (chunk == null || !chunk.Any())
                return multiplier;

            var multString = string.Join(string.Empty, chunk);
            if (string.IsNullOrEmpty(multString))
                return multiplier;

            i += multString.Length;

            multiplier = Int32.Parse(multString);

            return multiplier;
        }


        public static bool IsBracket(char c)
        {
            return c == '(' || c == '{' || c == '[';
        }

        public static char GetClosingBracket(char c)
        {
            char endBracket = char.MinValue;
            switch (c)
            {
                case '(':
                    endBracket = ')';
                    break;
                case '{':
                    endBracket = '}';
                    break;
                case '[':
                    endBracket = ']';
                    break;
            }
            return endBracket;

        }
        #endregion

        #region DuplicateEncoder
        public static string DuplicateEncode(string word)
        {
            word = word.ToLower();
            Dictionary<char, int> lettersCount = new Dictionary<char, int>();
            var sb = new StringBuilder();

            var arr = word.GroupBy(x => x).Select(group => new { _letter = group.Key, _count = group.Count()}).OrderBy(x => x._letter).ToList();
            arr.ForEach(x => {
                //Debug.WriteLine($"{x._letter,5} {x._count,7}");
                lettersCount.Add(x._letter, x._count);
            });

            word.ToList().ForEach(x => {sb.Append(lettersCount[x] == 1 ? "(" : ")");});
            return sb.ToString();
        }
        #endregion

        #region MaxSequence
        /*
        {-2, -3, 4, -1, -2, 1, 5, -3}
        for i=0 a[0]=-2     max_ending_here = -2    max_so_far = -2  max_ending_here = 0
        for i=1 a[1]=-3     max_ending_here = -3    max_so_far = -2  max_ending_here = 0
        for i=2 a[2]=4      max_ending_here = 4     max_so_far = 4   max_ending_here = 4
        for i=3 a[3]=-1     max_ending_here = 3     max_so_far = 4   max_ending_here = 3
        for i=4 a[4]=-2     max_ending_here = 1     max_so_far = 4   max_ending_here = 1
        for i=5 a[5]=1      max_ending_here = 2     max_so_far = 4   max_ending_here = 2
        for i=6 a[6]=5      max_ending_here = 7     max_so_far = 7   max_ending_here = 7
        for i=7 a[7]=-3     max_ending_here = 4     max_so_far = 7   max_ending_here = 4

            
            
        */
        public static int MaxSequence_Kagane(int[] arr)
        {
            int max_so_far = int.MinValue,
                max_ending_here = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                max_ending_here += arr[i];

                if (max_so_far < max_ending_here)
                    max_so_far = max_ending_here;

                if (max_ending_here < 0)
                    max_ending_here = 0;
            }

            return max_so_far;
        }



        /*
        maxSequence[-2, 1, -3, 4, -1, 2, 1, -5, 4]
        should be 6: [4, -1, 2, 1]
        */

        /*
         Kadane’s Algorithm:
        Initialize:
            max_so_far = 0
            max_ending_here = 0

        Loop for each element of the array
        (a) max_ending_here = max_ending_here + a[i]
        (b) if(max_ending_here < 0)
                max_ending_here = 0
        (c) if(max_so_far < max_ending_here)
            max_so_far = max_ending_here
        return max_so_far

         */
        public static int MaxSequence_0N(int[] arr)
        {
            //[-2, 1, -3, 4, -1, 2, 1, -5, 4]
            int max = 0, res = 0, sum = 0;
            foreach (var item in arr)
            {
                sum += item;
                //max = sum > max ? max : sum;
                //res = res > sum - max ? res : sum - max;

                if (sum < max)
                    max = sum;

                var delta = sum - max;
                if (res < delta)
                    res = delta;

                Debug.WriteLine($"{item,5} {sum,5} {max,5} {res,5}");
            }
            return res;
        }

        public static int MaxSequence(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return 0;

            var max_sum = 0;
            var curr_sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int ii = 0; ii < arr.Length; ii++)
                {
                    var curr_arr = arr.Skip(i).Take(ii + 1);
                    curr_sum = curr_arr.Sum();
                    //Debug.WriteLine($"i = {i,-3} ii = {ii, -3}  curr_sum = {curr_sum, -7} {string.Join(",", curr_arr)} ");
                    if (curr_sum > max_sum)
                        max_sum = curr_sum;
                }
            }
            return max_sum;
        }
        #endregion

        #region IQTest
        public static int IQTest(string numbers)
        {
            int[] arr_int = Array.ConvertAll(numbers.Split(), s => Int32.Parse(s));
            var result = arr_int.Length;
            var even_count = 0;
            var odd_count = 0;
            for (var j = 0; j < 3; j++)
            {
                if (arr_int[j] % 2 == 0)
                    even_count++;
                else
                    odd_count++;
            }

            for (var i = 0; i < arr_int.Length; i++)
            {
                var n = arr_int[i] % 2;
                if ((n != 0 && (even_count > odd_count)) || (n == 0 && (even_count < odd_count)))
                {
                    result = i + 1;
                    break;
                }
            }

            return result;
        }

        #endregion

        #region RomanConvert
        /*
                Symbol Value
                I          1
                V          5
                X          10
                L          50
                C          100
                D          500
                M          1,000
        */
        public static string RomanConvert(int n)
        {
            var romanMumeral = string.Empty;
            var remainder = n;
            var thouthands = n / 1000;
            if (thouthands > 0)
            {
                romanMumeral = new string('M', thouthands);
                remainder = n - (thouthands * 1000);
            }

            var nineHundred = remainder / 900;
            if (nineHundred == 1)
            {
                romanMumeral += "CM";
                remainder -= 900;
            }

            var fivehundreds = remainder / 500;
            if (fivehundreds == 1)
            {
                romanMumeral += "D";
                remainder -= 500;
            }

            var fourhundred = remainder / 400;
            if (fourhundred == 1)
            {
                romanMumeral += "CD";
                remainder -= 400;
            }

            var hundreds = remainder / 100;
            if (hundreds > 0)
            {
                romanMumeral += new string('C', hundreds);
                remainder -= (100 * hundreds);
            }

            var ninety = remainder / 90;
            if (ninety == 1)
            {
                romanMumeral += "XC";
                remainder -= 90;
            }

            var fifties = remainder / 50;
            if (fifties == 1)
            {
                romanMumeral += "L";
                remainder -= 50;
            }

            var forty = remainder / 40;
            if (forty == 1)
            {
                romanMumeral += "XL";
                remainder -= 40;
            }

            var tens = remainder / 10;
            if (tens > 0)
            {
                romanMumeral += new string('X', tens);
                remainder -= (10 * tens);
            }

            var nine = remainder / 9;
            if (nine == 1)
            {
                romanMumeral += "IX";
                remainder -= 9;
            }

            var fives = remainder / 5;
            if (fives == 1)
            {
                romanMumeral += "V";
                remainder -= 5;
            }

            var four = remainder / 4;
            if (four == 1)
            {
                romanMumeral += "IV";
                remainder -= 4;
            }

            var singles = remainder;
            romanMumeral += new string('I', singles);
            return romanMumeral;
        }
        #endregion

        #region FindMissingLetter

        //char[] alphabet = { 'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};
        //var results = alphabet.Join(array, x => char.ToUpper(x), y => char.ToUpper(y), (x, y) => new { x=char.ToUpper(x), y=char.ToUpper(y) }).ToList();
        //return ' ';

        public static char FindMissingLetter(char[] array)
        {
            char result = default(char);
            char c_curr = array[0];
            char c_next_expected = c_curr;

            foreach (var c in array)
            {
                if (c != c_next_expected)
                {
                    result = c_next_expected;
                    break;
                }
                c_next_expected = Convert.ToChar(Convert.ToInt32(c) + 1);
            }
            return result;
        }
        #endregion

        #region Longest
        public static string Longest(string s1, string s2)
        {
            //return string.Concat((s1 + s2).Distinct().OrderBy(c => c));
            var arr = string.Concat(s1, s2).Distinct().ToArray();
            Array.Sort<char>(arr);
            string s = new string(arr);
            return s;
        }
        #endregion

        #region Persistence
        public static int Persistence(long n)
        {
            int result = 0, product;
            if (n < 10)
                return result;

            var s = n.ToString();
            do
            {
                product = 1;
                s.ToList().ForEach(x =>
                {
                    product *= (x - '0');
                    Debug.WriteLine($" ======>>> x={x} product={product}");
                });
                s = product.ToString();
                result++;
            } while (product >= 10);

            return result;
        }
        #endregion

        #region FriendOrFoe
        public static IEnumerable<string> FriendOrFoe(string[] names)
        {
            return names.Where(x => x.Length == 4);
        }


        public static IEnumerable<string> FriendOrFoe2(string[] names)
        {
            return (names != null)
              ? names.Where(name => name != null && name.Length == 4)
              : Enumerable.Empty<string>();
        }
        #endregion

        #region UniqueInOrder
        public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable)
        {

            IList<T> result = new List<T>();

            T curr = iterable.Take<T>(1).FirstOrDefault<T>();
            if (!curr.Equals(default(T)))
                result.Add(curr);
            iterable.ToList<T>().ForEach((T x) =>
            {
                Debug.WriteLine($"===>>> {x}");
                if (!x.Equals(curr))
                    result.Add(x);
                curr = x;
            });
            return result;
        }
        #endregion
    }
}
