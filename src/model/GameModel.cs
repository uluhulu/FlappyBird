using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using FlappyBird.src.model.domain;

namespace FlappyBird.src.model
{
    public delegate void UpdateGravity(float gravity);
    public delegate void UpdateTubes(ArrayList tubes);
    public delegate void UpdateScores(int score);

    class GameModel
    {

        ArrayList tubes = new ArrayList();

        public int score = 0;

        public bool Collide(Bird bird, Tube tube1)
        {
            var delta = new PointF();
            delta.X = (bird.x + bird.size / 2) - (tube1.x + tube1.widht / 2);
            delta.Y = (bird.y + bird.size / 2) - (tube1.y + tube1.height / 2);
            if (Math.Abs(delta.X) <= bird.size / 2 + tube1.widht / 2 - 10)
            {
                if (Math.Abs(delta.Y) <= bird.size / 2 + tube1.height / 2 - 10 )
                {
                    return true;
                }
            }
            return false;
        }

        public bool isGameOver(Bird bird, ArrayList tubes, UpdateScores updateScores)
        {

            var tubesArr = tubes.ToArray();
            for (var i = 0; i < tubesArr.Length; i++)
            {
                DoubleTube doubleTube = ((DoubleTube)tubesArr[i]);
                
                if (bird.y > 600)
                {
                    score = 0;
                    updateScores(0);
                    return true;
                }

                if (Collide(bird, doubleTube.topTube) || Collide(bird, doubleTube.bottomTube))
                {
                    score = 0;
                    updateScores(0);
                    return true;
                }

            }
  
            return false;

        }


        public void jump(Bird bird, UpdateGravity updateGravity)
        {
            if (bird.isAlive)
            {
                updateGravity(0);
                bird.gravityValue = -0.125f;
            }
        }

        public void move(Bird bird, float gravity, UpdateGravity updateGravity)
        {
            if (bird.gravityValue != 0.1f)
                bird.gravityValue += 0.005f;

            gravity += bird.gravityValue;
            bird.y += gravity;
            updateGravity(gravity);
        }

        public void handleTubes( UpdateTubes updateTubes, UpdateScores updateScores)
        {
            var tubesArr = tubes.ToArray();
            for (var i = 0; i < tubesArr.Length; i++)
            {
                DoubleTube doubleTube = ((DoubleTube)tubesArr[i]);
                doubleTube.move(-1);
                if (tubes.Count <= 1) {
                    if (doubleTube.topTube.x <= 10)
                    {
                        generateTubes(updateTubes);
                        updateScores(score++);
                    }
                }
        
                removeTubes(doubleTube, updateTubes);
            }
  

        }

        public void generateTubes(UpdateTubes updateTubes) {
                Random random = new Random();
                var x = 650;
                var y = random.Next(-200, 000);
              
                DoubleTube doubleTube = new DoubleTube(x, y);
                tubes.Add(doubleTube);
                updateTubes(tubes);
            }
 

        private void removeTubes(DoubleTube tube, UpdateTubes updateTubes)
        {
            if (tube.topTube.x <= -100)
            {
                tubes.Remove(tube);
                updateTubes(tubes);
            }
        }

        public void removeAllTubes(UpdateTubes update) {
            tubes.Clear();
            update(tubes);
        }
    }
}
