// ReSharper disable once CheckNamespace
namespace PyramidChallenge {
  public interface IParseResult {
    bool Successful { get; }
    string Message { get; }
    INode Result { get; }
  }
}
