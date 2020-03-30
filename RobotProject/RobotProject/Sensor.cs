using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RobotProject
{
    public class Sensor
    {
        public float x, y, a;
        public float maxDist = 100;
        public float CheckDistance(world w)
        {
            float step = 1;
            float s = (float)Math.Sin(a);
            float c = (float)Math.Cos(a);
            float x_ = x, y_ = y;
            for (float i = 0; i < maxDist; i += step)
            {
                x_ += step * c;
                y_ += step * s;
                if (CheckPoint(x_, y_, w.obstacles))
                {
                    return (float)Math.Sqrt(x_ * x_ + y_ * y_);

                }
            }
            return maxDist;
        }
        public bool CheckPoint(float x, float y, List<Obstacle> obstacles) { 
            for (int i = 0; i<obstacles.Count; i++)
        {
            var o = obstacles[i];
                var dx = o.x - x;
                var dy = o.y - y;
                if (Math.Sqrt(dx * dx + dy + dy) < o.d) return true;
            }
            return false;
    

        }

    }
}
