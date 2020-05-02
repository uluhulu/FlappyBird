using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlappyBird.src.model;
using NUnit.Framework;

namespace FlappyBird.test
{
    [TestFixture]
    class GameModelTest

    {
        private GameModel gameModel;


        [SetUp]
        public void SetUp() {
            gameModel = new GameModel();
    
        }

        [Order(0)]
        [TestCase(0, 0, 0, 0, true)]
        [TestCase(0, 0, 50, 50, true)]
        [TestCase(0, 0, 100, 50, false)]
        public void TestCollide(int birdX, int birdY, int tubeX, int tubeY, bool isExpectedCollide) {
            Bird bird = new Bird(birdX, birdY);
            Tube tube = new Tube(tubeX, tubeY);
            bool isActualCollide = gameModel.Collide(bird, tube);
           
            Assert.AreEqual(isExpectedCollide, isActualCollide);

        }

        [Order(1)]
        [TestCase(0, 601, 0, 0, true)]
        [TestCase(0, 600, 0, 0, false)]
        [TestCase(0,0, 0, 0, true)]
        [TestCase(0, 0, 50, 50, true)]
        [TestCase(0, 0, 100, 50, false)]
        public void TestGameOver(int birdX, int birdY, int tubeX, int tubeY, bool isExpectedGameOver) {
            Bird bird = new Bird(birdX, birdY);
            Tube tube = new Tube(tubeX, tubeY);
            bool isActualGameOver = gameModel.isGameOver(bird, tube);
          
            Assert.AreEqual(isExpectedGameOver, isActualGameOver);
        }

        [Order(2)]
        [TestCase(0, -0.1025f, true, true)]
        [TestCase(1, -0.1025f, false, true)]
        [TestCase(0, 0, true, false)]
        [TestCase(1, 0, false, false)]
        public void TestJump(
            float gravity,
            float birdGravityValue,
            bool isExpectedGravity,
            bool isExceptedBirdGravityValue
            )
        {
            Bird bird = new Bird(0, 0);

            gameModel.jump(bird, UpdateGravity);

            void UpdateGravity(float _gravity)
            {
                Assert.AreEqual(isExpectedGravity, gravity == 0);
                Assert.AreEqual(isExceptedBirdGravityValue, birdGravityValue == -0.1025f);
            }
        }

        [Order(3)]
        [TestCase(0, 0, true, true)]
        [TestCase(10, 0, true, false)]
        public void TestMove(
            float birdY, 
            float gravityValue,
            bool isExpectedGravity,
            bool isExceptedBirdY)
        {
            Bird bird = new Bird(0, 0);
            bird.gravityValue = 0.2f;
            gameModel.move(bird, gravityValue, UpdateGravity);

            void UpdateGravity(float gravity)
            {
                Assert.AreEqual(isExpectedGravity, gravity > gravityValue);
                Assert.AreEqual(isExceptedBirdY, bird.y > birdY);
            }
        }

        [Order(4)]
        [TestCase(0, 0, 0, true, true, true)]
        public void TestTubeMove(
            int tube1x,
            int tube2x,
            int scores,
            bool firstTubeIsMove,
            bool secondTubeIsMove,
            bool scoresIsAdded) {
            Tube tube1 = new Tube(tube1x, 0);
            Tube tube2 = new Tube(tube2x, 0);

            Bird bird = new Bird(0 , 0);
            bird.score = scores;

            gameModel.handleTubes(tube1, tube2, bird, UpdateTubes);

            void UpdateTubes(Tube _tube1, Tube _tube2) {
                Assert.AreEqual(firstTubeIsMove, _tube1.x < tube1.x);
                Assert.AreEqual(secondTubeIsMove, _tube2.x < tube2.x);
                Assert.AreEqual(scoresIsAdded, bird.score  >scores);
            }
        }
      
    }
}
