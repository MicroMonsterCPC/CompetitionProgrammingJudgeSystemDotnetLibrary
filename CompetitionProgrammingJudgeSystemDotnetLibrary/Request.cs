using Newtonsoft.Json;
using System.Threading.Tasks;

namespace CompetitionProgrammingJudgeSystemDotnetLibrary {
  /// <summary>
  /// HTTP Request
  /// </summary>
  public class Request {
    /// <summary>
    /// Get All of Programming Question.
    /// </summary>
    /// <returns>Question Array</returns>
    public static async Task<Question[]> GetQuestionsAsync() {
      string json = await RequestCore.GetAsync("http://localhost:3000/api/questions");
      Question[] questions = JsonConvert.DeserializeObject<Question[]>(json);
      return questions;
    }

    /// <summary>
    /// Submit to Judge Your Answer Code.
    /// </summary>
    /// <param name="id">Question ID</param>
    /// <param name="code">Your Code</param>
    /// <param name="lang">Programming Language</param>
    /// <returns>Is Code Success</returns>
    public static async Task<bool?> SubmitAnswerAsync(int id, string code, Language lang) {
      Answer obj = new Answer() { Id = id, Code = code, Language = lang };
      string responseJson = await RequestCore.PostAsync(obj, "http://localhost:3000/answers");
      AnswerResponse response = JsonConvert.DeserializeObject<AnswerResponse>(responseJson);
      return response.Success;
    }
  }
}
