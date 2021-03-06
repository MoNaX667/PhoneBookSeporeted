﻿using System.Linq;
using ConsoleApplication1;

namespace ConsoleInterface
{ 
    using System;
    using System.Collections.Generic;
    using PhoneBookCore;
    internal class ConsoleDateBuilder
    {
        /// <summary>
        /// Load start info in info block
        /// </summary>
        /// <param name="phoneBook">phoneBook</param>
        /// <param name="contactStartIndex">contactStartIndex</param>
        /// <param name="contactLastIndex">contactLastIndex</param>
        public static void LoadStartInfo(DataService service,ref int contactStartIndex, ref int contactLastIndex)
        {
            List<Person> myContactsList = new List<Person>();
            int startIndex = contactStartIndex;
            contactLastIndex = startIndex + 20;

            // Check list for next 20 element if its true than output 20 elements on page
            // else list.count-startIndex
            if (service.GetLenght() < (startIndex + 20))
            {
                contactLastIndex = startIndex + (service.GetLenght() - startIndex);
            }

            myContactsList =  service.GetPersonList().ToList();

            // Output index
            for (int i = 0; i < contactLastIndex - contactStartIndex; i++)
            {
                Console.SetCursorPosition(2, 5 + i);
                Console.Write($"{startIndex + i + 1}".PadLeft(3, ' '));
            }

            // Output Names
            for (int i = 0; i < contactLastIndex - contactStartIndex; i++)
            {
                string[] pairNamePhone = new string [2];
                pairNamePhone[0] = myContactsList[i].Name;
                pairNamePhone[1] = myContactsList[i].PhoneNumber;
                string[] nameTemp = pairNamePhone[0].Split(' ');

                Console.SetCursorPosition(8, 5 + i);

                // If lenght of name big ... forename and middlename was replaced by first letter
                if (pairNamePhone[0].Length > 45)
                {
                    Console.Write("{0} {1}.{2}.", nameTemp[0], nameTemp[1][0], nameTemp[2][0]);
                }
                else
                {
                    Console.Write(pairNamePhone[0]);
                }       
            }

            // Output PhoneNumbers
            for (int i = 0; i < contactLastIndex - contactStartIndex; i++)
            {
                string[] pairNamePhone = new string[2];
                pairNamePhone[0] = myContactsList[i].Name;
                pairNamePhone[1] = myContactsList[i].PhoneNumber;
                string[] nameTemp = pairNamePhone[1].Split(' ');

                Console.SetCursorPosition(50, 5 + i);
                Console.Write("{0} ", pairNamePhone[1]);
            }
        }

        /// <summary>
        /// Load command info
        /// </summary>
        /// <param name="myPhoneBook">MyPhoneBook</param>
        public static void LoadCommandInfo(DataService service)
        {
            // Command block
            Console.SetCursorPosition(81, 2);
            Console.Write("Commands");

            for (int i = 0; i < 9; i++)
            {
                Console.SetCursorPosition(74, 4 + i);
                Console.Write((Commands)i);
            }

            // Status block
            Console.SetCursorPosition(82, 16);
            Console.Write("Status");
            Console.SetCursorPosition(74, 18);
            Console.Write(new string(' ', 23));
            Console.SetCursorPosition(74, 18);
            Console.Write("Current lenght: {0}".PadRight(3,' '),service.GetLenght() );
        }

        public static void ClearInfoFrame()
        {
            Console.Clear();

            // Common frame
            ConsoleFrameBuilder.DrawFrame(0, 0, 27, 98);

            // Info frame
            ConsoleFrameBuilder.DrawInfoFrame(1, 1, 26, 64);

            // Command frame
            ConsoleFrameBuilder.DrawCommandFrame(1, 72, 26, 96);

            // Terminal Frame
            ConsoleFrameBuilder.DrawTerminalFrame(28, 0, 38, 98);
        }

        public static void ClearTerminalFrame()
        {
            for (int i = 0; i < 6; i++)
            {
                Console.SetCursorPosition(3, 29 + i);
                Console.Write(new string(' ', 94));
            }
        }
    }
}
