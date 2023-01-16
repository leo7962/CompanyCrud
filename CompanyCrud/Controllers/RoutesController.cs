using Infrastructure.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompanyCrud.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoutesController : ControllerBase
{
    private readonly IAuthorizationService _authorizationService;

    public RoutesController(IAuthorizationService authorizationService)
    {
        _authorizationService = authorizationService;
    }

    [HttpGet(Name = "ObtenerRoot")]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<DataHateoas>>> Get()
    {
        var datosHateoas = new List<DataHateoas>();

        var isAdmin = await _authorizationService.AuthorizeAsync(User, "isAdmin");

        datosHateoas.Add(new DataHateoas(Url.Link("allEmployees", new { }), "Obtain all employees", "GET"));

        datosHateoas.Add(new DataHateoas(Url.Link("getEmployee", new { }), "Get an unique employee",
            "GET"));
        if (!isAdmin.Succeeded) return datosHateoas;
        datosHateoas.Add(new DataHateoas(Url.Link("createEmployee", new { }), "Create an employee",
            "POST"));
        datosHateoas.Add(new DataHateoas(Url.Link("UpdateEmployee", new { }), "Update info of an employee",
            "PUT"));

        return datosHateoas;
    }
}