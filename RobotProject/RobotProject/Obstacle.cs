using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace RobotProject
{
    public class Obstacle
    {
        
        public float x;
        public float d;
        public float y;

        public void Draw(Graphics g)
        {
            g.DrawEllipse(Pens.Blue, x - d / 2, y - d / 2, d, d);
        }
    }
    
}
