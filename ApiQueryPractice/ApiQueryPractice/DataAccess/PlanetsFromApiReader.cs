//This app is meant to demonstrate API querying competancy by reading data from the SWAPI (open Star Wars API)
//And presenting information about planets from the Star Wars Universe

using ApiQueryPractice.DataAccess;
using ApiQueryPractice.DTOs;
using System.Text.Json;

public class PlanetsFromApiReader : IPlanetsReader
{
    private readonly IApiDataReader _apiDataReader;
    private readonly IApiDataReader _mockApiDataReader;
    private readonly IUserInteractor _userInteractor;

    public PlanetsFromApiReader(IApiDataReader apiDataReader, IApiDataReader mockApiDataReader, IUserInteractor userInteractor)
    {
        _apiDataReader = apiDataReader;
        _mockApiDataReader = mockApiDataReader;
        _userInteractor = userInteractor;
    }

    public async Task<IEnumerable<Planet>> Read()


    {
        string? json = null;

        try
        {
            json = await _apiDataReader.Read(
                "https://swapi.dev/", "api/planets");
        }
        catch (HttpRequestException ex)
        {
            //In the event that the Star Wars API is closed or down or for some other reason unreadable, we'll use a 'practice' API that just contains mock data
            _userInteractor.ShowMessage("API request unsuccessful" +
                "Switching to Mock Data" +
                "Exception Message: " + ex.Message);
        }

        //In the event of our JSON string being null, this is our plan B
        json ??= await _mockApiDataReader.Read(
            "https://swapi.dev/", "api/planets");

        var root = JsonSerializer.Deserialize<Root>(json);

        return ToPlanets(root);
    }

    private static IEnumerable<Planet> ToPlanets(Root? root)
    {
        if (root is null)
        {
            throw new ArgumentNullException(nameof(root));
        }

        return root.results.Select(
            planetDto => (Planet)planetDto);
    }
}
