using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotProject
{
    public class Robot
    {
        public float x, y; //координаты робота
        public float w, h; //размеры робота
        public float a; //угол в радианах
        public List <Sensor> sensors = new List<Sensor>();
        public float speed, rot_speed; //скорость движения и поворота робота

        //конструктор
        public Robot()
        {
            x = 50; y = 70;
            w = 100; h = 70;
            a = 1;
            speed = 50;//пикс в секунду
            rot_speed = 1;//радиан в секунду
            for (int i = -5; i<=5;i++)
            {
                sensors.Add(new Sensor { a = i * 0.1f });
            }
        }

        public void Draw(Graphics g) //отрисовка
        {
            var t = g.Transform;
            g.TranslateTransform(x, y);
            g.RotateTransform(a*180/(float)Math.PI);
            g.DrawRectangle(Pens.Black, -w/2, -h/2, w, h);
            foreach(var s in sensors)
            {
                g.DrawLine(Pens.Violet, s.x, s.y, s.x + s.maxDist * (float)Math.Cos(s.a), s.y + s.maxDist * (float)Math.Sin(s.a));
            }
            g.Transform = t;
        }

        public void Sim(float dt) //симуляция
        {
            float s = (float)Math.Sin(a);
            float c = (float)Math.Cos(a);

            x += speed * c * dt;
            y += speed * s * dt;
            a += rot_speed * dt;
        }
    }
}
