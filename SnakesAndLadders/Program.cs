using System;

namespace SnakesAndLadders
{
	class Program
	{

		static void Main(string[] args)
		{
			IDie die = new Die();
			IBoard board = new BoardSnakesAndLadders(die);
			IGame game = new Game(board);
			Console.WriteLine($"Numbers of players?");
			var key = Console.ReadKey();

			if (!char.IsDigit(key.KeyChar) || !int.TryParse(key.KeyChar.ToString(), out var numPlayers))
			{
				numPlayers = 1;
			}
			
			game.AddPlayers(numPlayers);
			Console.WriteLine("");
			
			game.Start();
		}
	}
}
