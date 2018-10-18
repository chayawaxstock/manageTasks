
using BOL.Models;
using BOL.Validations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace _01_BOL
{
    public class User
    {
        [Required]
        public int UserId { get; set; }
        [Required(ErrorMessage = "name is required")]
        [MinLength(2, ErrorMessage = "name must be more than 2 chars"), MaxLength(15, ErrorMessage = "name must be less than 15 chars")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "password is required")]
        [UniquePassword]
        [MinLength(64), MaxLength(64)]
        public string Password { get; set; }

        [Required(ErrorMessage = "email is required")]
        [UniqueEmail]
        [EmailAddress]
        public string Email { get; set; }

        public string UserComputer { get; set; }
        [DefaultValue(1)]
        public int NumHoursWork { get; set; }
        public User manager { get; set; }
        public DepartmentUser Department { get; set; }


    }
}
