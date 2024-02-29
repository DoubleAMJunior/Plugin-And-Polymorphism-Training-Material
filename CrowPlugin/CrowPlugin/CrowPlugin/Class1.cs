using System;
using System.Drawing;

namespace CrowPlugin
{
    public class Crow : Interfaces.IBird
    {
        protected Point pos;
        protected const int maxX = 400;
        protected const int maxY = 100;
        protected const int minX = 50;
        protected const int minY = 400;
        protected int maxSpeed = 10;
        protected int minSpeed = 1;
        public int speed;

        public Crow()
        {
            pos = new Point(50, 400);
            Random rnd = new Random();
            speed = rnd.Next(minSpeed, maxSpeed);
        }

        public string getName()
        {
            return "pluginCrow";
        }

        int dirY = -1;
        int dir = 1;
        public Point Move()
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
