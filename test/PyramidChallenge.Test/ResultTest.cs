using System.Threading.Tasks;
using NUnit.Framework;

namespace PyramidChallenge.Test {
  [TestFixture]
  public class ResultTest {
    //TODO: tests for invalid
    [Test]
    [TestCaseSource( typeof( FileTestCases ), nameof( FileTestCases.FileResults ) )]
    public async Task Test( string filePath, int[] result, int sum ) {
      var solver = Setup.GetPyramidSolver();
      var maxPath = await solver.SolveFileAsync( filePath );
      Assert.That( result, Is.EqualTo( maxPath.Path ) );
      Assert.AreEqual( sum, maxPath.Sum );
    }
  }
}
