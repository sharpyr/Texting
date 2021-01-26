namespace Texting {
  public static class Indices {
    public static char First(this string tx) => tx[0];

    public static char Last(this string tx) => tx[tx.Length - 1];
  }
}