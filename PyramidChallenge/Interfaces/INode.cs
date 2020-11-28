// ReSharper disable once CheckNamespace
namespace PyramidChallenge {
  /// <summary>
  /// Represents a node in the pyramid
  /// </summary>
  public interface INode {
    /// <summary>
    /// The integer value of the node/>
    /// </summary>
    int Value { get; }
    /// <summary>
    /// The child leaf on the left (directly below)
    /// </summary>
    INode Left { get; }
    /// <summary>
    /// The child leaf on the right
    /// </summary>
    INode Right { get; }
  }
}
