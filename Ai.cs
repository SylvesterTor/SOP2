class Ai
{

    public int make_move(Board board)
    {
        float best_score = -1000f;
        float score;
        int best_move = 0;
        for (int i = 0; i < board.dimensions[0]; i++)
        {
            if (board.dimensions[1] == board.columns[i])
            {
                continue;
            }
            else
            {
                board.add_move(i, "2");
                score = minimax(board, 2, "2",i);
                Console.Write("move:  "+i);
                Console.WriteLine("  score: "+score);
                //board.display_board(); 
                board.remove_move(i, "2");
                if (best_score < score)
                {
                    best_score = score;
                    best_move = i;
                }
            }
        }
    
        return best_move;
    }

    public float minimax(Board board, int depth, string player, int move)
    {
        if(board.check_game(move, "2",false)==1){
            return 100*depth;
        }else if(board.check_game(move, "1",false)==1){
            return -1;
        }
        float score;
        if (depth == 0)
        {
            return eval_board(board, move, player);
        }

        if (player == "2")
        {
            Console.WriteLine("depth:" + depth);
            float best_score = -1000f;
            for (int i = 0; i < board.dimensions[0]; i++)
            {
                if (board.dimensions[1] == board.columns[i])
                {
                    continue;
                }
                else
                {
                    board.add_move(i, "2");
                    score = minimax(board, depth-1, "1",i);
                    //Console.Write("move:  "+i);
                    //Console.WriteLine("  score: "+score);
                    //board.display_board(); 
                    board.remove_move(i, "2");
                    best_score = Math.Max(score, best_score);
                }
            }
            Console.WriteLine(best_score);
            return best_score;
        }
        else
        {
            float best_score = 1000f;
            for (int i = 0; i < board.dimensions[0]; i++)
            {
                if (board.dimensions[1] == board.columns[i])
                {
                    continue;
                }
                else
                {
                    board.add_move(i, "1");
                    score = minimax(board, depth-1, "2",i);
                    board.remove_move(i, "1");
                    //Console.Write("move:  "+i);
                    //Console.WriteLine("score: "+score);
                    best_score = Math.Min(score, best_score);
                }
            }
            return best_score;
        }
    }

    public float eval_board(Board board, int move, string player)
    {
        float score;
        return 6f;
    }
}