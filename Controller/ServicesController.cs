using Umbraco.Cms.Web.Common.Controllers;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Umbraco.Cms.Core.Web;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Umbraco.Cms.Web.Common.PublishedModels;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Umbraco.Cms.Web.Common.Controllers
{
    public class ServicesController : RenderController
    {
        private IPublishedValueFallback _publishedValueFallback;
        private readonly ILogger<RenderController> _logger;
        private static readonly HttpClient client = new();

        
        public ServicesController(
            ILogger<RenderController> logger,
            ICompositeViewEngine compositeViewEngine,
            IUmbracoContextAccessor umbracoContextAccessor,
            IPublishedValueFallback publishedValueFallback
            )
            : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
            _publishedValueFallback = publishedValueFallback;
            _logger = logger;
        }

        public override IActionResult Index()
        {
            // _logger.Log(LogLevel.Information, "From IActionResult Index()");

            var responseTask = client.GetStringAsync("http://localhost:8000/portalapp/api/services");

            string response = responseTask.Result;

            var result = JsonConvert.DeserializeObject<Dictionary<string, List<Dictionary<string, string>>>>(response);

            if (result == null)
            {
                return View("~/Views/Services.cshtml");
            }

            // Insert the data into the model
            var servicesList = new Services(CurrentPage, _publishedValueFallback);
            // ServicesList servicesList = new ServicesList(CurrentPage, _publishedValueFallback);

            Dictionary<string, string> tempDict;

            foreach (var listItem in result["san_services"])
            {
                tempDict = new Dictionary<string, string>
                {
                    ["service_id"] = listItem["service_id"],
                    ["service_name"] = listItem["service_name"],
                    ["service_desc"] = listItem["service_desc"]
                };
                servicesList.services["san_services"].Add(tempDict);
            }
            foreach (var listItem in result["hnas_services"])
            {
                tempDict = new Dictionary<string, string>
                {
                    ["service_id"] = listItem["service_id"],
                    ["service_name"] = listItem["service_name"],
                    ["service_desc"] = listItem["service_desc"]
                };
                servicesList.services["hnas_services"].Add(tempDict);
            }

            var loggingResponse = $"response data: {servicesList.services?["san_services"][0]["service_id"]}";

            _logger.Log(LogLevel.Information, loggingResponse);

            // _logger.Log(LogLevel.Information, CurrentPage?.Children?.ToString());


            // services.ServiceId

            return View("~/Views/Services.cshtml", servicesList);
        }

        public IActionResult HomePage()
        {
            _logger.Log(LogLevel.Information, "From IActionResult Homepage()");
            return CurrentTemplate(CurrentPage);
        }


        // public ServicesController(
        //     ILogger<RenderController> logger
        // )
        // {
        //     _logger = logger;
        // }

        // public ActionResult Index()
        // {

        //     var responseTask = client.GetStringAsync("http://localhost:8000/portalapp/api/services");

        //     string response = responseTask.Result;

        //     var result = JsonConvert.DeserializeObject<Dictionary<string, List<Dictionary<string, string>>>>(response);

        //     _logger.Log(LogLevel.Information, "[ServicesController]: Normal dotnet controller here!");

        //     return View("~/Views/Services.cshtml");
        // }
    }
}

