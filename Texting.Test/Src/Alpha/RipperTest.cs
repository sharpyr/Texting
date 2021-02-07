using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;
using Spare.Deco;
using Spare.Logger;
using Texting.Phrasing;
using Texting.Presets;

namespace Texting.Test.Alpha {
  public static class Candidates {
    public static Dictionary<string, string> Testables = new Dictionary<string, string> {
      {"onlyDash", "-._"},
      {"wsjSnake", "THE_WALL_STREET_JOURNAL"},
      {"nytPascal", "NewYorkTimesFW_2ND"},
      {"dorian", "theHurricaneDorianNE1passes"},
      {"initials", "A-B-C.BETA"},
      {"jdwKebab", "janes-defense-weekly"},
      {"cp2077", "THE_CYBER-PUNK.2077 cdpr"},
      {"dior", "ChristianDiorSS21"},
    };
  }

  [TestFixture]
  public class RipperTest {
    [Test]
    public void Test() {
      var candidates = new[] {
        "foo.bar.zen",
        "foo_bar_zen",
        "fooBarZen",
        "foo/bar/zen",
        "foo.barZen10th-2022.pdf",
        "https://www.foo-bar.com/main?format=json&slice=20",
      };
      var regex = new Regex(Phrasings.LITERAL);
      foreach (var candidate in candidates) {
        regex.Matches(candidate).OfType<Match>().ToArray().Deco().Logger();
        // .ToString().Logger();
      }
    }

    [Test]
    public void CamelToSnakeTest() {
      foreach (var kv in Candidates.Testables) {
        $"{kv.Key}: {kv.Value} -> {kv.Value.CamelToSnake()}".Logger();
      }
    }

    [Test]
    public void SnakeToCamelTest() {
      foreach (var kv in Candidates.Testables) {
        $"{kv.Key}: {kv.Value} -> {kv.Value.SnakeToCamel()}".Logger();
      }
    }

    [Test]
    public void SnakeToPascalTest() {
      foreach (var kv in Candidates.Testables) {
        $"{kv.Key}: {kv.Value} -> {kv.Value.SnakeToPascal()}".Logger();
      }
    }
  }
}