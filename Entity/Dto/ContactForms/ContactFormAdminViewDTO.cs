using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.ContactForms
{
    public class ContactFormAdminViewDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
