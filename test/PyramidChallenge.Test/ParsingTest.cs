using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PyramidChallenge.Test {
  [TestFixture]
  public class ParsingTest {
    [Test]
    [TestCase( @"..\..\..\..\files\simple.txt", new[] { 1, 8, 5, 2 }, 16 )]
    [TestCase( @"..\..\..\..\files\complex.txt",
      new[] { 215, 192, 269, 836, 805, 728, 433, 528, 863, 632, 931, 778, 413, 310, 253 },
      8186 )]
    public async Task Test( string filePath, int[] result, int sum ) {
      await using var stream = new StreamHelper().FromFile( filePath );
      Assert.NotNull( stream );
      var root = await new SimpleInputParser().Parse( stream );
      Assert.NotNull( root );
      var pathFinder = new SimplePathFinder();
      var paths = await pathFinder.FindPathsAsync( root );
      var maxPath = await pathFinder.FindMaxPathAsync( paths );
      Assert.That( result, Is.EqualTo( maxPath.Path.Select( p => p.Value ) ) );
      Assert.AreEqual( sum, maxPath.Sum );
    }
  }
}
