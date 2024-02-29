using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdApplication
{

    class Crow : Bird
    {
        public Crow(Point p)
        {
            name = "Crow";
            pos = p;
            Random rnd = new Random();
            speed = rnd.Next(minSpeed, maxSpeed);
        }

        int dirY = -1;
        int dir = 1;
        public override Point Move()
        {
            if (pos.Y > maxY)
                dirY *= -1;
            if (pos.X >= maxX || pos.X < minX)
                dir *= -1;
            pos.X += dir * speed;
            pos.Y += dirY * speed;
            return pos;
        }
    }
}
