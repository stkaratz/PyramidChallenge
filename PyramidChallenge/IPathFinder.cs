﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace PyramidChallenge {
  public interface IPathFinder {
    Task<IEnumerable<IEnumerable<INode>>> FindPathsAsync( INode root );

    Task<(IEnumerable<INode> Path, int Sum)> FindMaxPathAsync( IEnumerable<IEnumerable<INode>> paths );
  }
}
