World world1 = new("World_1.txt");
Screen screen1 = new(world1);

Console.Clear();

ConsoleKeyInfo input;
do
{
    input = Console.ReadKey(true);
    world1.StepFrame(input);
    screen1.PrintScreen();
}
while (input.Key != ConsoleKey.Escape);