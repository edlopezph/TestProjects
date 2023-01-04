using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Core;

namespace ToyRobot
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputCommand = String.Empty;

            Robot toyRobot = new Robot();

            Console.WriteLine("Robot initialised. Enter commands to send to Robot: (X at any time to quit)");

            while (true)
            {
                Console.WriteLine("Enter command for Robot:");
                inputCommand = Console.ReadLine();

                if (inputCommand.ToUpper().Equals("X"))
                    break;

                Console.WriteLine(toyRobot.Command(inputCommand));
                Console.WriteLine();
            }
            Console.WriteLine("Exited - press any key to close");
            Console.ReadLine();
        }
    }
}
