using PyramidChallenge.Interfaces;
using Unity;

namespace PyramidChallenge.Cli {
  public static class Bootstrapper {
    public static IUnityContainer Initialize() {
      var container = new UnityContainer();
      container.RegisterType<IInputParser, SimpleInputParser>();
      container.RegisterType<IPathFinder, SimplePathFinder>();
      container.RegisterType<IPyramidSolver, PyramidSolver>();
      return container;
    }
  }
}
