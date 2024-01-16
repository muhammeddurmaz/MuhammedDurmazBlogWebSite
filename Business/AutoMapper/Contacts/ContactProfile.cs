using AutoMapper;

using Entity;
using Entity.Dto.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper.Contacts
{
    public class ContactProfile : Profile
    {
        public ContactProfile() 
        {
            CreateMap<ContactCreateDTO, Contact>().ReverseMap();
            CreateMap<ContactViewDTO, Contact>().ReverseMap();
            CreateMap<ContactCreateDTO, ContactViewDTO>().ReverseMap();
        }
    }
}
