using System;
using System.Numerics;

namespace LR2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number \'a\': ");
            UInt64 a;
            string input_a = Console.ReadLine();
            while (!UInt64.TryParse(input_a, out a))
            {
                Console.Write("Invalid input, please try again: ");
                input_a = Console.ReadLine();
            }
            Console.Write("Enter the number \'b\': ");
            UInt64 b;
            string input_b = Console.ReadLine();
            while (!UInt64.TryParse(input_b, out b))
            {
                Console.Write("Invalid input, please try again: ");
                input_b = Console.ReadLine();
            }
            UInt64 product = 1;
            if (a < b)
            {
                for (; a <= b; a++)
                {
                    product *= a;
                }
            }
            else if (a > b)
            {
                for (; b <= a; b++)
                {
                    product *= b;
                }
            }
            else product = a;
            byte power = 0;
            for (; power < 64; power++)
            {
                if (product >> power == 1) break;
            }
            Console.WriteLine($"The maximum power of two by which the number  is divisible is twenty");
        }
    }
}
