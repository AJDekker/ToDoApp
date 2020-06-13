using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Models
{
    public class Person
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } 
        public Guid AddressId { get; set; }
        public Address Address { get; set; }
    }
}
