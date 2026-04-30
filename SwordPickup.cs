class SwordPickUp(int x, int y, char symbol, ConsoleColor symbolColor, World parentWorld) : MovableEntity(x, y, symbol, symbolColor, parentWorld)
{
    public List<Type> DeadlyEntityTypes = new List<Type> {typeof(Player)}; // don't need to use this because location of player is known.
    public override void StepFrame(ConsoleKeyInfo input)
    {
        Player player = (Player)ParentWorld.Entities[0];
        if (X == player.X && Y == player.Y)
        {
            player.HeldWeapon = Weapons.Sword;
            ParentWorld.EntitiesAddList.Push((1, new Sword(0, 0, '|', symbolColor, ParentWorld)));
            ParentWorld.GarbageCollection.Push(this);
        }
    }
}