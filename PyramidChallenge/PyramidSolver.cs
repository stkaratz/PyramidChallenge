﻿using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using PyramidChallenge.Interfaces;

namespace PyramidChallenge {
  /// <inheritdoc cref="IPyramidSolver"/>
  public class PyramidSolver: IPyramidSolver {
    private readonly IInputParser _parser;
    private readonly IPathFinder _pathFinder;
    public PyramidSolver( IInputParser parser, IPathFinder pathFinder ) {
      _parser = parser ?? throw new ArgumentNullException( nameof( parser ) );
      _pathFinder = pathFinder ?? throw new ArgumentNullException( nameof( pathFinder ) );
    }

    /// <inheritdoc cref="IPyramidSolver.SolveAsync"/>
    public async Task<IPyramidSolveResult> SolveAsync( Stream input, Encoding encoding = null ) {
      var res = await _parser.ParseAsync( input, encoding );
      if ( !res.Successful ) {
        return new Result {
          Message = res.Message
        };
      }
      var paths = await _pathFinder.FindPathsAsync( res.RootNode );
      var maxPath = await _pathFinder.FindMaxPathAsync( paths );
      return new Result {
        Successful = true,
        Path = maxPath.Path,
        Sum = maxPath.Sum
      };
    }
  }
}
