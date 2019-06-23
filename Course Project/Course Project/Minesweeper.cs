using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project
{
    class Minesweeper : gameboardModel, IPlayable{

        int counter = 0;

        //constructor
        public Minesweeper(int numOfRows, int numOfColumns)
        {
            this.NumOfRows = numOfRows;
            this.NumOfColumns = numOfColumns;
            this.SafeTiles = NumOfColumns * NumOfRows;
            this.Gameboard = new cell[numOfRows, numOfColumns];
        }

        //From the abstract class. Displays active game board while game is being played.
        public override void displayGameboard(){
            Console.WriteLine("Displaying game board");
            Console.Write("  ");
            //Display column numbers for grid
            for (int column = 0; column < NumOfColumns; column++)
            {
                Console.Write(column);
            }
            Console.WriteLine("");

            //Display tiles with a row number at the beginning of every row, along with a border
            for (int row = 0; row < NumOfRows; row++)
            {
                Console.Write(row);
                Console.Write("|");
                for (int column = 0; column < NumOfColumns; column++)
                {
                    Console.Write(this.Gameboard[row, column].DisplayTile);
                }
                Console.WriteLine("");
            }
        }

        //Method used to check if the user selected tile is a live mine
        public bool checkIsLive(int row, int column)
        {
            if(Gameboard[row, column].IsLive == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Recursive algorithm used to reveal the user-selected tile. Method calls itself if user selects empty tile with no mine or numeric indicators
        public void revealTile(int row, int column)
        {
            //If the user selects a tile with a live mine, game is over and user loses
            if (Gameboard[row, column].IsLive == true)
            {
                this.displayEntireBoard(PlayerLost);
            }
            //If the user selects a tile with a numeric indicator displaying how many neighboring mines there are
            else if (Gameboard[row, column].NumberOfLiveNeighbors > 0)
            {
                this.Gameboard[row, column].DisplayTile = this.Gameboard[row, column].NumberOfLiveNeighbors.ToString();
            }
            //If user selects empty tile that has no mine and no numeric indicator. This is where recursion takes place
            else
            {
                this.Gameboard[row, column].DisplayTile = "~";

                //Display tiles in the row above user-selected empty tile
                if (row > 0)
                {
                    if (column > 0)
                    {
                        if (this.Gameboard[row - 1, column - 1].WasVisited == false)
                        {
                            this.Gameboard[row - 1, column - 1].WasVisited = true;
                            revealTile(row - 1, column - 1);
                        }
                    }

                    if (this.Gameboard[row - 1, column].WasVisited == false)
                    {
                        this.Gameboard[row - 1, column].WasVisited = true;
                        revealTile(row - 1, column);
                    }

                    if (NumOfColumns - 1 > column)
                    {
                        if (this.Gameboard[row - 1, column + 1].WasVisited == false)
                        {
                            this.Gameboard[row - 1, column + 1].WasVisited = true;
                            revealTile(row - 1, column + 1);
                        }
                    }

                }

                //Display tiles in the same row as user-selected empty tile
                if (column > 0)
                {
                    if (this.Gameboard[row, column - 1].WasVisited == false)
                    {
                        this.Gameboard[row, column - 1].WasVisited = true;
                        revealTile(row, column - 1);
                    }
                }

                if (column < NumOfColumns - 1)
                {
                    if (this.Gameboard[row, column + 1].WasVisited == false)
                    {
                        this.Gameboard[row, column + 1].WasVisited = true;
                        revealTile(row, column + 1);
                    }
                }

                //Display tiles in the row below user-selected empty tile
                if (row < NumOfRows - 1)
                {
                    if (column > 0)
                    {
                        if (this.Gameboard[row + 1, column - 1].WasVisited == false)
                        {
                            this.Gameboard[row + 1, column - 1].WasVisited = true;
                            revealTile(row + 1, column - 1);
                        }
                    }

                    if (this.Gameboard[row + 1, column].WasVisited == false)
                    {
                        this.Gameboard[row + 1, column].WasVisited = true;
                        revealTile(row + 1, column);
                    }

                    if (NumOfColumns - 1 > column)
                    {
                        if (this.Gameboard[row + 1, column + 1].WasVisited == false)
                        {
                            this.Gameboard[row + 1, column + 1].WasVisited = true;
                            revealTile(row + 1, column + 1);
                        }
                    }
                }
            }
        }
        
        //From the interface. Method keeping game active. This method calls all other functions within Minesweeper class
        public override void playGame(){

            Console.WriteLine("Game On");

            //do-while loop continues to iterate while the game is active (until user wins or selects a tile with a mine)
            do
            {
                //If no safe tiles exist, trigger a win. Otherwise, continue game with newly revealed tile
                if (this.SafeTiles == 0)
                {
                    this.displayEntireBoard(true);
                }
                else
                {
                    this.displayGameboard();
                }

                //Prompt user to enter valid row number
                int row, column;
                do
                {
                    Console.WriteLine("Choose a row to select a tile: ");
                    String input = Console.ReadLine();
                    Int32.TryParse(input, out row);
                    if (row > NumOfRows)
                    {
                        Console.WriteLine("Row number exceeds boundaries. Please try again.");
                    };
                } while (row > NumOfRows - 1);

                //Prompt user to enter valid column number
                do
                {
                    Console.WriteLine("Now choose a column: ");
                    String input = Console.ReadLine();
                    Int32.TryParse(input, out column);
                    if (row > NumOfRows)
                    {
                        Console.WriteLine("Row number exceeds boundaries. Please try again.");
                    };
                } while (column > NumOfColumns - 1);

                //Check to see if selected tile is a mine (game over, user loses). If not, reveal selected tile.
                if(checkIsLive(row, column))
                {
                    this.displayEntireBoard(false);
                }
                else
                {
                    this.revealTile(row, column);
                }

            } while (this.PlayerLost == false);
        }
    }
}