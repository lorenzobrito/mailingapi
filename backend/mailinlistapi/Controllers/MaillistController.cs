using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mailinlistapi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MaillistController : ControllerBase
  {
    IRepository _repository;
    public MaillistController(IRepository repository)
    {
      this._repository = repository;
    }
    // GET: api/<MaillistController>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
      return  Ok(await _repository.GetAllAsync(null));
    }

    // GET api/<MaillistController>/5
    [HttpGet("filter/{lastname?}/{sort?}")]
    public async Task<IActionResult> Get(string? lastname,string? sort="Asc")
    {
      return Ok(await _repository.GetAllAsync(lastname,sort));
    }

    // POST api/<MaillistController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] User value)
    {
      try
      {
      await  _repository.AddAsync(value);
        return Ok(new { 
           message = "User added"
        });
      }
      catch (Exception ex)
      {

        return BadRequest(ex.Message);
      }
    }

 
  }
}
