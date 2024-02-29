using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdApplication
{
    abstract class Bird : Interfaces.IBird
    {
        protected string name;
        public string getName (){  return name;  }
        protected Point pos;
        protected const int maxX=400;
        protected const int maxY=100;
        protected const int minX=50;
        protected const int minY=400;
        protected int maxSpeed=10;
        protected int minSpeed=1;
        public  int speed;
        public abstract Point Move();
        
        
    }
}
