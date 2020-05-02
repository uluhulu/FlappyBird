using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace FlappyBird
{
    class Bird
    {
        public float x;
        public float y;
        public Image birdIMG;
        public int size;
        public float gravityValue;
        public bool isAlive;
        public int score;

        public Bird(int x, int y)
        {
            birdIMG = new Bitmap("C:\\Users\\ульяна\\Source\\Repos\\FlappyBird\\FlappyBird\\images\\flappybird.jpg");
            this.x = x;
            this.y = y;
            size = 50;
            gravityValue = 0.1f;
            isAlive = true;
            score = 0;
        }
    }
}
