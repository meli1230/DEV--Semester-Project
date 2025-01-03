﻿using System.ComponentModel.DataAnnotations;

namespace MelisaIuliaProiect.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string? FirstName {  get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        [Display(Name = "Full Name")] //display the full name of the customer
        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public ICollection<TestDrive>? TestDrives { get; set; }
    }
}
