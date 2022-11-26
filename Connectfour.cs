using System;

public class Connectfour
{
    static public void Main()
    {
        Board game = new Board(7, 7);
        New_ai ai= new New_ai();
        //Ai ai= new Ai();
        int move;
        while (true)
        {
            game.display_board();
            Console.WriteLine("player 1 to move: ");
            move = Convert.ToInt32(Console.ReadLine());
            game.add_move(move, "1");
            if (game.check_game(move, "1",true)==1)
            {
                Console.WriteLine("player 1 wins");
                break;
            }
            game.display_board();
            Console.WriteLine("AI to move: ");
            move=ai.make_move(game);
            game.add_move(move, "2");
            Console.WriteLine(move);
            if (game.check_game(move, "2",true)==1)
            {
                Console.WriteLine("player 2 wins");
                break;
            }
        }

        Console.ReadLine();
    }

}