    using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.AboutDto;
using SignalREntityLayer.Entities;
using System.Reflection;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult AboutLİst()
        {
            var values=_aboutService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            About about = new About()
            {
                Title = createAboutDto.Title,
                Description = createAboutDto.Description,
                ImageURl=createAboutDto.ImageURl,


            };
           _aboutService.TAdd(about);
            return Ok("Ekleme işlemi başarıyla gerçekleştirilmiştir.");

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var values=_aboutService.TGetByID(id);
            _aboutService.TDelete(values);
            return Ok("Hakkımda alanı silindi.");

        }
        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            About about = new About()
            {
                AboutID= updateAboutDto.AboutID,
                Title = updateAboutDto.Title,
                Description = updateAboutDto.Description,
                ImageURl = updateAboutDto.ImageURl,


            };
            _aboutService.TUpdate(about);
            return Ok("Hakkında alanı güncellendi.");

        }
        [HttpGet("{id}")]
        public IActionResult Getbout(int id)
        {
           var value= _aboutService.TGetByID(id);
            return Ok(value);

        }
    }
}
