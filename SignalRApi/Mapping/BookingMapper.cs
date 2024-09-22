using AutoMapper;
using SignalRDtoLayer.BookingDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class BookingMapper:Profile
    {
        public BookingMapper()
        {
            CreateMap<Booking, ResultBookingDto>().ReverseMap();
            CreateMap<Booking, CreateBookingDto>().ReverseMap();
            CreateMap<Booking, UpdateBookingDto>().ReverseMap();
            CreateMap<Booking, GetBookingDto>().ReverseMap();
        }
    }
}
