using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FindWinner.Test
{
    [TestClass]
    public class SolutionTests
    {
        private static readonly Solution Sut = new();
        
        [TestMethod]
        public void AWinsFiveMoves()
        {
            var moves = new []
            {
                new[] { 0, 0 },
                new[] { 2, 0 },
                new[] { 1, 1 },
                new[] { 2, 1 },
                new[] { 2, 2 }
            };

            var result = Sut.Tictactoe(moves);

            Assert.AreEqual("A", result);
        }
        
        [TestMethod]
        public void BWinsSixMoves()
        {
            var moves = new []
            {
                new[] { 0, 0 },
                new[] { 1, 1 },
                new[] { 0, 1 },
                new[] { 0, 2 },
                new[] { 1, 0 },
                new[] { 2, 0 }
            };

            var result = Sut.Tictactoe(moves);

            Assert.AreEqual("B", result);
        }
        
        [TestMethod]
        public void Draw()
        {
            var moves = new []
            {
                new[] { 0, 0 },
                new[] { 1, 1 },
                new[] { 2, 0 },
                new[] { 1, 0 },
                new[] { 1, 2 },
                new[] { 2, 1 },
                new[] { 0, 1 },
                new[] { 0, 2 },
                new[] { 2, 2 }
            };

            var result = Sut.Tictactoe(moves);

            Assert.AreEqual("Draw", result);
        }
        
        [TestMethod]
        public void Pending()
        {
            var moves = new []
            {
                new[] { 0, 0 },
                new[] { 1, 1 }
            };

            var result = Sut.Tictactoe(moves);

            Assert.AreEqual("Pending", result);
        }
    }
}