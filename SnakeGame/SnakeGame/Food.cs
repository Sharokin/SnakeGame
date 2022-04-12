using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SnakeGame
{
    abstract class Food : Circle , IFood 
    {
        public abstract void Draw(Graphics g);
        public abstract bool Eaten(Snake snake);
    }
}
