using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.MessageDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessageController : ControllerBase
	{
		private readonly IMessageService _messageService;

		public MessageController(IMessageService MessageService)
		{
			_messageService = MessageService;
		}

		[HttpGet]
		public IActionResult MessageLİst()
		{
			var values = _messageService.TGetListAll();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult CreateMessage(CreateMessageDto createMessageDto)
		{
			Message message = new Message()
			{
				NameSurname = createMessageDto.NameSurname,
				Mail = createMessageDto.Mail,
				Phone = createMessageDto.Phone,
				Subject= createMessageDto.Subject,
				MesageContent= createMessageDto.MesageContent,
				MessageSendDate= createMessageDto.MessageSendDate,
				Status= false,


			};
			_messageService.TAdd(message);
			return Ok("Ekleme işlemi başarıyla gerçekleştirilmiştir.");

		}
		[HttpDelete("{id}")]
		public IActionResult DeleteMessage(int id)
		{
			var values = _messageService.TGetByID(id);
			_messageService.TDelete(values);
			return Ok("Mesaj alanı silindi.");

		}
		[HttpPut]
		public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
		{
			Message message = new Message()
			{
				MessageID = updateMessageDto.MessageID,
				NameSurname = updateMessageDto.NameSurname,
				Mail = updateMessageDto.Mail,
				Phone = updateMessageDto.Phone,
				Subject = updateMessageDto.Subject,
				MesageContent = updateMessageDto.MesageContent,
				MessageSendDate = updateMessageDto.MessageSendDate,
				Status = false,


			};
			_messageService.TUpdate(message);
			return Ok("Mesaj alanı güncellendi.");

		}
		[HttpGet("{id}")]
		public IActionResult Getbout(int id)
		{
			var value = _messageService.TGetByID(id);
			return Ok(value);

		}
	}
}
