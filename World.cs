using System.Reflection.Metadata;

public class World
{
    public int Width { get; set; }
    public int Height { get; set; }
    public char[,] Grid { get; set; }
    public List<MovableEntity> Entities { get; set; } = [];
    public Stack<MovableEntity> GarbageCollection { get; set; } = [];

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
                switch (worldText[y][x])
                {
                    case '@': // Player
                        Entities.Insert(0, new Player(x, y, '@', ConsoleColor.Cyan, this));
                        Grid[x, y] = ' ';
                        break;
                    case '^': // Charger
                        Entities.Add(new Charger(x, y, '^', ConsoleColor.Red, 0, this));
                        Grid[x, y] = ' ';
                        break;
                    case '<':
                        Entities.Add(new Charger(x, y, '<', ConsoleColor.Red, 1, this));
                        Grid[x, y] = ' ';
                        break;
                    case 'v':
                        Entities.Add(new Charger(x, y, 'v', ConsoleColor.Red, 2, this));
                        Grid[x, y] = ' ';
                        break;
                    case '>':
                        Entities.Add(new Charger(x, y, '>', ConsoleColor.Red, 3, this));
                        Grid[x, y] = ' ';
                        break;
                    case '┬':
                        Entities.Add(new SwordPickUp(x, y, '┬', ConsoleColor.Yellow, this));
                        Grid[x, y] = ' ';
                        break;
                    default:
                        Grid[x, y] = worldText[y][x];
                        break;
                }
            }
        }
    }

    public bool IsLegalCoord(int x, int y)
    {
        return x >= 0 && x < Width && y >= 0 && y < Height;
    }

    public List<MovableEntity> GetEntitiesAt(int x, int y)
    {
        List<MovableEntity> entities = [];
        if (!IsLegalCoord(x, y)) {return entities;}
        foreach (MovableEntity entity in Entities)
        {
            if (x == entity.X && y == entity.Y)
                entities.Add(entity);
        }
        return entities;
    }

    public void StepFrame(ConsoleKeyInfo input)
    {
        foreach(MovableEntity entity in Entities)
        {
            entity.StepFrame(input);
        }

        while (GarbageCollection.Count() > 0)
        {
            Entities.Remove(GarbageCollection.Pop());
        }
    }
}