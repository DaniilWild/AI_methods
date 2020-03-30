using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotProject
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }
        world world;
        //Robot r; //робот
        //Obstacle o1, o2;
        Graphics g;//графический контекст
        private void Form1_Load(object sender, EventArgs e)
        {
            pb.Image = new Bitmap(pb.Width, pb.Height);
            g = Graphics.FromImage(pb.Image);
            //o1 = new Obstacle { x = 50, y = 100, d =40 };
            //o2 = new Obstacle { x = 90, y = 70, d =40 };

            world = new world();
            //r = new Robot();

            timer1.Enabled = true;
        }

        //float x = 50, y = 70;
        float time = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            var dt = timer1.Interval / 1000f;
            g.Clear(Color.Yellow);
            //g.DrawRectangle(Pens.Black, x, y, 100, 150);
            //r.Sim(dt);
            //r.Draw(g);
            //o1.Draw(g);
            //o2.Draw(g);
            
            world.Sim(dt);
            world.Draw(g);
            //пример управления
            pb.Refresh();
            world.r.rot_speed = (float)Math.Sin(5*time);

            //x+=(float)Math.Sin(y/3);
            //y++;

            time += dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
