using System;

namespace Task_1
{
    class Program
    {
        static bool UpSearch(byte y, byte x, char[,] field)
        {
            for (byte shift = 1; shift < 4; shift++)
            {
                if (field[y, x] != field[y - shift, x] || field[y,x] == '_')
                {
                    return false;
                }
            }
            return true;
        }
        static bool RightSearch(byte y, byte x, char[,] field)
        {
            for (byte shift = 1; shift < 4; shift++)
            {
                if (field[y, x] != field[y, x + shift] || field[y, x] == '_')
                {
                    return false;
                }
            }
            return true;
        }
        static bool UpRightSearch(byte y, byte x, char[,] field)
        {
            for (byte shift = 1; shift < 4; shift++)
            {
                if (field[y, x] != field[y - shift, x + shift] || field[y, x] == '_')
                {
                    return false;
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            byte circle = 176, plus = 177;
            int colChoice;
            string colChoiceStr;
            bool exit = true;
            char[,] field = new char[6, 7];
            for (byte y = 0; y < 6; y++)
            {
                for (byte x = 0; x < 7; x++)
                {
                    field[y, x] = '_';
                }
            }
            Console.WriteLine(" \"Four in a row\"\n" +
                " The players alternately choose the column in which they will place their chip.\n" +
                " The chip \"falls\" down and stops if there is another chip under it, or if it is at the bottom.\n" +
                " The goal of the game is to place 4 chips in a row, whether vertically, horizontally or diagonally.\n" +
                " Press any key to continue");
            Console.ReadKey();
            Console.Clear();
            for (byte numOfTurns = 0; numOfTurns < 42; numOfTurns++) 
            {
                for (byte y = 0; y < 6; y++)
                {
                    Console.Write("|");
                    for (byte x = 0; x < 7; x++)
                    {
                        Console.Write($"{field[y, x]}|");
                    }
                    Console.WriteLine();
                }
                if (!exit)
                {
                    if (numOfTurns % 2 == 0) Console.Write(" Second player won");
                    else Console.Write(" First player won");
                    break;
                }
                Console.WriteLine(" 1 2 3 4 5 6 7");
                if (numOfTurns % 2 == 0) Console.WriteLine($"\n First player's turn\n Your chip is \'{(char)circle}\'");
                else Console.WriteLine($"\n Second player's turn\n Your chip is \'{(char)plus}\'");
                Console.Write(" Choose a column: ");
                colChoiceStr = Console.ReadLine();
                if(!int.TryParse(colChoiceStr, out colChoice))
                { 
                    while (!int.TryParse(colChoiceStr, out colChoice))
                    {
                        Console.Write(" Invalid input, try again.\n Choose a column: ");
                        colChoiceStr = Console.ReadLine();
                    }
                    while (colChoice > 7 || colChoice < 1)
                    {
                        Console.Write(" Invalid input, try again.\n Choose a column: ");
                        colChoice = Convert.ToInt32(Console.ReadLine());
                    }
                }
                else
                {
                    while(colChoice > 7 || colChoice < 1)
                    {
                        Console.Write(" Invalid input, try again.\n Choose a column: ");
                        colChoice = Convert.ToInt32(Console.ReadLine());
                    }
                }
                colChoice--;
                for (byte y = 0; y < 6; y++)
                {
                    if (y == 5 || field[y + 1, colChoice] == (char)circle || field[y + 1, colChoice] == (char)plus )
                    {
                        if (numOfTurns % 2 == 0) field[y, colChoice] = (char)circle;
                        else field[y, colChoice] = (char)plus;
                        break;
                    }
                }
                for (byte y = 3; y < 6; y++)
                {
                    for (byte x = 0; x < 7; x++)
                    {
                        if (UpSearch(y, x, field))
                        {
                            exit = false;
                            break;
                        }
                    }
                }
                if (exit)
                {
                    for (byte x = 0; x < 4; x++)
                    {
                        for (byte y = 0; y < 6; y++)
                        {
                            if (RightSearch(y, x, field))
                            {
                                exit = false;
                                break;
                            }
                        }
                    }
                }
                if (exit)
                {
                    for (byte x = 0; x < 4; x++)
                    {
                        for (byte y = 3; y < 6; y++)
                        {
                            if (UpRightSearch(y, x, field))
                            {
                                exit = false;
                                break;
                            }
                        }
                    }
                }
                Console.Clear();
            }
        }
    }
}