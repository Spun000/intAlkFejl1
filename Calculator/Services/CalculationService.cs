
using System.Net;
using Calculator;

static class CalculationService {
    public static string Calculation(Calculation calculation) {
        float res;
        switch (calculation.Operator) {
            case "add":
                res = calculation.Number1 + calculation.Number2;
                return $"{calculation.Number1} + {calculation.Number2} = {res}";
            case "sub":
                res = calculation.Number1 - calculation.Number2;
                return $"{calculation.Number1} - {calculation.Number2} = {res}";
            case "mult":
                res = calculation.Number1 * calculation.Number2;
                return $"{calculation.Number1} * {calculation.Number2} = {res}";
            case "div":
                res = calculation.Number1 / calculation.Number2;
                return $"{calculation.Number1} / {calculation.Number2} = {res}";
            default:
                throw new BadHttpRequestException("invalid operator", (int)HttpStatusCode.InternalServerError);
        }
    }
}