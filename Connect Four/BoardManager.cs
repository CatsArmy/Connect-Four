using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_Four
{
    internal class BoardManager
    {
        private Board gameBoard;
        private int x;
        private int y;

        private char[,] board;
        private char type;
        public BoardManager(Board board)
        {
            gameBoard = board;
            this.board = gameBoard.GetBoard();
            type = gameBoard.GetTokenType();
        }
        /// <summary>
        /// checks all of the possiable areas that you could win from where you placed your last token
        /// </summary>
        /// <return>true if atlesat 1 is connected</return>
        /// <param name="x"></param>
        /// <returns></returns>
        public bool BoardCheck(int x)
        {
            type = gameBoard.GetTokenType();
            this.x = x;
            y = GetY();
            bool is4Connected = CheckRows() ||
                CheckCollums() || CheckDiagonals();
            return is4Connected;
        }
        /// <summary>
        /// Checks if there is any blank slots when its the last turn and no one has won
        /// </summary>
        /// <returns>true if all slots are filled with tokens</returns>
        public bool CheckIsDraw()
        {
            type = gameBoard.GetTokenType();
            int numOfRows = board.GetLength(0);
            int numOfCollums = board.GetLength(1);
            for (int i = 0; i < numOfRows; i++)
            {
                for (int j = 0; j < numOfCollums; j++)
                {
                    if (this.board[i, j] == ' ')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// checks all of the diagonals and returns true if 3 of the same token are in a row
        /// (logic for this is that it checks from where u place and so it doesnt need to check it self)
        /// </summary>
        /// <remarks>potenial bug on line 83</remarks>
        /// <returns>true if atlesat 1 diagonal is connected</returns>
        private bool CheckDiagonals()
        {
            /*
            if (y > 2)
            {
                if (x > 2)
                {
                    if (board[y - 1, x - 1] == type && board[y - 2, x - 2] == type && board[y - 3, x - 3] == type)
                    {
                        return true;
                    }
                }
                if (x < 4)
                {
                    if (board[y - 1, x + 1] == type && board[y - 2, x + 2] == type && board[y - 3, x + 3] == type)
                    {
                        return true;
                    }
                }
            }
            if (y < 3)
            {
                if (x > 2)// && x< 4)
                {
                    if (board[y + 1, x - 1] == type && board[y + 2, x - 2] == type && board[y + 3, x - 3] == type)//line83
                    {
                        return true;
                        //[3,2] == [2,3], [1,4], [0.5]
                    }
                }
                if (x < 4)// && x > 2)
                {
                    if (board[y + 1, x - 1] == type && board[y + 2, x - 2] == type && board[y + 3, x - 3] == type)//bad line
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
            */
            return Recursion();
        }
        bool Recursion()
        {
            //Counters
            int diagonalSecondary = 0;
            int diagonalPrime = 0;
            bool diagUpRightStop = false;
            bool diagDownRightStop = false;
            bool diagUpLeftStop = false;
            bool diagDownLeftStop = false;
            for (int i = 0; i < 3; i++)
            {
                bool diagDL = CheckDiagonalDownLeft(x, y, i);
                bool diagDR = CheckDiagonalDownRight(x, y, i);
                bool diagUL = CheckDiagonalUpLeft(x, y, i);
                bool diagUR = CheckDiagonalUpRight(x, y, i);

                if (diagDL && !diagDownLeftStop)
                    diagonalPrime++;
                else
                    diagDownLeftStop = true;
                if (diagUR && !diagUpRightStop)
                    diagonalPrime++;
                else
                    diagUpRightStop = true;
                if (diagDR && !diagDownRightStop)
                    diagonalSecondary++;
                else
                    diagDownRightStop = true;
                if (diagUL && !diagUpLeftStop)
                    diagonalSecondary++;
                else
                    diagUpLeftStop = true;

                if (diagonalPrime >= 3)
                    return true;
                if (diagonalSecondary >= 3)
                    return true;
            }
            return false;
        }
        //y - 1 = x
        //y = 5 == y = bottom
        bool IsCoordinateValid(int x,int y)
        {
            return x >= 0 && y >= 0 && x < 7 && y < 6;
        }
        //-1 means out of range | 1 = true | 0 false
        bool CheckRowUp(int y,int offset)
        {
            offset += 1;
            y -= offset;

            if (!IsCoordinateValid(x, y))
                return false;

            return board[y, x] == type;
        }
        bool CheckRowDown(int y, int offset)
        {
            offset += 1;
            y += offset;

            if (!IsCoordinateValid(x, y))
                return false;

            return board[y, x] == type;
        }
        bool CheckCollumRight(int x,int offset)
        {
            offset += 1;
            x += offset;

            if (!IsCoordinateValid(x, y))
                return false;

            return board[y, x] == type;
        }
        bool CheckCollumLeft(int x, int offset)
        {
            offset += 1;
            x -= offset;

            if (!IsCoordinateValid(x, y))
                return false;

            return board[y, x] == type;
        }
        bool CheckDiagonalUpRight(int x,int y, int offset)
        {
            offset += 1;
            x += offset;
            y -= offset;
            if (!IsCoordinateValid(x, y)) 
                return false;

            return board[y,x] == type;
        }
        bool CheckDiagonalDownRight(int x, int y,int offset)
        {
            offset += 1;
            x += offset;
            y += offset;
            if (!IsCoordinateValid(x, y))
                return false;

            return board[y, x] == type;
        }
        bool CheckDiagonalUpLeft(int x, int y, int offset)
        {
            offset += 1;
            x -= offset;
            y -= offset;
            if (!IsCoordinateValid(x, y))
                return false;

            return board[y, x] == type;
        }
        bool CheckDiagonalDownLeft (int x, int y, int offset)
        {
            offset += 1;
            x -= offset;
            y += offset;
            if (!IsCoordinateValid(x, y))
                return false;

            return board[y, x] == type;
        }

        /// <summary>
        /// checks all of the x positions on a certin y level
        /// </summary>
        /// <returns>true if atleast 4 x positions of the same type are connected with no split inbetween</returns>
        private bool CheckCollums()
        {
            /*
            int numOfCollums = board.GetLength(1);
            int collumTrackerRight = 0, collumTrackerLeft = 0;
            for (int i = 0, j = numOfCollums - 1; i < numOfCollums; i++,j--)
            {
                if (collumTrackerLeft == 4 || collumTrackerRight == 4)
                    return true;
                if (board[y, i] == type)
                    collumTrackerRight++;
                else
                    collumTrackerRight = 0;
                if (board[y, j] == type)
                    collumTrackerLeft++;
                else
                    collumTrackerLeft = 0;
            }
            */
            int collumTracker = 0;
            bool collumRightStop = false;
            bool collumLeftStop = false;
            for (int i = 0; i < 3; i++)
            {
                bool collumRight = CheckCollumRight(x, i);
                bool collumLeft = CheckCollumLeft(x, i);
                if (collumRight && !collumRightStop)
                    collumTracker++;
                else
                    collumRightStop = true;
                if (collumLeft && !collumLeftStop)
                    collumTracker++;
                else
                    collumLeftStop = true;
                if (collumTracker >= 3)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// checks all the y positions on the x position of where the token was placed
        /// </summary>
        /// <returns>true if atlesat 4 of the same token type is connected</returns>
        private bool CheckRows()
        {
            /*
            int numOfRows = board.GetLength(0);
            int rowTrackerUp = 0, rowTrackerDown = 0;
            for (int i = 0, j = numOfRows - 1; i < numOfRows; i++, j--) 
            {
                if (rowTrackerUp == 4 || rowTrackerDown == 4)
                    return true;
                if (board[i, x] == type)
                    rowTrackerUp++;
                else
                    rowTrackerUp = 0;
                if (board[j, x] == type)
                    rowTrackerDown++;
                else
                    rowTrackerDown = 0;
            }
            */
            int rowTracker = 0;
            bool rowUpStop = false;
            bool rowDownStop = false;
            for (int i = 0; i < 3; i++)
            {
                bool rowUp = CheckRowUp(y, i);
                bool rowDown = CheckRowDown(y, i);
                if (rowUp && !rowUpStop)
                    rowTracker++;
                else
                    rowUpStop = true;
                if (rowDown && !rowDownStop)
                    rowTracker++;
                else
                    rowDownStop = true;
                if (rowTracker >= 3)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// uses the x position of where the token was placed to find its y level
        /// </summary>
        /// <remarks>logic is that the first slot that isnt empty is the slot that was last placed</remarks>
        /// <returns>the y level of the last x position placed</returns>
        private int GetY()
        {
            int numOfRows = board.GetLength(0);
            int numOfCollums = board.GetLength(1);
            for (int i = 0; i < numOfRows; i++)
            {
                if (board[i, x] != ' ')
                {
                    return i;
                }
            }
            return 5;
        }
    }
}
