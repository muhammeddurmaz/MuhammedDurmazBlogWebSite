using AutoMapper;
using Business.Abstract;
using Data.UnitOfWorks;
using Entity;
using Entity.Dto.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ContactServiceImpl : IContactService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ContactServiceImpl(IUnitOfWork unitOfWork,IMapper mapper) 
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public ContactViewDTO GetContactView()
        {
            var contact = unitOfWork.GetRepository<Contact>().GetAll().FirstOrDefault();
            var contactDto = mapper.Map<ContactViewDTO>(contact);
            return contactDto;
        }

        public void Update(ContactCreateDTO contact)
        {
           
            if(contact.Id != Guid.Empty) 
            {
                var entity = unitOfWork.GetRepository<Contact>().GetById(contact.Id);
                var updated = mapper.Map(contact, entity);
                unitOfWork.GetRepository<Contact>().Update(updated);
            }
            else
            {
                var entity = mapper.Map<Contact>(contact);
                entity.CreatedBy = "Admin";
                unitOfWork.GetRepository<Contact>().Save(entity);
            }  
            unitOfWork.SaveChanges();
        }
    }
}
