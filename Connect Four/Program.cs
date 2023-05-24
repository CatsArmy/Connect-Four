using Connect_Four;
/*////////////////

  |x|0|0|x|0|0|x|
  |0|x|0|x|0|x|0|
  |0|0|x|x|x|0|0|
  |x|x|x|x|x|x|x|
  |0|0|x|x|x|0|0|
  |0|x|0|x|0|x|0|
  

////////////////*/
static void BoardPrinter(char[,] arr)
{
    int numOfRows = arr.GetLength(0);
    int numOfCollums = arr.GetLength(1);
    for (int j = 0; j < numOfRows; j++)
    {
        Console.WriteLine('\n');
        for (int i = 0; i < numOfCollums; i++)
        {
            if (arr[j, i] == ' ')
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(" |");
                Console.ResetColor();
            }
            else if (arr[j, i] == 'x')
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{arr[j, i]}");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("|");
                Console.ResetColor();
            }
            else if (arr[j, i] == 'o')
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{arr[j, i]}");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("|");
                Console.ResetColor();
            }
        }
    }
    Console.WriteLine();
}
///possiable states | X | * | O |
///bool check prime diag
///bool check secondery diag
///bool check all rows
///bool check all collums

///turn starts with X
///on input check if the collum selected is available

///<remarks>Quick code i wrote to test the board</remarks>
///Todo
///make the code function with player changing and who wins
///refactor the code to be in a class
///move this code into a class and the static void main should just create the class and run
///check if the collum is full and if it is let the player chose a diffrent spot
///check if game is draw by checking the entire board and if its full and no one won in that turn then its
///a draw


//ctor properys
char[,] board = new char[6, 7];
char tokenType;
bool gameOver = false;
bool turn = true;
//when creating class
for (int i = 0; i < board.GetLength(0); i++)
{
    for (int j = 0; j < board.GetLength(1); j++)
    {
        board[i, j] = ' ';
    }
}
//the game loop
while (!gameOver)
{
    //determin the player type
    ConsoleColor color = turn ? ConsoleColor.Red : ConsoleColor.Yellow;
    tokenType = turn ? 'x' : 'o';
    //input with lil vfx
    Console.ForegroundColor = color;
    int x = int.Parse(Console.ReadLine());
    //clear last turn
    Console.ResetColor();
    Console.Clear();
    //check where it lands *Todo add portection for if row is full
    for (int i = 0; i < 6; i++)
    {
        if (board[i, x] != ' ')
        {
            //place token and check if game is over
            board[i - 1, x] = tokenType;
            gameOver = IsConnected.BoardChecker(board, x, i - 1, tokenType);
            break;
        }
        if (i == 5 && board[i,x] == ' ')
        {
            //place token and check if game is over
            board[i, x] = tokenType;
            gameOver = IsConnected.BoardChecker(board, x, i, tokenType);
        }
    }
    //swap player and print the action *Part of Todo prevent this when giving the turn back
    //untill he placed a valid token or its a draw
    turn = !turn;
    BoardPrinter(board);
}