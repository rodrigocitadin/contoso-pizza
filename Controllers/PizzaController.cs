using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PizzaController : ControllerBase
{
    public PizzaController()
    {
    }

    [HttpGet]
    public ActionResult<List<Pizza>> GetAll()
    {
        return PizzaService.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        var pizza = PizzaService.Get(id);

        if (pizza == null) return NotFound();

        return pizza;
    }

    [HttpPost]
    public IActionResult Create(Pizza pizza)
    {
        if (pizza is Pizza)
        {
            PizzaService.Add(pizza);
            return Created();
        }

        return BadRequest();
    }

    [HttpPut]
    public IActionResult Update(Pizza pizza)
    {
        if (pizza is Pizza)
        {
            PizzaService.Update(pizza);
            return Ok();
        }

        return BadRequest();
    }
}
