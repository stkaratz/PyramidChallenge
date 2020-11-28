using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyramidChallenge {
  public class SimpleInputParser: IInputParser {
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

      return new ParseResult { Successful = true, Result = root };
    }

    private async Task<(string error, int[][] result)> GetItemList( Stream stream, Encoding encoding ) {
      var parsed = new List<int[]>();
      using var sr = new StreamReader( stream, encoding ?? Encoding.UTF8 );
      var i = 0;
      while ( !sr.EndOfStream ) {
        var line = await sr.ReadLineAsync();
        var parts = line?.Split( ' ', StringSplitOptions.RemoveEmptyEntries ) ?? Array.Empty<string>();
        if ( parts.Length != ++i ) {
          return ($"Error on line {i}, expected numbers were {i} but were {parts.Length}.", null);
        }
        var numbers = parts
          .Select( p => int.TryParse( p, out var num ) ? (int?) num : null )
          .ToList();
        var notParsed = numbers.IndexOf( null );
        if ( notParsed > -1 ) {
          return ($"Error reading number on line {i} position {notParsed}.", null);
        }
        parsed.Add( numbers.OfType<int>().ToArray() );
      }
      return (string.Empty, parsed.ToArray());
    }
  }
}
