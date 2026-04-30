class Goal(int x, int y, char symbol, ConsoleColor symbolColor, World parentWorld) : MovableEntity(x, y, symbol, symbolColor, parentWorld)
{
    public override void StepFrame(ConsoleKeyInfo input)
    {
        Player player = (Player)ParentWorld.Entities[0];
        if (X == player.X && Y == player.Y)
        {
            ParentWorld.WorldCompleted = true;
        }
    }
}