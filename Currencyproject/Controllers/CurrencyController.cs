using Currencyproject.Client.Helpers;
using CurrencyProject.BusinessEntities.ResponseDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;



namespace Currencyproject.Client.Controllers
{
    public class CurrencyController : Controller
    {
        private readonly ILogger<CurrencyController> _logger;
        public CurrencyController(ILogger<CurrencyController> logger)
        {
            _logger = logger;
        }
        public IActionResult List()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllCurrency()
        {
            try
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory() + @"\wwwroot\lib\CurrencyJson\", "CurrencyData.json");
                using (StreamReader sourceReader = System.IO.File.OpenText(filePath))
                {
                    var clientHandler = new WebClient();
                    var Apiresponse = clientHandler.DownloadString(filePath);

                    if (!string.IsNullOrEmpty(Apiresponse))
                    {
                        var response = JsonConvert.DeserializeObject<List<CurrencyMaster>>(Apiresponse);
                        return Json(new { data = response });
                    }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message + " " + exp.StackTrace);
            }
            return Json(new { data = "" });
        }
    }
}
