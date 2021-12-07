namespace SnakesAndLadders
{
	public interface IBoard
	{
		int Start { get; }
		int End { get; }
		int Move(int pos);

		int LastResultDie { get; set; }
	}
}