
using System;
using System.Diagnostics;
using System.Threading;

class New_ai
{
    Stopwatch stopwatch = new Stopwatch();
    public int make_move(Board game, int x) //controls what move the AI is to make
    {
        int best_move = 0; //best move
        float score; //score of a given move
        float best_score = -100000; //Best score, maximizer optimmaly starts at negtive infinity 
        int rand;
        Random rnd = new Random();

        for (int i = 0; i < game.dimensions[0]; i++) //for all columns in game
        {
            if (game.check_move(i)) //if column is full skip to next one
            {
                continue;
            }
            else
            {
                game.add_move(i, "2"); //ad new potential move
                Boolean isTerminal = 1 == game.check_game_2_0("2"); //Check if is a terminal node in gametree, it is, if it is a winning move
                score = minimax(game, i, x, "1", isTerminal); //score the potential move, using the minimax function
                //Console.Write("move:  " + i);
                //Console.WriteLine("  score: " + score);
                game.remove_move(i, "2"); //remove the move from active play.
                //if score is better than best_score make it the new best score. And define the new best_move
                if (score > best_score)
                {
                    best_move = i;
                    best_score = score;
                }
                else if (score == best_score)
                {
                    //kinda randomize if scores are equal, not truly thoudh. Kinda sucksS
                    rand = rnd.Next(1, 3);
                    if (rand == 1)
                    {
                        best_score = score;
                        best_move = i;
                    }
                }
            }
        }
        return best_move;
    }

    public float minimax(Board game_board, int move, int depth, string player, Boolean isTerminal)
    {
        //If depth has reached zero, or the state of the game is a leave on gametree, then evalute the current game_state
        if (depth == 0 || isTerminal)
        {
            return eval_table(game_board, move, isTerminal) * (depth+1);
        }

        if (player == "1")
        {
            float best_score = 100000f;
            for (int i = 0; i < game_board.dimensions[0]; i++)
            {
                if (game_board.check_move(i))
                {
                    continue;
                }
                game_board.add_move(i, "1");
                isTerminal = 1 == game_board.check_game_2_0("1");
                best_score = Math.Min(minimax(game_board, i, depth - 1, "2", isTerminal), best_score);
                game_board.remove_move(i, "1");
            }
            return best_score;
        }
        else
        {
            float best_score = -100000f;
            for (int i = 0; i < game_board.dimensions[0]; i++)
            {
                float score;
                if (game_board.check_move(i))
                {
                    continue;
                }
                game_board.add_move(i, "2");
                isTerminal = 1 == game_board.check_game_2_0("2");
                score=minimax(game_board, i, depth - 1, "1", isTerminal);
                best_score = Math.Max(score, best_score);
                game_board.remove_move(i, "2");
            }
            return best_score;
        }
    }

    public float eval_table(Board game, int move, Boolean isTerminal)
    {
        float score;
        if (isTerminal)//if it is terminal there is a winner or it is a tie. Find the winner if pos
        {
            if (1 == game.check_game_2_0("2"))
            {
                return 100;
            }
            else
            {
                score = -100;
            }
        }
        else
        { //the heuristics for the game
            score = game.analyze_board();
        }
        return score;
    }
}