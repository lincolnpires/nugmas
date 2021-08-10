using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Nugmas.FunctionSite
{
    public static class Home
    {
        [FunctionName("Home")]
        public static async Task<IActionResult> RunAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]
            HttpRequest req,
            ExecutionContext context,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var wwwroot = context.FunctionAppDirectory;
            var stream = File.OpenRead($"{wwwroot}/index.html");
            var result = new FileStreamResult(stream, "text/html");
            return result;
        }
    }
}
