using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionProgrammingJudgeSystemDotnetLibrary {
  /// <summary>
  /// HTTP Request Core
  /// </summary>
  internal class RequestCore {
    /// <summary>
    /// Post Request with Async
    /// </summary>
    /// <param name="obj">Post Data Object</param>
    /// <param name="url">Post Target URL</param>
    /// <returns>Result Json String</returns>
    public static async Task<string> PostAsync(object obj, string url) {
      HttpClient client = new HttpClient();
      string requestJson = JsonConvert.SerializeObject(obj);
      Debug.WriteLine(requestJson); // debug
      HttpContent requestContent = new StringContent(requestJson, Encoding.UTF8, "application/json");
      HttpResponseMessage response = await client.PostAsync(url, requestContent);
      HttpContent responseContent = response.Content;
      string responseJson = await responseContent.ReadAsStringAsync();
      Debug.WriteLine(responseJson); // debug
      return responseJson;
    }

    /// <summary>
    /// Get Request with Async
    /// </summary>
    /// <param name="url">Get Target URL</param>
    /// <returns>Result Json String</returns>
    public static async Task<string> GetAsync(string url) {
      HttpClient client = new HttpClient();
      HttpResponseMessage response = await client.GetAsync(url);
      HttpContent content = response.Content;
      string json = await content.ReadAsStringAsync();
      Debug.WriteLine(json); // debug
      return json;
    }
  }
}
