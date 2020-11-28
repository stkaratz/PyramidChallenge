using System.IO;
using System.Text;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace PyramidChallenge {
  public interface IInputParser {
    Task<INode> ParseAsync( Stream input, Encoding encoding = null );
  }
}
