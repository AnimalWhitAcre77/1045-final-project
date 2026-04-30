class Sword(int x, int y, char symbol, ConsoleColor symbolColor, World parentWorld) : MovableEntity(x, y, symbol, symbolColor, parentWorld)
{
    public int Direction { get; set; }
    private char[] DirectionSymbols = ['|', '─', '|', '─'];
    public override void StepFrame(ConsoleKeyInfo input)
    {
        Player player = (Player)ParentWorld.Entities[0];
        
        // Go to the location in front of Player 
        Direction = player.Direction;
        Symbol = DirectionSymbols[Direction];

        switch(player.Direction)
        {
            case 0:
                (X, Y) = (player.X, player.Y - 1);
                break;
            case 1:
                (X, Y) = (player.X - 1, player.Y);
                break;
            case 2:
                (X, Y) = (player.X, player.Y + 1);
                break;
            case 3:
                (X, Y) = (player.X + 1, player.Y);
                break;
        }
    }
}