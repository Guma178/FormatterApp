using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;

namespace FormatterApp
{
    class Program
    {//
        static List<string> DisplayDate(string input)
        {
            DateTime dt;
            List<string> output = new List<string>();
            if (DateTime.TryParse(input, out dt))
            {
                output.Add(dt.ToString(CultureInfo.InvariantCulture));
                output.Add(dt.ToString(CultureInfo.GetCultureInfo("ja-JP")));
                output.Add(dt.ToString("d"));
                output.Add(dt.ToString("D"));
                output.Add(dt.ToString("dd:MM|yyyy[hh[m"));
                return output;
            }
            else
            {
                output.Add("Неверный формат");
                return output;
            }
        }
        static string DisplayInt(string input)
        {
            int nubIn;
            if (Int32.TryParse(input, out nubIn))
            {
                return nubIn.ToString();
            }
            else
                return "Неверный формат";
        }
        static List<string> DisplayDouble(string input)
        {
            List<string> output = new List<string>();

            double d;
            if (Double.TryParse(input, out d))
            {
                output.Add(d.ToString("000%"));
                output.Add(d.ToString("0.0E000"));
                output.Add(d.ToString("C"));
                NumberFormatInfo f = new NumberFormatInfo();
                f.NumberGroupSizes = new int[3] { 4, 2, 2 };
                f.NumberGroupSeparator = "|";
                output.Add(d.ToString("N", f));
            }
            else
                output.Add("Неверный формат");

            return output;
        }
        static void Main(string[] args)
        {
            string input;
            int choose;
            while (true)
            {
                choose = 0;
                Console.WriteLine("Введите входную строку");
                input = Console.ReadLine();
                Console.WriteLine("Выберите вариант разбора");
                Console.WriteLine("1. DateTime");
                Console.WriteLine("2. Integer");
                Console.WriteLine("3. Double");
                Console.WriteLine("4. String");
                Int32.TryParse(Console.ReadLine(), out choose);
                switch (choose)
                {
                    case 1:
                        foreach (string output in DisplayDate(input))
                            Console.WriteLine(output);
                        break;
                    case 2:
                        Console.WriteLine(DisplayInt(input));
                        break;
                    case 3:
                        foreach (string output in DisplayDouble(input))
                            Console.WriteLine(output);
                        break;
                    case 4:
                        Console.WriteLine(input);
                        break;
                    default:
                        Console.WriteLine("Недопустимый сценарий");
                        break;
                }
            }
        }
    }
}
