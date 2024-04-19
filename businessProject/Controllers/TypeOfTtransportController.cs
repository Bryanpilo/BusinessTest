using businessProject.Business.Interface;
using businessProject.DTO;
using Microsoft.AspNetCore.Mvc;

namespace businessProject.Controllers;

[ApiController]
[Route("[controller]")]
public class TypeOfTransportController : ControllerBase
{
    private readonly ILogger<TypeOfTransportController> _logger;
    private readonly ITypeOfTransportBL _typeOfTransportBl;

    public TypeOfTransportController(ILogger<TypeOfTransportController> logger, ITypeOfTransportBL typeOfTransportBL)
    {
        _typeOfTransportBl = typeOfTransportBL;
        _logger = logger;
    }

    //Post, create a new type of transport 
    [HttpPost("AddType")]
    public IActionResult AddNewType(AddTypeOfTransportDto addTypeOfTransportDto)
    {
        var type = _typeOfTransportBl.addTransport(addTypeOfTransportDto);
        if (!type)
        {
            return StatusCode(409);
        }
        return StatusCode(201);
    }

    //Get, Get all values in database
    [HttpGet("GetAll")]
    public IActionResult GetValues()
    {
        var values = _typeOfTransportBl.getAll();
        return Ok(values);
    }

    //Get a specific value by id
    //GET api/values/5
    [HttpGet("GetById/{id}")]
    public IActionResult Get(int id)
    {
        var value = _typeOfTransportBl.getById(id);
        return Ok(value);
    }

    //Update By id
    // PUT api/values/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, AddTypeOfTransportDto addTypeOfTransportDto)
    {
        var result = _typeOfTransportBl.updateTransport(id, addTypeOfTransportDto);

        if (!result)
        {
            return StatusCode(409);
        }
        return StatusCode(201);
    }

    //Delete By Id
    // DELETE api/values/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _typeOfTransportBl.deleteTransport(id);
        if (!result)
        {
            return StatusCode(409);
        }
        return StatusCode(201);
    }

}
