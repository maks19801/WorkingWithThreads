using System;
using System.Threading;

namespace ThreadsNumberToShow
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int threadNumbers = GetTheNumberFromUser();
                CreateTheThreads(threadNumbers);
            }
            catch (ArgumentOutOfRangeException outOfRange)
            {
                Console.WriteLine("Error: {0}", outOfRange.Message);
            }
        }

        private static void CreateTheThreads(int threadNumbers)
        {
            for (int i = 1; i <= threadNumbers; i++)
            {
                Thread thread = new Thread(new ThreadStart(WriteYourNumber));
                string tabsAmount = string.Empty;

                for (int j = 0; j < i; j++)
                {
                    tabsAmount += "\t";
                }
                thread.Name = $"{tabsAmount}{i}";
                thread.Start();
            }
        }

        private static int GetTheNumberFromUser()
        {
            Console.WriteLine("Hello! Please enter from 1 to 7 numbers of Threads you want to create!");

            string enteredNumber = Console.ReadLine();
            int threadNumbers;
            if (!int.TryParse(enteredNumber, out threadNumbers))
            {
                Console.WriteLine($"{enteredNumber} is not an integer");
            }
            else if (threadNumbers < 1 || threadNumbers > 7)
            {
                throw new ArgumentOutOfRangeException("Numbers should be from 1 to 7");
            }


            return threadNumbers;
        }

        private static void WriteYourNumber()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}");
            }

        }
    }
}
