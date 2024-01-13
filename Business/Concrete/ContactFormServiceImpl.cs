using AutoMapper;
using Business.Abstract;
using Data.UnitOfWorks;
using Entity;
using Entity.Dto.ContactForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ContactFormServiceImpl : IContactFormService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ContactFormServiceImpl(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public List<ContactFormAdminViewDTO> ContactFormAdminView()
        {
            //var formList = unitOfWork.GetRepository<ContactForm>().GetAll(x => !x.IsDeleted);
            var formList = unitOfWork.GetRepository<ContactForm>().OrderByDescending(x => !x.IsDeleted ,x => x.CreatedDate);
            var dtoList = mapper.Map<List<ContactFormAdminViewDTO>>(formList);
            return dtoList;
        }

        public void ContactFormInsert(ContactFormRequestDTO contactFormRequestDTO)
        {
            ContactForm contactForm = mapper.Map<ContactForm>(contactFormRequestDTO);
            contactForm.CreatedBy = "User";
            unitOfWork.GetRepository<ContactForm>().Save(contactForm);
            unitOfWork.SaveChanges();
        }

        public void HardDelete(Guid id)
        {
            unitOfWork.GetRepository<ContactForm>().Delete(id);
            unitOfWork.SaveChanges();
        }

        public void SafeDelete(Guid id)
        {
            var entity = unitOfWork.GetRepository<ContactForm>().GetById(id);
            entity.IsDeleted = true;
            unitOfWork.GetRepository<ContactForm>().Update(entity);
            unitOfWork.SaveChanges();
        }
    }
}
