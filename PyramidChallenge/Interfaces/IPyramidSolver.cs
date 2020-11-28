using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PyramidChallenge.Interfaces {
  public interface IPyramidSolver {
    Task<(IEnumerable<int> Path, int Sum)> SolveAsync( Stream input, Encoding encoding = null );
  }
}
