//   CODE FOR FINDING USABLE CHARACTERS
//for (int x=0; x<200; x++)
//{
//    for (int i=0; i<100; i++)
//        Console.Write((char)(i + (x*100)));
//    Console.WriteLine();
//}
//Console.ReadLine();

// box chars ═║╔╗╚╝╠╣╦╩╬ ▒

using System.Threading;

World world;
Player player;
Screen screen;

(int score, Weapons heldWeapon) playerData = (0, 0); // Used to give the player correct info between levels

string[] worlds = ["World_1.txt", "World_2.txt"];
int currentWorld = 0;

LoadWorld(worlds[currentWorld]);

Console.ForegroundColor = ConsoleColor.White;
Console.Clear();

Console.Write(@"╔══════════════════════════════╦══════════════════════════════╗
║                              ║  CS 1045: THE FINAL PROJECT  ║
║                              ╠══════════════════════════════╣
║                              ║                              ║
║                              ║                              ║
║                              ║                              ║
║                              ║                              ║
║                              ║                              ║
║                              ║                              ║
║                              ║                              ║
║                              ║                              ║
╚══════════════════════════════╩══════════════════════════════╝");

WriteMenuLine(0, "(Set Terminal to Fullscreen)");
WriteMenuLine(1, "Press any key to wake up.");


ConsoleKeyInfo input;
do
{
    input = Console.ReadKey(true);
    world.StepFrame(input);
    
    // move the screen so the player is closer to center
    screen.Move((player.X - screen.X - (screen.Width / 2)) / (screen.Width / 5), (player.Y - screen.Y - (screen.Height / 2)) / (screen.Height / 5));
    screen.Print(1, 1, ConsoleColor.White);

    WriteMenuLine(0, "Player Info");
    WriteMenuLine(1, $"Score: {player.Score}");
    WriteMenuLine(2, $"Holding: {player.HeldWeapon}");

    // Check if Player died
    if (world.Entities[0].GetType() != typeof(Player))
    {
        screen.Print(1, 1, ConsoleColor.DarkGray); // gray out screen

        WriteMenuLine(0, "You died!");
        WriteMenuLine(1, "Press any key to wake up. ");

        Console.ReadKey(true);

        LoadWorld("World_1.txt"); // reset world
    }

    // Check if the next world needs loaded
    if (world.WorldCompleted)
    {
        TransitionWorld(currentWorld + 1);
    }
}

while (input.Key != ConsoleKey.Escape);

void LoadWorld(string filePath)
{
    world = new World(filePath);
    player = (Player)world.Entities[0];
    screen = new(world, 30, 10, 0, 0);

    (player.Score, player.HeldWeapon) = playerData; // set to last save point info
}

void TransitionWorld(int newLevelIndex)
{
    Thread.Sleep(500);
    screen.Print(1, 1, ConsoleColor.Gray);
    Thread.Sleep(500);
    screen.Print(1, 1, ConsoleColor.DarkGray);
    Thread.Sleep(500);
    screen.Print(1, 1, ConsoleColor.Black);

    playerData = (player.Score, player.HeldWeapon);
    currentWorld = newLevelIndex;
    LoadWorld(worlds[currentWorld]);

    Thread.Sleep(500);
    screen.Print(1, 1, ConsoleColor.DarkGray);
    Thread.Sleep(500);
    screen.Print(1, 1, ConsoleColor.Gray);
    Thread.Sleep(500);
}

void WriteMenuLine(int lineIndex, string text)
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.SetCursorPosition(32, 3 + lineIndex);
    Console.Write($"{text, -30}");
}