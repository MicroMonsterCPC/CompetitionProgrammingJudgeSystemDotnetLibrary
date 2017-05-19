using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionProgrammingJudgeSystemDotnetLibrary {
  public class Request {
    /// <summary>
    /// Get All of Programming Question.
    /// </summary>
    /// <returns>Question Array</returns>
    public static async Task<Question[]> GetQuestionsAsync() {
      string json = await GetAsync("http://localhost:3000/api/questions");
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
    public static async Task<bool> SubmitAnswerAsync(int id, string code, Language lang) {
      Answer obj = new Answer() { Id = id, Code = code, Language = lang };
      string requestJson = JsonConvert.SerializeObject(obj);
      string json = await PostAsync(requestJson, "http://localhost:1323/answer-data");
      AnswerResponse response = JsonConvert.DeserializeObject<AnswerResponse>(json);
      bool success;
      bool.TryParse(response.Success, out success);
      return success;
    }



    private static async Task<string> PostAsync(object obj, string url) {
      HttpClient client = new HttpClient();
      string requestJson = JsonConvert.SerializeObject(obj);
      HttpContent requestContent = new StringContent(requestJson, Encoding.UTF8, "application/json");
      HttpResponseMessage response = await client.PostAsync(url, requestContent);
      HttpContent responseContent = response.Content;
      string responseJson = await responseContent.ReadAsStringAsync();
      return responseJson;
    }

    private static async Task<string> GetAsync(string url) {
      HttpClient client = new HttpClient();
      HttpResponseMessage response = await client.GetAsync(url);
      HttpContent content = response.Content;
      string json = await content.ReadAsStringAsync();
      return json;
    }
  }
}
