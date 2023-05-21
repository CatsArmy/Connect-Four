/*////////////////

  |x|0|0|x|0|0|x|
  |0|x|0|x|0|x|0|
  |0|0|x|x|x|0|0|
  |x|x|x|x|x|x|x|
  |0|0|x|x|x|0|0|
  |0|x|0|x|0|x|0|
  

////////////////*/
static string Printer(char[,] arr)
{
    int numOfRows = arr.GetLength(0);
    int numOfCollums = arr.GetLength(1);
    string result = " ";
    string nextRow = "\n";
    for (int j = 0; j < numOfRows; j++)
    {
        result += nextRow + nextRow;
        for (int i = 0; i < numOfCollums; i++)
        {
            if (arr[j, i] > 99)
                result += $" {arr[j, i]}|";
            else if (arr[j, i] > 9)
                result += $"  {arr[j, i]}|";
            else
                result += $"   {arr[j, i]}|";
        }
    }
    return result;
}
///possiable states | X | * | O |
///bool check prime diag
///bool check secondery diag
///bool check all rows
///bool check all collums

///turn starts with X
///on input check if the collum selected is available

char[,] board = new char[6, 7];
bool gameOver = false;
bool turn = false;
for (int i = 0; i < board.GetLength(0); i++)
{
    for (int j = 0; j < board.GetLength(1); j++)
    {
        board[i, j] = ' ';
    }
}
int x = int.Parse(Console.ReadLine());
board[5, x] = 'x';
Console.WriteLine(Printer(board));
while (!gameOver)
{
    x = int.Parse(Console.ReadLine());
    Console.Clear();
    for (int i = 0; i < 6; i++)
    {
        if (board[i, x] != ' ')
        {
            board[i - 1, x] = turn ? 'x' : 'o';
            break;
        }
        else if (i == 5)
        {
            board[i, x] = turn ? 'x' : 'o';
        }
    }
    turn = turn ? false : true;
    Console.WriteLine(Printer(board));
}