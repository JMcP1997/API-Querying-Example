//This app is meant to demonstrate API querying competancy by reading data from the SWAPI (open Star Wars API)
//And presenting information about planets from the Star Wars Universe

using ApiQueryPractice.DTOs;

public readonly record struct Planet
{
    public string Name { get; }
    public int Diameter { get; }
    public int? SurfaceWater { get; }
    public long? Population { get; }

    public Planet(
        string name,
        int diameter,
        int? surfaceWater,
        long? population)
    {
        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }
        Name = name;
        Diameter = diameter;
        SurfaceWater = surfaceWater;
        Population = population;
    }

    public static explicit operator Planet(Result planetDto)
    //Were this project larger, it might warrant creating a custom Json -> DTO -> custom classes converter
    //But the scope of this project is rather small, so this should work fine
    {
        var name = planetDto.name;

        //We always expect the diameter to carry a value so we dont need to TryParse();
        var diameter = int.Parse(planetDto.diameter);

        //However the SurfaceWater and Population are nullable, so we will use TryParse here

        long? population = planetDto.population.ToLongOrNull();

        int? surfaceWater = planetDto.surface_water.ToIntOrNull();

        return new Planet(name, diameter, surfaceWater, population);
    }
}
