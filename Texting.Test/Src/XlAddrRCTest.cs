using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Aryth;
using NUnit.Framework;
using Spare;

namespace Texting.Test {
  [TestFixture]
  public class XlAddrRCTest {
    [Test]
    public void Test1() {
      var candidates = new[] {
                               "R[1]C",
                               "R[1]C[16383]",
                               "RC[1]",
                               "R[1048575]C[1]",
                             };
      var regex = new Regex(@"R(\[\d+\])?C(\[\d+\])?");
      foreach (var candidate in candidates) {
        var matches = regex.Matches(candidate);
        $"[matches #{matches.Count}] {matches.OfType<Match>().ToArray().Deco()}".Logger();
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

    [Test]
    public void Test2() {
      var candidates = new[] {
                               "R[1]C",
                               "R[1]C[16383]",
                               "RC[1]",
                               "R[1048575]C[1]",
                             };
      var regex = new Regex(@"(?<=[RC])(\[\d+\])?");
      foreach (var candidate in candidates) {
        var matches = regex.Matches(candidate);
        $"[matches #{matches.Count}] {matches.OfType<Match>().ToArray().Deco()}".Logger();
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

    [Test]
    public void Test3() {
      var candidates = new[] {
                               "R[1]C",
                               "R[1]C[16383]",
                               "RC[1]",
                               "R[1048575]C[1]",
                             };
      var regex = new Regex(@"(?:R)((?:\[)\d+(?:\]))?(?:C)((?:\[)\d+(?:\]))?");
      foreach (var candidate in candidates) {
        var matches = regex.Matches(candidate);
        $"[matches #{matches.Count}] {matches.OfType<Match>().ToArray().Deco()}".Logger();
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

    [Test]
    public void Test4() {
      var candidates = new[] {
                               "R[1]C",
                               "R[1]C[16383]",
                               "RC[1]",
                               "R[1048575]C[1]",
                             };
      var regex = new Regex(@"(?<=[RC])((?<=\[)\d+(?=\]))?");
      foreach (var candidate in candidates) {
        var matches = regex.Matches(candidate);
        $"[matches #{matches.Count}] {matches.OfType<Match>().ToArray().Deco()}".Logger();
      }
      "".Logger();

      foreach (var candidate in candidates) {
        candidate.Logger();
        var match = regex.Match(candidate);
        while (match.Success) {
          var groups = match.Groups;
          $"  [match] ({match.Success}) [groups #{groups.Count}] {groups.OfType<Group>().ToArray().Deco()}".Logger();
          foreach (var group in groups.OfType<Group>()) {
            var captures = group.Captures;
            $"    [captures #{captures.Count}] {captures.OfType<Capture>().ToArray().Deco()}".Logger();
          }
          match = match.NextMatch();
        }
      }
    }
  }
}