using AutoMapper;
using Entity;
using Entity.Dto.ContactForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper.ContactForms
{
    public class ContactFormProfile : Profile
    {
        public ContactFormProfile()
        {
            CreateMap<ContactFormAdminViewDTO, ContactForm>().ReverseMap();
            CreateMap<ContactFormDTO, ContactForm>().ReverseMap();
            CreateMap<ContactFormRequestDTO, ContactForm>().ReverseMap();
        }
    }
}
