class Charger(int x, int y, char symbol, ConsoleColor symbolColor, int direction, World parentWorld) : MovableEntity(x, y, symbol, symbolColor, parentWorld)
{
    public int Direction { get; set; } = direction;
    private char[] DirectionSymbols = ['^', '<', 'v', '>'];

    public override void StepFrame(ConsoleKeyInfo input)
    {
        Player player = (Player)ParentWorld.Entities[0];
        switch(Direction)
        {
            case 0:
                if (Walls.Contains(ParentWorld.Grid[X, Y-1])) { Direction = (Direction + 1) % 4; }
                else {Move(0, -1);}
                break;
            case 1:
                if (Walls.Contains(ParentWorld.Grid[X-1, Y])) { Direction = (Direction + 1) % 4; }
                else {Move(-1, 0);}
                break;
            case 2:
                if (Walls.Contains(ParentWorld.Grid[X, Y+1]))  {Direction = (Direction + 1) % 4; }
                else {Move(0, 1);}
                break;
            case 3:
                if (Walls.Contains(ParentWorld.Grid[X+1, Y])) { Direction = (Direction + 1) % 4; }
                else {Move(1, 0);}
                break;
        }
        Symbol = DirectionSymbols[Direction];
    }
}