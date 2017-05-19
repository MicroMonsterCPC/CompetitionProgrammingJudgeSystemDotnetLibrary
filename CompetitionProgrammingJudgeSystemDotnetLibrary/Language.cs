using System.Runtime.Serialization;

namespace CompetitionProgrammingJudgeSystemDotnetLibrary {
  public enum Language {
    [EnumMember(Value = "rb")]
    Ruby,
    [EnumMember(Value = "py")]
    Python
  }
}
