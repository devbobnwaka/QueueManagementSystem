using System.ComponentModel.DataAnnotations;

namespace QMSWebAPI.Shared.DataTransferObjects
{
    public record PersonnelForAuthenticationDTO
    {
        [Required(ErrorMessage ="User name is required")]
        public string? UserName { get; init; }
        [Required(ErrorMessage ="Password is required")]
        public string? Password { get; init; }

    }
}
