using Newtonsoft.Json;

namespace CompetitionProgrammingJudgeSystemDotnetLibrary {
  /// <summary>
  /// Answer Response Json Payload
  /// </summary>
  public class AnswerResponse {
    /// <summary>
    /// Is Answer Success
    /// </summary>
    [JsonProperty("Result")]
    public bool? Success { get; set; }
  }
}
