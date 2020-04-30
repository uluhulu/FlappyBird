using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {
        Player bird;
        Tube tube1;
        Tube tube2;
        float gravity;
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 10;
            timer1.Tick += new EventHandler(update);
            
            Initialize();
            Invalidate();
        }

        public void Initialize()
        {
            bird = new Player(150, 200);
            tube1 = new Tube(500, -100,true);
            tube2 = new Tube(500, 300);
            this.Text = "Flappy Bird Score : 0";
            gravity = 0;
            timer1.Start();
        }

       
        public void update (object sender, EventArgs eventArgs)
        {
            if(bird.y > 600)
            {
                bird.isAlive = false;
                timer1.Stop();
                Initialize();
            }

            if (Collide(bird, tube1) || Collide(bird, tube2))
            {
                bird.isAlive = false;
                timer1.Stop();
                Initialize();
            }
                

            if (bird.gravityValue != 0.1f)
                bird.gravityValue += 0.005f;
            gravity+= bird.gravityValue;
            bird.y += gravity;
            if (bird.isAlive)
            {
                MoveTubes();
            }
            
            Invalidate();
        } 

        private void CreateNewTubes()
        {
            if(tube1.x< bird.x-300)
            {
                Random random = new Random();
                int y1 = random.Next(-200,000);
                tube1 = new Tube(500, y1, true);
                tube2 = new Tube(500, y1+400);
                bird.score++;
                this.Text = "Flappy Bird Score : "+bird.score;
            }
        } 
        
        public void MoveTubes()
        {
            tube1.x -= 1;
            tube2.x -= 1    ;
            CreateNewTubes();
        }

        private bool Collide(Player bird, Tube tube1)
        {
            PointF delta = new PointF();
            delta.X = (bird.x + bird.size / 2) - (tube1.x + tube1.widht / 2);
            delta.Y = (bird.y + bird.size / 2) - (tube1.y + tube1.height / 2);
            if (Math.Abs(delta.X)<= bird.size/2 + tube1.widht / 2)
            {
                if (Math.Abs(delta.Y) <= bird.size / 2 + tube1.height / 2)
                {
                    return true;
                }
            }
            return false;
        }
        private void onPaint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            graphics.DrawImage(bird.birdIMG, bird.x, bird.y, bird.size, bird.size);

            //tube1.tubeIMG.RotateFlip(RotateFlipType.Rotate180FlipX);
            graphics.DrawImage(tube1.tubeIMG, tube1.x, tube1.y, tube1.widht, tube1.height);

            //tube1.tubeIMG.RotateFlip(RotateFlipType.Rotate180FlipNone);
            graphics.DrawImage(tube2.tubeIMG, tube2.x, tube2.y, tube2.widht, tube2.height);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                if (bird.isAlive) 
                { 
                gravity = 0;
                bird.gravityValue = -0.1025f;
                }
            }
        }
    }
}
