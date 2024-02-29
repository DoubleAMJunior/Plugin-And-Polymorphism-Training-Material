using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace EaglePlugin
{
    public class Eagle : Interfaces.IBird
    {
        protected Point pos;
        protected const int maxX = 400;
        protected const int maxY = 100;
        protected const int minX = 50;
        protected const int minY = 400;
        protected int maxSpeed = 10;
        protected int minSpeed = 1;
        public int speed;

        public Eagle()
        {
            pos = new Point(50, 400);
            Random rnd = new Random();
            speed = rnd.Next(minSpeed, maxSpeed);
        }

        public string getName()
        {
            return "pluginEagle";
        }

        int dirY = -1;
        int dir = 1;
        public Point Move()
        {
            if (pos.Y > maxY)
                pos.Y -= speed;
            if (pos.X >= maxX || pos.X < minX)
                dir *= -1;
            pos.X += dir * speed;
            return pos;
        }
    }
}
