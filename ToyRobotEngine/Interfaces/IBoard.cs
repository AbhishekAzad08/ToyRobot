using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotEngine.Interfaces
{
    public interface IBoard
    {
        int RowCount { get; }
        int ColumnCount { get; }

        void AddToObsructedList(Position pos);
        bool CheckIfValidMove(Position position);
    }
}
