using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Contact : BaseEntity
    {
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Linkedin { get; set; }
        public string? Twitter { get; set; }
        public string? Github { get; set; }
        public string? Medium { get; set; }
        public string? StackOverflow { get; set; }
    }
}
