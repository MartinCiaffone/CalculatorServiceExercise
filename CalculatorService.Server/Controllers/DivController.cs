using CalculatorService.Library;
using CalculatorService.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace CalculatorService.Server.Controllers
{
    [Route("calculator/div")]
    [ApiController]
    public class DivController : CommonController
    {

        public DivController(ILoggerFactory factory, Journal journal) : base(factory, journal)
        {
        }

        [HttpPost]
        public ActionResult<Object> Post(DivideModel value)
        {
            try
            {
                //Get Result from calculator engine
                DivideResultModel QuotientAndRemainder = new();
                QuotientAndRemainder.SetQuotientAndRemainder(Calculator.Division(value.Dividend, value.Divisor));
                string calculation = $"{value.Dividend}/{value.Divisor}={QuotientAndRemainder.Quotient + (String.IsNullOrWhiteSpace(QuotientAndRemainder.Remainder.ToString()) ? "" : " rem:" + QuotientAndRemainder.Remainder)}";
                return base.Post(QuotientAndRemainder, calculation);
            }
            catch (Exception ex)
            {
                return base.Post(ex);
            }
        }
    }
}
