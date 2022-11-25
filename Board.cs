class Board
{
    public string[,] game_board;
    public int[] dimensions = new int[2];
    public List<int[]> player_1_moves;
    public List<int[]> player_2_moves;
    public List<int> columns = new List<int>();
    public Board(int x, int y)
    {
        for (int o = 0; o < x; o++)
        {
            columns.Add(0);
        }
        dimensions[0] = x;
        dimensions[1] = y;
        game_board = new string[x, y];
        for (int i = 0; i < x; i++)
        {
            for (int k = 0; k < y; k++)
            {
                game_board[i, k] = "0";
            }
        }
    }

    public Boolean add_move(int move, string player)
    {
        if (dimensions[1] == columns[move])
        {
            Console.WriteLine("no more space in that column");
            return false;
        }
        else
        {
            game_board[columns[move], move] = player;
            columns[move] += 1;
            return true;
        }
    }

    public void display_board()
    {
        string space = " ";
        Console.Write(" " + space);
        for (int i = 0; i < game_board.GetLength(0); i++)
        {
            Console.Write(i + space);
        }
        Console.WriteLine();
        for (int i = game_board.GetLength(0) - 1; i >= 0; i--)
        {
            Console.Write(i + space);
            for (int j = 0; j < game_board.GetLength(0); j++)
            {
                Console.Write(game_board[i, j] + space);
            }
            Console.WriteLine();
        }
    }

    public Boolean check_game(int move, string player)
    {
        int column_height = columns[move];
        int player_int = Int32.Parse(player);
        int count = player_int;
        if (column_height >= 4) //straight down
        {
            count = player_int;
            for (int i = 2; i < 5; i++)
            {
                count += Int32.Parse(game_board[columns[move] - i, move]);
            }
            if (count == player_int * 4){
                Console.WriteLine("winner winner");
            return true;
            }
        }

        if (column_height >= 4 && move>=3) //down and left
        {
            count = player_int;
            for (int i = 1; i < 4; i++)
            {
                if(Int32.Parse(game_board[columns[move] - i-1, move-i])!=0)
                {count += Int32.Parse(game_board[columns[move] - i-1, move-i]);}
            }
            if (count == player_int * 4){
                Console.WriteLine("winner winner");
            return true;}
        }

        if (column_height >= 4 && move<=dimensions[1]-4) //down and right
        {
            count = player_int;
            for (int i = 1; i < 4; i++)
            {
                if (Int32.Parse(game_board[columns[move]-i-1, move+i])!=0)
                {
                count += Int32.Parse(game_board[columns[move]-i-1, move+i]);
                }
            }
            if (count == player_int * 4){
                Console.WriteLine("winner winner");
            return true;}
        }

        if (column_height < dimensions[0]-2 && move<=dimensions[1]-4) //up n right
        {
            count = player_int;
            for (int i = 0; i < 3; i++)
            {
                if (Int32.Parse(game_board[columns[move] + i, move+i+1])!=0)
                {
                 count += Int32.Parse(game_board[columns[move] + i, move+i+1]);   
                }
            }
            if (count == player_int * 4){
                Console.WriteLine("winner winner");
            return true;
            }
        }
        if (column_height < dimensions[0]-2 && move>=3) //up n left
        {
            count = player_int;
            for (int i = 0; i < 3; i++)
            {
                if(Int32.Parse( game_board[columns[move] + i, move-i-1])!=0)
               {count += Int32.Parse( game_board[columns[move] + i, move-i-1]);}
            }
            if (count == player_int * 4){
                Console.WriteLine("winner winner");
            return true;
            }
        }
          
        if (move>=3) //straight left
        {
            count = player_int;
            for (int i = 0; i < 3; i++)
            {
                if(Int32.Parse(game_board[columns[move]-1, move-i-1])!=0)
               {count += Int32.Parse(game_board[columns[move]-1, move-i-1]);}
            }
            if (count == player_int * 4){
                Console.WriteLine("winner winner");
            return true;
            }
        }

        if (move<=dimensions[1]-4) //straight Right
        {
            count = player_int;
            for (int i = 0; i < 3; i++)
            {
               if(Int32.Parse(game_board[columns[move]-1, move+i+1])!=0){
                count += Int32.Parse(game_board[columns[move]-1, move+i+1]);
               }
            }
            if (count == player_int * 4){
                Console.WriteLine("winner winner");
            return true;
            }
        }
        return false;

    }
}