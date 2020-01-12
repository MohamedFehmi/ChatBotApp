using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ChatBotApp.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

        /// <summary>
        /// Send content as a question to the bot service
        /// </summary>
        /// <param name="message">A string that represents the question of the user</param>
        /// <returns>A string text that represents the response for the question in argument</returns>
        public async Task SendActivityAsync(string message)
        {
            string endpoint = $"/v3/directline/conversations/{_Conversation.ConversationId}/activities";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://directline.botframework.com");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer 5_H3d9CT8JY.3IdaA1U9fh8OtDswkowQ69kXDrBeYA1YceLrcUfbT3g");

                Activity activity = new Activity()
                {
                    From = new ChannelAccount()
                    {
                        Id = "user1"
                    },
                    Text = message,
                    Type = "message"//writing...
                };

                string jsonContent = JsonConvert.SerializeObject(activity);
                var buffer = Encoding.UTF8.GetBytes(jsonContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                var response = await client.PostAsync(endpoint, byteContent);
                string json = await response.Content.ReadAsStringAsync();

                var obj = JObject.Parse(json);
                string id = (string)obj.SelectToken("id");
            }
        }


    }
}