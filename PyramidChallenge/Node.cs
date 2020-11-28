using System.Diagnostics;

namespace PyramidChallenge {
  /// <inheritdoc cref="INode"/>
  [DebuggerDisplay( "{Value}, Left: {Left?.Value}, Right: {Right?.Value}" )]
  public class Node: INode {
    /// <summary>
    /// Initializes a <see cref="Node"/> with a value
    /// </summary>
    /// <param name="value"></param>
    public Node( int value ) {
      Value = value;
    }

    /// <inheritdoc cref="INode.Value"/>
    public int Value { get; }
    /// <inheritdoc cref="INode.Left"/>
    public INode Left { get; internal set; }
    /// <inheritdoc cref="INode.Right"/>
    public INode Right { get; internal set; }
  }
}
