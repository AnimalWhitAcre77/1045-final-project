public class Screen
{
    public World ParentWorld { get; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int X { get; set; }
    public int Y { get; set; }

    public Screen (World parentWorld)
    {
        ParentWorld = parentWorld;

        X = 0;
        Y = 0;

        Width = parentWorld.Width;
        Height = parentWorld.Height;
    }

    public Screen (World parentWorld, int width, int height)
    {
        ParentWorld = parentWorld;

        X = 0;
        Y = 0;
        
        Width = Math.Min(width, parentWorld.Width);
        Height = Math.Min(height, parentWorld.Height);
    }

    public Screen (World parentWorld, int width, int height, int x, int y)
    {
        ParentWorld = parentWorld;

        X = Math.Min(Math.Max(0, x), parentWorld.Width - 1);
        Y = Math.Min(Math.Max(0, y), parentWorld.Height - 1);

        Width = Math.Min(width, parentWorld.Width - X);
        Height = Math.Min(height, parentWorld.Height - Y);
    }

    public bool IsLegalPosition(int x, int y)
    {
        if (x < 0 || x + Width > ParentWorld.Width) { return false; }
        if (y < 0 || y + Height > ParentWorld.Height) { return false; }
        return true;
    }

    public List<MovableEntity> GetEntitiesOnScreen()
    {
        List<MovableEntity> entities = [];

        foreach (MovableEntity entity in ParentWorld.Entities)
        {
            if ((entity.X - X) < 0 || (entity.X - X) >= Width) { continue; }
            if ((entity.Y - Y) < 0 || (entity.Y - Y) >= Height) { continue; }
            entities.Add(entity);
        }

        return entities;
    }

    public void Move(int deltaX, int deltaY)
    {
        if (IsLegalPosition(X + deltaX, Y)) {X += deltaX;}
        if (IsLegalPosition(X, Y + deltaY)) {Y += deltaY;}
    }

    public void Print(ConsoleColor textColor)
    {
        Console.SetCursorPosition(0, 0);
        Console.ForegroundColor = textColor;

        for (int y=Y; y<Y + Height; y++) // World/Background
        {
            for (int x=X; x<X + Width; x++)
            {
                Console.Write(ParentWorld.Grid[x, y]);
            }
            Console.WriteLine();
        }

        foreach (MovableEntity entity in GetEntitiesOnScreen()) // Sprites
        {
            Console.SetCursorPosition(entity.X - X, entity.Y - Y);
            Console.ForegroundColor = entity.SymbolColor;
            Console.Write(entity.Symbol);
        }

        Console.CursorVisible = false;
    }
}