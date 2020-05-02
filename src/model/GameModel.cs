using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird.src.model
{
    public delegate void UpdateGravity(float gravity);
    public delegate void UpdateTubes(Tube tube1, Tube tube2);
    class GameModel
    {

        public bool Collide(Bird bird, Tube tube1)
        {
            var delta = new PointF();
            delta.X = (bird.x + bird.size / 2) - (tube1.x + tube1.widht / 2);
            delta.Y = (bird.y + bird.size / 2) - (tube1.y + tube1.height / 2);
            if (Math.Abs(delta.X) <= bird.size / 2 + tube1.widht / 2)
            {
                if (Math.Abs(delta.Y) <= bird.size / 2 + tube1.height / 2)
                {
                    return true;
                }
            }
            return false;
        }

        public bool isGameOver(Bird bird, Tube tube)
        {
            if (bird.y > 600)
            {
                return true;
            }

            if (Collide(bird, tube))
            {
                return true;
            }

            return false;

        }


        public void jump(Bird bird, UpdateGravity updateGravity)
        {
            if (bird.isAlive)
            {
                updateGravity(0);
                bird.gravityValue = -0.1025f;
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

        public void handleTubes(Tube tube1, Tube tube2, Bird bird, UpdateTubes updateTubes)
        {
            tube1.x -= 1;
            tube2.x -= 1;

            if (tube1.x < bird.x - 300)
            {
                Random random = new Random();
                var y1 = random.Next(-200, 000);
                bird.score++;
                updateTubes(new Tube(500, y1, true), new Tube(500, y1 + 400));
            }

        }
    }
}
