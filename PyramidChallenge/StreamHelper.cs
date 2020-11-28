using System.IO;
using System.Text;

namespace PyramidChallenge {
  public class StreamHelper {
    public Stream FromFile( string filePath ) {
      if ( !File.Exists( filePath ) ) {
        throw new FileNotFoundException( "File could not be found", filePath );
      }
      return new FileStream( filePath, FileMode.Open, FileAccess.Read );
    }

    public Stream FromString( string value, Encoding encoding = null ) =>
      new MemoryStream( ( encoding ?? Encoding.UTF8 ).GetBytes( value ) );
  }
}
