using CalculatorService.Library;
using CalculatorService.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace CalculatorService.Server.Controllers
{
    [Route("calculator/mult")]
    [ApiController]
    public class MultController : CommonController
    {

        public MultController(ILoggerFactory factory, Journal journal) : base(factory, journal)
        {
        }

        [HttpPost]
        public ActionResult<Object> Post(MultiplyModel value)
        {
            try
            {
                //Validate at least two factors
                if (value.Factors.Length < 2) { throw new LessOperandsThanExpectedException(); }
                //Get Result from calculator engine
                MultiplyResultModel Product = new() { Product = Calculator.Multiplication(value.Factors) };
                string calculation = $"{String.Join('*', value.Factors)}={Product.Product}";
                return base.Post(Product, calculation);
            }
            catch (Exception ex)
            {
                return base.Post(ex);
            }
        }
    }
}
