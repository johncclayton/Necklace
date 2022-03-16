using CommandLine;

namespace FakeDataGen
{
    public class Options
    {
        [Option('a', "product-name", SetName = "local", Required = false, HelpText = "The name of the software product", Default = "myproduct")]
        public string ProductName { get; set; }

        [Option('n', "number-of-entries", SetName = "local", Required = false, HelpText = "The number of entries/items to create", Default = 100)]
        public int NumberOfEntries { get; set; }

        [Option('s', "gen-software-release", SetName = "local", Required = false, HelpText = "Generate fake data for the SoftwareRelease object", Default = true)]
        public bool GenSoftwareRelease { get; set; }
    }
}
