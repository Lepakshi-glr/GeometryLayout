using Microsoft.VisualStudio.TestTools.UnitTesting;
using Geometric.Utilities;
using System.Drawing;

namespace Geometric.Tests
{
    [TestClass]
    public class GeometryServiceTests
    {        
        [TestMethod]
        public void ShouldGetA3TriangleVerticies()
        {
            //Arrange
            int xSquarePos = 10;
            int ySquarePos = 0;

            //Act
            Triangle triangle = Helper.GetBottomTriangle(xSquarePos, ySquarePos, Constants.SQUARE_SIZE);

            //Assert
            Assert.IsTrue(triangle.Point1.X == 10 && triangle.Point1.Y == 0);
            Assert.IsTrue(triangle.Point2.X == 10 && triangle.Point2.Y == 10);
            Assert.IsTrue(triangle.Point3.X == 20 && triangle.Point3.Y == 10);
        }

        [TestMethod]
        public void ShouldGetA4TriangleVerticies()
        {
            //Arrange
            int xSquarePos = 10;
            int ySquarePos = 0;

            //Act
            Triangle triangle = Helper.GetTopTriangle(xSquarePos, ySquarePos, Constants.SQUARE_SIZE);

            //Assert
            Assert.IsTrue(triangle.Point1.X == 10 && triangle.Point1.Y == 0);
            Assert.IsTrue(triangle.Point2.X == 20 && triangle.Point2.Y == 0);
            Assert.IsTrue(triangle.Point3.X == 20 && triangle.Point3.Y == 10);
        }
                
        //Test square starting positions
        //Examples //Input = F11 //Output = 50, 50                
        [TestMethod]
        public void ShouldGetF11SquareStartingPosition()
        {
            //Arrange
            Grid grid = new Grid(Constants.GRID_SIZE, Constants.GRID_SIZE, Constants.SQUARE_SIZE);
            string input = "F11";

            //Act
            Point point = grid.CalculateGridStartingPoint(input);

            //Assert
            Assert.IsTrue(point.X == 50 && point.Y == 50);
        }

        [TestMethod]
        public void ShouldGetF12SquareStartingPosition()
        {
            //Arrange
            Grid grid = new Grid(Constants.GRID_SIZE, Constants.GRID_SIZE, Constants.SQUARE_SIZE);
            string input = "F12";

            //Act
            Point point = grid.CalculateGridStartingPoint(input);

            //Assert
            Assert.IsTrue(point.X == 50 && point.Y == 50);
        }

        [TestMethod]
        public void ShouldGetA1TriangleRowAndColumn()
        {
            //Arrange
            Grid grid = new Grid(Constants.GRID_SIZE, Constants.GRID_SIZE, Constants.SQUARE_SIZE);
            Point point1 = new Point(0, 0);
            Point point2 = new Point(0, 10);
            Point point3 = new Point(10, 10);

            //Act
            string result = grid.CalculateTriangleRowAndColumn(point1, point2, point3);

            //Assert
            Assert.AreEqual("A1", result);
        }
        
        [TestMethod]
        public void ShouldGetD8TriangleRowAndColumn()
        {
            //Arrange
            Grid grid = new Grid(Constants.GRID_SIZE, Constants.GRID_SIZE, Constants.SQUARE_SIZE);
            Point point1 = new Point(30, 30);
            Point point2 = new Point(40, 30);
            Point point3 = new Point(40, 40);

            //Act
            string result = grid.CalculateTriangleRowAndColumn(point1, point2, point3);

            //Assert
            Assert.AreEqual("D8", result);
        }                     
        
        [TestMethod]
        public void ShouldGetA1TriangleRowAndColumn_PointsInDifferentOrder()
        {
            //Arrange
            Grid grid = new Grid(Constants.GRID_SIZE, Constants.GRID_SIZE, Constants.SQUARE_SIZE);
            Point point1 = new Point(10, 10);
            Point point2 = new Point(0, 0);
            Point point3 = new Point(0, 10);

            //Act
            string result = grid.CalculateTriangleRowAndColumn(point1, point2, point3);

            //Assert
            Assert.AreEqual("A1", result);
        }
        
        [TestMethod]
        public void ShouldThrowException_InvalidPoints1()
        {
            Grid grid = new Grid(Constants.GRID_SIZE, Constants.GRID_SIZE, Constants.SQUARE_SIZE);
            Point point1 = new Point(5, 10);
            Point point2 = new Point(0, 0);
            Point point3 = new Point(10, 0);
            bool threwException = false;

            try
            {
                string result = grid.CalculateTriangleRowAndColumn(point1, point2, point3);
                Assert.IsTrue(false);
            }
            catch (System.Exception e)
            {
                threwException = true;
            }

            Assert.IsTrue(threwException);
        }
              
        [TestMethod]
        public void ShouldThrowException_InvalidPoints3()
        {
            Grid grid = new Grid(Constants.GRID_SIZE, Constants.GRID_SIZE, Constants.SQUARE_SIZE);
            Point point1 = new Point(50, 50);
            Point point2 = new Point(50, 50);
            Point point3 = new Point(50, 50);
            bool threwException = false;

            try
            {
                string result = grid.CalculateTriangleRowAndColumn(point1, point2, point3);
                Assert.IsTrue(false);
            }

            catch (System.Exception e)
            {
                threwException = true;
            }

            Assert.IsTrue(threwException);
        }
        
    }
}
