using System;

namespace LR2_3
{
    class Program
    {
        static void CountDigits(int digit, string str)
        {
            int counter = 0;
            int pointer = 0;
            while (pointer < str.Length)
            {
                if (str[pointer] == Convert.ToChar(48 + digit)) counter++;
                pointer++;
            }
            if (counter == 1) Console.WriteLine($"The number {digit} was repeated 1 time");
            else Console.WriteLine($"The number {digit} was repeated {counter} times");
        }
        static void Main(string[] args)
        {
            DateTime ThisMoment = new DateTime();
            ThisMoment = DateTime.Now;
            Console.WriteLine(ThisMoment);
            Console.WriteLine($"{ThisMoment.ToLongDateString()}   {ThisMoment.ToLongTimeString()}");
            string str = Convert.ToString(ThisMoment);
            for (int digit = 0; digit < 10; digit++)
            {
                CountDigits(digit, str);
            }
        }
    }
}
