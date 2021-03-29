using CalculatorService.Library;
using CalculatorService.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace CalculatorService.Server.Controllers
{
    [Route("calculator/sqrt")]
    [ApiController]
    public class SqrtController : CommonController
    {

        public SqrtController(ILoggerFactory factory, Journal journal) : base(factory, journal)
        {
        }


        [HttpPost]
        [ActionName("JSONMethod")]
        public ActionResult<Object> Post(SquareRootModel value)
        {
            try
            {
                //Validate positive radicand only
                if (value.Number < 0) { throw new NegativeRadicandException(); }
                //Get Result from calculator engine
                SquareRootResultModel Square = new() { Square = Calculator.SquareRooting(value.Number) };
                string calculation = $"sqrt({value.Number})={Square.Square}";
                return base.Post(Square, calculation);
            }
            catch (Exception ex)
            {
                return base.Post(ex);
            }
        }
    }

}

