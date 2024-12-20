﻿//This app is meant to demonstrate API querying competancy by reading data from the SWAPI (open Star Wars API)
//And presenting information about planets from the Star Wars Universe

using ApiQueryPractice.DataAccess;

public class ApiQueryPracticeApp
{
    private readonly IPlanetsReader _planetsReader;
    private readonly IPlanetsStatisticsAnalyzer _planetsStatisticsAnalyzer;
    private readonly IPlanetsStatsUserInteractor _planetsStatsUserInteractor;

    public ApiQueryPracticeApp(
        IPlanetsReader planetsReader,
        IPlanetsStatisticsAnalyzer planetsStatisticsAnalyzer,
        IPlanetsStatsUserInteractor planetsStatsUserInteractor)
    {
        _planetsReader = planetsReader;
        _planetsStatisticsAnalyzer = planetsStatisticsAnalyzer;
        _planetsStatsUserInteractor = planetsStatsUserInteractor;
    }

    public async Task Run()
    {
        var planets = await _planetsReader.Read();

        _planetsStatsUserInteractor.Show(planets);

        _planetsStatisticsAnalyzer.Analyze(planets);
    }
}
