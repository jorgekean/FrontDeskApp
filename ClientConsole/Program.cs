using ClientConsole.Services;

Console.WriteLine("Welcome to the FrontDeskApp!!!");

while (true)
{
    Console.WriteLine();
    Console.WriteLine("What would you like to do?");
    Console.WriteLine("1. Create a new customer");
    Console.WriteLine("2. Check storage area availability");
    Console.WriteLine("3. Record box storage status");
    Console.WriteLine("4. Close");

    string input = Console.ReadLine();

    switch (input)
    {
        case "1":
            await FrontDeskAppService.CreateCustomer();
            break;
        case "2":
            await FrontDeskAppService.CheckStorageAreaAvailability();
            break;
        case "3":
            await FrontDeskAppService.RecordBoxStorageStatus();
            break;
        case "4":
            Console.WriteLine("Closing FrontDeskApp ...");
            return;
        default:
            Console.WriteLine("Invalid input.");
            break;
    }
}