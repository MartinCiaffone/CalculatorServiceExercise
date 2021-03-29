using CalculatorService.Library;
using CalculatorService.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace CalculatorService.Server.Controllers
{
    [Route("calculator/journal")]
    [ApiController]
    public class JournalController : CommonController
    {

        public JournalController(ILoggerFactory factory, Journal journal) : base(factory, journal)
        {
        }

        [HttpPost]
        public ActionResult<Object> Post(JournalModel value)
        {
            try
            {
                //Get the Journal for the given Id
                List<JournalEntry> entries = _journal.RetrieveByUserDefinedId(value.Id, ControllerContext.HttpContext.Connection.RemoteIpAddress.ToString());
                Operation[] operations = new Operation[entries.Count];
                int index = 0;
                foreach (JournalEntry entry in entries)
                {
                    operations[index] = new() { OperationName = entry.OperationName, Calculation = entry.Calculation, Date = entry.Timestamp.ToString("u") };
                    index++;
                }
                JournalResultModel resultOperations = new() { Operations = operations };

                //Do not "journalize" journal request
                return base.Post(resultOperations, null);
            }
            catch (Exception ex)
            {
                return base.Post(ex);
            }
        }
    }

}

