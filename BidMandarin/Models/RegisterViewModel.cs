using System.ComponentModel.DataAnnotations;

namespace BidMandarin.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]

        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)]

        public string Password { get; set; }
        [DataType(DataType.Password)]

        [Compare("Password", ErrorMessage ="The passwrod do not match")]
        
           public string ConfirmPassword { get; set; }  

    }
}
