using System.Collections;
using System.IO;
using System.Text;
using NUnit.Framework;

namespace PyramidChallenge.Test {
  public class FileTestCases {
    private static string TestFile( string fileName ) => Path.Combine( @"..\..\..\..\files\", fileName );
    private static readonly string _simpleFile = TestFile( "simple.txt" );
    private static readonly string _complexFile = TestFile( "complex.txt" );
    private static readonly string _utf32File = TestFile( "utf32.txt" );
    private static readonly string _extralines = TestFile( "extralines.txt" );

    private static readonly string _wronglinenumbers = TestFile( "wronglinenumbers.txt" );
    private static readonly string _wronglinenumbers_emptyLines = TestFile( "wronglinenumbers_emptylines.txt" );
    private static readonly string _invalidnumber_char = TestFile( "invalidnumber_char.txt" );
    private static readonly string _invalidnumber_decimal = TestFile( "invalidnumber_decimal.txt" );

    public static IEnumerable ValidFiles => new[] {
      new TestCaseData( _simpleFile, Encoding.UTF8 ),
      new TestCaseData( _complexFile, Encoding.UTF8 ),
      new TestCaseData( _utf32File, Encoding.UTF32 ),
      new TestCaseData( _extralines, Encoding.UTF8 ),
    };

    public static IEnumerable InvalidFiles => new[] {
      new TestCaseData( _wronglinenumbers, "Error on line 1, expected numbers were 2 but were 3." ),
      new TestCaseData( _wronglinenumbers_emptyLines, "Error on line 5, expected numbers were 3 but were 4." ),
      new TestCaseData( _invalidnumber_char, "Error reading number on line 2 position 2." ),
      new TestCaseData( _invalidnumber_decimal, "Error reading number on line 2 position 1." ),
    };

    public static IEnumerable FileResults => new[] {
      new TestCaseData( _simpleFile, new[] { 1, 8, 5, 2 }, 16 ),
      new TestCaseData( _complexFile,
        new[] { 215, 192, 269, 836, 805, 728, 433, 528, 863, 632, 931, 778, 413, 310, 253 },
        8186 )
    };
  }
}
