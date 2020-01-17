using System;
namespace ChatBotApp.Model
{
    public class ChatMessage
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public bool IsInComing { get; set; }
    }
}
