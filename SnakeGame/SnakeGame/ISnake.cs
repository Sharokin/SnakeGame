using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SnakeGame
{
    internal interface ISnake
    {
        public void EatFood(int points); // Eats food
        public void Collision(); // Snake runs in to itself
        public void Collision(Snake secondSnake); // Runs in to a second snake (2 player mode)
        public void ChangeDirection(string dir, bool trueOrfalse); // Changes direction of the snake
        public void Draw(Graphics g, int index, Brush color); // Draws the snake
        public void MoveHead(); // Moves the head
        public void ThroughWalls(int width, int height); // Makes snake go through walls
        public void MoveAlong(int index); // Moves body along the head
        public void SnakeDirection(); // Sets direction
        public bool RandomMoves(int move); // Random moves for 10 sec when interval food is eaten
    }
}
