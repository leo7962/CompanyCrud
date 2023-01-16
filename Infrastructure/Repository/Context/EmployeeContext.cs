namespace Infrastructure.Repository.Context;

public class EmployeeContext
{
    private readonly HttpClient _httpClient;

    public EmployeeContext(HttpClient httpClient)
    {
        httpClient.BaseAddress = new Uri("http://dummy.restapiexample.com");
        _httpClient = httpClient;
    }
}