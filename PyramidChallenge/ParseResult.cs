namespace PyramidChallenge {
  public class ParseResult: IParseResult {
    public bool Successful { get; internal set; }
    public string Message { get; internal set; } = string.Empty;
    public INode RootNode { get; internal set; }
  }
}
