using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace FlappyBird
{
   public class Tube
    {
        public int x;
        public int y;
        public Image tubeIMG;
        public int widht;
        public int height;

        public Tube(int x, int y, bool isRotated = false)
        {
            tubeIMG = new Bitmap("C:\\Users\\ульяна\\Source\\Repos\\FlappyBird\\FlappyBird\\images\\tube.jpg");
            this.x = x;
            this.y = y;
            widht = 50;
            height = 250;
            if (isRotated)
            {
                tubeIMG.RotateFlip(RotateFlipType.Rotate180FlipX);
            }
        }


    }
}
