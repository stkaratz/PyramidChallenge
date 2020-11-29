// ReSharper disable once CheckNamespace
namespace PyramidChallenge {
  /// <summary>
  /// Represents the result of an operation
  /// </summary>
  public interface IResult {
    /// <summary>
    /// Indication if the operation was successful
    /// </summary>
    bool Successful { get; }
    /// <summary>
    /// Message in case of error
    /// </summary>
    string Message { get; }
  }
}
