using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class NormalFood : Food
    {
        public NormalFood()
        {
            X = 0;
            Y = 0;
        }
        public override bool Eaten(Snake snake)
        {
            if (snake.SnakeBody[0].X == this.X && snake.SnakeBody[0].Y == this.Y)
            {
                snake.EatFood(Settings.NormalFoodPoint);
                return true;
            }
            return false;
        }
        public override void Draw(Graphics g)
        {
            g.FillEllipse(Brushes.Blue, new Rectangle
                 (
                 X * Settings.Width,
                 Y * Settings.Height,
                 Settings.Width, Settings.Height));
        }
    }
}
