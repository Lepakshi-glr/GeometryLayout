using Geometric.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System;

namespace Geometric.Layout.Controllers
{
    public class GridController : Controller
    {
        //A1 -> x1=0&y1=0&x2=0&y2=10&x3=10&y3=10
        //B1 -> x1=0&y1=10&x2=0&y2=20&x3=10&y3=20
        //D7 -> x1=30&y1=30&x2=30&y2=40&x3=40&y3=40
        //D9 -> x1=40&y1=30&x2=40&y2=40&x3=50&y3=40
        //E7 -> x1=30&y1=40&x2=30&y2=50&x3=40&y3=50
        [HttpGet("api/grid/triangle/byLoc")]
        public IActionResult GetTrianglePoints([FromQuery] string loc)
        {
            try
            {
                Grid grid = new Grid(Constants.GRID_SIZE, Constants.GRID_SIZE, Constants.SQUARE_SIZE);

                Triangle triangle = grid.GetTriangle(loc);

                return new JsonResult(triangle);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { errorMsg = ex.Message });                ;
            }
        }

        [HttpGet("api/grid/triangle/byPoints")]
        //example query string localhost:44398/api/grid/gettriangle?x1=0&y1=0&x2=0&y2=10&x3=10&y3=10 returns "A1"
        public IActionResult GetTriangleRowAndColumn([FromQuery] int x1, [FromQuery] int y1, [FromQuery] int x2, [FromQuery] int y2, [FromQuery] int x3, [FromQuery] int y3)
        {
            try
            {
                Grid grid = new Grid(Constants.GRID_SIZE, Constants.GRID_SIZE, Constants.SQUARE_SIZE);

                Point point1 = new Point(x1, y1);
                Point point2 = new Point(x2, y2);
                Point point3 = new Point(x3, y3);

                Data res = new Data
                {
                    point1 = point1,
                    point2 = point2,
                    point3 = point3,
                    result = grid.CalculateTriangleRowAndColumn(point1, point2, point3)
                };

                return new JsonResult(res);
                
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { errorMsg = ex.Message });                
            }
            
        }
        
    }
}
