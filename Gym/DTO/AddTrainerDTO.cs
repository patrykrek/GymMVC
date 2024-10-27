using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Gym.DTO
{
    public class AddTrainerDTO
    {
        public int Id { get; set; }

       
        [Required(ErrorMessage = "First name is required")]
        public string? FirstName { get; set; }

        
        [Required(ErrorMessage = "Last name is required")]
        public string? LastName { get; set; }

        
        [Required(ErrorMessage = "Bio is required")]
        public string? Bio { get; set; }


    }
}
