using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Texting.Bracket;
using Texting.Enums;
using Ch = Texting.Enums.Chars;
using static Texting.Enums.Strings;

namespace Texting {
  public static class Joiners {
    public static string Join(this IReadOnlyList<string> words, string delim) {
      var hi = words.Count;
      if (hi == 0) return "";
      var phrase = words[0];
      for (var i = 1; i < hi; i++) phrase += delim + words[i];
      return phrase;
    }
    public static string JoinLines(this IReadOnlyList<string> lines, string delim = ",", byte level = 0) {
      var ind = level > 0 ? Ch.SP.Repeat(level << 1) : "";
      return $"{ind + TB}{lines.Join(delim + LF + ind + TB)}{delim}";
    }
    public static string JoinLinesEdged(this IReadOnlyList<string> lines, string delim = ",", int level = 0) {
      var ind = level > 0 ? Ch.SP.Repeat(level << 1) : "";
      return $"{LF + ind + TB}{lines.Join(delim + LF + ind + TB)}{delim + LF + ind}";
    }

    public static readonly Regex LINEFEED = new Regex("\n", RegexOptions.Compiled);
    public static readonly Regex COMMA = new Regex(",", RegexOptions.Compiled);

    public static string ContingentLines(
      this IReadOnlyList<string> lines,
      string delim = LF,
      byte level = 0,
      Brac brac = Brac.NAN
    ) {
      var edged = brac != Brac.NAN;
      var joined = lines.Any() && LINEFEED.IsMatch(delim)
        ? edged
          ? lines.JoinLinesEdged(COMMA.IsMatch(delim) ? CO : "", level)
          : lines.JoinLines(COMMA.IsMatch(delim) ? CO : "", level)
        : lines.Join(delim);
      return joined.Br(brac);
    }
  }
}