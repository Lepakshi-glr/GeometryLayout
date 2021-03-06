using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Linq;

namespace Geometric.Utilities
{
    public class Grid
    {
        public int Length { get; }
        public int Height { get; }
        public int SquareSize { get; }
        public int NumberOfColumns { get; }
        public int NumberOfRows { get; }

        public Grid(int length, int height, int squareSize)
        {
            try
            {
                Length = length;
                Height = height;
                SquareSize = squareSize;

                if (Length % SquareSize != 0 || Height % SquareSize != 0 || SquareSize > Length || SquareSize > Height)
                    throw new Exception(
                        string.Format("Invalid grid! Defined SquareSize must be divisible by the grid width & height{0}SquareSize={1}{0}Grid:{2}x{3}",
                        Environment.NewLine, SquareSize, Length, Height));

                NumberOfColumns = Length / SquareSize;
                NumberOfRows = Height / SquareSize;
            }
            catch(DivideByZeroException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Point CalculateGridStartingPoint(string letterNumberCoordinates)
        {
            try
            {
                int y = 0;
                int x = 0;
                float num;

                if (letterNumberCoordinates.Length < 2 || !char.IsLetter(letterNumberCoordinates[0]) ||
                    !float.TryParse(letterNumberCoordinates.Substring(1), out num) || num <= 0)
                    throw new Exception("Invalid coordinates: " + letterNumberCoordinates);

                int column = (int)Math.Ceiling(num / 2) - 1;

                x += column * SquareSize;

                //Convert letter (A-Z) into alphabet index 
                int rowNumber = char.ToUpper(letterNumberCoordinates[0]) - 65;

                y += rowNumber * SquareSize;

                if (x > Length || y > Height)
                    throw new Exception("Triangle is outside of the grid");

                return new Point(x, y);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
                
        public Triangle GetTriangle(string letterNumberCoordinates)
        {
            try
            {
                int num;

                if (letterNumberCoordinates.Length < 2 || !char.IsLetter(letterNumberCoordinates[0]) ||
                    !int.TryParse(letterNumberCoordinates.Substring(1), out num))
                    throw new Exception("Invalid coordinates: " + letterNumberCoordinates);

                Point startingPoint = this.CalculateGridStartingPoint(letterNumberCoordinates);

                Triangle triangle;
                if (num % 2 == 0)
                {
                    triangle = Helper.GetTopTriangle(startingPoint.X, startingPoint.Y, SquareSize);
                }
                else
                {
                    triangle = Helper.GetBottomTriangle(startingPoint.X, startingPoint.Y, SquareSize);
                }

                return triangle;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string CalculateTriangleRowAndColumn(Point point1, Point point2, Point point3)
        {
            try
            {
                List<Point> points = new List<Point>() { point1, point2, point3 };
                ValidatePoints(points);

                //sort 3 points by lowest values to determine starting corner of square in grid (upperleft)
                points = new List<Point>(points.OrderBy(pt => pt.X + pt.Y)).ToList();
                int startingX = points[0].X;
                int startingY = points[0].Y;

                int row = (startingY / SquareSize);
                string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                string letterPosition = alphabet[row].ToString();

                int column = (points[0].X / SquareSize) + 1;
                int numberPosition = 0;
                if (startingX == points[1].X)
                {
                    //Bottom Triange
                    numberPosition = (column * 2) - 1;
                }
                else if (startingY == points[1].Y)
                {
                    //Top Triangle
                    numberPosition = (column * 2);
                }

                return letterPosition += numberPosition;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        //(20,20) (20,30) (30,30)
        private void ValidatePoints(List<Point> points)
        {
            try
            {
                foreach (var point in points)
                {
                    if (point.X % SquareSize != 0 || point.Y % SquareSize != 0)
                    {
                        throw new Exception(string.Format("Invalid input!  Coordinates should be divisible by {0}: {1}{2}",
                            SquareSize, Environment.NewLine, points.ToString()));
                    }
                }

                List<Line> sides = new List<Line>();

                sides.Add(new Line(points[0], points[1]));
                sides.Add(new Line(points[0], points[2]));
                sides.Add(new Line(points[1], points[2]));

                Line hypotenuse = null;

                foreach (var side in sides)
                {
                    if (side.Length == 0)
                    {
                        throw new Exception("Invalid Triangle: two or more vertices are similar ");
                    }

                    if (side.Length != Convert.ToDouble(SquareSize))
                    {
                        if (hypotenuse == null)
                            hypotenuse = side;
                        else
                            throw new Exception("Invalid Triangle: More than one side is longer or shorter than " + SquareSize);
                    }
                }

                if (hypotenuse.Point1.X > hypotenuse.Point2.X)
                {
                    if (hypotenuse.Point2.Y > hypotenuse.Point1.Y)
                        throw new Exception("Invalid hypotenuse");
                }
                else
                {
                    if (hypotenuse.Point2.Y < hypotenuse.Point1.Y)
                        throw new Exception("Invalid hypotenuse");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
