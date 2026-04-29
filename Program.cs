World world;
Player player;
Screen screen;

LoadWorld("World_1.txt");

Console.ForegroundColor = ConsoleColor.White;

Console.WriteLine("Expand the terminal before starting.");
Console.Write("Press any key to wake up... ");

ConsoleKeyInfo input;
do
{
    input = Console.ReadKey(true);
    world.StepFrame(input);
    
    // move the screen so the player is closer to center
    screen.Move((player.X - screen.X - (screen.Width / 2)) / (screen.Width / 5), (player.Y - screen.Y - (screen.Height / 2)) / (screen.Height / 5));
    screen.Print(ConsoleColor.White);

    // Check if the player died
    foreach (MovableEntity entity in world.Entities[1..])
    {
        if (player.DeadlyEntities.Contains(entity.GetType()))
        {
            if (entity.X == player.X && entity.Y == player.Y)
            {
                screen.Print(ConsoleColor.DarkGray);

                Console.SetCursorPosition(0, screen.Height + 1);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("You died!");
                Console.Write("Press any key to wake up: ");

                Console.ReadKey(true);

                LoadWorld("World_1.txt");
                break;
            }
        }
    }
}
while (input.Key != ConsoleKey.Escape);

void LoadWorld(string filePath)
{
    world = new World(filePath);
    player = (Player)world.Entities[0];
    screen = new(world, 30, 10, 0, 0);

    Console.Clear();
}