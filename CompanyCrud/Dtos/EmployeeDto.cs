using System.ComponentModel.DataAnnotations;

namespace CompanyCrud.Dtos;

public class EmployeeDto
{
    public string? Id { get; set; }
    [Required] public string? EmployeeName { get; set; }

    [Required] public string? EmployeeSalary { get; set; }

    [Required] public string? EmployeeAge { get; set; }
}