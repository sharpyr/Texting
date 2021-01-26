using System;
using System.Text;
using NUnit.Framework;
using Spare.Deco;

namespace Texting.Test.Alpha {
  [TestFixture]
  public class CharTest {
    [Test]
    public void SomeTest() {
      var value = "9quali52ty3";
      var asciiBytes = Encoding.ASCII.GetBytes(value);
      Console.WriteLine(asciiBytes);
      Console.WriteLine(asciiBytes.Deco());
    }
  }
}