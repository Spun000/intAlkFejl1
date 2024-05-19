using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CalculationController : ControllerBase
{
    private static readonly string[] Operations = new[]
    {
        "add", "sub", "mult", "div"
    };

    public CalculationController()
    {
    }

    [HttpPost(Name = "Calculation")]
    public IActionResult Post(Calculation calcInput)
    {
        try{
            calcInput.Validate();
            return Ok(CalculationService.Calculation(calcInput));
        } catch (BadHttpRequestException e){
            switch (e.StatusCode)
            {
                case 400:
                    return BadRequest(e.Message);
                case 500:
                    return Problem(e.Message,"",e.StatusCode,"","");                    
                default:
                    return Problem(e.Message,"",(int)HttpStatusCode.InternalServerError,"","");   
            }
        }        
    }
}
