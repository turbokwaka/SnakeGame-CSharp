namespace ConsoleApp1;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        GameLoop();
    }

    static void GameLoop()
    {
        Render();
        KeyInput().Wait();
    }
    
    static async Task Render()
    {
        while (true)
        {
            await Task.Delay(1000);
            Console.WriteLine("updated!");
        }
    }

    static async Task KeyInput()
    {
        while (true)
        {
            Console.WriteLine(Console.ReadKey().Key);
        }
    }
}

class Snake
{
    public List<List<int>> Cords;
    public int MovementDirection;

    public Snake()
    {
        Cords.Add(new List<int> { 2, 3 });
        MovementDirection = 6;
    }
}