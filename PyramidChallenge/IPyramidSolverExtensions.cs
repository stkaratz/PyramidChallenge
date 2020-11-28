using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PyramidChallenge.Interfaces;

namespace PyramidChallenge {
  public static class IPyramidSolverExtensions {
    public static async Task<(IEnumerable<int> Path, int Sum)> SolveFileAsync(
      this IPyramidSolver solver,
      string filePath,
      Encoding encoding = null ) {
      await using var stream = StreamHelper.FromFile( filePath );
      return await solver.SolveAsync( stream, encoding );
    }

    public static async Task<(IEnumerable<int> Path, int Sum)> SolveStringAsync(
      this IPyramidSolver solver,
      string value,
      Encoding encoding = null ) {
      await using var stream = StreamHelper.FromString( value );
      return await solver.SolveAsync( stream, encoding );
    }
  }
}
