using System.Collections.Generic;

namespace SnakesAndLadders
{
	public class BoardSnakesAndLadders : IBoard
	{
		private readonly IDie die;

		public BoardSnakesAndLadders(IDie die)
		{
			this.die = die;
			this.InitBoard();
		}
		public int Start => 1;

		public int End => 100;

		public int LastResultDie { get; set; }


		public Dictionary<int, int> Board { get; set; }

		public int Move(int pos)
		{
			this.LastResultDie = die.Roll();
			if (pos + this.LastResultDie <= End)
			{
				pos += this.LastResultDie;
				if (Board.ContainsKey(pos))
				{
					pos = Board[pos];
				}
				
			}

			return pos;
		}

		private void InitBoard()
		{
			this.Board = new Dictionary<int, int>
			{
				{ 2, 38 },
				{ 7, 14 },
				{ 8, 31 },
				{ 15, 26 },
				{ 16, 6 },
				{ 21, 42 },
				{ 28, 84 },
				{ 36, 44 },
				{ 46, 25 },
				{ 49, 11 },
				{ 51, 67 },
				{ 62, 19 },
				{ 64, 60 },
				{ 71, 91 },
				{ 74, 53 },
				{ 78, 98 },
				{ 87, 94 },
				{ 92, 88 },
				{ 95, 75 },
				{ 99, 80 }
			};
		}

	}
}