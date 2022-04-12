using System;
using System.Drawing;

namespace SnakeGame
{
	public class Circle // Food, SnakeBody, SnakeHead etc are all circles. Makes collisions easier to identify
	{
		public int X { get; internal set; }
		public int Y { get; internal set; }
		public Circle()
		{
			X = 0;
			Y = 0;
		}
	}
}
