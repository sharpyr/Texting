using System;
using NUnit.Framework;
using Texting.Joiner;
using Veho;
using Texting.Enums;

namespace Texting.Test {
  [TestFixture]
  public class JoinerTest {
    public static string[] Pastas = Vec.From(
      "conchiglie",
      "chifferi",
      "farfalle",
      "fusilli",
      "gnocchi",
      "lasagna",
      "linguine",
      "pennine",
      "ravioli",
      "spaghetti"
    );
    [Test]
    public void JoinerTestAlpha() {
      var text = Pastas.ContingentLines(delim: Strings.COLF, level: 0);
      Console.WriteLine($"[>> ContingentLines] ({text})");
    }
    [Test]
    public void JoinerTestBeta() {
      var text = Pastas.ContingentLines(delim: Strings.CO, level: 1);
      Console.WriteLine($"[>> ContingentLines] ({text})");
    }
    [Test]
    public void JoinerTestGamma() {
      var text = Pastas.ContingentLines(delim: Strings.LF, level: 2, brac: Brac.BRK);
      Console.WriteLine($"[>> ContingentLines] ({text})");
    }
    [Test]
    public void JoinerTestDelta() {
      var text = Pastas.ContingentLines(delim: Strings.SP, level: 0);
      Console.WriteLine($"[>> ContingentLines] ({text})");
    }
  }
}