using CommandLine;

namespace PyramidChallenge.Cli {

  internal class Options {
    [Option( 'i', "input", Required = true, HelpText = "The input file representing a pyramid." )]
    public string Input { get; set; }

    [Option( 'v', "verbose", Default = false, HelpText = "Prints all messages to standard output." )]
    public bool Verbose { get; set; }
  }
}
