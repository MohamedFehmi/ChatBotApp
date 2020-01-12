using System;
using System.Net.Http;
using System.Threading.Tasks;
using ChatBotApp.Model;
using Newtonsoft.Json;

namespace ChatBotApp.ViewModel.Helpers
{
    public class BotServiceHelper
    {
        public Conversation _Conversation { get; set; }

        public BotServiceHelper()
        {
            CreateConversationAsync();
        }

        /// <summary>
        /// Create a conversation
        /// </summary>
        private async Task CreateConversationAsync()
        {
            string endpoint = "/v3/directline/conversations";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://directline.botframework.com");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer 5_H3d9CT8JY.3IdaA1U9fh8OtDswkowQ69kXDrBeYA1YceLrcUfbT3g");

                var response = await client.PostAsync(endpoint, null);

                string json = await response.Content.ReadAsStringAsync();

                _Conversation = JsonConvert.DeserializeObject<Conversation>(json);
            }
        }

        public async Task SendActivityAsync(string Message)
        {
            string endpoint = $"/v3/directline/conversations/{_Conversation.ConversationId}/activities";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://directline.botframework.com");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer 5_H3d9CT8JY.3IdaA1U9fh8OtDswkowQ69kXDrBeYA1YceLrcUfbT3g");

                var response = await client.PostAsync(endpoint, null);

                string json = await response.Content.ReadAsStringAsync();

                _Conversation = JsonConvert.DeserializeObject<Conversation>(json);
            }
        }
    }
}