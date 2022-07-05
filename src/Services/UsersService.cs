using Data.Repositories;
using Entities;
using Microsoft.EntityFrameworkCore;
using Encryptor = BCrypt.Net.BCrypt;

namespace Services;

public class UsersService
{
    private readonly UsersRepository _repository;

    public UsersService(UsersRepository repository)
    {
        _repository = repository;
    }

    public bool SaveUser(User user)
    {
        try
        {
            user.Password = Encryptor.HashPassword(user.Password);
            _repository.Save(user);
            return true;
        }
        catch (DbUpdateException _)
        {
            return false;
        }
    }
}
