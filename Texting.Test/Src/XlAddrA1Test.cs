using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;
using Spare;

namespace Texting.Test {
  [TestFixture]
  public class XlAddrTest {
    private static readonly string[] CANDIDATES = {
                                                    "A2",
                                                    "Z1",
                                                    "AA1",
                                                    "AZ1",
                                                    "XFD2",
                                                    "B1",
                                                    "B1048576",
                                                  };
    [Test]
    public void Test() {
      var regex = new Regex(@"([A-Za-z]+)(\d+)");
      foreach (var candidate in CANDIDATES) {
        var matches = regex.Matches(candidate);
        $"[matches #{matches.Count}] {matches.OfType<Match>().ToArray().Deco()}".Logger();
      }
      "".Logger();

      foreach (var candidate in CANDIDATES) {
        var groups = regex.Match(candidate).Groups;
        var rt = groups[1].Value;
        var ct = groups[2].Value;
        var ri = AlphabetToInt(rt) - 1;
        var ci = int.Parse(ct) - 1;
        $"  [match] ({rt},{ct}) => ({ri},{ci})".Logger();
      }
      return;

      int AlphabetToInt(string text) {
        var n = 0;
        foreach (var ch in text) {
          var d = ch & 0x1F;
          n *= 26;
          n += d;
        }
        return n;
      }
    }

    [Test]
    public void Test2() {
      var regex = new Regex(@"([A-Za-z]+)(\d+)");
      foreach (var candidate in CANDIDATES) {
        var matches = regex.Matches(candidate);
        $"[matches #{matches.Count}] {matches.OfType<Match>().ToArray().Deco()}".Logger();
      }
      "".Logger();

      foreach (var candidate in CANDIDATES) {
        var match = regex.Match(candidate);
        var groups = match.Groups;
        $"  [match] ({match.Success}) [groups #{groups.Count}] {groups.OfType<Group>().ToArray().Deco()}".Logger();
        foreach (var group in groups.OfType<Group>()) {
          var captures = group.Captures;
          $"    [captures #{captures.Count}] {captures.OfType<Capture>().ToArray().Deco()}".Logger();
        }
      }
    }
  }
}