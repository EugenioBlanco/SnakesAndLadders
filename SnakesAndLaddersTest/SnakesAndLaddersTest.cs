using NUnit.Framework;
using Moq;
using SnakesAndLadders;

namespace SnakesAndLaddersTest
{
	public class SnakesAndLaddersTest
	{
		public IBoard board;
		public Mock<IDie> dieMock;
		[SetUp]
		public void Setup()
		{
			dieMock = new Mock<IDie>();
			this.board = new BoardSnakesAndLadders(dieMock.Object);
		}

		[Test]
		public void GivenGameStartedThenMove3()
		{
			this.dieMock.Setup(x => x.Roll()).Returns(3);
			var pos= this.board.Move(board.Start);

			Assert.AreEqual(4,pos);
		}

		[Test]
		public void GivenGameStartedThenMove3AndMove5()
		{
			this.dieMock.Setup(x => x.Roll()).Returns(3);
			var pos = this.board.Move(board.Start);
			this.dieMock.Setup(x => x.Roll()).Returns(5);
			pos = this.board.Move(pos);
			Assert.AreEqual(9, pos);
		}

		[Test]
		public void GivenToken97Move3ThenFinishGame()
		{
			this.dieMock.Setup(x => x.Roll()).Returns(3);
			var pos = this.board.Move(97);

			Assert.AreEqual(this.board.End, pos);
		}

		[Test]
		public void GivenToken97Move4ThenNotFinishGame()
		{
			this.dieMock.Setup(x => x.Roll()).Returns(4);
			var pos = this.board.Move(97);

			Assert.AreEqual(97, pos);
		}

		[Test]
		public void GivenLadder28ThenMoveTo84()
		{
			this.dieMock.Setup(x => x.Roll()).Returns(1);
			var pos = this.board.Move(27);

			Assert.AreEqual(84, pos);
		}

		[Test]
		public void GivenSnake62ThenMoveTo19()
		{
			this.dieMock.Setup(x => x.Roll()).Returns(1);
			var pos = this.board.Move(61);

			Assert.AreEqual(19, pos);
		}
	}
}