using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace Horserace
{
    class Race
    { //
        enum Horse
        {
            Trine = 1, Mille,Line,Sara
        }

        const int horse1 = 100;
        const int horse2 = 100;
        const int horse3 = 100;
        const int horse4 = 100;


        public static decimal Bet { get; set; }
        public static bool RunStart = true;
        public static float trineStartPos = 0.0f;
        public static float milleStartPos = 0.0f;
        public static float lineStartPos = 0.0f;
        public static float saraStartPos = 0.0f;


        public static void Start()
        {
           
            Console.WriteLine("Which horse you think are going to win\n\n1.Trine\n2.Mille\n3.Line\n4.Sara");

            bool loopState = true;
            do
            {
                switch (int.TryParse(Console.ReadLine(), out int value) ? value : 0)
                {
                    case (int)Horse.Trine:
                        Betting();
                        loopState = false;
                        break;
                    case (int)Horse.Mille:
                        Betting();
                        loopState = false;
                        break;
                    case (int)Horse.Line:
                        Betting();
                        loopState = false;
                        break;
                    case (int)Horse.Sara:
                        Betting();
                        loopState = false;
                        break;
                    default:
                        Console.WriteLine("Please choose between the following horses 1-4");
                        break;
                }
            } while (loopState);
      
        }

        public static void Betting()
        {
            Console.WriteLine("How much would you like to bet?");
            decimal Bet = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine($"You are betting {Bet}\n");
        }

        public static void BeginRace()
        {
            Thread trineThread = new Thread(Race.Trine);
            Thread milleThread = new Thread(Race.Mille);
            Thread lineThread = new Thread(Race.Line);
            Thread saraThread = new Thread(Race.Sara);

            trineThread.Start();
            milleThread.Start();
            lineThread.Start();
            saraThread.Start();

            Thread trackThread = new Thread(UpdateCenter);
            trackThread.Start();
            Console.ReadKey();


        }

        public static void UpdateCenter()
        {
            Console.CursorVisible = false;
            while (RunStart)
            {
                Console.CursorVisible = false;
                while (RunStart)
                {
                    var line1 = new string[Console.BufferWidth];
                    int pos1 = (int)(Console.BufferWidth * trineStartPos);
                    if (pos1 >= 0 && pos1 < line1.Length)
                        line1[pos1] = "1";

                    var line2 = new string[Console.BufferWidth];
                    int pos2 = (int)(Console.BufferWidth * milleStartPos);
                    if (pos2 >= 0 && pos2 < line2.Length)
                        line2[pos2] = "2";

                    var line3 = new string[Console.BufferWidth];
                    int pos3 = (int)(Console.BufferWidth * lineStartPos);
                    if (pos3 >= 0 && pos3 < line3.Length)
                        line3[pos3] = "3";

                    var line4 = new string[Console.BufferWidth];
                    int pos4 = (int)(Console.BufferWidth * saraStartPos);
                    if (pos4 >= 0 && pos4 < line4.Length)
                        line4[pos4] = "4";

                    Console.SetCursorPosition(0, 15);
                    Console.Write(string.Join("=", line1));
                    Console.SetCursorPosition(0, 16);
                    Console.Write(string.Join("=", line2));
                    Console.SetCursorPosition(0, 17);
                    Console.Write(string.Join("=", line3));
                    Console.SetCursorPosition(0, 18);
                    Console.Write(string.Join("=", line4));
                    Thread.Sleep(100);
                }
            }

        }

       
        public static void Trine()
        {
            while (RunStart && trineStartPos < 1)
            {
                
                trineStartPos += 0.01f;
                Thread.Sleep(horse1);
            }
        }
        public static void Mille()
        {
            while (RunStart && milleStartPos < 1)
            {

                milleStartPos += 0.01f;
                Thread.Sleep(horse2);
            }
        }
        public static void Line()
        {
            while (RunStart && lineStartPos < 1)
            {

                lineStartPos += 0.01f;
                Thread.Sleep(horse3);
            }
        }
        public static void Sara()
        {
            while (RunStart && saraStartPos < 1)
            {

                saraStartPos += 0.01f;
                Thread.Sleep(horse4);
            }
        }


    }
}
