using System;
using System.Globalization;
using NetParserLibrary;

class Program
{
    static void Main()
    {
        // Set the desired culture (e.g., en-US for US culture with "." as the decimal separator)
        CultureInfo customCulture = new CultureInfo("en-US");
        // Set the culture for the current thread
        CultureInfo.DefaultThreadCurrentCulture = customCulture;
        CultureInfo.DefaultThreadCurrentUICulture = customCulture;
        Console.WriteLine("Current Decimal Separator: " + customCulture.NumberFormat.CurrencyDecimalSeparator);

        Console.WriteLine("Введіть ім'я файлу з даними:");
        string input = "data.txt";// Console.ReadLine();
        FileParser fp = new FileParser();
        (int row, float sum) res;
        res =  fp.GetBiggestAmountOfRow(input);
        Console.WriteLine("Максимальне значення: " + res.sum + " у рядку номер " + res.row);

    }


}
