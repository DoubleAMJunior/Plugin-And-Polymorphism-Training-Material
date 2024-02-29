using System;
using System.Drawing;
namespace ChickenPlugin
{
    public class Chicken : Interfaces.IBird
    {
        protected Point pos;
        protected const int maxX = 400;
        protected const int maxY = 100;
        protected const int minX = 50;
        protected const int minY = 400;
        protected int maxSpeed = 10;
        protected int minSpeed = 1;
        public int speed;

        public Chicken()
        {
            pos = new Point(50, 400);
            Random rnd = new Random();
            speed = rnd.Next(minSpeed, maxSpeed);
        }

        public string getName()
        {
            return "pluginChicken";
        }

        int dirY = -1;
        int dir = 1;
        public Point Move()
        {
            if (pos.X >= maxX || pos.X < minX)
                dir *= -1;
            pos.X += dir * speed;
            return pos;
        }
    }
}
