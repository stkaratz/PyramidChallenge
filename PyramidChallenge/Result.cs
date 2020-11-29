using System.Collections.Generic;

namespace PyramidChallenge {
  /// <inheritdoc cref="IPyramidSolveResult"/>
  public class Result: IPyramidSolveResult {
    /// <inheritdoc cref="IResult.Successful"/>
    public bool Successful { get; internal set; }
    /// <inheritdoc cref="IResult.Message"/>
    public string Message { get; internal set; } = string.Empty;
    /// <inheritdoc cref="IPyramidSolveResult.Path"/>
    public IEnumerable<int> Path { get; internal set; }
    /// <inheritdoc cref="IPyramidSolveResult.Sum"/>
    public int Sum { get; internal set; }
  }
}
