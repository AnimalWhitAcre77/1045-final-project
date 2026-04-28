World world1 = new("World_1.txt");
Player player = (Player)world1.Entities[0];
Screen screen1 = new(world1, 30, 10, 0, 0);

Console.Clear();

Console.Write("Press any key to wake up... ");

ConsoleKeyInfo input;
do
{
    input = Console.ReadKey(true);
    world1.StepFrame(input);
    
    // move the screen so the player is closer to center
    screen1.Move((player.X - screen1.X - (screen1.Width / 2)) / (screen1.Width / 4), (player.Y - screen1.Y - (screen1.Height / 2)) / (screen1.Height / 4));
    screen1.Print();
}
while (input.Key != ConsoleKey.Escape);