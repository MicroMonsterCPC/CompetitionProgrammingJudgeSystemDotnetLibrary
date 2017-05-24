using Newtonsoft.Json;
using CommonMark;

namespace CompetitionProgrammingJudgeSystemDotnetLibrary {
  /// <summary>
  /// Question Json Payload
  /// </summary>
  public class Question {
    /// <summary>
    /// Question ID
    /// </summary>
    [JsonProperty("id")]
    public int Id { get; set; }
    
    /// <summary>
    /// Question Title
    /// </summary>
    [JsonProperty("title")]
    public string Title { get; set; }

    /// <summary>
    /// Question Body (Raw Markdown)
    /// </summary>
    [JsonProperty("body")]
    public string BodyRaw { get; set; }

    /// <summary>
    /// Question Body (HTML)
    /// </summary>
    public string BodyHtml {
      get { return CommonMarkConverter.Convert(BodyRaw); }
    }
    
    /// <summary>
    /// Question Created DateTime
    /// </summary>
    [JsonProperty("created_at")]
    public string CreatedAt { get; set; }
  }
}
