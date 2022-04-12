using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SnakeGame
{
    internal interface IFood
    {
        public void Draw(Graphics g); // Draws food
        public bool Eaten(Snake snake); // Snake ate food
    }
}
