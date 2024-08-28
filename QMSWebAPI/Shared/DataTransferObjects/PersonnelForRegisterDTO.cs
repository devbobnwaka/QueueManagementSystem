using System.ComponentModel.DataAnnotations;

namespace QMSWebAPI.Shared.DataTransferObjects
{
    public record PersonnelForRegisterDTO
    {
        public string FirstName { get; init; } = null!; 
        public string LastName { get; init; } = null!;
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; init; } = null!;
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; init; } = null!;
        [Required(ErrorMessage = "SectionID is required")]
        public int SectionID { get; init; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; init; } = null!;
        public string? Role { get; init; }


    }
}
