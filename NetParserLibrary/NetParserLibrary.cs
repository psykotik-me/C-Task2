using System.ComponentModel;
using System.Globalization;
using System.Xml.Linq;
using NLog;

namespace NetParserLibrary
{

    public class ResOut
    {
        private Dictionary<int, float> digitsdict = new ();
        private Dictionary<int, string> stringsdict = new ();
        public (int row, float sum) result;

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

        public void printResult()
        {
            Console.WriteLine("Максимальне значення: " + result.sum + " у рядку номер " + result.row);
        }

        public void printBadRows()
        {

            if (stringsdict.Count > 0)
            {
                Console.WriteLine("Неправильні рядки(містять інші символи крім чисел):"); 
                foreach (var pair in stringsdict)
                {
                    Console.WriteLine($"Номер рядка: {pair.Key}, рядок: {pair.Value}");
                }
            }
            else Console.WriteLine("У вказаному файлі всі рядки правильні");
        }
        public void printDigitsRows()
        {
            if (digitsdict.Count > 0)
            {
                Console.WriteLine("Правильні рядки(містять тільки числа, розділені комами):");
                foreach (var pair in digitsdict)
                {
                    Console.WriteLine($"Номер рядка: {pair.Key}, рядок: {pair.Value}");
                }
            }
            else Console.WriteLine("У вказаному файлі немає жодного правильного рядка");
        }
    }

    public class FileParser
    {

        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        public string[] getStringsFromFile(string filename)
            {
            try
            {
                string[] lines = File.ReadAllLines(filename);
                return lines;
            }
            catch (FileNotFoundException)
            {
                Logger.Error($"Файл {filename} не знайдено.");
                return null;
            }
            }

            public void AnalyseLines(string[] lines,ResOut res)
            {
            string line = "";
            for (int i = 0; i < lines.Length; i++)
            {
                line = lines[i];
                string[] s = line.Split(",");
                float sum = 0;
                if (s.Length == 0) continue;
                int j = 0;

                foreach (var sub in s)
                {
                    if (float.TryParse(sub, out float num))
                    {
                        sum += num;
                        j++;
                    }
                    else
                    {
                        // Add line to ListArray
                        res.AddToStringsDict(i + 1, line);
                        break;
                    }
                };

                if (j == s.Length)
                {
                    res.AddToDigitsDict(i + 1, sum);
                    // Add line number and sum to ListArray
                }
            }
        }

            public ResOut GetBiggestAmountOfRow(string filename)   
            {
            try
            {
                // Set the desired culture (e.g., en-US for US culture with "." as the decimal separator)
                CultureInfo customCulture = new CultureInfo("en-US");
                // Set the culture for the current thread
                CultureInfo.DefaultThreadCurrentCulture = customCulture;
                CultureInfo.DefaultThreadCurrentUICulture = customCulture;
                Logger.Info("Поточний розділювач цілої і дробної частини числа: " + customCulture.NumberFormat.CurrencyDecimalSeparator);

                ResOut res = new ResOut();
                string[] lines = getStringsFromFile(filename);

                if (lines != null) AnalyseLines(lines, res);
                else
                {
                    res.result = (0, -1);
                    Logger.Error($"File {filename} not found!");

                }


                if (res.Digitsdict.Count > 0)
                {
                    float maxValue = res.Digitsdict.Max(x => x.Value);
                    int key = res.Digitsdict.FirstOrDefault(pair => pair.Value == maxValue).Key;
                    res.result = (key, maxValue);
                }
                else res.result = (0, 0);
                return res;
            }

            catch (Exception ex)
            {
                Logger.Error($"З файлом {filename} cталася помилка: " + ex.Message);
                return null;
            }

            }
    }

 }