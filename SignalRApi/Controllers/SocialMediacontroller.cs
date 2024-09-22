using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.SocialMediaDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediacontroller : ControllerBase
    {

        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediacontroller(ISocialMediaService SocialMediaService, IMapper mapper)
        {
            _socialMediaService = SocialMediaService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var value = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.TGetListAll());
            return Ok(value);

        }
        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            _socialMediaService.TAdd(new SocialMedia()
            {
                Title = createSocialMediaDto.Title,
                Url = createSocialMediaDto.Url,
                Icon = createSocialMediaDto.Icon,
               

            });
            return Ok("Kategori eklendi");

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _socialMediaService.TGetByID(id);
            _socialMediaService.TDelete(value);
            return Ok("Kategori silindi");

        }
        [HttpGet("{id}")]
        public IActionResult GetSocialMedia(int id)
        {
            var value = _socialMediaService.TGetByID(id);

            return Ok(value);

        }
        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            _socialMediaService.TUpdate(new SocialMedia()
            {
                SocialMediaID = updateSocialMediaDto.SocialMediaID,
                Title = updateSocialMediaDto.Title,
                Url = updateSocialMediaDto.Url,
                Icon = updateSocialMediaDto.Icon,
               
            });
            return Ok("Kategori Güncellendi");

        }
    }
}
