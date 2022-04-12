using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SnakeGame
{
    internal class Snake : ISnake
    {
        public Snake(string direction)
        {
            SnakeBody = new List<Circle>();
            Direction = direction;
        }
        public List<Circle> SnakeBody { get; internal set; }
        public int SnakeScore { get; internal set; }
        public string Direction { get; internal set; }
        public bool GoLeft { get; internal set; } //Directions
        public bool GoRight { get; internal set; }
        public bool GoUp { get; internal set; }
        public bool GoDown { get; internal set; }
        public bool IntervalActive { get; internal set; } // EXTENSION
        public float ThirtySeconds { get; internal set; } // EXTENSION

        public void EatFood(int points)
        {
            SnakeScore += points;

            if (points == Settings.NormalFoodPoint)
            {
                Circle Body = new Circle
                {
                    X = SnakeBody[SnakeBody.Count - 1].X,
                    Y = SnakeBody[SnakeBody.Count - 1].Y
                };

                SnakeBody.Add(Body);
            }

            if (points == Settings.ValuableFoodPoints)
            {
                for (int i = 0; i < Settings.ValuableFoodPoints; i++)
                {
                    Circle Body = new Circle
                    {
                        X = SnakeBody[SnakeBody.Count - 1].X,
                        Y = SnakeBody[SnakeBody.Count - 1].Y
                    };

                    SnakeBody.Add(Body);
                }
            }

            if (points == Settings.DietFoodPoints)
            {
                SnakeBody.RemoveAt(SnakeBody.Count - 1);
            }

            if (points == Settings.IntervalFoodPoints)
            {

            }
        }
        public void Collision()
        {
            for (int j = 1; j < SnakeBody.Count; j++)
            {
                if (SnakeBody[0].X == SnakeBody[j].X && SnakeBody[0].Y == SnakeBody[j].Y) //Runs into itself
                {
                    ThirtySeconds = 30; // EXTENSION
                    SnakeBody.Clear(); // Dead
                }
            }
        }
        public void Collision(Snake secondSnake)
        {
            if (SnakeBody.Count > 0)
            {
                for (int s = 1; s < secondSnake.SnakeBody.Count; s++) // Other snake
                {
                    if (SnakeBody[0].X == secondSnake.SnakeBody[s].X && SnakeBody[0].Y == secondSnake.SnakeBody[s].Y) // Runs into other snake
                    {
                        ThirtySeconds = 30; // EXTENSION
                        SnakeBody.Clear(); // Dead
                        secondSnake.SnakeScore += 5;
                        break;
                    }
                }
            }
        }
        public void ChangeDirection(string dir, bool trueOrfalse)
        {
            switch (dir)
            {
                case "left":
                    GoLeft = trueOrfalse;
                    break;
                case "right":
                    GoRight = trueOrfalse;
                    break;
                case "up":
                    GoUp = trueOrfalse;
                    break;
                case "down":
                    GoDown = trueOrfalse;
                    break;
            }
        }
        public void Draw(Graphics g, int index, Brush color) 
        {
            Brush SnakeColor;

            if (index == 0)
                SnakeColor = Brushes.Black;
            else
                SnakeColor = color;

            g.FillEllipse(SnakeColor, new Rectangle
                   (
                   SnakeBody[index].X * Settings.Width,
                   SnakeBody[index].Y * Settings.Height,
                   Settings.Width, Settings.Height));
        }
        public void MoveHead() 
        {
            switch (Direction) 
            {
                case "left":
                    SnakeBody[0].X--;
                    break;
                case "right":
                    SnakeBody[0].X++;
                    break;
                case "up":
                    SnakeBody[0].Y--;
                    break;
                case "down":
                    SnakeBody[0].Y++;
                    break;
            }
        }
        public void ThroughWalls(int width, int height)
        {
            if (SnakeBody[0].X < 0) 
            {
                SnakeBody[0].X = width;
            }
            if (SnakeBody[0].X > width)
            {
                SnakeBody[0].X = 0;
            }
            if (SnakeBody[0].Y < 0)
            {
                SnakeBody[0].Y = height;
            }
            if (SnakeBody[0].Y > height)
            {
                SnakeBody[0].Y = 0;
            }
        }
        public void MoveAlong(int index) 
        {
            SnakeBody[index].X = SnakeBody[index - 1].X;
            SnakeBody[index].Y = SnakeBody[index - 1].Y;
        }
        public void SnakeDirection()
        {
            if (GoLeft)
            {
                Direction = "left";
            }
            if (GoRight)
            {
                Direction = "right";
            }
            if (GoDown)
            {
                Direction = "down";
            }
            if (GoUp)
            {
                Direction = "up";
            }
        }
        public bool RandomMoves(int move) // EXTENSION
        {
            if (ThirtySeconds < 30)
            {
                ThirtySeconds += 0.06f; // Timer interval is 50 m/s plus 0.01 for the delay
                switch (move)
                {
                    case 1:
                        if (Direction != "down")
                            Direction = "up";
                        break;
                    case 2:
                        if (Direction != "up")
                            Direction = "down";
                        break;
                    case 3:
                        if (Direction != "right")
                            Direction = "left";
                        break;
                    case 4:
                        if (Direction != "left")
                            Direction = "right";
                        break;
                }
                return false;
            }
            else
            {
                ThirtySeconds = 0;
                IntervalActive = false;
                return true;
            }
        }             
    }
}
