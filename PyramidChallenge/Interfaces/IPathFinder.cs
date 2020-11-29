using System.Collections.Generic;
using System.Threading.Tasks;
// ReSharper disable once CheckNamespace
namespace PyramidChallenge {
  public interface IPathFinder {
    Task<IEnumerable<IEnumerable<int>>> FindPathsAsync( INode root );

    Task<(IEnumerable<int> Path, int Sum)> FindMaxPathAsync( IEnumerable<IEnumerable<int>> paths );
  }
}
