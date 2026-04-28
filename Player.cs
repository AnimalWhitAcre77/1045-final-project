class Player(int x, int y, char symbol, World parentWorld) : MovableEntity(x, y, symbol, parentWorld)
{
    public int Score { get; set; } = 0;
    public int Health { get; set; } = 100;

    public override void StepFrame(ConsoleKeyInfo input)
    {
        switch(input.Key)
        {
            case ConsoleKey.UpArrow:
                Move(0, -1);
                break;
            case ConsoleKey.LeftArrow:
                Move(-1, 0);
                break;
            case ConsoleKey.DownArrow:
                Move(0, 1);
                break;
            case ConsoleKey.RightArrow:
                Move(1, 0);
                break;
        }
    }
}