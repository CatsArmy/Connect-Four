using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_Four
{
 /// <summary>
 /// The Class is used to check if someone has won by having 4 tokens connected
 /// </summary>
 /// <remarks>potentialy need to refactor the code and make it work with a board/GameManager class</remarks>
    internal class IsConnected
    {
        static int numOfRows = 6;
        static int numOfCollums = 7;

        /*bool CheckSumOfPrimaryDiagonal(char[,] board, int xLevel, int yLevel, char current)
        {
            int PrimeDiagTracker = 0;
            //start at drop location
            //end at 0
            //start drop end 7
            //y offset = y max - x - y

            // 4,3 
            for (int i = 0; i < numOfRows - yLevel; i++)
            {

            }
            for (int i = yLevel, j = xLevel; i < numOfRows - () && j < numOfCollums; i++, j++)
            {
                if (board[i, j] == current)
                {

                }
            }
            return false;
        }*/
        /*int GetSumOfSecondaryDiagonal(int[,] arr)
        {
            int numOfRows = arr.GetLength(0);
            int numOfCollums = arr.GetLength(1);
            int sumOfSecondaryDiaginal = 0;
            for (int i = numOfRows - 1, j = 0; i >= 0; i--, j++)
            {
                sumOfSecondaryDiaginal += arr[i, j];
            }
            return sumOfSecondaryDiaginal;
        }*/
        
        /// <summary>
        ///  Gets the game board the position x (collum) of where the token was placed
        /// </summary>
        /// <param name="board"></param>
        /// <param name="x"></param>
        /// <param name="currentSlot"></param>
        /// <returns>True if 4 of the same token are connected</returns>
        static bool CheckRows(char[,] board, int x, char type)
        {
            int rowTracker = 0;
            //for (int i = 0; i < numOfRows; i++)
            for (int i = numOfRows - 1; i >= 0; i--)
            {
                if (rowTracker == 4)
                    return true;
                if (board[i, x] == type)
                    rowTracker++;
                else
                    rowTracker = 0;
            }
            return false;
        }

        /// <summary>
        /// Gets the game board the position y (row) of where the token was placed
        /// </summary>
        /// <param name="board"></param>
        /// <param name="y"></param>
        /// <param name="currentSlot"></param>
        /// <returns>True if 4 of the same token are connected</returns>
        static bool CheckCollums(char[,] board, int y, char type)
        {
            int collumTracker = 0;
            //for (int i = 0; i < numOfCollums; i++)
            for (int i = numOfCollums - 1; i >= 0; i--)
            {
                if (collumTracker == 4)
                    return true;
                if (board[y, i] == type)
                    collumTracker++;
                else
                    collumTracker = 0;
            }
            return false;
        }

        /// <summary>
        /// Gets The <paramref name="x"/> (collum) and <paramref name="y"/> (row) of the placed token 
        /// and the tokens <paramref name="type"/>
        /// </summary>
        /// <param name="board"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="type"></param>
        /// <returns>True if any diagonal stack of 4 tokens of the same <paramref name="type"/>
        /// are connected on the <paramref name="board"/> are </returns>
        static bool CheckDiagonals(char[,] board, int x, int y, char type)
        {
            if (y > 2)
            {
                if (x < 4)
                {
                    if (board[y - 1, x + 1] == type && board[y - 2, x - 2] == type && board[y - 3, x - 3] == type)
                    {
                        return true;
                    }

                }
                if (x > 2)
                {
                    if (board[y - 1, x - 1] == type && board[y - 2, x - 2] == type && board[y - 3, x - 3] == type)
                    {
                        return true;
                    }
                }
            }
            if (y < 3)
            {
                if (x < 4)
                {
                    if (board[y + 1, x + 1] == type && board[y + 2, x - 2] == type && board[y + 3, x - 3] == type)
                    {
                        return true;
                    }

                }
                if (x > 2)
                {
                    if (board[y + 1, x - 1] == type && board[y + 2, x - 2] == type && board[y + 3, x - 3] == type)
                    {
                        return true;
                    }
                }
            }
            if (y < 5 && y > 1)
            {
                if (x < 5 && x > 0)
                {
                    if (board[y + 1, x - 1] == type && board[y - 1, x + 1] == type && board[y - 2, x + 2] == type)
                    {
                        return true;
                    }
                }
                if (x < 6 && x > 1)
                {
                    if (board[y + 1, x + 1] == type && board[y - 1, x - 1] == type && board[y - 2, x - 2] == type)
                    {
                        return true;
                    }
                }
            }
            if (y < 4 && y > 0)
            {
                if (x < 5 && x > 0)
                {
                    if (board[y - 1, x - 1] == type && board[y + 1, x + 1] == type && board[y + 2, x + 2] == type)
                    {
                        return true;
                    }
                }
                if (x < 6 && x > 1)
                {
                    if (board[y - 1, x + 1] == type && board[y + 1, x - 1] == type && board[y + 2, x - 2] == type)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// checks all the diagonals above and below the point placed
        /// </summary>
        /// <return>true if </return>
        /// <param name="board"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="type"></param>
        /// <returns>true if at lesat one lines (<see cref="CheckCollums(char[,], int, char)"/>,
        /// <see cref="CheckRows(char[,], int, char)"/>,<see cref="CheckDiagonals(char[,], int, int, char)"/>)
        /// returns true</returns>
        public static bool BoardChecker(char[,] board, int x, int y, char type)
        {
            bool isConnected = CheckRows(board, x, type) || CheckCollums(board, y, type) || CheckDiagonals(board, x, y, type);
            return isConnected;   
        }
    }

}