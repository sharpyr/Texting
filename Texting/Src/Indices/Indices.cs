using System;

namespace Texting.Indices {
  public static class Indices {
    public static int Loc(this string tx, string de) => tx.IndexOf(de, StringComparison.Ordinal);
    public static int FarLoc(this string tx, string de) => tx.LastIndexOf(de, StringComparison.Ordinal);
    public static char First(this string tx) => tx[0];
    public static char Last(this string tx) => tx[tx.Length - 1];
  }
}