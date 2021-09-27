using NUnit.Framework;
using Spare;

namespace Texting.Test {
  [TestFixture]
  public class StringDequeTest {
    // [Test]
    // public void Test() {
    //   const string text = ">>King_Richard_III.William_Shakespeare";
    //   text.Carve('.').ToVector().Deco().Logger();
    //   text.Carve("III").ToVector().Deco().Logger();
    //   text.Carve(">>").ToVector().Deco().Logger();
    // }
    [Test]
    public void PushPopTest() {
      var text = "1 + 2";
      (text = text.PushAt('2')).Logger();
      (text = text.PushAt('3')).Logger();
      (text = text.PopAt('2')).Logger();
      (text = text.PopAt('3')).Logger();
      (text = text.PopAt('2')).Logger();
    }
    [Test]
    public void ShiftUnshiftTest() {
      var text = "1 + 2";
      (text = text.UnshiftAt('1')).Logger();
      (text = text.UnshiftAt('=')).Logger();
      (text = text.ShiftAt('1')).Logger();
      (text = text.ShiftAt('=')).Logger();
      (text = text.ShiftAt('1')).Logger();
    }
  }
}