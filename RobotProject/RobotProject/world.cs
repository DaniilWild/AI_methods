using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RobotProject
{
    public class world
    {
        public Robot r;
        
        public List<Obstacle> obstacles = new List<Obstacle>();
        //конструктор
        public world()
        {
            r = new Robot { x = 50, y = 50, w = 100, h = 50 };
            obstacles.Add(new Obstacle{x = 50, y = 50, d = 50});
            obstacles.Add(new Obstacle { x = 100, y = 70, d = 60 });

        }
        public void Sim(float dt)
        {
            r.Sim(dt);

        }

        public void Draw(Graphics g)
        {
            r.Draw(g);
            foreach (var o in obstacles)
                o.Draw(g);

        }
    }
}
