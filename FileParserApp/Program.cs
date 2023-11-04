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
        if (res.result.sum == 0 && res.result.row == 0) Console.WriteLine($"Файл {input} не існує або в ньому немає жодного рядка, де є тільки числа(");
        else //Console.WriteLine("Максимальне значення: " + res.result.sum + " у рядку номер " + res.result.row);
        {
            res.printResult();
            Console.WriteLine("Введіть '1' щоб побачити неправильні рядки:");
            if (Console.ReadLine().Equals("1"))   res.printBadRows();
        }

    }


}
