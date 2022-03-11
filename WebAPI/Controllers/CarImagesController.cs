using Business.Abstract;
using Core.Utilities.Images;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        
        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
 
            
        }
        [HttpGet("get")]
        public IActionResult Get(CarImage carImage)
        {
            return Ok(carImage);
        }
        [HttpPost("add")]
        public IActionResult Add([FromForm(Name ="images")]IFormFile file, [FromForm]CarImage carImage)
        {
            var result = _carImageService.Add(file,carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



    }
}
