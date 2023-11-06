using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetParserLibrary
{
    public class ResOut
    {
        private Dictionary<int, float> digitsdict = new();
        private Dictionary<int, string> stringsdict = new();
        public int resrow;
        public float ressum;

        public Dictionary<int, string> Stringsdict
        {
            get { return stringsdict; }
        }

        public Dictionary<int, float> Digitsdict
        {
            get { return digitsdict; }
        }

        public void AddToStringsDict(int rownum, string s)
        {
            stringsdict.Add(rownum, s);
        }

        public void AddToDigitsDict(int rownum, float s)
        {
            digitsdict.Add(rownum, s);
        }

        public string printResult()
        {
           return "Максимальне значення: " + ressum + " у рядку номер " + resrow;
        }

        public Dictionary<int, string> getBadRows()
        {

            if (stringsdict.Count > 0)
            {
                return stringsdict;
            }
            else return null;
        }
        public Dictionary<int, float> getDigitsRows()
        {
            if (digitsdict.Count > 0)
            {
                return digitsdict;
            }
            else //Console.WriteLine("У вказаному файлі немає жодного правильного рядка");
                return null;
        }
    }
}
