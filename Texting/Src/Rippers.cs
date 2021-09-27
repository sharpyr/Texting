using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Texting {
  public static class Rippers {
    public static List<string> Ripper(this Regex reg, string text) {
      var vec = new List<string>();
      int l = 0, r = 0;
      string space;
      var match = reg.Match(text);
      while (match.Success) {
        r = match.Index;
        // Console.WriteLine($">> [match] ({match.Value}) [l] {l} [r] {r}");
        if ((space = text.Slice(l, r - l)).Length > 0) vec.Add(space);
        vec.Add(match.Value);
        l = r + match.Length;
        match = match.NextMatch();
      }
      if (l < text.Length) vec.Add(text.Slice(l));
      return vec;
    }
  }
}