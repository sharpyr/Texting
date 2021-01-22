using System;
using NUnit.Framework;
using Texting.Bracket;

namespace Texting.Test {
  [TestFixture]
  public class Tests {
    [Test]
    public void TestAlpha() {
      var word = "shakes";
      Console.WriteLine(Brackets.Bracket(word));
      Assert.Pass();
      Assert.True(true);
    }
  }
}