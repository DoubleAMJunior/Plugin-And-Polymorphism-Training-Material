using System;
using System.Drawing;

namespace plugin
{
    public class Class1 : BirdTest.IBird
    {
        protected Point pos;
        protected const int maxX = 400;
        protected const int maxY = 100;
        protected const int minX = 50;
        protected const int minY = 400;
        protected int maxSpeed = 10;
        protected int minSpeed = 1;
        public int speed;

        public string getName()
        {
            return "pluginBird";
        }

        int dirY = -1;
        int dir = 1;
        public  Point Move()
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
