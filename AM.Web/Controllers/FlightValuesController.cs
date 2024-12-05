using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AM.Web.Controllers;

    [Route("api/[controller]")]
    [ApiController]
public class FlightValuesController : ControllerBase
{
    private readonly IServiceFlight _flightService;

    public FlightValuesController(IServiceFlight flightService)
    {
        _flightService = flightService;
    }

    // GET: api/FlightValues
    [HttpGet]
    public IActionResult Get()
    {
        var flights = _flightService.GetAll();
        return Ok(flights);
    }

    // GET: api/FlightValues/5
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var flight = _flightService.GetById(id);
        if (flight == null)
            return NotFound();
        return Ok(flight);
    }

    // POST: api/FlightValues
    [HttpPost]
    public IActionResult Post([FromBody] Flight flight)
    {
        if (flight == null)
            return BadRequest();

        _flightService.Add(flight);
        return CreatedAtAction(nameof(Get), new { id = flight.FlightId }, flight);
    }

    // PUT: api/FlightValues/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Flight flight)
    {
        if (flight == null || id != flight.FlightId)
            return BadRequest();

        var existingFlight = _flightService.GetById(id);
        if (existingFlight == null)
            return NotFound();

        _flightService.Update(flight);
        return NoContent();
    }

    // DELETE: api/FlightValues/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var flight = _flightService.GetById(id);
        if (flight == null)
            return NotFound();

        _flightService.Delete(flight);
        return NoContent();
    }
}


