using System;
using System.Collections.Generic;
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
        
        public bool BoardCheck(int x)
        {
            type = gameBoard.GetTokenType();
            this.x = x;
            y = GetY();
            bool is4Connected =  CheckRows() ||
                CheckCollums() || CheckDiagonals();
            return is4Connected;
        }
        public bool CheckIsDraw()
        {
            type = gameBoard.GetTokenType();
            int numOfRows = board.GetLength(0);
            int numOfCollums = board.GetLength(1);
            for (int i = 0; i < numOfRows; i++)
            {
                for (int j = 0; j < numOfCollums; j++)
                {
                    if (this.board[i,j] == ' ')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private bool CheckDiagonals()
        {
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
                if (x > 2)
                {
                    if (board[y + 1, x - 1] == type && board[y + 2, x - 2] == type && board[y + 3, x - 3] == type)
                    {
                        return true;
                    }
                }
                if (x < 4)
                {
                    if (board[y + 1, x + 1] == type && board[y + 2, x - 2] == type && board[y + 3, x - 3] == type)
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
        private bool CheckCollums()
        {
            int numOfCollums = board.GetLength(1);
            int collumTrackerLeft = 0, collumTrackerRight = 0;
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
            return false;
        }
        private bool CheckRows()
        {
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
            return false;
        }
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
