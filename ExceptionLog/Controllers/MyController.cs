using CustomLogService.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExceptionLog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyController : BaseController
    {
        public MyController(ILoggerManager logger) : base(logger) { }

        //error using try catch
        [HttpGet]
        [Route("GetAllData")]
        public IActionResult GetAllData()
        {
            try
            {
                Logger.LogInfo("Initiate GetAllData method");
                dynamic a = new List<dynamic> {
                new
                {
                    Name = "Akash",
                    ID = 101
                },
                new
                {
                    Name = "Akash1",
                    ID = 102
                }
            };
                //throw new Exception("Custom exception");
                Logger.LogInfo("Data received");
                return Ok(a);
            }
            catch (Exception e)
            {
                Logger.LogError("Error : " + e);
                return BadRequest(e.Message);
            }
        }


        //error handling using custom middleware
        [HttpGet]
        [Route("GetAllDataCustom")]
        public IActionResult GetAllDataCustom()
        {
            Logger.LogInfo("Initiate GetAllData method");
            dynamic a = new List<dynamic> {
                new
                {
                    Name = "Akash",
                    ID = 101
                },
                new
                {
                    Name = "Akash1",
                    ID = 102
                }
            };
            throw new FormatException();
            //Logger.LogInfo("Data received");
            return Ok(a);
        }
    }


}
