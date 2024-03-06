using System.Diagnostics;

namespace ConsoleApp1;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var game = new Game();
        game.GameLoop();
    }
}

class Game
{
    private Snake _snake = new Snake();
    
    public async Task GameLoop()
    {
        var snake = new Snake();
        
        Render();
        KeyInput().Wait();
    }
    
    private async Task KeyInput()
    {
        while (true)
        {
            var pressedKey = Console.ReadKey().Key;
            InputHandling(pressedKey);
        }
    }
    
    private void InputHandling(ConsoleKey key)
    {
        switch (key)
        {
            case ConsoleKey.DownArrow:
                Console.WriteLine("down");
                _snake.MovementDirection = 6;
                break;
            case ConsoleKey.UpArrow:
                Console.WriteLine("up");
                _snake.MovementDirection = 12;
                break;
            case ConsoleKey.LeftArrow:
                Console.WriteLine("left");
                _snake.MovementDirection = 9;
                break;
            case ConsoleKey.RightArrow:
                Console.WriteLine("right");
                _snake.MovementDirection = 3;
                break;
            case ConsoleKey.Escape:
                Console.WriteLine("esc");
                break;
        }
    }
    
    private async Task Render()
    {
        while (true)
        {
            // Create a new Stopwatch
            Stopwatch stopwatch = new Stopwatch();

            // Start the Stopwatch
            stopwatch.Start();
            
            await Task.Delay(700);
            Console.Clear();
            _snake.Movement();
            
            DisplayGrid();

            stopwatch.Stop();

            // Get the elapsed time
            TimeSpan elapsedTime = stopwatch.Elapsed;

            // Display the elapsed time
            Console.WriteLine($"Elapsed Time: {elapsedTime.TotalMilliseconds} milliseconds");

        }
    }

    private void DisplayGrid()
    {
        // game field
        var Grid = new List<List<string>>
        {
            new List<string> {"\u25a1", "\u25a1", "\u25a1", "\u25a1", "\u25a1", "\u25a1", "\u25a1", "\u25a1" },
            new List<string> {"\u25a1", "\u25a1", "\u25a1", "\u25a1", "\u25a1", "\u25a1", "\u25a1", "\u25a1" },
            new List<string> {"\u25a1", "\u25a1", "\u25a1", "\u25a1", "\u25a1", "\u25a1", "\u25a1", "\u25a1" },
            new List<string> {"\u25a1", "\u25a1", "\u25a1", "\u25a1", "\u25a1", "\u25a1", "\u25a1", "\u25a1" },
            new List<string> {"\u25a1", "\u25a1", "\u25a1", "\u25a1", "\u25a1", "\u25a1", "\u25a1", "\u25a1" },
            new List<string> {"\u25a1", "\u25a1", "\u25a1", "\u25a1", "\u25a1", "\u25a1", "\u25a1", "\u25a1" },
            new List<string> {"\u25a1", "\u25a1", "\u25a1", "\u25a1", "\u25a1", "\u25a1", "\u25a1", "\u25a1" },
            new List<string> {"\u25a1", "\u25a1", "\u25a1", "\u25a1", "\u25a1", "\u25a1", "\u25a1", "\u25a1" },
        };
        
        // змійка на мапі
        foreach (var cord in _snake.Cords)
        {
            int row = cord[0];
            int col = cord[1];
            Grid[row][col] = "\u25cf"; 
        }
        
        // displaying field
        for (int i = 0; i < Grid.Count; i++)
        {
            for (int j = 0; j < Grid[i].Count; j++)
            {
                Console.Write(Grid[i][j] + " ");
            }
            Console.WriteLine();
        }
    }
}
class Snake
{
    public List<List<int>> Cords = new List<List<int>>();
    public int MovementDirection;

    public Snake()
    {
        Cords.Add(new List<int> { 2, 3 });
        MovementDirection = 6;
    }

    public void Movement()
    {
        switch (MovementDirection)
        {
            case 12:
                Cords.Add(new List<int> { Cords[0][0]--, Cords[0][1] });
                Cords.RemoveAt(Cords.Count - 1);
                break;
            case 6:
                Cords.Add(new List<int> { Cords[0][0]++, Cords[0][1] });
                Cords.RemoveAt(Cords.Count - 1);
                break;
            case 3:
                Cords.Add(new List<int> { Cords[0][0], Cords[0][1]++ });
                Cords.RemoveAt(Cords.Count - 1);
                break;
            case 9:
                Cords.Add(new List<int> { Cords[0][0], Cords[0][1]-- });
                Cords.RemoveAt(Cords.Count - 1);
                break;
        }
    }
}