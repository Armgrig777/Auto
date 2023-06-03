using Auto.Services;
using CarsInfoDB.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auto.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
       
            public CarsController(JsonFileService productService) =>
                ProductService = productService;

            public JsonFileService ProductService { get; }

            [HttpGet]
            public IEnumerable<Cars> Get() => ProductService.GetCars();

            //[HttpPatch]
            //public ActionResult Patch([FromBody] RatingRequest request)
            //{
            //    if (request?.ProductId == null)
            //        return BadRequest();

            //    ProductService.AddRating(request.ProductId, request.Rating);

            //    return Ok();
            //}

            //public class RatingRequest
            //{
            //    public string? ProductId { get; set; }
            //    public int Rating { get; set; }
            //}
        
    }
}
