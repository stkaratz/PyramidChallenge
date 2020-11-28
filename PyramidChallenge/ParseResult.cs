using PyramidChallenge.Interfaces;

namespace PyramidChallenge {
  public class ParseResult: IParseResult {
    public bool Successful { get; internal set; }
    public string Message { get; internal set; }
    public INode Result { get; internal set; }
  }
}
