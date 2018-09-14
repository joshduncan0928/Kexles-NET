using System;
using System.Diagnostics;
using ConsoleUtils.Logging;
using ConsoleUtils.Writing;
using Deveel.Math;
using KexlesFunctions;

namespace Kexles
{
    internal class Program
    {
        private Stopwatch timer = new Stopwatch();

        // Initialize writer service
        private Writer __WRITER = new Writer();

        // Initialize logger service
        private Logger __LOGGER = new Logger();

        private static void Main(string[] args)
        {
            Program prgm = new Program();
            prgm.StartMenu();
        }

        private void StartMenu()
        {
            __WRITER.Custom("Fahrenheit to Kexles by Josh Duncan", Color.Cyan);
            __WRITER.Custom("Press S to start conversion", Color.Cyan);
            __WRITER.Custom("Press I to show information", Color.Cyan);

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            switch (keyInfo.Key)
            {
                case ConsoleKey.S:
                    Console.Clear();
                    RunConversion(10000);
                    break;

                case ConsoleKey.I:
                    Console.Clear();
                    Information();
                    break;

                default:
                    Console.Clear();
                    StartMenu();
                    break;
            }
        }

        private void Information()
        {
            __WRITER.Custom("[Information]", Color.DarkGreen, true);
            __WRITER.Custom("Kexles is a very useless unit of measurement created by me, Josh Duncan, while I was in class rather than doing work.", Color.White, true);
            __WRITER.Custom("\"So why use it?\" you may ask and my answer to that would be, why not use it.", Color.White, true);
            __WRITER.Custom("[Conversions]", Color.DarkGreen, true);
            __WRITER.Custom("1 degree Kexle = 905 degrees Fahrenheit", Color.White, true);
            __WRITER.Custom("Fahrenheit to Kexle formula {Where F is degrees Fahrenheit and Kex is degrees Kexle}:", Color.White, true);
            __WRITER.Custom("Kex = ([2634] / [{F - 27} * 0.6]) - 4", Color.DarkGray, true);
            __WRITER.Custom("Press any key to return to the main menu.", Color.DarkYellow, true);
            Console.ReadKey();
            Console.Clear();
            StartMenu();
        }

        private void RunConversion(int timeToRepeat = 10)
        {
            BigDecimal fahr = 0.0905;
            BigDecimal _LAST = 0.00905;
            double lastExec = 0;
            for (int i = 0; i < timeToRepeat; i++)
            {
                timer.Reset();
                timer.Start();
                __LOGGER.Log("Coverting");

                BigDecimal kexles = Calculations.FahrenheitToKexle(fahr);

                Color color;
                if (i % 2 == 0)
                {
                    color = Color.White;
                }
                else
                {
                    color = Color.Gray;
                }

                MathContext mcInt2 = new MathContext(10, RoundingMode.Ceiling);
                __WRITER.Custom(i + 1 + "/" + timeToRepeat + " | Not alike. Difference from last: " + _LAST.Subtract(kexles, mcInt2) + " | Time take for last conversion (ms): " + lastExec, color);
                //__WRITER.Custom(fahr + " = " + kexles, color);
                if (kexles == _LAST)
                {
                    __WRITER.Custom(fahr + " = " + kexles, Color.White);
                    Console.ReadLine();
                }

                fahr *= 10;
                _LAST = kexles;
                lastExec = timer.Elapsed.TotalMilliseconds;
                timer.Stop();
            }

            Console.ReadKey();
            Console.Clear();
            StartMenu();
        }
    }
}