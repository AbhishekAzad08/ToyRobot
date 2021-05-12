using System;
using System.Collections.Generic;
using System.Text;
using ToyRobotEngine.Enums;
using ToyRobotEngine.Handlers;
using ToyRobotEngine.Interfaces;

namespace ToyRobotEngine
{
    public class CommandModule
    {
        private readonly IRobotEngine _robotEngine;

        public CommandModule(IRobotEngine robotEngine)
        {
            _robotEngine = robotEngine;
        }
        public void ExecuteCommands(string cmd)
        {
            Command command = CommandHandler.GetCommands(cmd);

            if (!CheckIfValidCommand(command))
                return;

            switch (command.NextCommand)
            {
                case Commands.REPORT:
                    _robotEngine.Report();
                    break;
                case Commands.LEFT:
                    _robotEngine.ChangeDirection(command.NextCommand);
                    break;
                case Commands.RIGHT:
                    _robotEngine.ChangeDirection(command.NextCommand);
                    break;
                case Commands.PLACE:
                    _robotEngine.Place(command.NextPosition, command.Direction);
                    break;
                case Commands.MOVE:
                    _robotEngine.MoveInCurrentDirection();
                    break;
                case Commands.AVOID:
                    _robotEngine.Avoid(command.NextCommand,command.NextPosition);
                    break;
                default:
                    break;
            }

        }
        /// <summary>
        /// Checks if the command is valid.
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public bool CheckIfValidCommand(Command cmd)
        {
            if (!Enum.IsDefined(typeof(Commands), cmd.NextCommand) || cmd.NextCommand.Equals(Commands.UNDEFINED))
                return false;
            if (!cmd.NextCommand.Equals(Commands.PLACE) && !_robotEngine.IfPlaceCommandEntered())
                return false;
            if (cmd.NextCommand.Equals(Commands.PLACE) && cmd.NextPosition == null)
                return false;
            if (cmd.Direction != null && !Enum.IsDefined(typeof(Directions), cmd.Direction.CurrentDirection))
                return false;
            return true;
        }
    }
}
