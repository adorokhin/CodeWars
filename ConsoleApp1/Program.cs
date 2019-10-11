using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = new string('a', 0);
            string s1 = null, s2 = "aaa";
            var s3 = string.Concat(s1, s2);
            var s4 = s1 + s2;
        }
    }
}
