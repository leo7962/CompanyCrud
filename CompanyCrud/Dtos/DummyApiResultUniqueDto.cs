using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace CompanyCrud.Dtos;

public class DummyApiResultUniqueDto
{
    [Required] public string? Status { get; set; }
    [Required] public Employee? Data { get; set; }
    [Required] public string? Message { get; set; }
}