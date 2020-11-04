#load "interfaces.csx"

using System.Security.Cryptography;

public static class PasswordEncrypter
{
    public static string Encrypt(string password)
    {
        var bytes = Encoding.Unicode.GetBytes(password);
        var inArray = HashAlgorithm.Create("SHA1").ComputeHash(bytes);

        return Convert.ToBase64String(inArray);
    }
}

public class UserService_SRP
{
    private readonly IUserRepository _userRepository;

    public UserService_SRP(IUserRepository userRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    }

    public void RegisterNewUser(string email, string password)
    {
        var encriptedPassword = PasswordEncrypter.Encrypt(password);

        var user = new User
        {
            Email = email,
            Password = encriptedPassword
        };

        _userRepository.Add(user);
    }
}
