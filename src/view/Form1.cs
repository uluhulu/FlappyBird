using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlappyBird.src.controller;

namespace FlappyBird
{
    public partial class Form1 : Form
    {

        FlappyBirdController controller;

        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 10;
            timer1.Tick += new EventHandler(update);
            controller = new FlappyBirdController(timer1);
            Invalidate();
        }
       
        public void update (object sender, EventArgs eventArgs)
        {
            controller.update();
            this.Text = controller.scoreTitle;
            Invalidate();
        } 

        private void onPaint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            graphics.DrawImage(controller.bird.birdIMG, controller.bird.x, controller.bird.y, controller.bird.size, controller.bird.size);

            //tube1.tubeIMG.RotateFlip(RotateFlipType.Rotate180FlipX);
            graphics.DrawImage(controller.tube1.tubeIMG, controller.tube1.x, controller.tube1.y, controller. tube1.widht, controller.tube1.height);

            //tube1.tubeIMG.RotateFlip(RotateFlipType.Rotate180FlipNone);
            graphics.DrawImage(controller.tube2.tubeIMG, controller.tube2.x, controller.tube2.y, controller.tube2.widht, controller.tube2.height);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            controller.onKeyDown(e);
        }
    }
}
