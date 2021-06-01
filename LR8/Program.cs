using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LR8
{
    class Program
    {
        static void Main(string[] args)
        {
            Footballer Lionella = new Footballer();
            Lionella.SalaryNotify += salary => Console.WriteLine($"Current salary: {salary}\n");
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    Lionella.DopingTest();
                    Lionella.Compete();
                }
                catch (Exception details)
                {
                    Console.WriteLine(details.Message);
                }
            }
            Weightlifter Tolya = new Weightlifter();
            Tolya.MedalNotify += delegate (int bronzeMedals, int silverMedals, int goldMedals)
            {
                Console.WriteLine($"Current medals:\nGold: {goldMedals}\nSilver: {silverMedals}\nBronze: {bronzeMedals}\n");
            };
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    Tolya.DopingTest();
                    Tolya.Compete();
                }
                catch (Exception details)
                {
                    Console.WriteLine(details.Message);
                }
            }
            Athlete Matvey = new Athlete();
            try
            {
                Matvey.Compete();
            }
            catch (Exception details)
            {
                Console.WriteLine(details.Message);
            }
            Matvey.Specialization = "Javelin-throwing";
            try
            {
                Matvey.Compete();
            }
            catch (Exception details)
            {
                Console.WriteLine(details.Message);
            }
            Console.ReadKey();
        }
    }
}
