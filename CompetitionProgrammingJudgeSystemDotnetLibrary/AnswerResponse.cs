using Newtonsoft.Json;

namespace CompetitionProgrammingJudgeSystemDotnetLibrary {
  public class AnswerResponse {
    [JsonProperty("Result")]
    public string Success { get; set; }
  }
}
