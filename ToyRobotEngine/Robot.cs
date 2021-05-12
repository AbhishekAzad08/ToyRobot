using System;
using System.Collections.Generic;
using System.Text;
using ToyRobotEngine.Interfaces;

namespace ToyRobotEngine
{
    public class Robot : IRobot
    {
        public Position RobotPosition { get; set; }
        public Direction RobotDirection { get; set; }

    }
}
