using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project
{
    class Program{
        static void Main(string[] args){

            Console.WriteLine("Enter the number of rows: ");
            String input = Console.ReadLine();
            int numOfRows;
            Int32.TryParse(input, out numOfRows);

            Console.WriteLine("Enter number of columns: ");
            input = Console.ReadLine();
            int numOfColumns;
            Int32.TryParse(input, out numOfColumns);

            gameboardModel myGameboard = new Minesweeper(numOfRows, numOfColumns);
            myGameboard.setGameBoard();
            myGameboard.playGame();
        }
    }
}
