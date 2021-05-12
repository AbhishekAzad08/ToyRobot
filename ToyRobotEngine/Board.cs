using System;
using System.Collections.Generic;
using System.Text;
using ToyRobotEngine.Interfaces;

namespace ToyRobotEngine
{
    public class Board : IBoard
    {
        private readonly int _rowCount;
        private readonly int _columnCount;
        public List<Position> obstructedPositions;

       
        public Board(int rows, int columns)
        {
            _rowCount = rows;
            _columnCount = columns;
            obstructedPositions = new List<Position>();
        }

        public int RowCount {
            get
            {
                return _rowCount;
            }
        }
        public int ColumnCount
        {
            get
            {
                return _columnCount;
            }
        }


        public bool CheckIfValidMove(Position position)
        {
            var obstructedPosition = obstructedPositions.Find(pos => pos.XCoordinate == position.XCoordinate && pos.YCoordinate == position.YCoordinate);
            if (obstructedPosition!=null)
                return false;

            return !((position.XCoordinate < 0 || position.YCoordinate < 0 || position.XCoordinate > RowCount || position.YCoordinate > ColumnCount));
        }
        public void AddToObsructedList(Position pos)
        {
            obstructedPositions.Add(pos);
        }
    }
}
