using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Shapes
{
    public class Shape
    {
        public Shape(int width, int height, int x, int y)
        {
            Size = new Size { Width = width, Height = height };
            Position = new Position { X = x, Y = y };
        }   

        public Position Position { get; }
        public Size Size { get; }

        public virtual void Draw() => Console.WriteLine($"Shape with {Position} and {Size}");

        public virtual void Move(Position newPosition)
        {
            Position.X = newPosition.X;
            Position.Y = newPosition.Y;
            Console.WriteLine($"moves to {Position}");
        }
    }
}
