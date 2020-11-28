using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PyramidChallenge {
  public interface IInputParser {
    Task<INode> Parse( Stream input, Encoding encoding = null );
  }
}
