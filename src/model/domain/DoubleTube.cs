using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird.src.model.domain
{

   
  public  class DoubleTube
    {

       public Tube topTube, bottomTube;
       public double x, y;

        public DoubleTube(int x, int y) {
            topTube = new Tube(x, y, true);
            bottomTube = new Tube(x, y + 400);
        }

        public void move(int speed) {
            topTube.x += speed;
            bottomTube.x += speed;
        }
    }
}
