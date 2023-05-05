using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPTModeration
{
    public interface IChatGPTService
    {
        Task<ModerationResponse> ExecutePrompt(ModerationRequest request);
    }
    public class ChatGPTService : IChatGPTService
    {
        public async Task<ModerationResponse> ExecutePrompt(ModerationRequest moderationRequest)
        {
            using(HttpClient httpClient = new HttpClient())
            {
                using var httpReq = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/moderations");

                var apiKey = "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";

                httpReq.Headers.Add("Authorization", $"Bearer {apiKey}");

                var reqContent = JsonConvert.SerializeObject(moderationRequest);

                httpReq.Content = new StringContent(reqContent, Encoding.UTF8, "application/json");

                using HttpResponseMessage? httpResponse = await httpClient.SendAsync(httpReq);
                
                if(httpResponse != null && httpResponse.IsSuccessStatusCode)
                {
                    var responseString = await httpResponse.Content.ReadAsStringAsync();
                    {
                        if(!string.IsNullOrWhiteSpace(responseString))
                        {
                            return JsonConvert.DeserializeObject<ModerationResponse>(responseString);
                        }
                    }
                }

                return null;
            }
        }
    }
}
