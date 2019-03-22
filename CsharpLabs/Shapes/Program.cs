using System;

namespace Shapes
{
    class Program
    {
        public class Rectangle : Shape
        {
            public Rectangle() : base()
            {

            }

            public override void Draw() =>
                Console.WriteLine($"Rectangle with {Position} and {Size}");

            public override void Move(Position newPosition)
            {
                Console.Write("Rectangle");
                base.Move(newPosition);
            }
        }

        public sealed class Square : Shape
        {
            public Square() : base()

            public void MoveBy(int x, int y)
            {
                Position.X += x;
                Position.Y += y;
            }

            new public void Move(Position newPosition)
            {
                Position.X = newPosition.X;
                Position.Y = newPosition.Y;
            }
        }

    static void Main(string[] args)
    {
        var r = new Rectangle();
        r.Position.X = 44;
        r.Position.Y = 33;
        r.Size.Width = 200;
        r.Size.Height = 100;
        r.Draw();
        r.Move(new Position { X = 110, Y = 30 });
        r.Draw();
    }
    }
}
