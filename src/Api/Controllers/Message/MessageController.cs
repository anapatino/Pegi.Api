using Microsoft.AspNetCore.Mvc;
using Services;
using Mapster;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers.Message
{
    [ApiController]
    [Route("messages")]
    public class MessageController : ControllerBase
    {
        private readonly MessageService _messageService;

        public MessageController(MessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost]
        [Authorize(Roles = "Administrador,Docente")]
        public ActionResult SaveMessages([FromBody] MessageRequest messageRequest)
        {
            try
            {
                var message = messageRequest.Adapt<Entities.Message>();
                var oldMessage = _messageService.GetMessageCode(message.Code);
                if (oldMessage != null && oldMessage?.Code == message.Code)
                {
                    var response = _messageService.UpdateMessage(message);
                }
                else
                {
                    message.Code = Random.Shared.Next().ToString();
                    var response = _messageService.SaveMessage(message);

                }
                return Ok(new Response<Void>("Mensaje guardado exitosamente", false));
            }
            catch (Exception e)
            {
                return BadRequest(new Response<Void>(e.Message));
            }
        }

        [HttpGet("get-all-messages")]
        [Authorize(Roles = "Administrador,Docente")]
        public ActionResult GetAllMessages()
        {
            List<Entities.Message> messages = _messageService.GetAllMessage();
            if (messages.Count < 0)
            {
                return BadRequest(new Response<Void>("No se encontraron mensajes"));
            }

            return Ok(new Response<List<MessageResponse>>(messages?.Adapt<List<MessageResponse>>()));
        }
    }
}
