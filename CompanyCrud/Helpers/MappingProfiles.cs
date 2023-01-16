using AutoMapper;
using CompanyCrud.Dtos;
using Core.Entities;

namespace CompanyCrud.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<EmployeeCreatedDto, Employee>();
        CreateMap<Employee, EmployeeDto>();
        CreateMap<DummyApiResultUnique, DummyApiResultUniqueDto>();
    }
}