using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdApplication
{
    class Chicken : Bird
    {
        public Chicken(Point p)
        {
            name = "Chicken";
            pos = p;
            Random rnd = new Random();
            speed = rnd.Next(minSpeed, maxSpeed);
        }
        int dir = 1;
        public override Point Move()
        {
            if (pos.X >= maxX || pos.X < minX)
                dir *= -1;
            pos.X += dir * speed;
            return pos;
        }
    }
}
