namespace PyramidChallenge {
  /// <inheritdoc cref="IParseResult"/>
  public class ParseResult: IParseResult {
    /// <inheritdoc cref="IResult.Successful"/>
    public bool Successful { get; internal set; }
    /// <inheritdoc cref="IResult.Message"/>
    public string Message { get; internal set; } = string.Empty;
    /// <inheritdoc cref="IParseResult.RootNode"/>
    public INode RootNode { get; internal set; }
  }
}
