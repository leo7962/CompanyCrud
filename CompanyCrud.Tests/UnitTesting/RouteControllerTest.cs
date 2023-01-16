using CompanyCrud.Controllers;
using CompanyCrud.Tests.Mocks;
using Microsoft.AspNetCore.Authorization;

namespace CompanyCrud.Tests.UnitTesting;

[TestClass]
public class RouteControllerTest
{
    [TestMethod]
    public async Task UserIsAdmid_Get4links()
    {
        //preparación
        var authoizationService = new AuthorizationMock
        {
            Result = AuthorizationResult.Success()
        };

        var rootController = new RoutesController(authoizationService)
        {
            Url = new UrlHelperMock()
        };

        //Ejecución
        var result = await rootController.Get();

        //Verificación
        if (result.Value != null) Assert.AreEqual(4, result.Value.Count());
    }
}