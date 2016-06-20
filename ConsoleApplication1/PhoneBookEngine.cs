using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleInterface;
using PhoneBookCore;

namespace ConsoleApplication1
{
    class PhoneBookEngine
    {
        public void StartApp()
        {
            this.StartWorkLoop();
        }

        public void StartWorkLoop()
        {
            Commands currentCommand = Commands.sort;
            int currentStartIndex = 0;
            int currentEndIndex = 0;
            var service=new DataService();

            while (currentCommand != Commands.exit)
            {
                // Load Start Page
                Console.Clear();
                LoadGeneralPage(service,ref currentStartIndex,ref currentEndIndex);

                // Get user command and anilize
                currentCommand = GetCommand();
                AnilizeCommand(currentCommand,ref service);
            }
        }

        public Commands GetCommand()
        {
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;

            // Output Start position
            Console.SetCursorPosition(3, 31);
            Console.CursorVisible = true;
            Console.Write(">> ");
            string tempCommand = Console.ReadLine();
            Commands userCommand = Commands.returnToStartPage;

            // Check user command
            for (int i = 0; i <= 10; i++)
            {
                if (tempCommand != null && ((Commands)i).ToString().ToLower()
                    == tempCommand.ToLower())
                {
                    userCommand = (Commands)i;
                    Console.CursorVisible = false;
                    Console.ForegroundColor = oldColor;
                    return userCommand;
                }
            }

            Console.SetCursorPosition(3, 32);
            Console.Write("Command not identified");
            Console.SetCursorPosition(3, 33);
            Console.ReadKey();
            Console.CursorVisible = false;
            Console.ForegroundColor = oldColor;
            return userCommand;
        }

        public void AnilizeCommand(Commands currentCommand,ref DataService service)
        {
            switch (currentCommand)
            {
                    case Commands.add:
                {
                        Add(service);
                        break;
                }
                    case Commands.nextPage:
                {
                        break;
                }
                    case Commands.previoslyPage:
                {
                        break;
                }
                    case Commands.search:

                {
                        break;
                }
                    case Commands.clear:
                {
                        service.Clear();
                        break;
                }
                    case Commands.removeById:
                {
                        RemoveById(service);
                        break;
                }
                case Commands.sort:
                {
                        break;
                }

                default:
                {
                        Console.Clear();
                        Console.WriteLine("not initilizate command");
                        break;
                }
            }
        }

        /// <summary>
        /// Output first page with command menu
        /// </summary>
        /// <param name="service">Service data object</param>
        /// <param name="contactStartIndex">Start contact index</param>
        /// <param name="contactEndIndex">End contact index</param>
        private static void LoadGeneralPage(
            DataService service,
            ref int contactStartIndex,
            ref int contactEndIndex)
        {
            // Common frame
            ConsoleFrameBuilder.DrawFrame(0, 0, 27, 98);

            // Info frame
            ConsoleFrameBuilder.DrawInfoFrame(1, 1, 26, 64);
            ConsoleDateBuilder.LoadStartInfo(
                service,
                ref contactStartIndex,
                ref contactEndIndex);

            // Command frame
            ConsoleFrameBuilder.DrawCommandFrame(1, 72, 26, 96);
            ConsoleDateBuilder.LoadCommandInfo(service);

            // Terminal Frame
            ConsoleFrameBuilder.DrawTerminalFrame(28, 0, 38, 98);
        }

        /// <summary>
        /// Add some element in PhoneBook
        /// </summary>
        /// <param name="myPhoneBook">Reference for current phone book</param>
        private static void Add(DataService service)
        {
            
            // Clear user teminal
            ConsoleDateBuilder.ClearTerminalFrame();
            Console.SetCursorPosition(3, 29);
            Console.Write("Input Name >> ");

            // Input surName
            var name = Console.ReadLine();

            // Check surName
            foreach (char value in name)
            {
                if (!char.IsLetter(value)&&(value!=' '))
                {
                    Console.SetCursorPosition(3, 30);
                    Console.Write("Bad input. Operation crashed ... Press any key to return at terminal");
                    Console.ReadKey();
                    return;
                }
            }

            // Input phoneNumber
            ConsoleDateBuilder.ClearTerminalFrame();
            Console.SetCursorPosition(3, 29);
            Console.Write("Input phoneNumber (in second format x-xxx-xxx-xxxx) >> ");
            string phoneNumber = Console.ReadLine();

            // PhoneNumber Check
            if (!CheckPhoneNumber(phoneNumber))
            {
                Console.SetCursorPosition(3, 30);
                Console.Write("Bad input. Operation crashed ... Press any key to return at terminal");
                Console.ReadKey();
                return;
            }

            service.Add(new Person() {Name = name,PhoneNumber = phoneNumber});
            }

        /// <summary>
        /// Check phone number
        /// </summary>
        /// <param name="phoneNumber">Phone number</param>
        /// <returns>Return flag</returns>
        private static bool CheckPhoneNumber(string phoneNumber)
        {
            if (phoneNumber.Any(temp => (!char.IsDigit(temp) && (temp != '-'))))
            {
                return false;
            }

            string[] blocksOfPhoneNumber = phoneNumber.Split('-');

            if (blocksOfPhoneNumber.Length < 4)
            {
                return false;
            }

            if ((blocksOfPhoneNumber[0].Length != 1) &&
                (blocksOfPhoneNumber[1].Length != 3) &&
                (blocksOfPhoneNumber[2].Length != 3) &&
                 (blocksOfPhoneNumber[3].Length != 4))
            {
                return false;
            }

            return true;
        }

        private void RemoveById(DataService service)
        {
            // Clear user teminal
            ConsoleDateBuilder.ClearTerminalFrame();
            Console.SetCursorPosition(3, 29);
            Console.Write("Input id >> ");

            // Input surName
            int i;

            // Check id
            if (!int.TryParse(Console.ReadLine(),out i)) 
            {
                Console.SetCursorPosition(3, 30);
                Console.Write("Bad input. Operation crashed ... Press any key to return at terminal");
                Console.ReadKey();
                return;
            }

            var tempList = service.GetPersonList().ToList();

            service.Remove(tempList[i-1].Id);
        }
    }
}
