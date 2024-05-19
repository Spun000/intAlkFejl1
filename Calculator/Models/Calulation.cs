namespace Calculator;

using System;
using System.Net;

public class Calculation
{

    private enum Operators {
        add,
        sub,
        mult,
        div,
    };

    public Calculation()
    {
    }
    
    public Calculation(float nr1, float nr2, string op)
    {
        Number1 = nr1;
        Number2 = nr2;
        Operator = op;
    }
    public float Number1 { get; set; }

    public float Number2 { get; set; }

    public string Operator { get; set; } = new string("");

    public void Validate() {
        
        if (!Enum.IsDefined(typeof(Operators), Operator)) {
            throw new BadHttpRequestException($"Invalid operator type: {Operator}", (int)HttpStatusCode.BadRequest);
        }
        
        if (Operator == "div" && Number2 == 0)
        {
            throw new BadHttpRequestException("Cannot devide with zero", (int)HttpStatusCode.BadRequest);
        }
    }
}
