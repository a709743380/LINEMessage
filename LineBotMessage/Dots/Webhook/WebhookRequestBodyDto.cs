using LineBotMessage.Dtos;
using Microsoft.AspNetCore;

namespace LineBotMessage.Dtos
{
    public class WebhookRequestBodyDto
    {
        public string? Destination { get; set; }
        public List<WebhookEventDto> Events { get; set; }
    }
}