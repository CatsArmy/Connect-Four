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
        /// <summary>
        /// Sets the board
        /// </summary>
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
        /// <summary>
        /// getter for the board matrix
        /// </summary>
        /// <returns>the board</returns>
        public char[,] GetBoard()
        {
            return board;
        }
        /// <summary>
        /// getter for token type
        /// </summary>
        /// <returns>the token type</returns>
        public char GetTokenType()
        {
            return tokenType;
        }
        /// <summary>
        /// sets the token type according to the turn
        /// </summary>
        /// <param name="_tokenType"></param>
        public void SetTokenType(bool _tokenType)
        {
            tokenType = _tokenType ? 'O' : '0';
        }
        /// <summary>
        /// lets you get a token at a certin coordination
        /// used for showing what player one the game
        /// </summary>
        /// <remarks>if the <paramref name="y"/> is unchanged then will return the last token in a certin collum</remarks>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>the token in the x and y coordination</returns>
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
        /// <summary>
        /// Sets the token at a user inputed coordination if its in the range and the collum isnt full
        /// </summary>
        /// <param name="x"></param>
        /// <returns>true if the collum isnt full and its a valid coordination</returns>
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
        /// <summary>
        /// Quick interface for getting the color for each type of token and the board base
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public ConsoleColor GetColor(char token)
        {
            if (token == 'O')
                return ConsoleColor.Red;
            if (token == '0')
                return ConsoleColor.Yellow;
            return ConsoleColor.Blue;
        }
        /// <summary>
        /// prints the board according the the values of the board with colors matching too
        /// </summary>
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
