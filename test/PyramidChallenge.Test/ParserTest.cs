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
      Assert.NotNull( res.Result );

      var fileContent = await File.ReadAllTextAsync( inputFile );
      Assert.IsFalse( string.IsNullOrWhiteSpace( fileContent ) );

      var lines = fileContent.Split( Environment.NewLine );

      //keeps track of the current level nodes
      var currentNodes = new[] { res.Result };
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

      //TODO: tests for invalid inputs (wrong characters), (wrong number of numbers) etc

      //TODO: test for empty lines
    }
  }
}
