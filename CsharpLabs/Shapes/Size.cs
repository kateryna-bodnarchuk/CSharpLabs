using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Size
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public override string ToString() => $"Width: {Width}, Height: {Height}";
    }
}
