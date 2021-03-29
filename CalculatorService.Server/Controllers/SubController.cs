using CalculatorService.Library;
using CalculatorService.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;


namespace CalculatorService.Server.Controllers
{
    [Route("calculator/sub")]
    [ApiController]
    public class SubController : CommonController
    {

        public SubController(ILoggerFactory factory, Journal journal) : base(factory, journal)
        {
        }

        [HttpPost]
        public ActionResult<Object> Post(SubtractModel value)
        {
            try
            {
                //Get Result from calculator engine
                SubtractResultModel Difference = new() { Difference = Calculator.Subtraction(value.Minuend, value.Subtrahend) };
                string calculation = $"{value.Minuend}-{value.Subtrahend}={Difference.Difference}";
                return base.Post(Difference, calculation);
            }
            catch (Exception ex)
            {
                return base.Post(ex);
            }
        }
    }

}

