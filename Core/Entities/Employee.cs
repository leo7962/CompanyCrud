using Newtonsoft.Json;

namespace Core.Entities;

public class Employee
{
    [JsonProperty(PropertyName = "id")] public string? Id { get; set; }

    [JsonProperty(PropertyName = "employee_name")]
    public string? EmployeeName { get; set; }

    [JsonProperty(PropertyName = "employee_salary")]
    public string? EmployeeSalary { get; set; }

    [JsonProperty(PropertyName = "employee_age")]
    public string? EmployeeAge { get; set; }

    [JsonProperty(PropertyName = "profile_image")]
    public string? ProfileImage { get; set; }
}