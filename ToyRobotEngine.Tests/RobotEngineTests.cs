using System;
using ToyRobotEngine.Enums;
using ToyRobotEngine.Interfaces;
using Xunit;

namespace ToyRobotEngine.Tests
{
    public class RobotEngineTests
    {
        IRobot robot;
        IBoard board;
        Direction direction;
        public RobotEngineTests()
        {
             robot = new Robot();
             board = new Board(6, 6);
            direction = new Direction();
            direction.CurrentDirection = Directions.NORTH;
        }
        /// <summary>
        /// Test PLACE command with valid input
        /// </summary>
        [Fact]
        public void Place_Test_SUCCESS()
        {            
            var robotEngine = new RobotEngine(robot, board);
            robotEngine.Place(new Position(1, 1), direction);
            Assert.Equal(1, robot.RobotPosition.XCoordinate);
            Assert.Equal(1, robot.RobotPosition.YCoordinate);
            Assert.Equal(Directions.NORTH, robot.RobotDirection.CurrentDirection);
        }
        
        /// <summary>
        /// Test Move command without Place command
        /// </summary>
        [Fact]
        public void MoveInCurrentDirection_Test_FirstCommand_NoPlace()
        {
            var robotEngine = new RobotEngine(robot, board);
            robotEngine.MoveInCurrentDirection();
            Assert.Null(robot.RobotPosition);
        }

        /// <summary>
        /// Test Move command with Place command
        /// </summary>
        [Fact]
        public void MoveInCurrentDirection_Test()
        {    
            var robotEngine = new RobotEngine(robot, board);
            robotEngine.Place(new Position(1, 1), direction);
            robotEngine.MoveInCurrentDirection();
            Assert.Equal(1, robot.RobotPosition.XCoordinate);
            Assert.Equal(2, robot.RobotPosition.YCoordinate);
            Assert.Equal(Directions.NORTH,robot.RobotDirection.CurrentDirection);
        }
        /// <summary>
        /// Test ChangeDirection with LEFT direction
        /// </summary>
        [Fact]
        public void ChangeDirection_LEFT_Test()
        {
            var robotEngine = new RobotEngine(robot, board);
            robotEngine.Place(new Position(1, 1), direction);           
            robotEngine.ChangeDirection(Commands.LEFT);
            Assert.Equal(1, robot.RobotPosition.XCoordinate);
            Assert.Equal(1, robot.RobotPosition.YCoordinate);
            Assert.Equal(Directions.WEST, robot.RobotDirection.CurrentDirection);
        }
        /// <summary>
        ///  Test ChangeDirection with RIGHT direction
        /// </summary>
        [Fact]
        public void ChangeDirection_RIGHT_Test()
        {    
            var robotEngine = new RobotEngine(robot, board);
            robotEngine.Place(new Position(1, 1), direction);
            robotEngine.ChangeDirection(Commands.RIGHT);
            Assert.Equal(1, robot.RobotPosition.XCoordinate);
            Assert.Equal(1, robot.RobotPosition.YCoordinate);
            Assert.Equal(Directions.EAST, robot.RobotDirection.CurrentDirection);
        }
        
    }
}
