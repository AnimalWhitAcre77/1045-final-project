public class World
{
    public int Width { get; set; }
    public int Height { get; set; }
    public char[,] Screen {get; set; }

    public World(int width, int height)
    {
        Width = width;
        Height = height;

        Screen = new  char[width, height];

        for (int y = 0; y < Screen.GetLength(1); y++)
        {
            for (int x = 0; x < Screen.GetLength(0); x++)
            {
                Screen[x, y] = '.';
            }
        }
    }



    public bool IsLegalCoord(int x, int y)
    {
        return x >= 0 && x < Screen.GetLength(0) && y >= 0 && y < Screen.GetLength(1);
    }
}