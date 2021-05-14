using System;
using System.Collections.Generic;

namespace contactmanager.Models
{
    public class ContactViewModel
    {
        public Person Person { get; set; }
        public List<Person> Persons {get; set; }
    }

}