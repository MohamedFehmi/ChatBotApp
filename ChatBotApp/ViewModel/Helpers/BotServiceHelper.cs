using System;
using System.Net.Http;
using ChatBotApp.Model;

namespace ChatBotApp.ViewModel.Helpers
{
    public class BotServiceHelper
    {
        public BotServiceHelper()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        private async System.Threading.Tasks.Task CreateConversationAsync()
        {
            string endpoint = "/qnamaker/v4.0";

            using HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://experimentalbotqna.cognitiveservices.azure.com");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer 5_H3d9CT8JY.3IdaA1U9fh8OtDswkowQ69kXDrBeYA1YceLrcUfbT3g");

            var response = await client.PostAsync(endpoint, null);

            string json = await response.Content.ReadAsStringAsync();
        }
    }
}
