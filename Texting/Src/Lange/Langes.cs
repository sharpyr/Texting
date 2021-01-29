using Texting.Charset;

namespace Texting.Lange {
  public static class Langes {
    public static int Lange(this string tx) => tx.ClearAnsi().ClearAstral().Length;
  }
}