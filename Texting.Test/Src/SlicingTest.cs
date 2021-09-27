using System.Text.RegularExpressions;
using NUnit.Framework;
using Spare;
using Veho;
using Veho.Vector;

namespace Texting.Test {
  public static partial class Candidates {
    public static readonly string[] ToBeDivided = {
      "foo bar zen",
      "foo  bar  zen",
      "foo, bar, zen, yid",
      "foo...bar...zen"
    };

    public static (string, string) Carve(this string tx, Regex reg) {
      var match = reg.Match(tx);
      var len = match.Length;
      return tx.Carve(len > 0 ? match.Index : -1, len);
    }
  }

  [TestFixture]
  public class SlicingTest {
    [Test]
    public static void SimpleTest() {
      var regex = new Regex(@"[,. ]+");
      string[] right = Candidates.ToBeDivided, left;
      for (var i = 0; i < 5; i++) {
        (left, right) = right.Map(tx => tx.Carve(regex)).Unwind();
        ("left:" + left.Deco() + " right: " + right.Deco()).Logger();
      }
    }
  }
}