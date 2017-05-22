using Newtonsoft.Json;

namespace CompetitionProgrammingJudgeSystemDotnetLibrary {
  /// <summary>
  /// Answer Json Payload
  /// </summary>
  public class Answer {
    /// <summary>
    /// Question ID
    /// </summary>
    [JsonProperty("id")]
    public int Id { get; set; }

    /// <summary>
    /// Answer Code
    /// </summary>
    [JsonProperty("code")]
    public string Code { get; set; }

    /// <summary>
    /// Answer Language
    /// </summary>
    [JsonProperty("lang")]
    public Language Language { get; set; }
  }
}
