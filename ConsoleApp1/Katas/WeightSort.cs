using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars
{
    public class WeightSort
    {
        public class Weight : IComparable<Weight>
        {
            public string str;
            int weight;

            private int GetSum(string s)
            {
                var arr = s.ToCharArray().Select(c => (int)char.GetNumericValue(c));
                return arr.Sum();
            }

            public int CompareTo(Weight other)
            {
                if (this.weight == other.weight)
                    return this.str.CompareTo(other.str);
                return this.weight.CompareTo(other.weight);
            }

            public Weight(string s)
            {
                str = s;
                weight = GetSum(s);
            }
        }

        public static int GetSum(string s)
        {
            var arr = s.ToCharArray().Select(c => (int)char.GetNumericValue(c));
            return arr.Sum();
        }

        public static string OrderWeight(string s)
        {
            var arr = s.Split().ToList().Select(_ => new Weight(_)).OrderBy(_=>_);
            var result = string.Join(" ", arr.Select(_=>_.str));
            return result;
        }
    }
}
