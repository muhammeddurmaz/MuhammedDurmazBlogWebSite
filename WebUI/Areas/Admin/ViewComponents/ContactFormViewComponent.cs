using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.ViewComponents
{
    public class ContactFormViewComponent : ViewComponent
    {
        private readonly IContactFormService contactFormService;

        public ContactFormViewComponent(IContactFormService contactFormService) 
        {
            this.contactFormService = contactFormService;
        }
        public IViewComponentResult Invoke()
        {
            var result = contactFormService.ContactFormAdminView();
            return View(result);
        }
    }
}
