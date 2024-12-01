public class ApiDataReader : IApiDataReader
{
    public async Task<String> Read(
        string baseAddress, string requestAddress)
    {
        //Create a disposable variable for receiving data from API
        using var client = new HttpClient();

        //Asynchronously get the data to ensure other processes are not blocked while we wait
        client.BaseAddress = new Uri(baseAddress);
        HttpResponseMessage response = await client.GetAsync(
            requestAddress);

        //If we fail to get the 'Success' status code, throw an exception
        response.EnsureSuccessStatusCode();

        //Return a string being read asynchronously
        return await response.Content.ReadAsStringAsync();
    }
}