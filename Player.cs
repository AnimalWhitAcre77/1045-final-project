class Player(int x, int y, char symbol, ConsoleColor symbolColor, World parentWorld) : MovableEntity(x, y, symbol, symbolColor, parentWorld)
{
    public Weapons HeldWeapon = Weapons.Empty;
    public int Direction = 0;
    public int Score { get; set; } = 0;
    public List<Type> DeadlyEntities = new List<Type> {typeof(Charger)};
    public override void StepFrame(ConsoleKeyInfo input)
    {
        switch(input.Key)
        {
            case ConsoleKey.W:
            case ConsoleKey.UpArrow:
                Move(0, -1);
                Direction = 0;
                break;
            case ConsoleKey.A:
            case ConsoleKey.LeftArrow:
                Move(-1, 0);
                Direction = 1;
                break;
            case ConsoleKey.S:
            case ConsoleKey.DownArrow:
                Move(0, 1);
                Direction = 2;
                break;
            case ConsoleKey.D:
            case ConsoleKey.RightArrow:
                Move(1, 0);
                Direction = 3;
                break;
        }
    }
}

enum Weapons { Empty, Sword }