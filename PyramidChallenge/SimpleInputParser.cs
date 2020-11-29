using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyramidChallenge {
  /// <inheritdoc cref="IInputParser"/>
  public class SimpleInputParser: IInputParser {
    /// <inheritdoc cref="IInputParser.ParseAsync"/>
    public async Task<IParseResult> ParseAsync( Stream input, Encoding encoding = null ) {
      if ( input == null ) {
        throw new ArgumentNullException( nameof( input ) );
      }

      var res = await GetItemList( input, encoding );
      if ( !string.IsNullOrEmpty( res.error ) ) {
        return new ParseResult { Message = res.error };
      }
      var nodes = res.result.Select( l => l.Select( n => new Node( n ) ).ToArray() ).ToArray();
      var root = nodes[0][0];
      //going through all the nodes and setting left and right
      for ( var i = 1; i < nodes.Length; i++ ) {
        for ( var j = 0; j < i + 1; j++ ) {
          var node = nodes[i][j];
          if ( i > j ) {
            nodes[i - 1][j].Left = node;
          }
          if ( j > 0 ) {
            nodes[i - 1][j - 1].Right = node;
          }
        }
      }

      return new ParseResult { Successful = true, RootNode = root };
    }

    private async Task<(string error, int[][] result)> GetItemList( Stream stream, Encoding encoding ) {
      var parsed = new List<int[]>();
      using var sr = new StreamReader( stream, encoding ?? Encoding.UTF8 );
      var textLine = 0;
      var parsedLine = 0;
      while ( !sr.EndOfStream ) {
        var line = await sr.ReadLineAsync();
        if ( string.IsNullOrWhiteSpace( line ) ) {
          textLine++;
          continue;
        }
        var parts = line.Split( ' ', StringSplitOptions.RemoveEmptyEntries );
        if ( parts.Length != parsedLine + 1 ) {
          return ($"Error on line {textLine}, expected numbers were {parsedLine + 1} but were {parts.Length}.", null);
        }
        var numbers = parts
          .Select( p => int.TryParse( p, out var num ) ? (int?) num : null )
          .ToList();
        var notParsed = numbers.IndexOf( null );
        if ( notParsed > -1 ) {
          return ($"Error reading number on line {textLine} position {notParsed}.", null);
        }
        parsed.Add( numbers.OfType<int>().ToArray() );
        textLine++;
        parsedLine++;
      }
      return (string.Empty, parsed.ToArray());
    }
  }
}
