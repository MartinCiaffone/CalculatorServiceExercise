using CalculatorService.Library;
using CalculatorService.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;

namespace CalculatorService.Server.Controllers
{
    // TIP.
    // Don't create a web API controller by deriving from the Controller class. 
    // Controller derives from ControllerBase and adds support for views, so it's for handling web pages, not web API requests. 
    // There's an exception to this rule: if you plan to use the same controller for both views and web APIs, derive it from Controller.
    public class CommonController : ControllerBase
    {

        internal CommonController()
        {
        }
        private readonly ILogger _logger;
        protected readonly Journal _journal;
        internal CommonController(ILoggerFactory factory, Journal journal)
        {
            _logger = factory.CreateLogger("CalculatorService.Server.Controllers");
            _journal = journal;
        }


        [NonAction]
        public ActionResult<Object> Post(Object Result, string calculation)
        {
            try
            {
                _logger.LogInformation($"Requested {ControllerContext.ActionDescriptor.ControllerName}");

                //Journal
                var id = HttpContext.Request.Headers["X-Evi-Tracking-Id"].ToString();
                if (!String.IsNullOrWhiteSpace(id) && !String.IsNullOrWhiteSpace(calculation))
                {
                    JournalEntry entry = new()
                    {
                        UserDefinedId = id,
                        //Addional Id for Client in case of duplicate UserDefinedId
                        RequestorId = ControllerContext.HttpContext.Connection.RemoteIpAddress.ToString(),
                        OperationName = ControllerContext.ActionDescriptor.ControllerName,
                        Calculation = calculation,
                        Timestamp = DateTime.UtcNow
                    };
                    _journal.AddToJournal(entry);
                    _logger.LogInformation($"Requested {ControllerContext.ActionDescriptor.ControllerName} added to Journal, id {id}");
                }

                return Ok(Result);
            }
            catch (Exception ex)
            {
                var response = new ObjectResult(new ErrorResponseModel() { ErrorCode = "InternalError", ErrorStatus = (int)HttpStatusCode.InternalServerError, ErrorMessage = "An unexpected error condition was triggered which made impossible to fulfill the request. Please try again later" })
                {
                    StatusCode = (int?)HttpStatusCode.InternalServerError
                };
                _logger.LogError($"Requested {ControllerContext.ActionDescriptor.ControllerName}", ex);
                return response;
            }
        }
        [NonAction]
        public ActionResult<Object> Post(Exception exception)
        {
            try
            {
                throw exception;
            }
            catch (OverflowException)
            {
                var errorCode = "Overflow";
                var response = new ObjectResult(new ErrorResponseModel() { ErrorCode = "Overflow", ErrorStatus = (int)HttpStatusCode.BadRequest, ErrorMessage = "The calculation generates an overflow condition" })
                {
                    StatusCode = (int?)HttpStatusCode.BadRequest
                };
                _logger.LogError($"Requested {ControllerContext.ActionDescriptor.ControllerName} - {errorCode}");
                return response;
            }
            catch (DivideByZeroException)
            {
                var errorCode = "DivideByZero";
                var response = new ObjectResult(new ErrorResponseModel() { ErrorCode = errorCode, ErrorStatus = (int)HttpStatusCode.BadRequest, ErrorMessage = "The calculation generates an divide by zero condition" })
                {
                    StatusCode = (int?)HttpStatusCode.BadRequest
                };
                _logger.LogError($"Requested {ControllerContext.ActionDescriptor.ControllerName} - {errorCode}");
                return response;
            }
            //Custom Exception
            catch (LessOperandsThanExpectedException)
            {
                var errorCode = "LessOperandsThanExpected";
                var response = new ObjectResult(new ErrorResponseModel() { ErrorCode = errorCode, ErrorStatus = (int)HttpStatusCode.BadRequest, ErrorMessage = "The calculation needs more operands" })
                {
                    StatusCode = (int?)HttpStatusCode.BadRequest
                };
                _logger.LogError($"Requested {ControllerContext.ActionDescriptor.ControllerName} - {errorCode}");
                return response;
            }
            //Custom Exception
            catch (NegativeRadicandException)
            {
                var errorCode = "NegativeRadicand";
                var response = new ObjectResult(new ErrorResponseModel() { ErrorCode = errorCode, ErrorStatus = (int)HttpStatusCode.BadRequest, ErrorMessage = "No negative radicands for the square root calculation are allowed" })
                {
                    StatusCode = (int?)HttpStatusCode.BadRequest
                };
                _logger.LogError($"Requested {ControllerContext.ActionDescriptor.ControllerName} - {errorCode}");
                return response;
            }
            catch (Exception ex)
            {
                var response = new ObjectResult(new ErrorResponseModel() { ErrorCode = "InternalError", ErrorStatus = (int)HttpStatusCode.InternalServerError, ErrorMessage = "An unexpected error condition was triggered which made impossible to fulfill the request. Please try again later" })
                {
                    StatusCode = (int?)HttpStatusCode.InternalServerError
                };
                _logger.LogError($"Requested {ControllerContext.ActionDescriptor.ControllerName}", ex);
                return response;
            }
        }
    }

    [Serializable]
    public class LessOperandsThanExpectedException : Exception
    {
        public LessOperandsThanExpectedException() { }
    }

    [Serializable]
    public class NegativeRadicandException : Exception
    {
        public NegativeRadicandException() { }
    }
}


