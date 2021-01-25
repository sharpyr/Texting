namespace Texting.Bracket {
  public static class Brackets {
    public static string Parenth(this string x) => "(" + x + ")";
    public static string Bracket(this string x) => "[" + x + "]";
    public static string Brace(this string x) => "{" + x + "}";
    public static string AngleBr(this string x) => "<" + x + ">";
  }
}