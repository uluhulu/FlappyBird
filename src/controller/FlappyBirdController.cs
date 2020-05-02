using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlappyBird.src.model;

namespace FlappyBird.src.controller
{
    class FlappyBirdController
    {

        public Bird bird;
        public Tube tube1;
        public Tube tube2;
        public float gravity;

        public String scoreTitle = "Flappy Bird Score : ";

        private GameModel birdModel = new GameModel();
       

        private Timer timer;


        public FlappyBirdController(Timer timer) {
            this.timer = timer;
            Init();
        }

        public void Init()
        {
            bird = new Bird(150, 200);
            tube1 = new Tube(500, -100, true);
            tube2 = new Tube(500, 300);
         
            gravity = 0;
            timer.Start();
        }

        public void update()
        {

            if (birdModel.isGameOver(bird, tube1) || birdModel.isGameOver(bird, tube2))
            {
                timer.Stop();
                Init();
            }
            else {
                birdModel.handleTubes(tube1, tube2, bird,UpdateTubes);
                this.scoreTitle = "scores" + bird.score;
            }

            birdModel.move(bird, gravity, UpdateGravity);
        }

        public void onKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                birdModel.jump(bird, UpdateGravity);
            }
        }

        void UpdateGravity(float gravity){
            this.gravity = gravity;
        }

        void UpdateTubes(Tube tube1, Tube tube2) {
            this.tube1 = tube1;
            this.tube2 = tube2;
        }
    }
}
