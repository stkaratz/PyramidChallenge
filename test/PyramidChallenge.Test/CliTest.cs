using System;
using System.Threading.Tasks;
using NUnit.Framework;
using PyramidChallenge.Cli;

namespace PyramidChallenge.Test {
  [TestFixture]
  public class CliTest {
    [Test]
    public async Task InvalidFile() {
      var res = await Program.Execute( "xxx" );
      Assert.AreEqual( "Input file \"xxx\" not found.", res );
    }

    [Test]
    public async Task EmptyFile() {
      var res = await Program.Execute( string.Empty );
      Assert.AreEqual( "Input file was empty.", res );
    }

    [Test]
    [TestCaseSource( typeof( FileTestCases ), nameof( FileTestCases.FileResults ) )]
    public async Task Successful( string filePath, int[] result, int sum ) {
      var res = await Program.Execute( filePath );

      Assert.AreEqual( $"Max Path:{Environment.NewLine}{string.Join( "->", result )}{Environment.NewLine}Sum: {sum}", res );
    }

    [Test]
    [TestCaseSource( typeof( FileTestCases ), nameof( FileTestCases.InvalidFiles ) )]
    public async Task Unsuccessful( string filePath, string error ) {
      var res = await Program.Execute( filePath );
      Assert.AreEqual( error, res );
    }
  }
}
