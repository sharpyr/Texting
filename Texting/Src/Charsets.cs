using System.Text.RegularExpressions;

namespace Texting {
  public static class Charsets {
    // public const string ESC = @"";
    // public const string CSI = @"";
    // public const string BEL = @"";

    private const string ANSI_ALPHA = @"(?:(?:[a-zA-Z\d]*(?:;[-a-zA-Z\d\/#&.:=?%@~_]*)*)?)";
    private const string ANSI_BETA = @"(?:(?:\d{1,4}(?:;\d{0,4})*)?[\dA-PR-TZcf-ntqry=><~])";
    public const string ANSI = @"[][[\]()#;?]*(?:" + ANSI_ALPHA + "|" + ANSI_BETA + ")";
    public const string ASTRAL = "[\uD800-\uDBFF][\uDC00-\uDFFF]";
    public const string HAN = "[\u4e00-\u9fa5]|[\uff00-\uffff]";

    public static readonly Regex Ansi = new Regex(ANSI, RegexOptions.Compiled);
    public static readonly Regex Astral = new Regex(ASTRAL, RegexOptions.Compiled);
    public static readonly Regex Han = new Regex(HAN, RegexOptions.Compiled);

    public static bool HasAnsi(this string text) => Ansi.IsMatch(text);
    public static bool HasAstral(this string text) => Astral.IsMatch(text);
    public static bool HasHan(this string text) => Han.IsMatch(text);
    public static string ClearAnsi(this string text) => Ansi.Replace(text, "");
    public static string ClearAstral(this string text) => Astral.Replace(text, "");
    public static string ClearHan(this string text) => Han.Replace(text, "");
  }
}