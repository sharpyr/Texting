using Texting.Enums;

namespace Texting.Bracket {
  public static class Brackets {
    public static string Parenth(this string x) => "(" + x + ")";
    public static string Bracket(this string x) => "[" + x + "]";
    public static string Brace(this string x) => "{" + x + "}";
    public static string AngleBr(this string x) => "<" + x + ">";
    public static string Br(this string text, Brac brac) {
      switch (brac) {
        case Brac.PAR: return "(" + text + ")";
        case Brac.BRK: return "[" + text + "]";
        case Brac.BRC: return "{" + text + "}";
        case Brac.ANG: return "<" + text + ">";
        case Brac.NAN: return text;
        default: return text;
      }
    }
  }
}