using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace FlappyBird
{
    class Tube
    {
        public int x;
        public int y;
        public Image tubeIMG;
        public int widht;
        public int height;

        public Tube(int x, int y, bool isRotated = false)
        {
            tubeIMG = new Bitmap("C:\\Users\\ульяна\\Source\\Repos\\FlappyBird\\FlappyBird\\images\\tube.png");
            this.x = x;
            this.y = y;
            widht = 90;
            height = 250;
            if (isRotated)
            {
                tubeIMG.RotateFlip(RotateFlipType.Rotate180FlipX);
            }
        }
    }
}
