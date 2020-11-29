// ReSharper disable once CheckNamespace
namespace PyramidChallenge {
  /// <summary>
  /// The result of a parse operation
  /// </summary>
  public interface IParseResult: IResult {
    /// <summary>
    /// The representation of a parsed pyramid
    /// </summary>
    INode RootNode { get; }
  }
}
