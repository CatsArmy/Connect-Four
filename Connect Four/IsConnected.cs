using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_Four
{
    internal class IsConnected
    {
        static int numOfRows = 6;
        static int numOfCollums = 7;
        bool CheckSumOfRows(char[,] board, int xLevel, char currentSlot)
        {
            int rowTracker = 0;
            for (int i = 0; i < numOfRows; i++)
            {
                if (board[i, xLevel] == currentSlot)
                    rowTracker++;
                else
                    rowTracker = 0;
                if (rowTracker == 4)
                {
                    return true;
                }
            }
            return false;
        }

        bool CheckSumOfCollums(char[,] board, int yLevel, char currentSlot)
        {
            int collumTracker = 0;
            for (int i = 0; i < numOfRows; i++)
            {
                if (board[yLevel, i] == currentSlot)
                    collumTracker++;
                else
                    collumTracker = 0;
                if (collumTracker == 4)
                {
                    return true;
                }
            }
            return false;
        }

        bool CheckSumOfPrimaryDiagonal(char[,] board,int xLevel,int yLevel,char current)
        {
            int PrimeDiagTracker = 0;
            //start at drop location
            //end at 0
            //start drop end 7
            
            for (int i = yLevel, j = xLevel; i < numOfRows || j < numOfCollums ; i++,j++)
            {
                if (board[i,j] == current)
                {

                }
            }
            return false;
        }
        int GetSumOfSecondaryDiagonal(int[,] arr)
        {
            int numOfRows = arr.GetLength(0);
            int numOfCollums = arr.GetLength(1);
            int sumOfSecondaryDiaginal = 0;
            for (int i = numOfRows - 1, j = 0; i >= 0; i--, j++)
            {
                sumOfSecondaryDiaginal += arr[i, j];
            }
            return sumOfSecondaryDiaginal;
        }

        public static bool isConnected(char[,] board, int xLevel, int yLevel, char currentSlot)
        {
            int collumTracker = 0;
            for (int i = yLevel; i < numOfRows; i++)
            {
                if (board[i, xLevel] == currentSlot)
                    rowTracker++;
                else
                    rowTracker = 0;
                if (board[])
                {

                }
            }
            for (int i = yLevel; i < numOfRows; i++)
            {
                if (board[yLevel + i,xLevel + i] == currentSlot)
                {

                }
                if (board[yLevel + i,xLevel - i] == currentSlot)
                {

                }
            }
/*////////////////

  |0|0|0|0|0|0|0|
  |0|0|0|0|0|0|0|
  |0|0|0|0|0|0|0|
  |0|0|0|0|0|0|0|
  |0|0|0|0|x|0|0|
  |0|0|0|0|0|0|0|
  |0|0|0|0|0|0|0|

////////////////*/
            for (int i = xLevel; i < numOfCollums; i++)
            {
                
            }
        }
    }
}
