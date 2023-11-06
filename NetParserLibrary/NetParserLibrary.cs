using System.ComponentModel;
using System.Globalization;
using System.Xml.Linq;
using NetParserLibrary;
using NLog;


namespace NetParserLibrary
{

  

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
                    res.resrow = 0;
                    res.ressum = -1.0f ;     // якщо файл пустий або не існує то повертаємо row=0, sum=-1
                    Logger.Error($"File {filename} not found!");
                    return res;

                }


                if (res.Digitsdict.Count > 0)
                {
                    float maxValue = res.Digitsdict.Max(x => x.Value);
                    int key = res.Digitsdict.FirstOrDefault(pair => pair.Value == maxValue).Key;
                    res.resrow = key;
                    res.ressum = maxValue;
                }
                else
                {
                    res.resrow = 0;
                    res.ressum = 0;
                }
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