class New_ai
{
    public int make_move(Board game){
        int best_move=0;
        float score;
        float best_score=-1000;
        for (int i = 0; i < game.dimensions[0]; i++)
        {
            if(game.check_move(i)){
                continue;
            }
            else{
            game.add_move(i,"2");
            Boolean isTerminal = 1==game.check_game(i,"2", false);
            score = minimax(game, i, 1, "1",isTerminal);
            game.remove_move(i,"2");
            if(score>best_score){
                best_move=i;
                best_score=score;
            }}
        }
        return best_move;
    }

    public float minimax(Board game_board, int move, int depth, string player, Boolean isTerminal){
        if(depth==0 || isTerminal){
            return eval_table(game_board, move, isTerminal);
        }

        if(player =="1"){
            float best_score=10000f;
            for (int i = 0; i < game_board.dimensions[0]; i++)
            {
                if(game_board.check_move(i)){
                    continue;
                }
                game_board.add_move(i,"1");
                isTerminal = 1==game_board.check_game(i,"1", false);
                best_score= Math.Min(minimax(game_board,i,depth-1,"2",isTerminal),best_score);
                game_board.remove_move(i,"1");
            }
            return best_score;
        }else{
            float best_score=-10000f;
            for (int i = 0; i < game_board.dimensions[0]; i++)
            {
                  if(game_board.check_move(i)){
                    continue;
                }
                game_board.add_move(i,"2");
                isTerminal = 1==game_board.check_game(i,"2", false);
                best_score= Math.Max(minimax(game_board,i,depth-1,"1",isTerminal),best_score);
                game_board.remove_move(i,"2");
            }
            return best_score;
        }
    }

    public float eval_table(Board game, int move, Boolean isTerminal){
        float score;
        if(isTerminal){
            if(1==game.check_game(move,"2",false)){
                return 100;
            }else{
                score= -100;
            }
        }else{
            score=0;
        }
        return score;
    }
}