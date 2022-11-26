class Board
{
    public string[,] game_board;
    public int[] dimensions = new int[2];
    public List<int[]> player_1_moves;
    public List<int[]> player_2_moves;
    public List<int> columns = new List<int>();
    /*public Board(int x, int y) //create board
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
    }*/
    public Board(int x, int y) //create board
    {
        for (int o = 0; o < x; o++)
        {
            columns.Add(0);
        }
        columns[0]=1;
        columns[1]=1;
        columns[2]=1;
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
        game_board[0,0]="2";
        game_board[0,1]="2";
        game_board[0,2]="2";
    }

    public Boolean add_move(int move, string player) 
    {
        if (check_move(move)) //if the move is in a column that is full
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

    public Boolean check_move(int move){
        return dimensions[1] == columns[move];
    }

    public Boolean remove_move(int move, string player) 
    {
        if (0== columns[move]) //if the move is in a column that is full
        {
            Console.WriteLine("no more space in that column");
            return false;
        }
        else
        {
            columns[move] -= 1;
            game_board[columns[move], move] = "0";
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
        for (int i = game_board.GetLength(0) - 1; i >= 0; i--) //reverse the columns to simulate real game of connect four
        {
            Console.Write(i + space);
            for (int j = 0; j < game_board.GetLength(0); j++)
            {
                Console.Write(game_board[i, j] + space);
            }
            Console.WriteLine();
        }
    }

    public int check_game(int move, string player, Boolean thing)
    {
        int column_height = columns[move];
        int player_int = Int32.Parse(player);
        Boolean count =true;
        if (column_height >= 4) //straight down
        {
            count =true;
            for (int i = 2; i < 5; i++)
            {
                if(game_board[columns[move]-i,move]!=player){
                    count =false;
                }
            }
            if (count){
                if(thing){
                Console.WriteLine("winner 1");
                }
                return 1;
            }
        }

        if (column_height >= 4 && move>=3) //down and left
        {
             count =true;
            for (int i = 1; i < 4; i++)
            {
                if(game_board[columns[move]-i-1, move-i]!=player)
                {count =false;}
            }
            if (count){
                if(thing){
                Console.WriteLine("winner 2");
                }
            return 1;}
        }

        if (column_height >= 4 && move<=dimensions[1]-4) //down and right
        {
            for (int i = 1; i < 4; i++)
            {
                if (game_board[columns[move]-i-1, move+i]!=player)
                {
                count = false;
                }
            }
            if (count){
                if(thing){
                Console.WriteLine("winner 3");
                }
            return 1;}
        }

        if (column_height < dimensions[0]-2 && move<=dimensions[1]-4) //up n right
        {
             count=true;
            for (int i = 0; i < 3; i++)
            {
                if (game_board[columns[move] + i, move+i+1]!=player)
                {
                 count =false;   
                }
            }
            if (count){
                if(thing){
                Console.WriteLine("winner 4");
                }
            return 1;
            }
        }
        if (column_height < dimensions[0]-2 && move>=3) //up n left
        {
            count = true;
            for (int i = 0; i < 3; i++)
            {
                if(game_board[columns[move] + i, move-i-1]!=player)
               {count =false;}
            }
            if (count){
                if(thing){
                Console.WriteLine("winner 5");
                }
                return 1;
            }
        }
          
        if (move>=3) //straight left
        {
            count = true;
            for (int i = 0; i < 3; i++)
            {

                if(game_board[columns[move]-1, move-i-1]!=player)
               {count =false;}
            }
            if (count){
                if(thing){
                Console.WriteLine("winner 6");
                }
            return 1;
            }
        }

        if (move<=dimensions[1]-4) //straight Right
        {
            count = true;
            for (int i = 0; i < 3; i++)
            {
               if(game_board[columns[move]-1, move+i+1]!=player){
                count =false;
               }
            }
            if (count){
                if(thing){
                Console.WriteLine("winner 7");
                }
            return 1;
            }
        }
        return -1;

    }
}