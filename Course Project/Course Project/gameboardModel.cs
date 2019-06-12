using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project
{
    class gameboardModel{

        public int numOfColumns { set; get; }
        public int numOfRows { set; get; }
        public cell[,] gameboard { set; get; }

        //constructor
        public gameboardModel(int numOfRows, int numOfColumns){
            this.numOfRows = numOfRows;
            this.numOfColumns = numOfColumns;

            this.gameboard = new cell[numOfRows, numOfColumns];
        }
        
        public void setGameBoard(){
            //Gameboard will contain 20% "live" cells
            int numOfLiveCells = (numOfColumns * numOfRows) / 5;
            int counter = 0;
            Random rand = new Random();

            //initialize gameboard to "false" live cells
            for (int row = 0; row < numOfRows; row++){
                for (int column = 0; column < numOfColumns; column++){
                    gameboard[row, column] = new cell(row, column);
                }
            }

            //set gameboard with "live" cells
            do{
                int rowRand = rand.Next(numOfRows);
                int columnRand = rand.Next(numOfColumns);

                //Random live cell placement on the gameboard
                gameboard[rowRand, columnRand].isLive = true;

                //Increment "Number of Live Neighbors" value for row above live cell
                if (rowRand > 0)
                {
                    if (columnRand > 0)
                    {
                        gameboard[rowRand - 1, columnRand - 1].numberOfLiveNeighbors++;
                    }

                    gameboard[rowRand - 1, columnRand].numberOfLiveNeighbors++;

                    if (numOfColumns - 1 > columnRand)
                    {
                        gameboard[rowRand - 1, columnRand + 1].numberOfLiveNeighbors++;
                    }
                }

                //Increment "Number of Live Neighbors" value for same row as live cell
                if (columnRand > 0)
                {
                    gameboard[rowRand, columnRand - 1].numberOfLiveNeighbors++;
                }

                if (columnRand < numOfColumns - 1)
                {
                    gameboard[rowRand, columnRand + 1].numberOfLiveNeighbors++;
                }

                //Increment "Number of Live Neighbors" value for row below live cell
                if (rowRand < numOfRows - 1)
                {
                    if (columnRand > 0)
                    {
                        gameboard[rowRand + 1, columnRand - 1].numberOfLiveNeighbors++;
                    }

                    gameboard[rowRand + 1, columnRand].numberOfLiveNeighbors++;

                    if (columnRand < numOfColumns - 1)
                    {
                        gameboard[rowRand + 1, columnRand + 1].numberOfLiveNeighbors++;
                    }
                }

                counter++;
            } while (counter < numOfLiveCells);
        }

        public void displayGameboard(){
            Console.WriteLine("Game on...");
            for(int row = 0; row < numOfRows; row++){
                for (int column = 0; column < numOfColumns; column++){
                    if (gameboard[row, column].isLive == true){
                        Console.Write("*");
                    }
                    else if(gameboard[row, column].numberOfLiveNeighbors > 0){
                        Console.Write(gameboard[row, column].numberOfLiveNeighbors);
                    }
                    else{
                        Console.Write(" ");
                    }
                }
                Console.WriteLine("");
            }
        }
    }
}