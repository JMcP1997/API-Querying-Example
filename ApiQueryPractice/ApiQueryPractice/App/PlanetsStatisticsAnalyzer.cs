//This app is meant to demonstrate API querying competancy by reading data from the SWAPI (open Star Wars API)
//And presenting information about planets from the Star Wars Universe

public class PlanetsStatisticsAnalyzer : IPlanetsStatisticsAnalyzer
{
    private readonly IPlanetsStatsUserInteractor _userInteractor;

    public PlanetsStatisticsAnalyzer(IPlanetsStatsUserInteractor userInteractor)
    {
        _userInteractor = userInteractor;
    }

    public void Analyze(IEnumerable<Planet> planets)
    {
        var propertyNamesToSelectorMapping =
            new Dictionary<string, Func<Planet, long?>>
            {
                ["population"] = planet => planet.Population,
                ["diameter"] = planet => planet.Diameter,
                ["surface water"] = planet => planet.SurfaceWater
            };

        var userChoice = _userInteractor
            .ChooseStatisticsToBeShown(
                propertyNamesToSelectorMapping.Keys);
        if (userChoice is null ||
            !propertyNamesToSelectorMapping.ContainsKey(userChoice))
        {
            _userInteractor.ShowMessage(
                "Invalid Choice.");
        }
        else
        {
            ShowStatistics(
                planets,
                userChoice,
                propertyNamesToSelectorMapping[userChoice]);
        }
    }

    private static void ShowStatistics(
        string descriptor,
        Planet selectedPlanet,
        Func<Planet, long?> propertySelector,
        string propertyName)
    {
        Console.WriteLine($"{descriptor} {propertyName} is: " +
            $"{propertySelector(selectedPlanet)} " +
            $"(planet: {selectedPlanet.Name})");
    }

    private void ShowStatistics(
        IEnumerable<Planet> planets,
        string propertyName,
        Func<Planet, long?> propertySelector)
    {
        ShowStatistics(
            "Max",
            planets.MaxBy(propertySelector),
            propertySelector,
            propertyName);

        ShowStatistics(
            "Min",
            planets.MinBy(propertySelector),
            propertySelector,
            propertyName);
    }
}
