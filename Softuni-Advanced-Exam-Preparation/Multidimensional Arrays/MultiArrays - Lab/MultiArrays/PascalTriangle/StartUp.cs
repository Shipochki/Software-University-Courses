int highOfTriangle = int.Parse(Console.ReadLine());

long[][] triangle = new long[highOfTriangle][];

for (int row = 0; row < highOfTriangle; row++)
{
    triangle[row] = new long[row + 1];
    triangle[row][0] = 1;
    for (int col = 1; col < row; col++)
    {
        triangle[row][col] =
            triangle[row - 1][col - 1] + triangle[row - 1][col];
    }
    triangle[row][triangle[row].Length - 1] = 1;
}

foreach (var row in triangle)
{
    Console.WriteLine(string.Join(" ", row));
}