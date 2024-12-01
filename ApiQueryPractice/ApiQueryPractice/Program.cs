//This app is meant to demonstrate API querying competancy by reading data from the SWAPI (open Star Wars API)
//And presenting information about planets from the Star Wars Universe

using static ApiQueryPracticeApp;
using ApiQueryPractice.ApiDataAccess;

try
{
    var consoleUserInteractor = new ConsoleUserInteractor();
    var planetsStatsUserInteractor =
        new PlanetsStatsUserInteractor(consoleUserInteractor);

    await new ApiQueryPracticeApp(
        new PlanetsFromApiReader(
            new ApiDataReader(),
            new MockStarWarsApiDataReader(),
            consoleUserInteractor),
        new PlanetsStatisticsAnalyzer(
            planetsStatsUserInteractor),
        planetsStatsUserInteractor).Run();
}
catch (Exception ex)
{
    Console.WriteLine("An error has occured. " +
        "Excption Message: " + ex.Message);
}


Console.WriteLine("Press any key to close");
Console.ReadKey();
