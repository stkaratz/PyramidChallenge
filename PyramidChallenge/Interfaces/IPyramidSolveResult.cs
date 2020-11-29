using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace PyramidChallenge {
  public interface IPyramidSolveResult: IResult {
    IEnumerable<int> Path { get; }
    int Sum { get; }
  }
}
