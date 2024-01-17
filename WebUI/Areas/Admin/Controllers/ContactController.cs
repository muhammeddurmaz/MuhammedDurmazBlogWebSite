using AutoMapper;
using Business.Abstract;
using Entity.Dto.ContactForms;
using Entity.Dto.Contacts;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IContactFormService contactFormService;
        private readonly IContactService contactService;
        private readonly IMapper mapper;

        public ContactController(IContactFormService contactFormService, IContactService contactService,IMapper mapper) 
        {
            this.contactFormService = contactFormService;
            this.contactService = contactService;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult FormList()
        {
            var formList = contactFormService.ContactFormAdminView();
            return View(formList);
        }
        public IActionResult FormDelete(Guid id)
        {
            contactFormService.SafeDelete(id);
            return RedirectToAction("FormList", "Contact", new { Area = "Admin" });
        }

        public IActionResult ContactInfo() 
        {
            var contantContent = contactService.GetContactView();
            return View(contantContent);  
        }
        [HttpPost]
        public IActionResult ContactUpdate(ContactCreateDTO contactCreateDTO) 
        {
            contactService.Update(contactCreateDTO);
            return RedirectToAction("Index", "Home", new { Area = "Admin" });
        }
        [HttpGet]
        public IActionResult ContactUpdate()
        {
            var contantContent = contactService.GetContactView();
            var result = mapper.Map<ContactCreateDTO>(contantContent);
            return View(result);
        }
    }
}
