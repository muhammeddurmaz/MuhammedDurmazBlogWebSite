using Business.Abstract;
using Entity.Dto.ContactForms;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactFormService contactFormService;
        private readonly IContactService contactService;

        public ContactController(IContactFormService contactFormService,IContactService contactService) 
        {
            this.contactFormService = contactFormService;
            this.contactService = contactService;
        }
        public IActionResult Index()
        {
            var result = contactService.GetContactView();
            return View(result);
        }
        [HttpPost]
        public IActionResult SendForm(ContactFormRequestDTO contactFormRequestDTO)
        {
            contactFormService.ContactFormInsert(contactFormRequestDTO);
            return RedirectToAction("Index", "Home");
        }
    }
}
