using Core.Entities;

namespace Core.Interfaces;

public interface IEmployeeRepository
{
    Task<Employee> CreateEmployeeAsync(Employee employee);
    Task<DummyApiResult> GetEmployeesAsync();
    Task<DummyApiResultUnique> GetEmployeeAsync(int employeeId);
    Task<Employee> UpdateEmployeeAsync(int id, Employee employee);
    Task DeleteEmployeeAsync(int employeeId);
    Task<int> GetAnualSalary(int employeeId);
}