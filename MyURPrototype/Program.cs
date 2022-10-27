using MyURPrototype;

var dataService = new RobotDataService();

Console.Write("Press 'Escape' to exit the process...\n");

while (Console.ReadKey().Key != ConsoleKey.Escape)
{
    dataService.HandleRobotUpdate();
}
