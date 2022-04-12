using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Settings // Game Settings
    {
        public static int Width { get; private set; }
        public static int Height { get; private set; }

        public static readonly int NormalFoodPoint = 1;
        public static readonly int ValuableFoodPoints = 5;
        public static readonly int DietFoodPoints = -1;
        public static readonly int IntervalFoodPoints = 0;
        public Settings()
        {
            Width = 16;
            Height = 16;
        }
    }
}
