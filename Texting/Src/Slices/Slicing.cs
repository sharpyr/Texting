using Texting.Indices;

namespace Texting.Slices {
  public static class Slicing {
    public static string Slice(this string tx, int lo) => lo >= 0
      ? tx.Substring(lo, tx.Length - lo)
      : tx.Substring(tx.Length + lo, -lo);
    public static string Slice(this string tx, int lo, int len) => tx.Substring(lo, len);
    public static string End(this string tx, int hi) => tx.Substring(tx.Length - hi, hi);
    public static string Trim(this string tx, char left = '\"', char right = '\"') => tx.TrimStart(left).TrimEnd(right);
    public static string UnshiftAt(this string tx, char ch) => tx.Any() && tx.First() == ch ? tx : ch + tx;
    public static string ShiftAt(this string tx, char ch) => tx.Any() && tx.First() == ch ? tx.Post(0) : tx;
    public static string PushAt(this string tx, char ch) => tx.Any() && tx.Last() == ch ? tx : tx + ch;
    public static string PopAt(this string tx, char ch) => tx.Any() && tx.Last() == ch ? tx.Remove(tx.Length - 1) : tx;
    public static string Pre(this string tx, int i) => tx.Substring(0, i);
    public static string Post(this string tx, int i) => tx.Substring(++i, tx.Length - i);

    public static string Pre(this string tx, char ch) => tx.Pre(tx.IndexOf(ch));
    public static string Post(this string tx, char ch) => tx.Post(tx.IndexOf(ch));
    public static string FarPre(this string tx, char ch) => tx.Pre(tx.LastIndexOf(ch));
    public static string FarPost(this string tx, char ch) => tx.Post(tx.LastIndexOf(ch));

    public static string Pre(this string tx, string de) => tx.Pre(tx.Loc(de));
    public static string Post(this string tx, string de) => tx.Post(tx.Loc(de) + de.Length - 1);
    public static string FarPre(this string tx, string de) => tx.Pre(tx.FarLoc(de));
    public static string FarPost(this string tx, string de) => tx.Post(tx.FarLoc(de) + de.Length - 1);

    public static (string, string) Carve(this string tx, int i) => i >= 0
      ? (tx.Pre(i), tx.Post(i))
      : (tx, "");
    public static (string, string) Carve(this string tx, int lo, int wd) => lo >= 0
      ? (tx.Pre(lo), tx.Post(lo + wd - 1))
      : (tx, "");
    public static (string, string) Carve(this string tx, char ch) => tx.Carve(tx.IndexOf(ch));
    public static (string, string) FarCarve(this string tx, char ch) => tx.Carve(tx.LastIndexOf(ch));
    public static (string, string) Carve(this string tx, string de) => tx.Carve(tx.Loc(de), de.Length);
    public static (string, string) FarCarve(this string tx, string de) => tx.Carve(tx.FarLoc(de), de.Length);
  }
}