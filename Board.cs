class Board
{
    public string[,] game_board;
    public int[] dimensions = new int[2];

    public List<int> columns = new List<int>();

    public Board(int x, int y) //create board
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
                game_board[i, k] = " ";
            }
        }
    }

    /*
    public Board(int x, int y) //create board
    {
        for (int o = 0; o < x; o++)
        {
            columns.Add(0);
        }
        columns[0] = 1;
        columns[1] = 1;
        columns[2] = 1;
        dimensions[0] = x;
        dimensions[1] = y;
        game_board = new string[x, y];
        for (int i = 0; i < x; i++)
        {
            for (int k = 0; k < y; k++)
            {
                game_board[i, k] = " ";
            }
        }
        game_board[0, 0] = "2";
        game_board[0, 1] = "2";
        game_board[0, 2] = "2";
    }*/

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

    public Boolean check_move(int move)
    {
        return dimensions[1] == columns[move];
    }

    public Boolean remove_move(int move, string player)
    {
        if (0 == columns[move])//if column is empty
        {
            return false;
        }
        else
        {
            columns[move] -= 1;
            game_board[columns[move], move] = " ";
            return true;
        }
    }


    public void display_board()
    {
        string space = "|";
        string UNDERLINE = "\x1B[4m";
        string RESET = "\x1B[0m";
        Console.Write(" " + space);
        for (int i = 0; i < game_board.GetLength(0); i++)
        {
            Console.Write(i + space);
        }
        Console.WriteLine();
        for (int i = dimensions[1] - 1; i >= 0; i--) //reverse the columns to simulate a real game of connect four. Otherwise it would be from the top to bottom
        {
            Console.Write(UNDERLINE + i + space + RESET);
            for (int j = 0; j < dimensions[0]; j++)
            {

                if (game_board[i, j] == "1")
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                else if (game_board[i, j] == "2")
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.Write(UNDERLINE + " ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(space + RESET);
            }
            Console.WriteLine();
        }
    }

    public int check_game_2_0(string player)
    {

        // check horizontal
        for (int i = 0; i < dimensions[1]; i++)
        {
            for (int k = 0; k < dimensions[0] - 3; k++)
            {
                if (
                game_board[i, k] == game_board[i, k + 1] &&
                game_board[i, k] == game_board[i, k + 2] &&
                game_board[i, k] == game_board[i, k + 3]
                )
                {
                    if (game_board[i, k] == player)
                    {
                        return 1;
                    }
                }
            }
        }
        // check diagonal right up
        for (int i = 0; i < dimensions[1] - 3; i++)
        {
            for (int k = 0; k < dimensions[0] - 3; k++)
            {
                if (
                game_board[i, k] == game_board[i + 1, k + 1] &&
                game_board[i, k] == game_board[i + 2, k + 2] &&
                game_board[i, k] == game_board[i + 3, k + 3]
                )
                {
                    if (game_board[i, k] == player)
                    {
                        return 1;
                    }
                }
            }
        }
        // check diagonal right down
        for (int i = dimensions[1] - 1; i > 2; i--)
        {
            for (int k = 0; k < dimensions[0] - 3; k++)
            {
                if (
                game_board[i, k] == game_board[i - 1, k + 1] &&
                game_board[i, k] == game_board[i - 2, k + 2] &&
                game_board[i, k] == game_board[i - 3, k + 3]
                )
                {
                    if (game_board[i, k] == player)
                    {
                        return 1;
                    }
                }
            }
        }
        // check vertical
        for (int i = 0; i < dimensions[1] - 3; i++)
        {
            for (int k = 0; k < dimensions[0]; k++)
            {
                if (
                game_board[i, k] == game_board[i + 1, k] &&
                game_board[i, k] == game_board[i + 2, k] &&
                game_board[i, k] == game_board[i + 3, k]
                )
                {
                    if (game_board[i, k] == player)
                    {
                        return 1;
                    }
                }
            }
        }
        return 0;
    }
    public void display_board_2(string[,] board)//used to display copies of a game_board
    {
        string space = " ";
        Console.Write(" " + space);
        for (int i = 0; i < board.GetLength(0); i++)
        {
            Console.Write(i + space);
        }
        Console.WriteLine();
        for (int i = board.GetLength(0) - 1; i >= 0; i--) //reverse the columns to simulate real game of connect four
        {
            Console.Write(i + space);
            for (int j = 0; j < board.GetLength(0); j++)
            {
                Console.Write(board[i, j] + space);
            }
            Console.WriteLine();
        }
    }


    //used to analyze 
    public float analyze_board()
    {
        float score = 0f; //running score
        string[] pieces = new string[4]; //creates an array for storing windows of four items. Used to store 4 game_pieces in a row
        
        //check horizontally
        for (int i = 0; i < dimensions[1]; i++) 
        {
            for (int k = 0; k < dimensions[0] - 3; k++)
            {
                //add the four consecetive game_spots to the array
                //Makes it possible to analyze the four spots
                pieces[0] = game_board[i, k];
                pieces[1] = game_board[i, k + 1];
                pieces[2] = game_board[i, k + 2];
                pieces[3] = game_board[i, k + 3];
                //score a given window of four game spots
                score += score_window(pieces);
            }
        }
        // check diagonal right up
        for (int i = 0; i < dimensions[1] - 3; i++)
        {
            for (int k = 0; k < dimensions[0] - 3; k++)
            {
                pieces[0] = game_board[i, k];
                pieces[1] = game_board[i + 1, k + 1];
                pieces[2] = game_board[i + 2, k + 2];
                pieces[3] = game_board[i + 3, k + 3];
                score += score_window(pieces);
            }
        }
        // check diagonal right down
        for (int i = dimensions[1] - 1; i > 2; i--)
        {
            for (int k = 0; k < dimensions[0] - 3; k++)
            {
                pieces[0] = game_board[i, k];
                pieces[1] = game_board[i - 1, k + 1];
                pieces[2] = game_board[i - 2, k + 2];
                pieces[3] = game_board[i - 3, k + 3];
                score += score_window(pieces);
            }
        }
        // check vertical
        for (int i = 0; i < dimensions[1] - 3; i++)
        {
            for (int k = 0; k < dimensions[0]; k++)
            {
                pieces[0] = game_board[i, k];
                pieces[1] = game_board[i + 1, k];
                pieces[2] = game_board[i + 2, k];
                pieces[3] = game_board[i + 3, k];
                score += score_window(pieces);
            }
        }
        return score;
    }

    public float score_window(string[] window)
    {
        string[] pieces = window;
        int player_2;
        int player_1;
        int neutral_pieces;
        float score = 0;
        player_2 = pieces.Count(s => s == "2"); //count player 2 pieces in window
        player_1 = pieces.Count(s => s == "1"); //count player 1 pieces in window
        neutral_pieces = pieces.Count(s => s == " "); //count neutral pieces in window

        if (player_2 == 3 && player_1 == 0) //if there are 3 player 2 pieces and none player 1 pices add 9 to score
        {
            score += 9;
        }
        else if (player_2 == 2 && player_1 == 0) //if there are 2 player 2 pieces and none player 1 pices add 3 to score
        {
            score += 3;
        }
        else if (player_2 == 1 && player_1 == 0)//if there are 1 player 2 pieces and none player 1 pices add 1 to score
        {
            score += 1;
        }
        if (player_1 == 3 && player_2 == 0)
        {
            score -= 9;
        }
        else if (player_1 == 2 && player_2 == 0)
        {
            score -= 3;
        }
        else if (player_1 == 1 && player_2 == 0)
        {
            score -= 1;
        }
        return score;
    }
}