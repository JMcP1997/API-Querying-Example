//This app is meant to demonstrate API querying competancy by reading data from the SWAPI (open Star Wars API)
//And presenting information about planets from the Star Wars Universe

namespace ApiQueryPractice.DataAccess
{
    public interface IPlanetsReader
    {
        Task<IEnumerable<Planet>> Read();
    }
}