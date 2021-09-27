using System;
using System.Text.RegularExpressions;

namespace Texting {
  public static partial class Phrasing {
    public static Regex IniLow = new Regex(Phrasing.INILOW);
    public static Regex CapWord = new Regex(Phrasing.CAPWORD);
    public static Regex Word = new Regex(Phrasing.WORD);
    public static string Capitalize(this string s) {
      if (string.IsNullOrEmpty(s)) throw new ArgumentException("There is no first letter");
      var chars = s.ToCharArray();
      chars[0] = char.ToUpper(chars[0]);
      return new string(chars);
    }
    public static string CamelToSnake(this string phrase, string de = "-") {
      Match iniLow = IniLow.Match(phrase), capWord = CapWord.Match(phrase);
      var ph = "";
      if (iniLow.Success) ph = iniLow.Value.ToLower();
      else if (capWord.Success) ph = capWord.Value.ToLower();
      while ((capWord = capWord.NextMatch()).Success) ph += de + capWord.Value.ToLower();
      return ph;
    }
    public static string SnakeToCamel(this string phrase, string de = "") {
      Match m;
      var ph = "";
      if ((m = Word.Match(phrase)).Success) ph = m.Value.ToLower();
      while ((m = m.NextMatch()).Success) ph += de + m.Value.Capitalize();
      return ph;
    }
    public static string SnakeToPascal(this string phrase, string de = "") {
      Match m;
      var ph = "";
      if ((m = Word.Match(phrase)).Success) ph = m.Value.Capitalize();
      while ((m = m.NextMatch()).Success) ph += de + m.Value.Capitalize();
      return ph;
    }
  }
}