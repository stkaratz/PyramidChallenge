namespace PyramidChallenge {
  /// <summary>
  /// Extensions for <see cref="INode"/>
  /// </summary>
  public static class INodeExtensions {
    /// <summary>
    /// Indicates whether a <see cref="INode"/> is an even number
    /// </summary>
    public static bool IsEven( this INode node ) => node.Value % 2 == 0;
    /// <summary>
    /// Indicates whether a <see cref="INode"/> is an end node (no children)
    /// </summary>
    public static bool IsEndNode( this INode node ) => node.Left is null && node.Right is null;
    /// <summary>
    /// Indicates whether the path can continue to the <see cref="INode"/> left leaf (directly below)
    /// </summary>
    public static bool CanGoLeft( this INode node ) => node.HaveDifferentParity( node.Left );
    /// <summary>
    /// Indicates whether the path can continue to the <see cref="INode"/> right leaf
    /// </summary>
    public static bool CanGoRight( this INode node ) => node.HaveDifferentParity( node.Right );

    /// <summary>
    /// Indicates whether two nodes can be in a path next to each other
    /// </summary>
    /// <param name="node">Start node</param>
    /// <param name="other">Leaf node</param>
    private static bool HaveDifferentParity( this INode node, INode other ) => node.IsEven() ^ other.IsEven();
  }
}
