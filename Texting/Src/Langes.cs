using System;

namespace Texting {
  public static class Langes {
    public static int Lange(this string tx) => tx.ClearAnsi().ClearAstral().Length;

    public static Func<string, int> ToLange(bool ansi) => ansi
      ? (Func<string, int>) Lange
      : x => x.Length;
  }
}