using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project
{
    class cell{

        //Properties
        public int columnX { get; set; }
        public int rowY { get; set; }
        public bool wasVisited { get; set; }
        public bool isLive { get; set; }
        public int numberOfLiveNeighbors { get; set; }

        //Constructor
        public cell(int rowY, int columnX)
        {
            this.columnX = columnX;
            this.rowY = rowY;
            this.wasVisited = false;
            this.isLive = false;
            this.numberOfLiveNeighbors = 0;
        }

       /* //Getter and Setter methods for properties
        public int ColumnX { get => columnX; set => columnX = value; }
        public int RowY { get => rowY; set => rowY = value; }
        public bool WasVisited { get => wasVisited; set => wasVisited = value; }
        public bool IsLive { get => isLive; set => isLive = value; }
        public int NumberOfLiveNeighbors { get => numberOfLiveNeighbors; set => numberOfLiveNeighbors = value; }
        */
    }
}
