using Microsoft.AspNetCore.Mvc;
using webapi.Models.Repository.Interface;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class BikeTypeController : ControllerBase
{
    private readonly ILogger<BikeTypeController> _logger;
    IBikeTypeRepository bikeTypeRepository;

    public BikeTypeController(ILogger<BikeTypeController> logger, IBikeTypeRepository _bikeTypeRepository)
    {
        _logger = logger;
        bikeTypeRepository = _bikeTypeRepository;
    }

    [HttpGet(Name = "BikeTypes")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var bikeTypes = await bikeTypeRepository.GetBikeTypes();
            if (bikeTypes == null)
            {
                return NotFound();
            }

            return Ok(bikeTypes);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}
