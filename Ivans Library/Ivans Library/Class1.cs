using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Ivans_Library
{
    public class Function
    {
        public static void ReplaceLine(int lineNum, string text)
        {
            int origCol = Console.CursorLeft;
            int origRow = Console.CursorTop;
            Console.SetCursorPosition(0, lineNum - 1);
            Console.Write(text);
            Console.SetCursorPosition(origCol, origRow);
        }

        public static void ClearLastLine(int repeats)
        {
            //code from https://stackoverflow.com/questions/8946808/can-console-clear-be-used-to-only-clear-a-line-instead-of-whole-console
            for (int i = 1; i < repeats; i++)
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.Write(new string(' ', Console.BufferWidth));
                Console.SetCursorPosition(0, Console.CursorTop - 1);
            }
        }

        public static int Random_Num_Generator(int min, int max)
        {
            Random random = new Random();
            int randNum = 0;
            randNum = random.Next(min, max + 1);

            return (randNum);
        }

        public static int Int_Check()
        {
            int choice = 0;
            bool valid = false;
            while (valid == false)
            {
                try
                {
                    choice = int.Parse(Console.ReadLine());
                    valid = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("That is not a valid option");
                    Thread.Sleep(250);
                    ClearLastLine(3);
                    valid = false;

                }
            }
            return (choice);
        }

        public static int Range_Check(int selection, int min, int max)
        {
            while (selection < min || selection > max)
            {
                Console.WriteLine("That is not a valid option");
                Thread.Sleep(250);
                ClearLastLine(3);
                selection = Int_Check();
            }
            return (selection);
        }

        public static void Underline(string text)
        {
            string underline = "";
            for (int i = 0; i < text.Length; i++)
            {
                underline = underline + "-";
            }
            Console.WriteLine(text + Environment.NewLine + underline);
        }

        public static int ConvertToAscii(string text)
        {
            int ascii;
            ascii = Convert.ToChar(text);
            return (ascii);
        }
    }
}
