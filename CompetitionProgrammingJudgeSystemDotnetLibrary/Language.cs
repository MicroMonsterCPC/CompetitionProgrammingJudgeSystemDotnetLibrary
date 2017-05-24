using System.Runtime.Serialization;

namespace CompetitionProgrammingJudgeSystemDotnetLibrary {
  /// <summary>
  /// Programming Language Enums
  /// </summary>
  public enum Language {
    /// <summary>
    /// Programming Language of Ruby
    /// </summary>
    [EnumMember(Value = "ruby")]
    Ruby,
    /// <summary>
    /// Programming Language of Python 2
    /// </summary>
    [EnumMember(Value = "python")]
    Python
  }
}
