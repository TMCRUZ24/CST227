using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project
{
    abstract class gameboardModel{

        public bool PlayerWon { set; get; }
        public int NumOfColumns { set; get; }
        public int NumOfRows { set; get; }
        public cell[,] Gameboard { set; get; }
        public int SafeTiles { set; get; }
        
        public void setGameBoard(){
            //initialize gameboard without live cells
            for (int row = 0; row < NumOfRows; row++)
            {
                for (int column = 0; column < NumOfColumns; column++)
                {
                    Gameboard[row, column] = new cell(row, column);
                }
            }

            //Gameboard will contain 20% "live" cells
            int numOfLiveCells = (NumOfColumns * NumOfRows) / 5;
            int counter = 0;
            Random rand = new Random();

            //set gameboard with "live" cells
            do{
                int rowRand = rand.Next(NumOfRows);
                int columnRand = rand.Next(NumOfColumns);

                //Random live cell placement on the gameboard
                if (Gameboard[rowRand, columnRand].IsLive == false){
                    Gameboard[rowRand, columnRand].IsLive = true;
                    this.SafeTiles--;
                }

                //Increment "Number of Live Neighbors" value for row above live cell
                if (rowRand > 0)
                {
                    if (columnRand > 0)
                    {
                        Gameboard[rowRand - 1, columnRand - 1].NumberOfLiveNeighbors++;
                    }

                    Gameboard[rowRand - 1, columnRand].NumberOfLiveNeighbors++;

                    if (NumOfColumns - 1 > columnRand)
                    {
                        Gameboard[rowRand - 1, columnRand + 1].NumberOfLiveNeighbors++;
                    }
                }

                //Increment "Number of Live Neighbors" value for same row as live cell
                if (columnRand > 0)
                {
                    Gameboard[rowRand, columnRand - 1].NumberOfLiveNeighbors++;
                }

                if (columnRand < NumOfColumns - 1)
                {
                    Gameboard[rowRand, columnRand + 1].NumberOfLiveNeighbors++;
                }

                //Increment "Number of Live Neighbors" value for row below live cell
                if (rowRand < NumOfRows - 1)
                {
                    if (columnRand > 0)
                    {
                        Gameboard[rowRand + 1, columnRand - 1].NumberOfLiveNeighbors++;
                    }

                    Gameboard[rowRand + 1, columnRand].NumberOfLiveNeighbors++;

                    if (columnRand < NumOfColumns - 1)
                    {
                        Gameboard[rowRand + 1, columnRand + 1].NumberOfLiveNeighbors++;
                    }
                }

                counter++;
            } while (counter < numOfLiveCells);
        }

        public void displayEntireBoard(bool playerWon)
        {
            Console.Write("  ");
            for (int column = 0; column < NumOfColumns; column++)
            {
                Console.Write(column);
            }
            Console.WriteLine("");
            
            for (int row = 0; row < NumOfRows; row++)
            {
                Console.Write(row);
                Console.Write("|");
                for (int column = 0; column <NumOfColumns; column++)
                {
                    if (Gameboard[row, column].IsLive == true)
                    {
                        Console.Write("*");
                    }
                    else if (Gameboard[row, column].NumberOfLiveNeighbors > 0)
                    {
                        Console.Write(Gameboard[row, column].NumberOfLiveNeighbors);
                    }
                    else
                    {
                        Console.Write("~");
                    }
                }
                Console.WriteLine("");
            }
            if (playerWon)
            {
                Console.WriteLine("Congratulations! You win!!");
                Environment.Exit(1);
            }
            else
            {
                Console.WriteLine("You hit a mine! You Lose!!");
                Environment.Exit(1);
            }
        }

        public abstract void playGame();

        public abstract void displayGameboard();
    }
}