public abstract class MovableEntity
{
    public World ParentWorld { get; }
    public int X { get; set; }
    public int Y { get; set; }
    public char Symbol { get; set; }

    public char[] Walls { get; protected set; } = ['█'];

    public MovableEntity(int x, int y, char symbol, World world)
    {
        X = x;
        Y = y;
        Symbol = symbol;
        ParentWorld = world;
    }

    public abstract void StepFrame(ConsoleKeyInfo input);

    public void Move(int deltaX, int deltaY)
    {
        int newX = X + deltaX;
        int newY = Y + deltaY;

        if (ParentWorld.IsLegalCoord(newX, newY) && !Walls.Contains(ParentWorld.Grid[newX, newY])) // If not moving into a wall
        {
            X = newX;
            Y = newY;
        }
    }
}