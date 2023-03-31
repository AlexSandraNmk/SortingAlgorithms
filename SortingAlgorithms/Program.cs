using SortingAlgorithms.UserInteraction;

bool endApp = false;

while (!endApp)
{
    Console.Clear();
    Console.WriteLine("Choose an algorithm type from the following list:");
    Console.WriteLine("1 - Sorting");
    Console.WriteLine("2 - Searching");
    Console.WriteLine("x - Exit");

    string type = Console.ReadLine();

    switch (type)
    {
        case "1":
            await new SortingOption().ExecuteAsync();
            break;
        case "2":
            await new SearchingOption().ExecuteAsync();
            break;
        case "x":
            endApp = true;
            break;
        default:
            break;
    }
}
