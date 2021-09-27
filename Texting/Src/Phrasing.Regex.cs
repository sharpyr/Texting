namespace Texting {
  public static partial class Phrasing {
    public const string INIWORD = @"[A-Za-z\d]+";
    public const string INILOW = @"^[a-z]+";
    public const string CAMEL = @"[A-Z]+|[0-9]+";
    public const string LITERAL = @"[a-z]+|[A-Z][a-z]+|(?<=[a-z]|\W|_)[A-Z]+(?=[A-Z][a-z]|\W|_|$)|[\d]+[a-z]*";
    public const string WORD = @"[A-Za-z\d]+";
    public const string CAPWORD = @"[A-Z][a-z]+|[A-Z]+(?=[A-Z][a-z]|\d|\W|_|$)|[\d]+[a-z]*";
    public const string DASH_CAPREST = @"[\W_]+([A-Za-z\d])([A-Za-z\d]*)";
    public const string CAPREST = @"([A-Za-z\d])([A-Za-z\d]*)";
  }
}