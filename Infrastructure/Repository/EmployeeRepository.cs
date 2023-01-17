using Core.Entities;
using Core.Interfaces;
using Newtonsoft.Json;

namespace Infrastructure.Repository;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly HttpClient _httpClient;

    public EmployeeRepository(HttpClient httpClient)
    {
        httpClient.BaseAddress = new Uri("http://dummy.restapiexample.com");
        _httpClient = httpClient;
    }

    public async Task<Employee> CreateEmployeeAsync(Employee employee)
    {
        var content = new StringContent(employee.ToString() ?? string.Empty);
        var response = await _httpClient.PostAsync("/api/v1/create", content);
        if (!response.IsSuccessStatusCode) return new Employee();
        var responseString = await response.Content.ReadAsStringAsync();
        var employeeCreated = JsonConvert.DeserializeObject<DummyApiResultUnique>(responseString);
        var userCreated = new Employee
        {
            Id = employeeCreated?.Data?.Id,
            EmployeeName = employee.EmployeeName,
            EmployeeSalary = employee.EmployeeSalary,
            EmployeeAge = employee.EmployeeAge
        };
        return userCreated;
    }

    public async Task<DummyApiResult> GetEmployeesAsync()
    {
        var response = await _httpClient.GetAsync("/api/v1/employees");
        if (!response.IsSuccessStatusCode) return new DummyApiResult();
        var responseString = await response.Content.ReadAsStringAsync();
        var employees = JsonConvert.DeserializeObject<DummyApiResult>(responseString);
        return employees ?? new DummyApiResult();
    }

    public async Task<DummyApiResultUnique> GetEmployeeAsync(int employeeId)
    {
        var response = await _httpClient.GetAsync($"/api/v1/employee/{employeeId}");
        if (!response.IsSuccessStatusCode) return new DummyApiResultUnique();
        var responseString = await response.Content.ReadAsStringAsync();
        var employee = JsonConvert.DeserializeObject<DummyApiResultUnique>(responseString);
        return employee ?? new DummyApiResultUnique();
    }

    public async Task<Employee> UpdateEmployeeAsync(int id, Employee employee)
    {
        var content = new StringContent(employee.ToString() ?? string.Empty);
        var response = await _httpClient.PutAsync($"/api/v1/update/{id}", content);
        if (!response.IsSuccessStatusCode) return new Employee();
        var responseString = await response.Content.ReadAsStringAsync();
        var employeeUpdated = JsonConvert.DeserializeObject<Employee>(responseString);
        var userCreated = new Employee
        {
            Id = employeeUpdated?.Id,
            EmployeeName = employee.EmployeeName,
            EmployeeSalary = employee.EmployeeSalary,
            EmployeeAge = employee.EmployeeAge
        };
        return userCreated;
    }

    public async Task DeleteEmployeeAsync(int employeeId)
    {
        var response = await _httpClient.DeleteAsync($"/api/v1/delete/{employeeId}");
        if (!response.IsSuccessStatusCode) await response.Content.ReadAsStringAsync();
    }

    public async Task<int> GetAnualSalary(int employeeId)
    {
        var response = await _httpClient.GetAsync($"/api/v1/employee/{employeeId}");
        if (!response.IsSuccessStatusCode) return 0;
        var responseString = await response.Content.ReadAsStringAsync();
        var employee = JsonConvert.DeserializeObject<DummyApiResultUnique>(responseString);
        var employeeAnualSalary = int.Parse(employee?.Data.EmployeeSalary) * 12;
        return employeeAnualSalary;
    }
}
