using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PyramidChallenge.Interfaces;

namespace PyramidChallenge {
  public class PyramidSolver: IPyramidSolver {
    private readonly IInputParser _parser;
    private readonly IPathFinder _pathFinder;

    public PyramidSolver( IInputParser parser, IPathFinder pathFinder ) {
      _parser = parser ?? throw new ArgumentNullException( nameof( parser ) );
      _pathFinder = pathFinder ?? throw new ArgumentNullException( nameof( pathFinder ) );
    }

    public async Task<(IEnumerable<int> Path, int Sum)> SolveAsync( Stream input, Encoding encoding = null ) {
      var root = await _parser.ParseAsync( input, encoding );
      var paths = await _pathFinder.FindPathsAsync( root );
      var maxPath = await _pathFinder.FindMaxPathAsync( paths );
      return (maxPath.Path.Select( p => p.Value ).ToArray(), maxPath.Sum);
    }
  }
}
