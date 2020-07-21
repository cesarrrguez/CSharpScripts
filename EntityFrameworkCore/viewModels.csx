using System.ComponentModel.DataAnnotations;

public class UserViewModel
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "The first name is required")]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "The last name is required")]
    [MaxLength(50)]
    public string LastName { get; set; }

    [Required(ErrorMessage = "The age is required")]
    public int Age { get; set; }

    public List<UserAddressViewModel> Addresses { get; set; }
    public List<UserEmailViewModel> Emails { get; set; }

    public override string ToString()
    {
        var result = $"User. Id: {Id}, FirstName: {FirstName}, LastName: {LastName}, Age: {Age}";

        foreach (var address in Addresses)
        {
            result += $"\n\t{address}";
        }

        foreach (var emailAddress in Emails)
        {
            result += $"\n\t{emailAddress}";
        }

        return result;
    }
}

public class UserAddressViewModel
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "The street is required")]
    [MaxLength(200)]
    public string Street { get; set; }

    [Required(ErrorMessage = "The city is required")]
    [MaxLength(100)]
    public string City { get; set; }

    [Required(ErrorMessage = "The state is required")]
    [MaxLength(50)]
    public string State { get; set; }

    [Required(ErrorMessage = "The zip code is required")]
    [MaxLength(10)]
    public string ZipCode { get; set; }

    [Required(ErrorMessage = "The user is required")]
    public UserViewModel User { get; set; }

    public override string ToString()
    {
        return $"Address. Id: {Id}, Street: {Street}, City: {City}, State: {State}, ZipCode: {ZipCode}";
    }
}

public class UserEmailViewModel
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "The email is required")]
    [MaxLength(200)]
    public string EmailAddress { get; set; }

    [Required(ErrorMessage = "The user is required")]
    public UserViewModel User { get; set; }

    public override string ToString()
    {
        return $"Email. Id: {Id}, EmailAddress: {EmailAddress}";
    }
}
