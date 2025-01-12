using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;
public class NewContactForm
{

    [Required(ErrorMessage = "First name is required")]
    [MinLength(2, ErrorMessage = "First name must contain at least two characters")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
        ErrorMessage = "Email format is invalid.")]
    public string? Email { get; set; }

    [Required]
    [MinLength(9, ErrorMessage = "Phone number is not valid. Has to be at least 9 characters")]
    public string? Phone { get; set; }

    [Required]
    public string? Address { get; set; }

    [Required]
    public string? PostalCode { get; set; }

    [Required]
    public string? City { get; set; }

}