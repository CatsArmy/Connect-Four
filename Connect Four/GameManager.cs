using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Connect_Four
{
    internal class GameManager
    {
        BoardManager manager;
        Board board;
        bool gameOver;
        bool draw;
        bool turn;
        public GameManager()
        {
            board = new Board();
            manager = new BoardManager(board);
            gameOver = false;
            draw = false;
            turn = true;
        }
        public bool Play()
        {
            int turnCounter = 0;
            Console.WriteLine("The Game Begins");
            Console.WriteLine("Input System\n|1|2|3|4|5|6|7|");
            while (!gameOver)
            {
                gameOver = PlayTurn(turnCounter);
                turn = !turn;
                board.Print();
                turnCounter++;
            }
            if (!draw)
                GameOver();
            bool rematch = Rematch();
            if (rematch)
                Reinstancuate();
            return rematch;
        }
        private bool PlayTurn(int turnCounter)
        {   
            board.SetTokenType(turn);
            bool isConnected = PlaceToken();
            if (turnCounter == 6 * 7 && !isConnected)
                return manager.CheckIsDraw();
            return isConnected;
        }
        private bool PlaceToken()
        {
            bool success = false;
            int x = -1;
            while (!success)
            {
                Console.ForegroundColor = board.GetColor(board.GetTokenType());
                try
                {
                    x = int.Parse(Console.ReadLine()) - 1;
                }
                catch (Exception)
                {
                    Console.WriteLine("dont input anything other then numbers boi");
                }
                success = board.SetTokenAtCoord(x);
            }
            Console.ResetColor();
            Console.Clear();
            return manager.BoardCheck(x);
        }
        private void GameOver()
        {
            int[] lastPosCords = board.GetLastPosition();
            char token = board.GetTokenAtCoord(lastPosCords[0], lastPosCords[1]);
            Console.WriteLine($"{token} Won the game", Console.ForegroundColor = board.GetColor(token));
            Console.ResetColor();
        }
        private bool Rematch()
        {
            if (draw)
                Console.WriteLine("The Game Was A Draw");
            Console.WriteLine("Do you want to rematch?");
            Console.WriteLine("Input 1 for yes");
            Console.WriteLine("Input anything else for no");
            int response = -1;
            while (response < 0)
            {
                try
                {
                    response = int.Parse(Console.ReadLine());
                }
                catch (Exception) 
                {
                    Console.WriteLine("dont input anything other then numbers boi");
                }
            }
            return response == 1;
        }
        private void Reinstancuate()
        {
            board = new Board();
            manager = new BoardManager(board);
            gameOver = false;
            draw = false;
            turn = true;
            Console.Clear();
        }
        private bool GetTurn()
        {
            return turn;
        }
        private bool GetGameOver()
        {
            return gameOver;
        }
    }
}
