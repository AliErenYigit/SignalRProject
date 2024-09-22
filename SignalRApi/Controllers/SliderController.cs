using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.SliderDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {

        private readonly ISliderService _sliderServices;
        private readonly IMapper _mapper;

        public SliderController(ISliderService SliderService, IMapper mapper)
        {
			_sliderServices = SliderService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult SliderList()
        {
            var value = _mapper.Map<List<ResultSliderDto>>(_sliderServices.TGetListAll());
            return Ok(value);

        }
        [HttpPost]
        public IActionResult CreateSlider(CreateSliderDto createSliderDto)
        {
			_sliderServices.TAdd(new Slider()
            {
                Title1 = createSliderDto.Title1,
                Title2 = createSliderDto.Title2,
                Title3 = createSliderDto.Title3,
                Description1 = createSliderDto.Description1,
                Description2 = createSliderDto.Description2,
                Description3 = createSliderDto.Description3,

            });
            return Ok("Kategori eklendi");

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSlider(int id)
        {
            var value = _sliderServices.TGetByID(id);
			_sliderServices.TDelete(value);
            return Ok("Kategori silindi");

        }
        [HttpGet("{id}")]
        public IActionResult GetSlider(int id)
        {
            var value = _sliderServices.TGetByID(id);

            return Ok(value);

        }
        [HttpPut]
        public IActionResult UpdateSlider(UpdateSliderDto updateSliderDto)
        {
			_sliderServices.TUpdate(new Slider()
            {
                SliderID = updateSliderDto.SliderID,
                Title1 = updateSliderDto.Title1,
                Title2 = updateSliderDto.Title2,
                Title3 = updateSliderDto.Title3,
                Description1 = updateSliderDto.Description1,
                Description2 = updateSliderDto.Description2,
                Description3 = updateSliderDto.Description3,
            });
            return Ok("Kategori Güncellendi");

        }
    }
}
