using System.ComponentModel.DataAnnotations;

public class RegisterViewModel
{
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    [StringLength(50)]
    public string City { get; set; }

    [Required]
    [StringLength(50)]
    public string Password { get; set; }

    [Required]
    [StringLength(50)]
    [Compare("Password")]
    [Display(Name = "Repeat Password")]
    public string Password2 { get; set; }

    [Required]
    [EmailAddress]
    [StringLength(50)]
    public string Email { get; set; }
}
