using System;
using System.Collections.Generic;
using System.Text;
using ToyRobotEngine.Enums;

namespace ToyRobotEngine.Interfaces
{
    public interface IRobotEngine
    {
        void Place(Position position, Direction direction);
        void MoveInCurrentDirection();
        void ChangeDirection(Commands dirCommand);
        void Report();//test
        bool IfPlaceCommandEntered();
        void Avoid(Commands dirCommand, Position pos);
    }
}
