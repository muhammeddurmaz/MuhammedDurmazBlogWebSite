using Entity.Dto.ContactForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContactFormService
    {
        void ContactFormInsert(ContactFormRequestDTO contactFormRequestDTO);
        List<ContactFormAdminViewDTO> ContactFormAdminView();
        void SafeDelete(Guid id);
        void HardDelete(Guid id);
    }
}
