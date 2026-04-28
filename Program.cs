World world1 = new("World_1.txt");
Player player = (Player)world1.Entities[0];
Screen screen1 = new(world1, 30, 10, 0, 0);

Console.Clear();
Console.ForegroundColor = ConsoleColor.White;

Console.Write("Press any key to wake up... ");

ConsoleKeyInfo input;
do
{
    input = Console.ReadKey(true);
    world1.StepFrame(input);
    
    // move the screen so the player is closer to center
    screen1.Move((player.X - screen1.X - (screen1.Width / 2)) / (screen1.Width / 5), (player.Y - screen1.Y - (screen1.Height / 2)) / (screen1.Height / 5));

    // Check if the player died
    foreach (MovableEntity entity in world1.Entities[1..])
    {
        if (player.DeadlyEntities.Contains(entity.GetType()))
        {
            if (entity.X == player.X && entity.Y == player.Y)
            {
                screen1.Print(ConsoleColor.DarkGray);

                Console.SetCursorPosition(0, screen1.Height + 2);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("You died!");
                Console.Write("Press any key to wake up... ");

                Console.ReadKey(true);

                world1 = new World("World_1.txt");
                break;
            }
        }
    }

    screen1.Print(ConsoleColor.White);
}
while (input.Key != ConsoleKey.Escape);