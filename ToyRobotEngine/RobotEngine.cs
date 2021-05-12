using System;
using System.Collections.Generic;
using System.Text;
using ToyRobotEngine.Enums;
using ToyRobotEngine.Interfaces;

namespace ToyRobotEngine
{
    public class RobotEngine : IRobotEngine
    {
        private readonly IRobot _robot;
        private readonly IBoard _board;
        public RobotEngine(IRobot robot, IBoard board)
        {
            _robot = robot;
            _board = board;
        }
        /// <summary>
        /// Moves the robot one position in the current direction
        /// </summary>
        public void MoveInCurrentDirection()
        {
            if (_robot.RobotPosition == null )
                return;
            Position newPosition = new Position(_robot.RobotPosition.XCoordinate, _robot.RobotPosition.YCoordinate);
            switch (_robot.RobotDirection.CurrentDirection)
            {
                case Directions.EAST:
                    newPosition.XCoordinate += 1;
                    break;
                case Directions.WEST:
                    newPosition.XCoordinate -= 1;
                    break;
                case Directions.NORTH:
                    newPosition.YCoordinate += 1;
                    break;
                case Directions.SOUTH:
                    newPosition.YCoordinate -= 1;
                    break;
                case Directions.NORTHEAST:
                    newPosition.YCoordinate += 1;
                    newPosition.XCoordinate += 1;
                    break;
                case Directions.SOUTHEAST:
                    newPosition.YCoordinate -= 1;
                    newPosition.XCoordinate += 1;
                    break;
                case Directions.SOUTHWEST:
                    newPosition.YCoordinate -= 1;
                    newPosition.XCoordinate -= 1;
                    break;
                case Directions.NORTHWEST:
                    newPosition.YCoordinate += 1;
                    newPosition.XCoordinate -= 1;
                    break;
                    
            }
            if (_board.CheckIfValidMove(newPosition))
                _robot.RobotPosition = newPosition;
        }

        /// <summary>
        /// Places the robot at the input position and direction
        /// </summary>
        /// <param name="position"></param>
        /// <param name="direction"></param>
        public void Place(Position position, Direction direction)
        {
            
            if (!_board.CheckIfValidMove(position))
                return;
            if (_robot.RobotPosition == null && direction == null)
                return;
            if (position != null)
                _robot.RobotPosition = position;

            if (direction != null)
                _robot.RobotDirection = direction;
        }

        /// <summary>
        /// Change the direction of the robot clockwise/anticlockwise by 90 degrees
        /// </summary>
        /// <param name="dirCommand"></param>
        public void ChangeDirection(Commands dirCommand)
        {
            switch (dirCommand)
            {
                case Commands.LEFT:
                    if ((int)_robot.RobotDirection.CurrentDirection - 1 < 0)
                        _robot.RobotDirection.CurrentDirection = (Directions)Enum.GetValues(typeof(Directions)).Length - 1;
                    else
                        _robot.RobotDirection.CurrentDirection = (Directions)((int)_robot.RobotDirection.CurrentDirection - 1);
                    break;
                case Commands.RIGHT:
                    if ((int)_robot.RobotDirection.CurrentDirection + 1 == Enum.GetValues(typeof(Directions)).Length)
                        _robot.RobotDirection.CurrentDirection = (Directions)(((int)_robot.RobotDirection.CurrentDirection + 1) % Enum.GetValues(typeof(Directions)).Length);
                    else
                        _robot.RobotDirection.CurrentDirection = (Directions)((int)_robot.RobotDirection.CurrentDirection + 1);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Writes the current coordinates and direction of the robot to the console.
        /// </summary>
        public void Report()
        {
            Console.WriteLine($"{_robot.RobotPosition.XCoordinate},{_robot.RobotPosition.YCoordinate},{_robot.RobotDirection.CurrentDirection}");
        }

        public void Avoid(Commands dirCommand,Position pos)
        {
            if (dirCommand.Equals(Commands.AVOID))
            {
                _board.AddToObsructedList(pos);
                return;
            }
        }

        /// <summary>
        /// Checks if valid PLACE command has been entered already
        /// </summary>
        /// <returns></returns>
        public bool IfPlaceCommandEntered()
        {
            return _robot.RobotPosition != null;
        }
    }
}
