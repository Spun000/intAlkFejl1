using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Calculator.Pages;

public class IndexModel : PageModel
{
    public bool hasData;
    public string result;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }

    public void OnPost()
    {
        Calculation calcInput = new Calculation(
            float.Parse(Request.Form["Number1"]),
            float.Parse(Request.Form["Number2"]),
            Request.Form["Operator"]);
        try{   
            calcInput.Validate();
            result = CalculationService.Calculation(calcInput);
            hasData = true;
        } catch (BadHttpRequestException e) {
            result = e.Message;
            hasData = true;
        }
    }
}

