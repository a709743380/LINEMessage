﻿using LineBotMessage.Dtos;
using LineBotMessage.Domain;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using LineBotMessage.Enum;
using LineBotMessage.Providers;

namespace LineBotMessage.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class LineBotController : ControllerBase
    {

        private readonly LineBotService _lineBotService;
        private readonly JsonProvider _jsonProvider;
        // constructor
        public LineBotController()
        {
            _lineBotService = new LineBotService();
            _jsonProvider = new JsonProvider();
        }

        [HttpPost("Webhook")]
        public IActionResult Webhook(WebhookRequestBodyDto body)
        {
            _lineBotService.ReceiveWebhook(body);
            return Ok();
        }

        /*
         {
           "Messages" : [{"Type" : "text" , "Text" : "測試推波幾個人"}]
         }
         */
        [HttpPost("SendMessage/Broadcast")]
        public IActionResult Broadcast([Required] string messageType, object body)
        {
            _lineBotService.BroadcastMessageHandler(messageType, body);
            return Ok();
        }
        [HttpPost("TEST")]
        public IActionResult TEST()
        {
            return Ok("ok");
        }
    }
}