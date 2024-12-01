//This app is meant to demonstrate API querying competancy by reading data from the SWAPI (open Star Wars API)
//And presenting information about planets from the Star Wars Universe

public class PlanetsStatsUserInteractor(IUserInteractor userInteractor) : IPlanetsStatsUserInteractor
{

    private readonly IUserInteractor _userInteractor = userInteractor;

    public string? ChooseStatisticsToBeShown(IEnumerable<string> propertiesThatCanBeChosen)
    {
        _userInteractor.ShowMessage(Environment.NewLine);
        _userInteractor.ShowMessage(
            "The statistics of which property would you " +
            "like to see?");
        _userInteractor.ShowMessage(
            string.Join(
                Environment.NewLine, propertiesThatCanBeChosen));

        return _userInteractor.ReadFromUser();
    }

    public void Show(IEnumerable<Planet> planets)
    {
        TablePrinter.Print(planets);
    }

    public void ShowMessage(string message)
    {
        _userInteractor.ShowMessage(message);
    }
}

public static class TablePrinter
{
    //This table printer implementation is very simple and only works because we have a predefined list that we know the contents of
    //Should we have a more varied data source to pull from, this method would need to be formatted to dynamically create appropriately sized columns
    //Instead of simply using a constant variable like it does right now
    public static void Print<T>(IEnumerable<T> items)
    {
        const int columnWidth = 15;
        //Magic number, needs to be changed for more complex data sets

        var properties = typeof(T).GetProperties();
        //Get a list of properties for the type passed into the method

        foreach(var property in properties)
        {
            Console.Write($"{{0, -{columnWidth}}}|", property.Name);
            //Create a series of a headers for each property name
        }

        Console.WriteLine("\n" +
            new string('-', properties.Length * (columnWidth + 1)));
            //Create a divider in the text between column header and data

        Console.WriteLine();

        foreach(var item in items)
        {
            foreach(var property in properties)
            {
                Console.Write(
                    $"{{0, -{columnWidth}}}|",
                    property.GetValue(item));
            }

            Console.WriteLine();
            //For each item in a given collection, print out the value of each property in that item's type
            //Then start a new line
        }
    }
}


