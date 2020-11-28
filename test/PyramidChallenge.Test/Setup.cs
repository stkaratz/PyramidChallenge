using PyramidChallenge.Interfaces;

namespace PyramidChallenge.Test {
  public static class Setup {
    public static IInputParser GetInputParser() => new SimpleInputParser();
    public static IPathFinder GetPathFinder() => new SimplePathFinder();
    public static IPyramidSolver GetPyramidSolver() => new PyramidSolver( GetInputParser(), GetPathFinder() );
  }
}
