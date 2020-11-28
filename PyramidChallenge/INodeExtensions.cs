namespace PyramidChallenge {
  public static class INodeExtensions {
    public static bool IsEven( this INode node ) => node.Value % 2 == 0;

    public static bool IsEndNode( this INode node ) => node.Left is null && node.Right is null;

    public static bool CanGoLeft( this INode node ) => node.HaveDifferentParity( node.Left );
    public static bool CanGoRight( this INode node ) => node.HaveDifferentParity( node.Right );

    private static bool HaveDifferentParity( this INode node, INode other ) => node.IsEven() ^ other.IsEven();
  }
}
