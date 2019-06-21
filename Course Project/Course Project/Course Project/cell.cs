using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project
{
    class cell{

        //Properties
        public int ColumnX { get; set; }
        public int RowY { get; set; }
        public bool WasVisited { get; set; }
        public bool IsLive { get; set; }
        public int NumberOfLiveNeighbors { get; set; }
        public String DisplayTile { get; set; }

        //Constructor
        public cell(int rowY, int columnX)
        {
            this.ColumnX = columnX;
            this.RowY = rowY;
            this.WasVisited = false;
            this.IsLive = false;
            this.NumberOfLiveNeighbors = 0;
            this.DisplayTile = "?";
        }
    }
}
