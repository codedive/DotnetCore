using Microsoft.AspNetCore.Mvc;
using webapi.Models.Repository.Interface;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class BrandController : ControllerBase
{
    private readonly ILogger<BrandController> _logger;
    IBrandRepository brandRepository;

    public BrandController(ILogger<BrandController> logger, IBrandRepository _brandRepository)
    {
        _logger = logger;
        brandRepository = _brandRepository;
    }

    [HttpGet(Name = "Brands")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var brands = await brandRepository.GetBrands();
            if (brands == null)
            {
                return NotFound();
            }

            return Ok(brands);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}
