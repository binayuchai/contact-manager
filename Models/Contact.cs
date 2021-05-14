using System;

namespace contactmanager.Models
{
    public class Contact{
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        //public List<Category> Category { get; set; }
    }
}