using System;

namespace Texting {
  public class Str {
    public static string Init(int len, Func<int, char> fn) {
      var chars = new char[len];
      for (var i = 0; i < len; i++) chars[i] = fn(i);
      return new string(chars);
    }
    public static string Iso(int len, char ch) {
      var chars = new char[len];
      for (var i = 0; i < len; i++) chars[i] = ch;
      return new string(chars);
    }
  }
}