using System;
using System.Collections.Generic;
using System.Text;
using ToyRobotEngine.Enums;

namespace ToyRobotEngine
{
    public class Command
    {
        public Position NextPosition { get; set; }
        public Commands NextCommand { get; set; }
        public Direction Direction { get; set; }
    }
}
