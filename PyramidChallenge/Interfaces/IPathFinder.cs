using System.Collections.Generic;
using System.Threading.Tasks;
// ReSharper disable once CheckNamespace
namespace PyramidChallenge {
  /// <summary>
  /// Performs path operations in a pyramid
  /// </summary>
  public interface IPathFinder {
    /// <summary>
    /// Finds all paths available paths in a pyramid
    /// </summary>
    /// <param name="root">The pyramid representation</param>
    /// <returns>Available paths</returns>
    Task<IEnumerable<IEnumerable<int>>> FindPathsAsync( INode root );
    /// <summary>
    /// Calculates the path with the maximum sum
    /// </summary>
    /// <param name="paths">The paths to examine</param>
    /// <returns>The path with the maximum sum</returns>
    Task<(IEnumerable<int> Path, int Sum)> FindMaxPathAsync( IEnumerable<IEnumerable<int>> paths );
  }
}
