using System.Threading.Tasks;
using NUnit.Framework;

namespace PyramidChallenge.Test {
  [TestFixture]
  public class ResultTest {
    [Test]
    [TestCase( @"..\..\..\..\files\simple.txt", new[] { 1, 8, 5, 2 }, 16 )]
    [TestCase( @"..\..\..\..\files\complex.txt",
      new[] { 215, 192, 269, 836, 805, 728, 433, 528, 863, 632, 931, 778, 413, 310, 253 },
      8186 )]
    public async Task Test( string filePath, int[] result, int sum ) {
      var solver = Setup.GetPyramidSolver();
      var maxPath = await solver.SolveFileAsync( filePath );
      Assert.That( result, Is.EqualTo( maxPath.Path ) );
      Assert.AreEqual( sum, maxPath.Sum );
    }
  }
}
