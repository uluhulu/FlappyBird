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
using FlappyBird.src.model.domain;

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

            var tubesArr = controller.tubes.ToArray();
            for (var i = 0; i < tubesArr.Length; i++)
            {
                DoubleTube doubleTube = ((DoubleTube)tubesArr[i]);
                graphics.DrawImage(doubleTube.topTube.tubeIMG, doubleTube.topTube.x, doubleTube.topTube.y, doubleTube.topTube.widht, doubleTube.topTube.height);

                graphics.DrawImage(doubleTube.bottomTube.tubeIMG, doubleTube.bottomTube.x, doubleTube.bottomTube.y, doubleTube.bottomTube.widht, doubleTube.bottomTube.height);
            }
           
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            controller.onKeyDown(e);
        }
    }
}
