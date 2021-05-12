using System;
using ToyRobotEngine;
using ToyRobotEngine.Interfaces;

namespace ToyRobotSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            IBoard board = new Board(8, 8);
            IRobot robot = new Robot();
            IRobotEngine re = new RobotEngine(robot, board);
            CommandModule cmd = new CommandModule(re);
            bool exit = false;
            Console.WriteLine($"Press E+Enter to exit.");
            while (!exit)
            {
                var command = Console.ReadLine();
                if (command == "E")
                    exit = true;
                else
                    cmd.ExecuteCommands(command);
            }
        }
    }
}
