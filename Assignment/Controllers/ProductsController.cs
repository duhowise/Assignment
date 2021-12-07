using Assignment.Domain.Products;
using Assignment.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        

        [HttpGet("filter")]
        public async Task<IActionResult> Filter([FromQuery]SearchProductQuery searchProductQuery)
        {
            return Ok(await _mediator.Send(searchProductQuery));
        }
    }
}