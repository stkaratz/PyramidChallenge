using CommandLine;

namespace PyramidChallenge.Cli {

  internal class Options {
    [Option( 'i', "input", Required = true, HelpText = "The input file representing a pyramid." )]
    public string Input { get; set; }
  }
}
