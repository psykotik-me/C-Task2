using System;
using System.Globalization;
using NetParserLibrary;

class Program
{
    static void Main()
    {

        Console.WriteLine("Введіть ім'я файлу з даними:");
        string input = Console.ReadLine();
        while (input == "") input = Console.ReadLine();

        FileParser fp = new FileParser();

        ResOut res =  fp.GetBiggestAmountOfRow(input);
//        Console.WriteLine(res.resrow + "  " + res.ressum+"  "+ res.resrow.Equals(-1));

        if (res.resrow == 0 && res.ressum.Equals(-1.0f)) Console.WriteLine($"Файл {input} не знайдено!");
        else if (res.resrow == 0 && res.ressum.Equals(0)) Console.WriteLine($"У файлі {input} немає жодного рядка, де є тільки числа(");
        else //Console.WriteLine("Максимальне значення: " + res.result.sum + " у рядку номер " + res.result.row);
        {
           Console.WriteLine(res.printResult());
            Console.WriteLine("Введіть '1' щоб побачити неправильні рядки:");
            if (Console.ReadLine().Equals("1")) 
                foreach (var pair in res.getBadRows())
                {
                    Console.WriteLine($"Номер рядка: {pair.Key}, рядок: {pair.Value}");
                }
        }

   
    }


}
