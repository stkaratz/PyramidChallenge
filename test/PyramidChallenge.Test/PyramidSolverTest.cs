using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PyramidChallenge.Test {
  [TestFixture]
  public class PyramidSolverTest {
    [Test]
    [TestCaseSource( typeof( FileTestCases ), nameof( FileTestCases.FileResults ) )]
    public async Task Successful( string filePath, int[] result, int sum ) {
      var solver = Setup.GetPyramidSolver();
      var res = await solver.SolveFileAsync( filePath );
      Assert.IsEmpty( res.Message );
      Assert.IsTrue( res.Successful );
      Assert.That( result, Is.EqualTo( res.Path ) );
      Assert.AreEqual( sum, res.Sum );
    }

    [Test]
    [TestCaseSource( typeof( FileTestCases ), nameof( FileTestCases.InvalidFiles ) )]
    public async Task Unsuccessful( string filePath, string error ) {
      var solver = Setup.GetPyramidSolver();
      var res = await solver.SolveFileAsync( filePath );
      Assert.IsFalse( res.Successful );
      Assert.IsNull( res.Path );
      Assert.AreEqual( error, res.Message );
    }

    [Test]
    public void NullArgument() {
      var solver = Setup.GetPyramidSolver();
      Assert.ThrowsAsync<ArgumentNullException>( () => solver.SolveAsync( null ) );
    }
  }
}
