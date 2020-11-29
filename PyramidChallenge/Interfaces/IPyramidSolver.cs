using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PyramidChallenge.Interfaces {
  public interface IPyramidSolver {
    Task<IPyramidSolveResult> SolveAsync( Stream input, Encoding encoding = null );
  }
}
