using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PyramidChallenge {
  public class SimplePathFinder: IPathFinder {
    public Task<IEnumerable<IEnumerable<int>>> FindPathsAsync( INode root ) =>
      Task.Run<IEnumerable<IEnumerable<int>>>( () => {
        var queue = new Queue<(IEnumerable<INode> Path, INode Current)>();
        queue.Enqueue( (new List<INode> { root }, root) );

        var paths = new List<IEnumerable<INode>>();
        while ( queue.Any() ) {
          var path = queue.Dequeue();
          if ( !path.Current.IsEndNode() ) {
            if ( path.Current.CanGoLeft() ) {
              queue.Enqueue( ContinuePath( path, path.Current.Left ) );
            }
            if ( path.Current.CanGoRight() ) {
              queue.Enqueue( ContinuePath( path, path.Current.Right ) );
            }
          }
          else {
            paths.Add( path.Path.ToArray() );
          }
        }
        return paths.Select( p => p.Select( x => x.Value ).ToArray() ).ToArray();
      } );

    public Task<(IEnumerable<int> Path, int Sum)>
      FindMaxPathAsync( IEnumerable<IEnumerable<int>> paths ) =>
      Task.Run<(IEnumerable<int> Path, int Sum)>( () => {
        var pathList = paths.Select( p => {
          var pArray = p.ToArray();
          return (
            Path: pArray,
            Sum: pArray.Sum()
          );
        } ).ToArray();
        var max = pathList.Max( p => p.Sum );
        return pathList.FirstOrDefault( p => p.Sum == max );
      } );

    private static (IEnumerable<INode> Path, INode Current) ContinuePath( (IEnumerable<INode> Path, INode Current) path,
      INode newNode ) =>
      (( path.Path ?? Enumerable.Empty<INode>() ).Concat( new[] { newNode } ), newNode);

  }
}
