using AutoMapper;
using CompanyCrud.Dtos;
using Core.Entities;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompanyCrud.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly EmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public EmployeesController(EmployeeRepository employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }

    [HttpGet(Name = "allEmployees")]
    [AllowAnonymous]
    public async Task<ActionResult> GetEmployees()
    {
        var employees = await _employeeRepository.GetEmployeesAsync();

        if (employees == null) return NotFound();

        return Ok(employees);
    }

    [HttpGet("{id}", Name = "getEmployee")]
    [AllowAnonymous]
    public async Task<ActionResult<DummyApiResultUniqueDto>> GetEmployeeById(string id)
    {
        var employee = await _employeeRepository.GetEmployeeAsync(id);

        if (employee == null) return NotFound();

        var dto = _mapper.Map<DummyApiResultUnique>(employee);
        return Ok(dto);
    }

    [HttpPost(Name = "createEmployee")]
    public async Task<ActionResult> CreateEmployee(EmployeeCreatedDto? employeeDto)
    {
        if (employeeDto == null) return BadRequest();

        var createemployee = _mapper.Map<Employee>(employeeDto);
        await _employeeRepository.CreateEmployeeAsync(createemployee);
        _mapper.Map<EmployeeDto>(createemployee);
        return Ok();
    }

    [HttpPut("{id}", Name = "UpdateEmployee")]
    public async Task<ActionResult> UpdateEmployee(string id, [FromBody] EmployeeCreatedDto employeeCreatedDto)
    {
        if (employeeCreatedDto == null) BadRequest();
        var entity = _mapper.Map<Employee>(employeeCreatedDto);
        await _employeeRepository.UpdateEmployeeAsync(id, entity);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteEmployee(int id)
    {
        await _employeeRepository.DeleteEmployeeAsync(id);
        return NoContent();
    }
}