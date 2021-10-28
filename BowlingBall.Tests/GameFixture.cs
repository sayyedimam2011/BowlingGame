using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBall.Tests
{
    [TestClass]
    public class GameFixture
    {
        private IGame game;

        public GameFixture()
        {
            game = new Game();
        }

        [TestMethod]
        public void Gutter_game_score_should_be_zero_test()
        {
            Roll(0, 20);
            Assert.AreEqual(0, game.GetScore());
        }

        [TestMethod]
        public void TestAllOnes()
        {
            RollMany(20, 1);
            Assert.AreEqual(20, game.GetScore());
        }

        [TestMethod]
        public void TestOneSpare()
        {
            game.Roll(6);
            game.Roll(4);
            game.Roll(4);
            RollMany(17, 0);
            Assert.AreEqual(18, game.GetScore());
        }

        [TestMethod]
        public void TestOneStrike()
        {
            game.Roll(10);
            game.Roll(4);
            game.Roll(5);
            RollMany(17, 0);
            Assert.AreEqual(28, game.GetScore());
        }

        [TestMethod]
        public void TestRandomGameNoExtraRoll()
        {
            game.Roll(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 0 });
            Assert.AreEqual(131, game.GetScore());
        }

        [TestMethod]
        public void TestRandomGameFromExample()
        {
            game.Roll(new int[] { 10, 9, 1, 5, 5, 7, 2, 10, 10, 10, 9, 0, 8, 2, 9, 1, 10 });
            Assert.AreEqual(187, game.GetScore());
        }

        private void Roll(int pins, int times)
        {
            for (int i = 0; i < times; i++)
            {
                game.Roll(pins);
            }
        }

        private void RollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                game.Roll(pins);
            }
        }
    }
}
