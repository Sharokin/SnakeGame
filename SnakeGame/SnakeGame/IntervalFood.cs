using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SnakeGame
{
    internal class IntervalFood : Food
    {
        public IntervalFood()
        {
            X = 0;
            Y = 0;
        }
        public override bool Eaten(Snake snake)
        {
            if (snake.SnakeBody[0].X == this.X && snake.SnakeBody[0].Y == this.Y)
            {
                snake.IntervalActive = true;
                return true;
            }
            else
                return false;
        }
        public override void Draw(Graphics g)
        {
            g.FillEllipse(Brushes.DarkViolet, new Rectangle // ValuableFood
                (
                this.X * Settings.Width,
                this.Y * Settings.Height,
                Settings.Width, Settings.Height));
        }
    }
}
