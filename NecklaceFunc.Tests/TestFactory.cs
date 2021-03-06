using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using Azure.Storage.Blobs;

namespace NecklaceFunc.Tests;

public class TestFactory
{
    public static IEnumerable<object[]> Data()
    {
        return new List<object[]>
            {
                new object[] { "name", "Bill" },
                new object[] { "name", "Paul" },
                new object[] { "name", "Steve" }

            };
    }

    private static Dictionary<string, StringValues> CreateDictionary(string key, string value)
    {
        var qs = new Dictionary<string, StringValues>
            {
                { key, value }
            };
        return qs;
    }

    public static BlobContainerClient GetBlobContainerClient(string containerName = "$web")
    {
        var connectionString = "DefaultEndpointsProtocol=http;AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;";
        return new BlobContainerClient(connectionString, containerName);
    }

    public static HttpRequest CreateHttpRequest(string queryStringKey, string queryStringValue)
    {
        var context = new DefaultHttpContext();
        var request = context.Request;
        request.Query = new QueryCollection(CreateDictionary(queryStringKey, queryStringValue));
        return request;
    }

    public static ILogger CreateLogger(LoggerTypes type = LoggerTypes.Null)
    {
        ILogger logger;

        if (type == LoggerTypes.List)
        {
            logger = new ListLogger();
        }
        else
        {
            logger = NullLoggerFactory.Instance.CreateLogger("Null Logger");
        }

        return logger;
    }
}
