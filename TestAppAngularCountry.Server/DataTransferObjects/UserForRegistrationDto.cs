using EntitiesDAL.Models;
using System.ComponentModel.DataAnnotations;

namespace TestAppAngularCountry.Server.DataTransferObjects
{
    public class UserForRegistrationDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "A valid email is required.")]
        [EmailAddress(ErrorMessage = "A valid email is required.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Minimum password length is 2 characters.")]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$", ErrorMessage = "Must contain min 1 digit and min 1 letter.")]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Agree is required.")]
        [Range(1, 1, ErrorMessage = "You must agree to the checkbox.")]
        public bool Agree { get; set; }
    }
}
