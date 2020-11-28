using System.Collections.Generic;
using System.Threading.Tasks;
// ReSharper disable once CheckNamespace
namespace PyramidChallenge {
  public interface IPathFinder {
    Task<IEnumerable<IEnumerable<INode>>> FindPathsAsync( INode root );

    //TODO: this should be moved somewhere else?
    Task<(IEnumerable<INode> Path, int Sum)> FindMaxPathAsync( IEnumerable<IEnumerable<INode>> paths );
  }
}
