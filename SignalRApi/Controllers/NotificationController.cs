using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.NotificationDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NotificationController : ControllerBase
	{
		private readonly INotificationService _notificationService;

		public NotificationController(INotificationService notificationService)
		{
			_notificationService = notificationService;
		}
		[HttpGet]
		public IActionResult NotificationList()
		{
			return Ok(_notificationService.TGetListAll());
		}
		[HttpGet("NotificationCountByStatusFalse")]
		public IActionResult NotificationCountByStatusFalse()
		{
			return Ok(_notificationService.TNotificationCountByStatusFalse());
		}
		[HttpGet("GetAllNotificationsByFalse")]
		public IActionResult GetAllNotificationsByFalse()
		{
			return Ok(_notificationService.TGetAllNotificationsByFalse());
		}
		[HttpPost]
		public IActionResult CreateNotification(CreateNotificationDto createNotificationDto) 
		{
			Notification notification = new Notification()
			{
				Description = createNotificationDto.Description,
				Icon = createNotificationDto.Icon,
				Type = createNotificationDto.Type,
				Status = false,
				Date= Convert.ToDateTime(DateTime.Now.ToShortDateString())


			};
			_notificationService.TAdd(notification);
			return Ok("Ekleme işlemi yapıldı");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteNotification(int id)
		{
			var value=_notificationService.TGetByID(id);
			_notificationService.TDelete(value);
			return Ok("Bildirim silindi"); 
		}
		[HttpGet("{id}")]
		public IActionResult GetNotification(int id)
		{
			var value = _notificationService.TGetByID(id);
			return Ok(value);

		}
		[HttpPut]
		public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
		{
			Notification notification = new Notification()
			{
				NotificationID= updateNotificationDto.NotificationID,
				Description = updateNotificationDto.Description,
				Icon = updateNotificationDto.Icon,
				Type = updateNotificationDto.Type,
				Status = updateNotificationDto.Status,
				Date = updateNotificationDto.Date


			};
			_notificationService.TUpdate(notification);
			return Ok("Güncelleme işlemi yapıldı");
		}
		[HttpGet("NotificationStatusChangeToFalse/{id}")]
		public IActionResult NotificationStatusChangeToFalse(int id)
		{
			_notificationService.TNotificationStatusChangeToFalse(id); 
			return Ok("Güncelleme Yapıldı");
		}
		[HttpGet("NotificationStatusChangeToTrue/{id}")]
		public IActionResult NotificationStatusChangeToTrue(int id)
		{
			_notificationService.TNotificationStatusChangeToTrue(id);
			return Ok("Güncelleme Yapıldı");
		}


	}
}
