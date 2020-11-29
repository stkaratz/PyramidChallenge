using System.IO;
using System.Text;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace PyramidChallenge {
  /// <summary>
  /// Responsible for parsing a <see cref="Stream"/>
  /// </summary>
  public interface IInputParser {
    /// <summary>
    /// Parses a <see cref="Stream"/> into an <see cref="INode"/>
    /// </summary>
    /// <param name="input">The input <see cref="Stream"/></param>
    /// <param name="encoding">Encoding of the <see cref="Stream"/></param>
    Task<IParseResult> ParseAsync( Stream input, Encoding encoding = null );
  }
}
