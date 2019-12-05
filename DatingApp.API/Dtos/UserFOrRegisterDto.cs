using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Dtos
{
    public class UserFOrRegisterDto
    {
        [Required]
        public string Username {set; get;}

        [Required]
        [StringLength(8, ErrorMessage = "Must specify password between 4 and 8 characters")]
        public string Password  {set; get;}
    }
}