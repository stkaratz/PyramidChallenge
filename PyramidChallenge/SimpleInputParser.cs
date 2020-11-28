using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyramidChallenge {
  public class SimpleInputParser: IInputParser {
    public async Task<INode> ParseAsync( Stream input, Encoding encoding = null ) {
      if ( input == null ) {
        throw new ArgumentNullException( nameof( input ) );
      }

      var lines = await GetItemList( input, encoding );
      var nodes = lines.Select( l => l.Select( n => new Node( n ) ).ToArray() ).ToArray();
      var root = nodes[0][0];
      for ( int i = 1; i < lines.Length; i++ ) {
        for ( int j = 0; j < i + 1; j++ ) {
          var node = nodes[i][j];
          if ( i > j ) {
            nodes[i - 1][j].Left = node;
          }
          if ( j > 0 ) {
            nodes[i - 1][j - 1].Right = node;
          }
        }
      }

      return root;
    }

    private async Task<int[][]> GetItemList( Stream stream, Encoding encoding = null ) {
      var parsed = new List<int[]>();
      using var sr = new StreamReader( stream, encoding ?? Encoding.UTF8 );
      var i = 0;
      while ( !sr.EndOfStream ) {
        var line = await sr.ReadLineAsync();
        var parts = line?.Split( ' ', StringSplitOptions.RemoveEmptyEntries ) ?? Array.Empty<string>();
        if ( parts.Length != ++i ) {
          throw new Exception( $"Error on line {i}, expected numbers were {i} but were {parts.Length}." );
        }
        var numbers = parts
          .Select( p => int.TryParse( p, out var num ) ? (int?) num : null )
          .ToList();
        var notParsed = numbers.IndexOf( null );
        if ( notParsed > -1 ) {
          throw new Exception( $"Error reading number on line {i} position {notParsed}" );
        }
        parsed.Add( numbers.OfType<int>().ToArray() );
      }
      return parsed.ToArray();
    }
  }
}
