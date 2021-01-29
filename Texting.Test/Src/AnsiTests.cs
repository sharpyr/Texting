using System;
using System.Text.RegularExpressions;
using NUnit.Framework;
using Spare.Logger;
using Texting.Charset;
using Veho.List;

namespace Texting.Test {
  public static class Candidates {
    public static string[] typical = new[] {
      "tora",
      "\u001B[4mcake\u001B[0m",
      "\u001b[38;2;255;255;85mTolstoy\u001b[0m",
      @"\u{1F4A9}",
      "𝐀",
      "I \u2661 STEAK",
      "\u001b[3;4;31mhatsu\u001b[0m",
      @"\u{1F3C3}2\u{1F525}7",
      "\u001B[0m\u001B[4m\u001B[42m\u001B[31mfoo\u001B[39m\u001B[49m\u001B[24mfoo\u001B[0m🦄bar"
    };
  }

  [TestFixture]
  public class AnsiTests {
    [Test]
    public static void SimpleTest() {
      string input = "1851 1999 1950 1905 2003";
      string pattern = @"(?<=19)\d{2}\b";
      var regex = new Regex(pattern);
      foreach (Match match in regex.Matches(input))
        Console.WriteLine(match.Value);
    }

    [Test]
    public void AnsiTest() {
      const string ESC = @"";
      const string CSI = @"";
      const string BEL = @"";
      const string ANSI_ALPHA = @"(?:(?:[a-zA-Z\d]*(?:;[-a-zA-Z\d\/#&.:=?%@~_]*)*)?)";
      const string ANSI_BETA = @"(?:(?:\d{1,4}(?:;\d{0,4})*)?[\dA-PR-TZcf-ntqry=><~])";
      const string ANSI_COMBINED = @"[][[\]()#;?]*(?:" + ANSI_ALPHA + "|" + ANSI_BETA + ")";
      // const string ASTRAL = /[\uD800-\uDBFF][\uDC00-\uDFFF]/
      var ansi = new Regex(ANSI_COMBINED);

      Candidates.typical.Iterate(x => {
        $"[{x}] [ansi] ({Charsets.Ansi.IsMatch(x)})".Logger();
      });
    }

    [Test]
    public void AstralTest() {
      // const string ASTRAL = "[\uD800-\uDBFF][\uDC00-\uDFFF]";
      // var ansi = new Regex(ASTRAL);

      Candidates.typical.Iterate(x => {
        $"[{x}] [astral] ({Charsets.Astral.IsMatch(x)})".Logger();
      });
    }

    [Test]
    public void AnsiTestBeta() {
      var alpha = @"[\u001B\u009B][[\]()#;?]*(?:(?:(?:[a-zA-Z\d]*(?:;[-a-zA-Z\d\/#&.:=?%@~_]*)*)?\u0007)";
      var beta = @"(?:(?:\d{1,4}(?:;\d{0,4})*)?[\dA-PR-TZcf-ntqry=><~]))";
      var ansi = new Regex(alpha + beta);
      Candidates.typical.Iterate(x => {
        $"[{x}] [ansi] ({Regex.IsMatch(x, alpha + beta)})".Logger();
      });
    }
  }
}