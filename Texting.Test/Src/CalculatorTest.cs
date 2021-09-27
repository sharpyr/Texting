using System;
using System.Text.RegularExpressions;
using NUnit.Framework;
using Spare;
using Veho;
using static Palett.Presets;

namespace Texting.Test {
  [TestFixture]
  public class CalculatorTest {
    [Test]
    public void RipperTest() {
      var candidates = Seq.From(
        ("simple", "foo.bar"),
        ("dot", "foo.bar.zen.NASA.Lite.DB"),
        ("snake", "__foo_bar_zen_NASA_Lite_DB"),
        ("mixed", "FOOBarROCKAndROLL_NASALiteDB"),
        ("slashed", "foo/bar/zen/NASA/Lite/DB"),
        ("file", "foo.barZen10th-2022.pdf"),
        ("method", "sendHTTPRequestAsync "),
        ("numbers", "256.512.1024.2048"),
        ("url", "https://www.foo-bar.com/main?format=json&slice=20"),
        ("camel", "fooBarROCKAndROLL李白杜甫ZenNASALiteDB")
      );
      var regexLiteral = new Regex(@"[a-z]+|[A-Z][a-z]+|(?<=[a-z]|\W|_)[A-Z]+(?=[A-Z][a-z]|\W|_|$)|[\d]+[a-z]*", RegexOptions.Compiled);
      foreach (var (key, value) in candidates) {
        Console.WriteLine($">> [{key}] {regexLiteral.Ripper(value).Deco(presets: (Metro, Fresh))}");
      }
    }
  }
}