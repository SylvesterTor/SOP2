using System;

public class Connectfour
{
    static public void Main()
    {
        Board game = new Board(7, 7);
        int move;
        while (true)
        {
            game.display_board();
            game.display_board();
            Console.WriteLine("player 1 to move: ");
            move = Convert.ToInt32(Console.ReadLine());
            game.add_move(move, "1");
            if (game.check_game(move, "1"))
            {
                Console.WriteLine("player 1 wins");
                break;
            }
            game.display_board();
            Console.WriteLine("player 2 to move: ");
            move = Convert.ToInt32(Console.ReadLine());
            game.add_move(move, "2");
            if (game.check_game(move, "2"))
            {
                Console.WriteLine("player 2 wins");
                break;
            }
        }
        game.display_board();
        Console.ReadLine();
    }

}