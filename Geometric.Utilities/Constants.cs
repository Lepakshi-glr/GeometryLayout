using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Geometric.Utilities
{
    public static class Constants
    {
        public const int SQUARE_SIZE = 10;
        public const int GRID_SIZE = 60;

    }

    public class Data
    {
        public Point point1 { get; set; }
        public Point point2 { get; set; }
        public Point point3 { get; set; }
        public string result { get; set; }
    }
}
