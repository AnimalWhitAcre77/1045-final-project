public class World
{
    public int Width { get; set; }
    public int Height { get; set; }
    public char[,] Grid { get; set; }
    public List<MovableEntity> Entities { get; set; } = [];

    public World(int width, int height)
    {
        Width = width;
        Height = height;

        Grid = new  char[width, height];

        for (int y = 0; y < Grid.GetLength(1); y++)
        {
            for (int x = 0; x < Grid.GetLength(0); x++)
            {
                Grid[x, y] = '.';
            }
        }
    }

    public World(string filePath)
    {
        string[] worldText = File.ReadAllLines(filePath);

        Grid = new char[worldText[0].Length, worldText.GetLength(0)];

        Width = Grid.GetLength(0);
        Height = Grid.GetLength(1);

        for (int y=0; y<Height; y++)
        {
            for (int x=0; x<Width; x++)
            {
                if (worldText[y][x] == '@')
                {
                    Entities.Insert(0, new Player(x, y, '@', this));
                    Grid[x, y] = ' ';
                }
                else
                {
                    Grid[x, y] = worldText[y][x];
                }
            }
        }
    }

    public bool IsLegalCoord(int x, int y)
    {
        return x >= 0 && x < Width && y >= 0 && y < Height;
    }

    public void StepFrame(ConsoleKeyInfo input)
    {
        foreach(MovableEntity entity in Entities)
        {
            entity.StepFrame(input);
        }
    }
}