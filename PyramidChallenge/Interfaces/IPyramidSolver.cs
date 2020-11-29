using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PyramidChallenge.Interfaces {
  /// <summary>
  /// Represents the class that solves the pyramid challenge
  /// </summary>
  public interface IPyramidSolver {
    /// <summary>
    /// Gets a stream representing a pyramid and solves it
    /// </summary>
    /// <param name="input">The input stream</param>
    /// <param name="encoding">Encoding of the stream</param>
    /// <returns></returns>
    Task<IPyramidSolveResult> SolveAsync( Stream input, Encoding encoding = null );
  }
}
