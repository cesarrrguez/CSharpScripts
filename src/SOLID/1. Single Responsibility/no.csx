#load "interfaces.csx"

using System.Security.Cryptography;

public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    }

    public void RegisterNewUser(string email, string password)
    {
        var bytes = Encoding.Unicode.GetBytes(password);
        var inArray = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
        var encriptedPassword = Convert.ToBase64String(inArray);

        var user = new User
        {
            Email = email,
            Password = encriptedPassword
        };

        _userRepository.Add(user);
    }
}
