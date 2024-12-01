//This app is meant to demonstrate API querying competancy by reading data from the SWAPI (open Star Wars API)
//And presenting information about planets from the Star Wars Universe

public class ConsoleUserInteractor : IUserInteractor
{
    public string? ReadFromUser()
    {
        return Console.ReadLine();
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}
