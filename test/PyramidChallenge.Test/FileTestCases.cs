using System.Collections;
using System.Text;
using NUnit.Framework;

namespace PyramidChallenge.Test {
  public class FileTestCases {
    private static readonly string _simpleFile = @"..\..\..\..\files\simple.txt";
    private static readonly string _complexFile = @"..\..\..\..\files\complex.txt";
    private static readonly string _utf32File = @"..\..\..\..\files\utf32.txt";

    public static IEnumerable ValidFiles => new[] {
      new TestCaseData( _simpleFile, Encoding.UTF8 ),
      new TestCaseData( _complexFile, Encoding.UTF8 ),
      new TestCaseData( _utf32File, Encoding.UTF32 ),
    };

    public static IEnumerable FileResults => new[] {
      new TestCaseData( _simpleFile, new[] { 1, 8, 5, 2 }, 16 ),
      new TestCaseData( _complexFile,
        new[] { 215, 192, 269, 836, 805, 728, 433, 528, 863, 632, 931, 778, 413, 310, 253 },
        8186 )
    };
  }
}
