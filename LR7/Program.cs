using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LR7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter fraction A: ");
            Fraction A = new Fraction();
            A.ConvertToFraction(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Enter fraction B: ");
            Fraction B = new Fraction();
            B.ConvertToFraction(Console.ReadLine());
            int choice;
            do
            {
                Console.Clear();
                Console.Write("Choose an action:\n1 - Find the sum of fractions\n2 - Find the difference of fractions\n" +
                    "3 - Find the product of fractions\n4 - Find the quotient of fractions\n5 - Compare fractions\n" +
                    "6 - Show information about fractions\n7 - Change fractions\n0 - Exit\n>> ");
                choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                switch (choice)
                {
                    case 1:
                        Console.WriteLine($"A + B = {A} + {B} = {A + B}");
                        break;
                    case 2:
                        Console.WriteLine($"A - B = {A} - {B} = {A - B}");
                        break;
                    case 3:
                        Console.WriteLine($"A * B = {A} * {B} = {A * B}");
                        break;
                    case 4:
                        Console.WriteLine($"A / B = {A} / {B} = {A / B}");
                        break;
                    case 5:
                        Console.WriteLine($"{A} & {B}");
                        Console.WriteLine($"A == B : {A == B}");
                        Console.WriteLine($"A != B : {A != B}");
                        Console.WriteLine($"A > B : {A > B}");
                        Console.WriteLine($"A < B : {A < B}");
                        Console.WriteLine($"A >= B : {A >= B}");
                        Console.WriteLine($"A <= B : {A <= B}");
                        break;
                    case 6:
                        Console.WriteLine($"A = {A} = {A.ToSpecialString()} = {(double)A} ~ {(int)A}");
                        Console.WriteLine($"B = {B} = {B.ToSpecialString()} = {(double)B} ~ {(int)B}");
                        break;
                    case 7:
                        Console.WriteLine("Enter fraction A: ");
                        A.ConvertToFraction(Console.ReadLine());
                        Console.WriteLine("Enter fraction B: ");
                        B.ConvertToFraction(Console.ReadLine());
                        break;
                    case 0: return;
                    default:
                        Console.WriteLine("Invalid input, try again");
                        break;
                }
                Console.WriteLine("\nPress any button to continue");
                Console.ReadKey();
            } while (true);
        }
    }
}