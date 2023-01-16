using Microsoft.Build.Framework;

namespace CompanyCrud.Dtos;

public class EmployeeCreatedDto
{
    [Required] public string? EmployeeName { get; set; }

    [Required] public string? EmployeeSalary { get; set; }

    [Required] public string? EmployeeAge { get; set; }
}