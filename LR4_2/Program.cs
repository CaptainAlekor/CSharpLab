using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace LR4_2
{
    class Program
    {
        [DllImport("fact.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern UInt32 CalcFactorialCDECL(UInt32 n);
        [DllImport("fact.dll", CallingConvention = CallingConvention.StdCall)]
        static extern UInt32 CalcFactorialSTD(UInt32 n);
        [DllImport("fact.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern UInt32 CalcFibonacciCDECL(UInt32 n);
        [DllImport("fact.dll", CallingConvention = CallingConvention.StdCall)]
        static extern UInt32 CalcFibonacciSTD(UInt32 n);
        static void Main(string[] args)
        {
            Console.Write("Enter the number whose factorial you want to find: ");
            UInt32 n;
            string input = Console.ReadLine();
            while (!(UInt32.TryParse(input, out n)) || n <= 0)
            {
                Console.WriteLine("Invalid input, try again: ");
                input = Console.ReadLine();
            }
            Console.WriteLine($"CDECL: {CalcFactorialCDECL(n)}");
            Console.WriteLine($"STDCALL: {CalcFactorialSTD(n)}");
            Console.Write("Enter the index of the fibonacci number: ");
            input = Console.ReadLine();
            while (!(UInt32.TryParse(input, out n)))
            {
                Console.WriteLine("Invalid input, try again: ");
                input = Console.ReadLine();
            }
            Console.WriteLine($"CDECL: {CalcFibonacciCDECL(n)}");
            Console.WriteLine($"STDCALL: {CalcFibonacciSTD(n)}");
            Console.ReadKey();
        }
    }
}
