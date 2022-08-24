using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingBall;

namespace BowlingBall.Tests
{
    [TestClass]
    public class GameFixture
    {
        [TestMethod]
        public void Gutter_game_score_should_be_zero_test()
        {
            var game = new Game();
            Roll(game, 0, 20);
            Assert.AreEqual(0, game.GetScore());
        }

        private void Roll(Game game, int pins, int times)
        {
            for (int i = 0; i < times; i++)
            {
                game.Roll(pins);
            }
        }
        [TestMethod]
        public void givenBowlingGame()
        {
            Game g = new Game();
            g.Roll(10);
            g.Roll(9);
            g.Roll(1);
            g.Roll(5);
            g.Roll(5);
            g.Roll(7);
            g.Roll(2);
            g.Roll(10);
            g.Roll(10);
            g.Roll(10);
            g.Roll(9);
            g.Roll(0);
            g.Roll(8);
            g.Roll(2);
            g.Roll(9);
            g.Roll(1);
            g.Roll(10);
            Assert.AreEqual(187, g.GetScore());
        }
        [TestMethod]
        public void AllStrikes()
        {
            Game g = new Game();
            for (int i = 0; i < 12; i++)
            {
                g.Roll(10);
            }
            Assert.AreEqual(300, g.GetScore());
        }
        [TestMethod]
        public void AllOnePin() {
            Game g = new Game();
            for (int i = 0; i < 20; i++) {
                g.Roll(1);
            }
            Assert.AreEqual(20,g.GetScore());
        }
        [TestMethod]
        public void OneSpareScore()
        {
            Game g = new Game();
            g.Roll(5);
            g.Roll(5);
            g.Roll(3);
            for (int i = 0; i < 17; i++)
            {
                g.Roll(0);
            }
            Assert.AreEqual(16, g.GetScore());
        }
        [TestMethod]
        public void OneStrikeScore()
        {
            Game g = new Game();
            g.Roll(10);
            g.Roll(5);
            g.Roll(0);
            g.Roll(6);
            for (int i = 0; i < 15; i++) {
                g.Roll(0);
            }
            Assert.AreEqual(26, g.GetScore());

        }
        [TestMethod]
        public void SpareStrikeScore()
        {
            Game g = new Game();
            g.Roll(5);
            g.Roll(5);
            g.Roll(10);
            for (int i = 0; i < 16; i++)
            {
                g.Roll(1);
            }

            Assert.AreEqual(48, g.GetScore());
        }
        [TestMethod]
        public void RollStrikeFirstFrame() {
            Game g = new Game();
            g.Roll(10);
            for (int i = 0; i < 18; i++) {
                g.Roll(1);
            }
            Assert.AreEqual(30,g.GetScore());
        }
        [TestMethod]
        public void RollSpareFirstFrame()
        {
            Game g = new Game();
            g.Roll(9);
            for (int i = 0; i < 19; i++) {
                g.Roll(1);
            }
            Assert.AreEqual(29, g.GetScore());
        }
        [TestMethod]
        public void RollLastStrikeSpare() {
            Game g = new Game();
            for (int i = 0; i < 18; i++)
            {
                g.Roll(1);
            }
            g.Roll(10);
            g.Roll(5);
            g.Roll(5);
            Assert.AreEqual(38, g.GetScore());
        }
        [TestMethod]
        public void AllSpares()
        {
            Game g = new Game();
            g.Roll(9);
            g.Roll(1);
            g.Roll(8);
            g.Roll(2);
            g.Roll(7);
            g.Roll(3);
            g.Roll(6);
            g.Roll(4);
            g.Roll(5);
            g.Roll(5);
            g.Roll(4);
            g.Roll(6);
            g.Roll(3);
            g.Roll(7);
            g.Roll(2);
            g.Roll(8);
            g.Roll(1);
            g.Roll(9);
            g.Roll(9);
            g.Roll(1);
            g.Roll(9);
            Assert.AreEqual(154, g.GetScore());
        }
    }
}
