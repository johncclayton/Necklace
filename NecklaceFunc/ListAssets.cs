using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace Necklace
{
    public static class ListAssets
    {
        [FunctionName("ListAssets")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [Blob("$web")] BlobContainerClient container,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request to LIST THE ASSETS.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            //name = name ?? data?.name;

            // when using Environment to get auth. 
            //string connectionString = Environment.GetEnvironmentVariable("AzureWebJobsStorage");
            //var container = new BlobContainerClient(connectionString, "$web");

            // use the Blob SDK to read out a list of all the files we've got, then pump this into the code 
            Queue<string> prefixes = new Queue<string>();
            prefixes.Enqueue("");

            List<string> directoryNames = new List<string>();
            List<string> fileNames = new List<string>();

            do
            {
                string prefix = prefixes.Dequeue();
                await foreach (BlobHierarchyItem blobHierarchyItem in container.GetBlobsByHierarchyAsync(prefix: prefix, delimiter: "/"))
                {
                    if (blobHierarchyItem.IsPrefix)
                    {
                        directoryNames.Add(blobHierarchyItem.Prefix);
                        prefixes.Enqueue(blobHierarchyItem.Prefix);
                    }
                    else
                    {
                        fileNames.Add(blobHierarchyItem.Blob.Name); 
                    }
                }
            } while (prefixes.Count > 0);

            string allNames = string.Join(", ", fileNames);
            string responseMessage = $"we found these names: {allNames}"; 

            return new OkObjectResult(responseMessage);
        }
    }
}
