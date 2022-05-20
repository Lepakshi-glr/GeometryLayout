# GeometryLayout
Given a Layout containing right angled triangles, program would be able to do the below things
1. For a given row(A-F) and column(1-12) returns the vertices of a triangle if a match is found.
   e.g Input-B6  output-(20,10) (30,10) (30,20)   
2. For given coordinates, calculates the row and column of the triangle 
   e.g Input-(30,40) (30,50) (40,50) output-E8
![GeometryLayoutImage](https://user-images.githubusercontent.com/17550115/169399554-70941b3c-b0ae-47cc-98a3-b126dd9d6413.jpeg)

Design for finding the coordinates for a given triangle position.
1.	Find the starting point using the 2 steps below and then find the coordinates of bottom or top triangle.
   a.	Find point x - Divide the column by 2, take the ceiling number, subtract it by 1 and finally multiply with 10.
      Each cell contains 2 triangles so division by 2 would give the correct column.
      The starting point (x, y) of the image or matrix are 0 based index, subtraction by 1 gives the right x-coordinate.
      As each side is 10pixel, we multiply with 10
      e.g. B6 -> ((6/2)-1)*10 = 20

   b.	Find point y -  ascii value of alphabet starts with 65. Subtracting the alphabet with 65 and multiplying with 10 would give the row position
      e.g. B6 -> 66-65 = 1*10 = 10

2.	Modulo division of the column with 2 would help us in finding the bottom or top triangle.

Design for finding the triangle position for a given vertices.
1.	Sort the points by adding each (x,y). This helps us in determining the first point.
2.	Find row position - Divide the y with 10 and to get the index of alphabet array
   e.g. (20,30) -> 30/10 = 3    
        string strAlphabet = “abcdefgh”
        strAlphabet[3] = D
3.	Find column position – Divide the x with 10 and add 1 
   e.g. (20,30) -> 20/10 = 2 + 1 = 3
4.	For bottom triangle, we multiply the column position by 2 and subtract the result by 1
5.	For top triangle, we multiply the column position by 2.
