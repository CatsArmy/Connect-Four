using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_Four
{
    internal class Board
    {
        char[,] board;
        int[] lastPostion;
        char tokenType;

        public Board()
        {
            board = new char[6, 7];
            tokenType = ' ';
            lastPostion = new int[2];
            Initialize();
        }
        void Initialize()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = tokenType;
                }
            }
        }
        public char[,] GetBoard()
        {
            return board;
        }
        public char GetTokenType()
        {
            return tokenType;
        }
        public void SetTokenType(bool _tokenType)
        {
            tokenType = _tokenType ? 'O' : '0';
        }
        public char GetTokenAtCoord(int x, int y = -1)
        {
            if (x > 6)
                x = 6;
            else if (x < 0)
                x = 0;
            if (y > -1)
                return board[y, x];
            for (int i = board.GetLength(0) - 1; i >= 0; i--)
            {
                if (board[i, x] != ' ')
                {
                    return board[i, x];
                }
            }
            return ' ';
        }
        public bool SetTokenAtCoord(int x)
        {
            if (x < 0 || x > 6)
            {
                Console.WriteLine("You should read as if you have you wouldnt input an invalid number");
                return false;
            }
            
            for (int i = board.GetLength(0) - 1; i >= 0; i--)
            {
                if (board[i, x] == ' ')
                {
                    board[i, x] = tokenType;
                    SetLastPostion(x, i);
                    return true;
                }
                if (i == 0 && board[i,x] != ' ')
                {
                    Console.Clear();
                    Print();
                    Console.WriteLine("Collum is full pick a diffent collum");
                }
            }
            return false;
        }

        /// <summary>
        /// lastPosition[0] = x
        /// <br></br>
        /// lastPosition[1] = y
        /// </summary>
        /// <returns><see cref="lastPostion"/></returns>
        public int[] GetLastPosition()
        {
            return lastPostion;
        }
        /// <summary>
        /// lastPosition[0] = <paramref name="x"/>
        /// <br></br>
        /// lastPosition[1] = <paramref name="y"/>
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetLastPostion(int x, int y)
        {
            lastPostion[0] = x;
            lastPostion[1] = y;
        }
        public ConsoleColor GetColor(char token)
        {
            if (token == 'O')
                return ConsoleColor.Red;
            if (token == '0')
                return ConsoleColor.Yellow;
            return ConsoleColor.Blue;
        }
        public void Print()
        {
            int numOfRows = board.GetLength(0);
            int numOfCollums = board.GetLength(1);
            Console.WriteLine("===============",
                Console.ForegroundColor = ConsoleColor.Cyan);
            Console.Write("|1|2|3|4|5|6|7|");
            for (int j = 0; j < numOfRows; j++)
            {
                Console.Write("\n|=============|" +
                    "\n|", Console.ForegroundColor = GetColor('|'));
                for (int i = 0; i < numOfCollums; i++)
                {
                    if (board[j, i] == ' ')
                    {
                        Console.Write(" |",Console.ForegroundColor = GetColor('|'));
                        Console.ResetColor();
                    }
                    else if (board[j, i] == 'O')
                    {
                        Console.Write($"{board[j, i]}", Console.ForegroundColor = GetColor('O'));
                        Console.Write("|", Console.ForegroundColor = GetColor('|'));
                        Console.ResetColor();
                    }
                    else if (board[j, i] == '0')
                    {
                        Console.Write($"{board[j, i]}", Console.ForegroundColor = GetColor('0'));
                        Console.Write("|", Console.ForegroundColor = GetColor('|'));
                        Console.ResetColor();
                    }
                }
                Console.ResetColor();
            }
            Console.WriteLine("\n|=============|",
                Console.ForegroundColor = GetColor('|'));
            Console.WriteLine("|1|2|3|4|5|6|7|",
                Console.ForegroundColor = ConsoleColor.Cyan);
            Console.WriteLine("===============");
            Console.ResetColor();

        }
    }
}
