using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;
using Spare;
using Veho.Vector;

namespace Texting.Test {
  [TestFixture]
  public class DepriveBracketTest {
    [Test]
    public void Test2() {
      var candidates = new[] {
                               "R[1]C",
                               "R[1]C[16383]",
                               "RC[1]",
                               "R[1048575]C[1]",
                             };
      var regex = new Regex(@"(?<=[RC])(\[\d+\])?");
      var bracket = new Regex(@"[\[\]']+");
      foreach (var candidate in candidates) {
        var matches = regex.Matches(candidate);
        var pair = matches.OfType<Match>().ToArray();
        $"[matches #{matches.Count}] {pair.Deco()}".Logger();
        // var (rs, cs) = pair.T2();
        // var rt = bracketPattern.Replace(rs.Value, "");
        // var ct = bracketPattern.Replace(cs.Value, "");
        // var rb = int.TryParse(rt, out var ri);
        // var cb = int.TryParse(ct, out var ci);
        
        
        var rs = matches[0].Value;
        var cs = matches[1].Value;
        var rt = bracket.Replace(rs, "");
        var ct = bracket.Replace(cs, "");
        int.TryParse(rt, out var ri);
        int.TryParse(ct, out var ci);
        $"[ ({rs}), ({cs}) ] => ({ri}, {ci}) ".Logger();
      }
      "".Logger();

      foreach (var candidate in candidates) {
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