public class MovableEntity
{
    public int X { get; set; }
    public int Y { get; set; }
    public char Symbol { get; set; }
    public Screen ParentScreen { get; set; }

    public char[] Walls { get; protected set; } = ['*', '|', '-'];

    public MovableEntity(int x, int y, char symbol, Screen screen)
    {
        X = x;
        Y = y;
        Symbol = symbol;
        ParentScreen = screen;
        ParentScreen.Map[X, Y] = Symbol; // Draw initial position
    }

    public void Move(int deltaX, int deltaY)
    {
        int newX = X + deltaX;
        int newY = Y + deltaY;

        if (!Walls.Contains(ParentScreen.Map[newX, newY])) // If not moving into a wall
        {
            ParentScreen.Map[X, Y] = ' '; // Clear old position
            X = newX;
            Y = newY;
            ParentScreen.Map[X, Y] = Symbol; // Draw at new position
        }
    }
}