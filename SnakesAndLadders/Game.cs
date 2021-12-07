using System;
using System.Collections.Generic;

namespace SnakesAndLadders
{
	public class Game : IGame
	{
		private Dictionary<int, int> players;
		private readonly IBoard board;

		public void AddPlayers(int numGames)
		{
			for (var idPlayer = 1; idPlayer <= numGames; idPlayer++)
			{
				players.Add(idPlayer, 1);
			}
		}

		public Game(IBoard board)
		{
			this.players= new Dictionary<int, int>();
			this.board = board;
		}

		public void Start()
		{
			var point = board.Start;
			Console.WriteLine($"Start playing");
			while (point != board.End)
			{
				foreach (var game in players.Keys)
				{
					Console.WriteLine($"Press a key to roll the die the player: {game}");
					Console.ReadKey();
					
					point = board.Move(players[game]);
					Console.WriteLine($"You have: {board.LastResultDie}");
					if(point == board.End)
					{
						Console.WriteLine($"The player {game} won!!!");
						break;
					} 
					
					Console.WriteLine($"Box: {point}");
					

					players[game] = point;
				}
			}
		}
	}
}