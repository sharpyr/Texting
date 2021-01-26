using System;

namespace Texting {
  public class Str {
    public static string Init(int len, Func<int, char> func) {
      var chars = new char[len];
      for (var i = 0; i < len; i++) chars[i] = func(i);
      return new string(chars);
    }
    public static string Iso(int len, char character) {
      var chars = new char[len];
      for (var i = 0; i < len; i++) chars[i] = character;
      return new string(chars);
    }
  }
}