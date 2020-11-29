using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PyramidChallenge.Test {
  [TestFixture]
  public class PathFinderTest {
    [Test]
    public async Task FindPaths() {
      var rootNode = await Parse( FileTestCases.SimpleFile );

      var pathFinder = Setup.GetPathFinder();
      var paths = await pathFinder.FindPathsAsync( rootNode );
      Assert.That( new[] {
          new[]{1, 8, 5, 2},
          new[]{1, 8, 1, 4}
        },
        Is.EquivalentTo( paths )
      );
    }

    [Test]
    [TestCaseSource( typeof( FileTestCases ), nameof( FileTestCases.Files ) )]
    public async Task ValidatePaths( string filePath ) {
      var rootNode = await Parse( filePath );

      var pathFinder = Setup.GetPathFinder();
      var paths = ( await pathFinder.FindPathsAsync( rootNode ) )
        .Select( p => p.ToArray() );

      foreach ( var path in paths ) {
        for ( int i = 1; i < path.Length; i++ ) {
          Assert.IsTrue( ( path[i] % 2 == 0 ) ^ ( path[i - 1] % 2 == 0 ) );
        }
      }
    }

    [Test]
    [TestCase( new[] {
        "3 1 4",
        "1 2 3",
        "4 3 2"
      },
      new[] { 4, 3, 2 }, 9 )]
    [TestCase( new[] {
        "35 44 18 90",
        "100 38 97 55",
        "99 90 50 50"
      },
      new[] { 100, 38, 97, 55 }, 290 )]
    //in case that paths have same path we select the first one
    [TestCase( new[] {
        "1 2 3",
        "3 2 1",
        "2 1 3"
      },
      new[] { 1, 2, 3 }, 6 )]
    public async Task FindMaxPath( IEnumerable<string> paths, int[] maxpath, int sum ) {
      var pathFinder = Setup.GetPathFinder();
      var res = await pathFinder.FindMaxPathAsync( paths.Select( p => p.Split( ' ' ).Select( int.Parse ) ) );
      Assert.AreEqual( sum, res.Sum );
      Assert.That( maxpath, Is.EqualTo( res.Path ) );
    }

    private static async Task<INode> Parse( string filePath ) {
      var parser = Setup.GetInputParser();
      await using var stream = StreamHelper.FromFile( filePath );
      var parseResult = await parser.ParseAsync( stream );
      Assert.IsEmpty( parseResult.Message );
      Assert.IsTrue( parseResult.Successful );
      Assert.NotNull( parseResult.RootNode );
      return parseResult.RootNode;
    }
  }
}
