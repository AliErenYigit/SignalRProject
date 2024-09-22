using AutoMapper;
using SignalRDtoLayer.ContactDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class ContactMapper:Profile
    {
        public ContactMapper()
        {
            CreateMap<Contact, ResultContactDto>().ReverseMap();
            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();
            CreateMap<Contact, GetContactDto>().ReverseMap();
        }
    }
}
