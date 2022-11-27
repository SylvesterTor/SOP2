using System;

public class Connectfour
{
    static public void Main()
    {
        Board game = new Board(7, 7);
        
        New_ai ai = new New_ai();
        //Ai ai= new Ai();
        int move;
        while (true)
        {
                        game.display_board();
            Console.WriteLine("AI to move: ");
            move = ai.make_move(game, 4);

            // AI or human oponent.
            //Console.WriteLine("Player 2 to move: ");
            //move = Convert.ToInt32(Console.ReadLine()); 
            game.add_move(move, "2");
            Console.WriteLine("AI put a piece in column " + move);
            if (game.check_game_2_0("2") == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Player 2 wins");
                Console.ForegroundColor = ConsoleColor.White;
                break;
            }
            
            game.display_board();

            Console.WriteLine("player 1 to move: ");
            move = Convert.ToInt32(Console.ReadLine());
            game.add_move(move, "1");
            if (game.check_game_2_0("1") == 1)
            {
                Console.WriteLine("player 1 wins");
                break;
            }

        }
        game.display_board();
        Console.ReadLine();
    }

}