using System.Text;
using System.Threading.Tasks;
using PyramidChallenge.Interfaces;

namespace PyramidChallenge {
  public static class IPyramidSolverExtensions {
    /// <summary>
    /// Gets a file path representing a pyramid and solves it
    /// </summary>
    /// <param name="filePath">the file path</param>
    /// <param name="encoding">the file encoding (default UTF-8)</param>
    public static async Task<IPyramidSolveResult> SolveFileAsync(
      // ReSharper disable once InvalidXmlDocComment
      this IPyramidSolver solver,
      string filePath,
      Encoding encoding = null ) {
      await using var stream = StreamHelper.FromFile( filePath );
      return await solver.SolveAsync( stream, encoding );
    }

    /// <summary>
    /// Gets a string representing a pyramid and solves it
    /// </summary>
    /// <param name="value">the file path</param>
    /// <param name="encoding">the file encoding (default UTF-8)</param>
    public static async Task<IPyramidSolveResult> SolveStringAsync(
      this IPyramidSolver solver,
      string value,
      Encoding encoding = null ) {
      await using var stream = StreamHelper.FromString( value );
      return await solver.SolveAsync( stream, encoding );
    }
  }
}
