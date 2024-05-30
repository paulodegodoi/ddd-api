using DDD.Application.Dtos;
using DDD.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAll([FromServices] ICustomerServices customerServices)
    {
        try
        {
            return Ok(await customerServices.GetAll());
        }
        catch (Exception e)
        {
            return StatusCode(500, "Ocorreu um erro interno.");
        }
    }
}