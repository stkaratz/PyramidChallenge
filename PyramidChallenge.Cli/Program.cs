using System;
using System.IO;
using System.Threading.Tasks;
using CommandLine;
using PyramidChallenge.Interfaces;
using Unity;

namespace PyramidChallenge.Cli {
  public class Program {
    private static async Task Main( string[] args ) =>
      await new Parser( s => s.HelpWriter = Console.Out )
        .ParseArguments<Options>( args )
        .WithParsedAsync( async opts => Console.WriteLine( await Execute( opts.Input ) ) );

    public static async Task<string> Execute( string filePath ) {
      if ( string.IsNullOrWhiteSpace( filePath ) ) {
        return "Input file was empty.";
      }

      if ( !File.Exists( filePath ) ) {
        return $"Input file \"{filePath}\" not found.";
      }

      using var container = Bootstrapper.Initialize();
      var solver = container.Resolve<IPyramidSolver>();
      try {
        var result = await solver.SolveFileAsync( filePath );
        if ( !result.Successful ) {
          return result.Message;
        }
        return
            $"Max Path:{Environment.NewLine}{string.Join( "->", result.Path )}{Environment.NewLine}Sum: {result.Sum}";
      }
      catch ( Exception ex ) {
        return $"Error: {ex.Message}";
      }
    }
  }
}
