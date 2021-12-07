using System;

namespace SnakesAndLadders
{
	public class Die : IDie
	{
		private Random die = new Random();
		public int Roll()
		{
			return die.Next(1, 7);
		}
	}
}