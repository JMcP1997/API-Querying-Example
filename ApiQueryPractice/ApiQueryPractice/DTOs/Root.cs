//This app is meant to demonstrate API querying competancy by reading data from the SWAPI (open Star Wars API)
//And presenting information about planets from the Star Wars Universe

using System.Text.Json.Serialization;

namespace ApiQueryPractice.DTOs;

public record Root(
    [property: JsonPropertyName("count")] int count,
    [property: JsonPropertyName("next")] string next,
    [property: JsonPropertyName("previous")] object previous,
    [property: JsonPropertyName("results")] IReadOnlyList<Result> results
);