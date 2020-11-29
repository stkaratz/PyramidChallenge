using System.Collections.Generic;

namespace PyramidChallenge {
  public class Result: IPyramidSolveResult {
    public bool Successful { get; internal set; }
    public string Message { get; internal set; } = string.Empty;
    public IEnumerable<int> Path { get; internal set; }
    public int Sum { get; internal set; }
  }
}
