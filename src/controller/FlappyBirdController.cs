using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlappyBird.src.model;
using FlappyBird.src.model.domain;

namespace FlappyBird.src.controller
{
    class FlappyBirdController
    {

        public Bird bird;
        public float gravity;
        public ArrayList tubes;
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

            gravity = 0;
            timer.Start();
            birdModel.generateTubes(UpdateTubes);
        }

        public void update()
        {


            if (birdModel.isGameOver(bird, tubes, UpdateScores))
            {
                timer.Stop();
                birdModel.removeAllTubes(UpdateTubes);
               
                Init();
            }
            else {
                birdModel.handleTubes(UpdateTubes, UpdateScores);
 
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

        void UpdateTubes(ArrayList tubes) {
            this.tubes = tubes;
        }

       public void UpdateScores(int scores)
        {
            this.scoreTitle = "Flappy Bird Score : " + scores;
        }
    }
}
