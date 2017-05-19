using Newtonsoft.Json;

namespace CompetitionProgrammingJudgeSystemDotnetLibrary {
  public class Answer {
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("code")]
    public string Code { get; set; }

    [JsonProperty("lang")]
    public Language Language { get; set; }
  }
}
