using Entity.Dto.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContactService
    {
        ContactViewDTO GetContactView();
        void Update(ContactCreateDTO contact);
    }
}
