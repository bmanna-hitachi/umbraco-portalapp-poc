using Umbraco.Cms.Web.Common.Controllers;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Umbraco.Cms.Core.Web;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WASP.Controller
{
    public class ServicesController : RenderController
    {
        private readonly ILogger<RenderController> _logger;
        private static readonly HttpClient client = new();
        public ServicesController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor) : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
            _logger = logger;
        }

        public override IActionResult Index()
        {
            _logger.Log(LogLevel.Information, "From IActionResult Index()");

            var responseTask = client.GetStringAsync("http://localhost:8000/portalapp/api/services");

            string response = responseTask.Result;

            var result = JsonConvert.DeserializeObject<Dictionary<string, List<Dictionary<string, string>>>>(response);

            var loggingResponse = $"response data: {result?["san_services"][0]["service_id"]}";

            _logger.Log(LogLevel.Information, loggingResponse);

            return CurrentTemplate(CurrentPage);
        }

        public IActionResult HomePage()
        {
            _logger.Log(LogLevel.Information, "From IActionResult Homepage()");
            return CurrentTemplate(CurrentPage);
        }
    }
}

