class SwordPickUp(int x, int y, char symbol, ConsoleColor symbolColor, World parentWorld) : MovableEntity(x, y, symbol, symbolColor, parentWorld)
{
    public List<Type> DeadlyEntities = new List<Type> {typeof(Player)};
    public override void StepFrame(ConsoleKeyInfo input)
    {
        Player player = (Player)ParentWorld.Entities[0];
        if (X == player.X && Y == player.Y)
        {
            player.HeldWeapon = Weapons.Sword;
            ParentWorld.GarbageCollection.Push(this);
        }
    }
}