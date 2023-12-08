using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCMongoDB.Models;
using MVCMongoDB.Services;

namespace MVCMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        public BeerService _beerService;

        public BeerController(BeerService beerService ) 
        {
            _beerService = beerService;
        }
        [HttpGet]
        public ActionResult<List<Beer>> Get()
        {
            return _beerService.Get();
        }
        [HttpGet("{id}")]
        public ActionResult<Beer> Get2(string id)
        {
            return _beerService.Get2(id);
        }

        [HttpPost]
        public ActionResult<Beer> Create(Beer beer) 
        { 
            _beerService.Create(beer);
            return Ok(beer);
        }
        [HttpPut]
        public ActionResult Update(Beer beer) 
        {
            _beerService.Update(beer.Id, beer);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            _beerService.Delete(id);
            return Ok();
        }
    }
}
