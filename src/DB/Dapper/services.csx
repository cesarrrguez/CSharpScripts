#load "interfaces.csx"

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task AddAsync(User user)
    {
        var result = await _unitOfWork.Users.AddAsync(user);

        if (result > 0)
        {
            user.Id = result;
            WriteLine($"User {user.Id} added successfully");
        }
    }

    public async Task UpdateAsync(User user)
    {
        var result = await _unitOfWork.Users.UpdateAsync(user);

        if (result > 0)
        {
            WriteLine($"User {user.Id} updated successfully");
        }
    }

    public async Task DeleteAsync(int id)
    {
        var result = await _unitOfWork.Users.DeleteAsync(id);

        if (result > 0)
        {
            WriteLine($"User {id} deleted successfully");
        }
    }

    public async Task<User> GetByIdAsync(int id)
    {
        return await _unitOfWork.Users.GetByIdAsync(id);
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _unitOfWork.Users.GetAllAsync();
    }
}
