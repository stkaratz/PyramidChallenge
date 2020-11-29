using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PyramidChallenge.Test {
  [TestFixture]
  public class ParserTest {
    [Test]
    [TestCaseSource( typeof( FileTestCases ), nameof( FileTestCases.ValidFiles ) )]
    public async Task Valid( string inputFile, Encoding encoding ) {
      var parser = Setup.GetInputParser();
      var res = await parser.ParseAsync( StreamHelper.FromFile( inputFile ), encoding );
      Assert.IsEmpty( res.Message );
      Assert.IsTrue( res.Successful );
      Assert.NotNull( res.RootNode );

      var fileContent = await File.ReadAllTextAsync( inputFile );
      Assert.IsFalse( string.IsNullOrWhiteSpace( fileContent ) );

      var lines = fileContent
        .Split( Environment.NewLine )
        .Where( l => !string.IsNullOrWhiteSpace( l ) )
        .ToArray();

      //keeps track of the current level nodes
      var currentNodes = new[] { res.RootNode };
      Assert.AreEqual( int.Parse( lines[0] ), currentNodes[0].Value );

      //Going through all the line numbers and asserting to currentNodes
      for ( var i = 1; i < lines.Length; i++ ) {
        var nums = lines[i].Split( ' ', StringSplitOptions.RemoveEmptyEntries )
          .Select( int.Parse ).ToArray();
        for ( var j = 0; j < nums.Length; j++ ) {
          if ( i > j ) {
            Assert.AreEqual( nums[j], currentNodes[j].Left.Value );
          }
          if ( j > 0 ) {
            Assert.AreEqual( nums[j], currentNodes[j - 1].Right.Value );
          }
        }
        currentNodes = currentNodes
          .Select( n => n.Left )
          .Concat( new[] { currentNodes.Last().Right } )
          .ToArray();
      }
    }

    [Test]
    [TestCaseSource( typeof( FileTestCases ), nameof( FileTestCases.InvalidFiles ) )]
    public async Task Invalid( string inputFile, string error ) {
      var parser = Setup.GetInputParser();
      var res = await parser.ParseAsync( StreamHelper.FromFile( inputFile ) );
      Assert.IsFalse( res.Successful );
      Assert.IsNull( res.RootNode );
      Assert.AreEqual( error, res.Message );
    }

    [Test]
    public void NullArgument() {
      var parser = Setup.GetInputParser();
      Assert.ThrowsAsync<ArgumentNullException>( () => parser.ParseAsync( null ) );
    }
  }
}
