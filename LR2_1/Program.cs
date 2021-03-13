using System;
using System.Text;

namespace LR2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a sentence:\n>>");
            StringBuilder sentence = new StringBuilder();
            string input = Console.ReadLine();
            int pointer = 0;
            do
            {
                if (pointer == input.Length)
                {
                    Console.Write("You haven't typed anything. Try again:\n>>");
                    input = Console.ReadLine();
                }
                pointer = 0;
                if (input.Length == 0)
                {
                    Console.Write("You haven't typed anything. Try again:\n>>");
                    input = Console.ReadLine();
                }
                else
                {
                    while (input[pointer] == ' ')
                    {
                        pointer++;
                        if (pointer == input.Length) break;
                    }
                }
            } while (pointer == input.Length);
            StringBuilder word = new StringBuilder();
            pointer = input.Length - 1;
            bool end = false;
            while (pointer >= 0)
            {
                while (input[pointer] == ' ')
                {
                    if (pointer == 0)
                    {
                        end = true;
                        break;
                    }
                    pointer--;
                }
                if (end) break;
                while (input[pointer] != ' ')
                {
                    word.Insert(0, input[pointer]);
                    pointer--;
                    if (pointer == -1) break;
                }
                sentence.Append(word);
                sentence.Append(' ');
                word.Clear();
            }
            Console.WriteLine($"Inverted  sentence: {sentence}");
        }
    }
}