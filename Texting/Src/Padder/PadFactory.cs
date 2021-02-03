using System;
using Texting.Charset;
using Texting.Lange;
using Typen.Numeral;

namespace Texting.Padder {
  public static class PadFactory {
    public static int AnsiPadLen(this string tx, int pd) => tx.HasAnsi() ? tx.Length + pd - tx.Lange() : pd;

    public static string LPad(this string tx, int pd, char ch) => tx.PadLeft(pd, ch);
    public static string RPad(this string tx, int pd, char ch) => tx.PadRight(pd, ch);

    public static string LAnsiPad(this string tx, int pd, char ch) => tx.PadLeft(AnsiPadLen(tx, pd), ch);
    public static string RAnsiPad(this string tx, int pd, char ch) => tx.PadRight(AnsiPadLen(tx, pd), ch);

    public static Func<string, int, string> ToPad(char ch, bool ansi) => ansi
      ? (Func<string, int, string>) ((tx, pd) => tx.ClearAnsi().IsNumeric() ? tx.LAnsiPad(pd, ch) : tx.RAnsiPad(pd, ch))
      : (Func<string, int, string>) ((tx, pd) => tx.IsNumeric() ? tx.PadLeft(pd, ch) : tx.PadRight(pd, ch));

    public static Func<string, int, T, string> ToPad<T>(char ch, bool ansi) => ansi
      ? (Func<string, int, T, string>) ((tx, pd, v) => v.IsNumeric() ? tx.LAnsiPad(pd, ch) : tx.RAnsiPad(pd, ch))
      : (Func<string, int, T, string>) ((tx, pd, v) => v.IsNumeric() ? tx.PadLeft(pd, ch) : tx.PadRight(pd, ch));

    public static Func<string, int, string> ToLPad(char ch, bool ansi) => ansi
      ? (Func<string, int, string>) ((tx, pd) => tx.LAnsiPad(pd, ch))
      : (Func<string, int, string>) ((tx, pd) => tx.PadLeft(pd, ch));

    public static Func<string, int, string> ToRPad(char ch, bool ansi) => ansi
      ? (Func<string, int, string>) ((tx, pd) => tx.RAnsiPad(pd, ch))
      : (Func<string, int, string>) ((tx, pd) => tx.PadRight(pd, ch));
  }
}