using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotEngine.Interfaces
{
    public interface IRobot
    {
        Position RobotPosition { get; set; }
        Direction RobotDirection { get; set; }
    }
}
