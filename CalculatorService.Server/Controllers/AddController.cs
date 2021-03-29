using CalculatorService.Library;
using CalculatorService.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;


namespace CalculatorService.Server.Controllers
{
    [Route("calculator/add")]
    [ApiController]
    public class AddController : CommonController
    {

        public AddController(ILoggerFactory factory, Journal journal) : base(factory, journal)
        {
        }

        [HttpPost]
        public ActionResult<Object> Post(AdditionModel value)
        {
            try
            {
                //Validate at least two addends
                if (value.Addends.Length < 2) { throw new LessOperandsThanExpectedException(); }
                //Get Result from calculator engine
                AdditionResultModel Sum = new() { Sum = Calculator.Addition(value.Addends) };
                string calculation = $"{String.Join('+', value.Addends)}={Sum.Sum}";
                return base.Post(Sum, calculation);
            }
            catch (Exception ex)
            {
                return base.Post(ex);
            }
        }
    }
}




