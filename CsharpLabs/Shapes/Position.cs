using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public override string ToString() => $"X: {X}, Y: {Y}";
    }

}
