using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace PyramidChallenge {
  /// <summary>
  /// Represents the result of solving a pyramid challenge
  /// </summary>
  public interface IPyramidSolveResult: IResult {
    /// <summary>
    /// The path with the maximum sum
    /// </summary>
    IEnumerable<int> Path { get; }
    /// <summary>
    /// The sum of the path
    /// </summary>
    int Sum { get; }
  }
}
