using System;
using System.Collections.Generic;

namespace SnakesAndLadders
{
	class Program
	{

		static void Main(string[] args)
		{
			IDie die = new Die();
			IBoard board = new BoardSnakesAndLadders(die);
			
			var games = new Dictionary<int, int>();

			var point = board.Start;
			Console.WriteLine($"Numbers of games?");
			var key = Console.ReadKey();

			if (!char.IsDigit(key.KeyChar) || !int.TryParse(key.KeyChar.ToString(), out var numGames))
			{
				numGames = 1;
			}

			for (var game = 1; game <= numGames; game++)
			{
				games.Add(game, 1);
			}

			Console.WriteLine("");
			Console.WriteLine($"Start game");

			while (point != board.End)
			{
				foreach (var game in games.Keys)
				{
					Console.WriteLine($"Press a key to roll the die the player: {game}");
					Console.ReadKey();

					
					point = board.Move(games[game]);
					Console.WriteLine($"You have: {board.LastResultDie}");
					Console.WriteLine(point == board.End ? $"The player {game} won!!!" : $"Box :{point}");

					games[game] = point;
				}
			}
		}
	}
}
