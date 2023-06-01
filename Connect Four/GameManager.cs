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
        /// <summary>
        /// When Run the game will play untill someone wins
        /// </summary>
        /// <remarks>the rematch function only works with play if its in a while loop (example: while (manager.Play());</remarks>
        /// <returns>true if you want to rematch</returns>
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
        /// <summary>
        /// syncs the token type according to the turn then lets you place a token
        /// </summary>
        /// <remarks>if <paramref name="turnCounter"/> == all slots filled check if its a draw</remarks>
        /// <param name="turnCounter"></param>
        /// <returns>true if placing the token connects 4 tokens of the same type in the same direction</returns>
        private bool PlayTurn(int turnCounter)
        {   
            board.SetTokenType(turn);
            bool isConnected = PlaceToken();
            if (turnCounter == 6 * 7 && !isConnected)
                return manager.CheckIsDraw();
            return isConnected;
        }
        /// <summary>
        /// lets you place a  token untill you have a valid token spot
        /// </summary>
        /// <returns>true if 4 or more are connected</returns>
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
        /// <summary>
        /// Game Over message
        /// </summary>
        private void GameOver()
        {
            int[] lastPosCords = board.GetLastPosition();
            char token = board.GetTokenAtCoord(lastPosCords[0], lastPosCords[1]);
            Console.WriteLine($"{token} Won the game", Console.ForegroundColor = board.GetColor(token));
            Console.ResetColor();
        }
        /// <summary>
        /// asks the user if he wants a rematch
        /// </summary>
        /// <returns>true if user inputs a yes</returns>
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
        /// <summary>
        /// reset the game
        /// </summary>
        private void Reinstancuate()
        {
            board = new Board();
            manager = new BoardManager(board);
            gameOver = false;
            draw = false;
            turn = true;
            Console.Clear();
        }
        /// <summary>
        /// unused function
        /// </summary>
        /// <returns>the turn</returns>
        private bool GetTurn()
        {
            return turn;
        }
        /// <summary>
        /// unsed function
        /// </summary>
        /// <returns>the game over boolean</returns>
        private bool GetGameOver()
        {
            return gameOver;
        }
    }
}
