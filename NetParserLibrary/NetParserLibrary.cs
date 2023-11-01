using System.ComponentModel;

namespace NetParserLibrary
{
    public class FileParser
    {

            public (int,float) GetBiggestAmountOfRow(string filename)   // [0] is line number, [1] is the sum of numbers in that line
            {
                 (int row, float sum) res;   
                 res = (-1, 0);
            try
            {
                string[] lines = File.ReadAllLines(filename);

                Dictionary<int, float> digitsdict = new Dictionary<int, float>();
                Dictionary<int, string> stringsdict = new Dictionary<int, string>();


                Console.WriteLine("Зміст файлу:");
                string line = "";
                for (int i = 0; i < lines.Length; i++)
                // foreach (string line in lines)
                {
                    line = lines[i];
                    Console.WriteLine(line);
                    string[] s = line.Split(",");
                    float sum = 0;
                    if (s.Length == 0) return res;
                    int j = 0;

                    foreach (var sub in s)
                    {
                        // Console.WriteLine(sub+' '+ float.TryParse(sub,out float num));
                        if (float.TryParse(sub, out float num))
                        {
                            sum += num;
                            j++;
                        }
                        else
                        {
                            // Add line to ListArray
                            stringsdict.Add(i + 1, line);
                            break;
                        }
                    };

                    if (j == s.Length)
                    {
                        digitsdict.Add(i + 1, sum);
                        // Add line number and sum to ListArray
                    }
                }

                Console.WriteLine("stringsdict:"); // contains rows with symbols and their numbers
                foreach (var pair in stringsdict)
                {
                    Console.WriteLine($"Row number: {pair.Key}, row: {pair.Value}");
                }

                Console.WriteLine("digitsdict:");
                foreach (var pair in digitsdict)
                {
                    Console.WriteLine($"Row number: {pair.Key}, row: {pair.Value}");
                }

                if (digitsdict.Count > 0)
                {
                    float maxValue = digitsdict.Max(x => x.Value);
                    int key = digitsdict.FirstOrDefault(pair => pair.Value == maxValue).Key;
                    //Console.WriteLine("Максимальне значення: " + maxValue + " у рядку номер " + key);
                    res = (key, maxValue);
                }
                else res = (0, 0);
                return res;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не знайдено.");
                res = (-1, 0);
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Сталася помилка: " + ex.Message);
                res = (-2, 0);
                return res;
            }

            }
    }

 }