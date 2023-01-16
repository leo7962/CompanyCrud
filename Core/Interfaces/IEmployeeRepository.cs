using Core.Entities;

namespace Core.Interfaces;

public interface IEmployeeRepository
{
    Task<Employee> CreateEmployeeAsync(Employee employee);
    Task<DummyApiResult> GetEmployeesAsync();
    Task<DummyApiResultUnique> GetEmployeeAsync(string employeeId);
    Task<Employee> UpdateEmployeeAsync(string id, Employee employee);
    Task DeleteEmployeeAsync(int employeeId);
}