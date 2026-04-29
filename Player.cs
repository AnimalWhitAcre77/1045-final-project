class Player(int x, int y, char symbol, ConsoleColor symbolColor, World parentWorld) : MovableEntity(x, y, symbol, symbolColor, parentWorld)
{
    public Weapons HeldWeapon = Weapons.Empty;
    public int Direction = 0;
    public int Score { get; set; } = 0;
    public List<Type> DeadlyEntityTypes = new List<Type> {typeof(Charger)};
    public override void StepFrame(ConsoleKeyInfo input)
    {
        int dX = 0;
        int dY = 0;

        switch(input.Key) // figure desired location
        {
            case ConsoleKey.W:
            case ConsoleKey.UpArrow:
                dY = -1;
                Direction = 0;
                break;
            case ConsoleKey.A:
            case ConsoleKey.LeftArrow:
                dX = -1;
                Direction = 1;
                break;
            case ConsoleKey.S:
            case ConsoleKey.DownArrow:
                dY = 1;
                Direction = 2;
                break;
            case ConsoleKey.D:
            case ConsoleKey.RightArrow:
                dX = 1;
                Direction = 3;
                break;
        }

        // Entity wall checks will go here

        Move(dX, dY);
    }
}

enum Weapons { Empty, Sword }