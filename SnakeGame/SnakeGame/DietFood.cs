using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class DietFood : Food
    {
        public DietFood()
        {
            X = 0;
            Y = 0;
        }
        public override bool Eaten(Snake snake)
        {
            if (snake.SnakeBody[0].X == this.X && snake.SnakeBody[0].Y == this.Y)
            {
                snake.EatFood(Settings.DietFoodPoints);
                return true;
            }
            return false;
        }
        public override void Draw(Graphics g)
        {
            g.FillEllipse(Brushes.Red, new Rectangle 
                (
                this.X * Settings.Width,
                this.Y * Settings.Height,
                Settings.Width, Settings.Height));
        }
    }
}
