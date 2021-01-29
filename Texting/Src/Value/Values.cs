using Texting.Slices;

namespace Texting.Value {
  public static class Values {
    public static int V1(this string word) => (word.ToLower()[0] & 0x7f) << 21;
    public static int V2(this string word) => (((word = word.ToLower())[0] & 0x7f) << 21) +
                                              ((word[1] & 0x7f) << 14);
    public static int V3(this string word) => (((word = word.ToLower())[0] & 0x7f) << 21) +
                                              ((word[1] & 0x7f) << 14) +
                                              ((word[2] & 0x7f) << 7);
    public static int V4(this string word) => (((word = word.ToLower())[0] & 0x7f) << 21) +
                                              ((word[1] & 0x7f) << 14) +
                                              ((word[2] & 0x7f) << 7) +
                                              (word[3] & 0x7f);
    public static double StringValue(this string word) {
      var l = word.Length;
      if (l >= 8) return (V4(word.Pre(4)) << 2) + V4(word.Slice(-4));
      switch (l) {
        case 7: return (V4(word.Pre(4)) << 2) + V3(word.Slice(-3));
        case 6: return (V4(word.Pre(4)) << 2) + V2(word.Slice(-2));
        case 5: return (V4(word.Pre(4)) << 2) + V1(word.Slice(-1));
        case 4: return V4(word) << 2;
        case 3: return V3(word) << 2;
        case 2: return V2(word) << 2;
        case 1: return V1(word) << 2;
        default: return double.NaN;
      }
    }
  }
}