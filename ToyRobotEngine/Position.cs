using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotEngine
{
    public class Position
    {
        private  int xCoordinate;
        private  int yCoordinate;
        public int XCoordinate {
            get { return xCoordinate; }
            set { xCoordinate = value; }
        }
        public int YCoordinate
        {
            get { return yCoordinate; }
            set { yCoordinate = value; }
        }

        public Position(int x, int y)
        {
            this.xCoordinate = x;
            this.yCoordinate = y;

        }
    }
}
