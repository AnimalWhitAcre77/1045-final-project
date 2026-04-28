class Player(int x, int y, char symbol, ConsoleColor symbolColor, World parentWorld) : MovableEntity(x, y, symbol, symbolColor, parentWorld)
{
    public int Score { get; set; } = 0;
    public int Health { get; set; } = 100;

    public override void StepFrame(ConsoleKeyInfo input)
    {
        switch(input.Key)
        {
            case ConsoleKey.W:
            case ConsoleKey.UpArrow:
                Move(0, -1);
                break;
            case ConsoleKey.A:
            case ConsoleKey.LeftArrow:
                Move(-1, 0);
                break;
            case ConsoleKey.S:
            case ConsoleKey.DownArrow:
                Move(0, 1);
                break;
            case ConsoleKey.D:
            case ConsoleKey.RightArrow:
                Move(1, 0);
                break;
        }
    }
}