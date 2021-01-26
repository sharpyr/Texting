namespace Texting {
  public static class Profile {
    public static bool Any(this string tx) => !string.IsNullOrEmpty(tx);
  }
}