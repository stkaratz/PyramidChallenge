// ReSharper disable once CheckNamespace
namespace PyramidChallenge {
  public interface IParseResult: IResult {
    INode RootNode { get; }
  }
}
