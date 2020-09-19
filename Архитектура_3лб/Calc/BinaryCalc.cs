using System;
using System.Collections.Generic;
using System.Text;

namespace Архитектура_3лб.Calc
{
    class BinaryCalc
    {
        public static void Binary()
        {
            Console.WriteLine("*Вместо символа '.' используйте ','");
            Console.Write("Введите первое число: ");
            double x = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите второе число: ");
            double y = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(
                "Выберите операцию:\n" +
                "1. Суммировать\n" +
                "2. Вычесть\n" +
                "3. Умножить\n" +
                "4. Разделить");

            double temp_1 = From2To10(x);
            double temp_2 = From2To10(y);

            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(new string('-', 40));
            double result = 0;
            switch (n)
            {
                case 1:
                    result = temp_1 + temp_2;
                    break;
                case 2:
                    result = temp_1 - temp_2;
                    break;
                case 3:
                    result = temp_1 * temp_2;
                    break;
                case 4:
                    result = temp_1 / temp_2;
                    break;
                default:
                    break;
            }
            Console.WriteLine($"Результат: {From10To2(result)}");
            Console.ReadKey();
        }
        private static double From2To10(double x)
        {
            long WholePart = (long)x;
            long length = (x.ToString().Length - WholePart.ToString().Length) - 1;
            long ModPart = (long)Math.Round((x % 10) * Math.Pow(10, length));

            double WholeSum = 0;
            double ModSum = 0;

            double result;

            List<long> WholeList = Digits(WholePart);
            List<long> ModList = Digits(ModPart);

            WholeList.Reverse();

            for (int i = 0; i < WholeList.Count; i++)
            {
                if (WholeList[i] == 1)
                {
                    WholeSum += Math.Pow(2, i);
                }
            }

            for (int i = 0; i < ModList.Count; i++)
            {
                if (ModList[i] == 1)
                {
                    ModSum += Math.Pow(2, -(i + 1));
                }
            }

            result = WholeSum + ModSum;

            return result;
        }
        private static List<long> Digits(long x)
        {
            List<long> input = new List<long>();
            while (x > 0)
            {
                input.Add(x % 10);
                x /= 10;
            }
            input.Reverse();
            return input;
        }
        private static string From10To2(double x)
        {
            long WholePart = (long)x;
            double ModPart = x - WholePart;

            List<long> WholeList = new List<long>();
            List<long> ModList = new List<long>();

            string result = "";

            //Whole Part = > WholeList
            while (WholePart >= 1)
            {
                int mod = (int)WholePart % 2;
                WholeList.Add(mod);
                WholePart /= 2;
            }
            //Mod Part = > ModList
            for (int n = 0; n < 4; n++)
            {
                double Whole = ModPart * 2;
                int temp = (int)Whole;
                ModList.Add(temp);
                ModPart = Math.Abs(temp - Whole);
            }

            WholeList.Reverse();

            for (int i = 0; i <= WholeList.Count; i++)
            {
                if (i < WholeList.Count)
                {
                    result += WholeList[i].ToString();
                }
                if (i == WholeList.Count)
                {
                    result += ",";
                }
            }

            foreach (long i in ModList)
            {
                result += i.ToString();
            }

            return result;
        }

    }
}
