using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LifeTimeTesting.Service;
using LifeTimeTesting.Filter;

namespace LifeTimeTesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LifetimeController : ControllerBase
    {
        private readonly IIdGenerator _idGenerator;

        public LifetimeController(IIdGenerator idGenerator) 
        {
            _idGenerator = idGenerator;
        }

        [HttpGet]
        [ServiceFilter(typeof(LifetimeIndicatorFilter))]
        public IActionResult Get()
        {
            IServiceProvider serviceProvider = HttpContext.RequestServices;

            return Ok(_idGenerator.Id);
        }
    }
}
