using CommandLine;
using System.Linq;
using System.Collections.Generic;
using DataModels.Models;
using Bogus;
using Bogus.Extensions;
using System.Text.Json;
using System.Threading.Channels;

namespace FakeDataGen
{
    class Program
    {
        static void Main(string[] args)
        {
            // lets make data generation a bit more deterministic
            Randomizer.Seed = new Random(1338);

            // By default, if no args given, print help
            if (args.Count() == 0)
            {
                args = new string[] { "--help" };
            }
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(Run)
                .WithNotParsed(HandleParseError);
        }

        private static void HandleParseError(IEnumerable<Error> obj)
        {
            obj.Output();
        }

        static void Run(Options opts)
        {
            if (opts.GenSoftwareRelease)
                GenerateSoftwareReleaseData(opts);
            
        }

        private static void GenerateSoftwareReleaseData(Options opts)
        {
            /*
             * What I need is to product a series of version numbers, between "start version" and "end version",
             * and the date/times should grow a random bit between all these versions. 
             * 
             * What is most important is that the versions increase over time, the version numbers should also belong
             * to a potentially different channel.  
             * 
             * If shipping a beta version, then the major or minor version number should increase compared to what is in
             * the stable channel.  So having a full history of shipping a beta, then converting that to stable, then 
             * having more betas, converting those to stable and so on - would be excellent. 
             * 
             * E.g.
             *  1.0.0       beta        (1 beta release)
             *  1.0.1       beta        (2 beta releases)
             *  1.0.0       stable      (1 stable, 1 beta release)
             *  1.0.1       delete      (1 stable release)
             *  1.1.0       stable      (2 stable releases)
             *  
             *  Conclusion: I shall test that via unit tests. The data generation is only here in order to test 
             *  fetching of HUNDREDS of records and to ensure that the DAPR API does in fact work - not to test logical completness.
             */

            var softwareFaker = new Faker<SoftwareRelease>()
                .CustomInstantiator(f =>
               new SoftwareRelease(
                   f.Random.Guid(),
                   ProductName:opts.ProductName,
                   Channel: "stable",
                   Description: f.Commerce.ProductAdjective(),
                   Created: f.Date.Past()
                   ));

            var data = softwareFaker.Generate(opts.NumberOfEntries);
            Console.WriteLine(JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true }));
        }
    }
}