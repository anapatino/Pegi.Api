using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers.Locations;

[ApiController]
[Route("locations")]
public class LocationsController: ControllerBase
{
    private readonly LocationsService _locationsService;

    public LocationsController(LocationsService locationsService)
    {
        _locationsService = locationsService;
    }

    [HttpGet ("departments")]
    public ActionResult GetDepartments()
    {
        List<Department> departments = _locationsService.GetDepartments();
        return Ok(new Response<List<Department>>(departments));
    }

    [HttpGet("cities")]
    public ActionResult GetCities([FromQuery] string department)
    {
        List<City> cities = _locationsService.GetCities(department);
        return Ok(new Response<List<City>>(cities));
    }

}
