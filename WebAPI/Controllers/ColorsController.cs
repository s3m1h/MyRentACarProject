using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        IColorService _colorService;
        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpPost("add")]
        public IActionResult Add(Color color) 
        {

            var result = _colorService.Add(color);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result);
        
        }
        [HttpPost("delete")]
        public IActionResult Delete(Color color)
        {
            var result = _colorService.Delete(color);
            if (result.Success)
            {
                return Ok(result.Success);
            }
            return BadRequest(result);
        }

    }
}
