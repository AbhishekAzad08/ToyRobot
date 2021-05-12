using System;
using System.Collections.Generic;
using System.Text;
using ToyRobotEngine.Enums;

namespace ToyRobotEngine.Handlers
{
    public class CommandHandler
    {
        /// <summary>
        /// Gets the input string provided by the user and returns a command object
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static Command GetCommands(string cmd)
        {
            Command command = new Command();
            Direction dir = new Direction();
            cmd = cmd.ToUpper();
            string[] commands = cmd.Split(' ');
            try
            {
                if (commands.Length > 1)
                {
                    string[] commandParam = commands[1].Split(',');

                    if (commandParam.Length < 2)
                        return command;
                    command.NextPosition = new Position(
                        Convert.ToInt32(commandParam[0]), Convert.ToInt32(commandParam[1]));
                    if (commandParam.Length > 2)
                    {
                        try
                        {
                            dir.CurrentDirection = (Directions)Enum.Parse(typeof(Directions), commandParam[2]);
                            command.Direction = dir;
                        }
                        catch (ArgumentException)
                        {
                            Console.WriteLine($"{commandParam[2]} is not a valid direction. Please enter a valid direction.");
                            return new Command();//return empty command in case of exception. Validity check in the next step will return false.
                        }
                    }
                }
                command.NextCommand = (Commands)Enum.Parse(typeof(Commands), commands[0]);
            }
            catch (FormatException)
            {
                Console.WriteLine($"Input not in a correct format.");
                return new Command();  //return empty command in case of exception. Validity check in the next step will return false.
            }
            catch (ArgumentException)
            {
                Console.WriteLine($"{commands[0]} is not a valid command.  Please enter a valid command.");
                return new Command(); //return empty command in case of exception. Validity check in the next step will return false.
            }
            return command;
        }


    }
}
