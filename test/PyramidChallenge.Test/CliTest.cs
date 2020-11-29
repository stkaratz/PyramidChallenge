using System;
using System.IO;
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
    public async Task ExceptionFileInUse() {
      await using var lockFile = new FileStream( FileTestCases.SimpleFile, FileMode.Open, FileAccess.ReadWrite );
      var res = await Program.Execute( FileTestCases.SimpleFile );
      Assert.AreEqual( $"Error: The process cannot access the file '{Path.GetFullPath( FileTestCases.SimpleFile )}' because it is being used by another process.",
        res );
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
