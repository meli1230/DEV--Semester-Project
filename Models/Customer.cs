using System.ComponentModel.DataAnnotations;

namespace MelisaIuliaProiect.Models
{
    public class Customer
    {
        public int ID { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "This field is required.")]
        [StringLength(50, ErrorMessage = "Requirements: at most 50 characters")]
        public string? FirstName {  get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "This field is required.")]
        [StringLength(50, ErrorMessage = "Requirements: at most 50 characters")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string? Email { get; set; }
        
        [Required(ErrorMessage = "This field is required.")]
        [RegularExpression(@"^0\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Requirement example: '0722-123-123', '0722.123.123' or '0722 123 123'")]
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
