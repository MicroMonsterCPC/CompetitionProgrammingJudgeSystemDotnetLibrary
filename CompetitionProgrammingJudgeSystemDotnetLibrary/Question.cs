using Newtonsoft.Json;

namespace CompetitionProgrammingJudgeSystemDotnetLibrary {
  public class Question {
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("body")]
    public string Body { get; set; }

    [JsonProperty("created_at")]
    public string CreatedAt { get; set; }
  }
}
