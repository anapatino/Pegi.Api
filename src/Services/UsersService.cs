using Data.Repository;
using Entities;
using Entities.Exceptions;

using Encryptor = BCrypt.Net.BCrypt;
namespace Services;

public class UsersService
{
    private readonly UsersRepository _usersRepository;

    public UsersService(UsersRepository repository)
    {
        _usersRepository = repository;
    }

    public bool SaveUser(User user)
    {
        try
        {
            user.Password = Encryptor.HashPassword(user.Password);
            _usersRepository.Save(user);
            return true;
        }
        catch
        {
            return false ;
        }
    }

    public User SearchUser(string name)
    {
       return _usersRepository.Find(user => user.Name == name);

    }

    public (string,bool?) AddPersonDocument(string document,string username)
    {
        try
        {
            User? user = _usersRepository.Find(user => user.Name == username );
            user!.PersonDocument = document;
            _usersRepository.Update(user);
            return ("se agrego con exito",true);
        }
        catch(AuthException e)
        {
            return ("error",false);
        }
    }

    public (string,bool?) DeletePersonDocument(string document)
    {
        try
        {
            User? user = _usersRepository.Find(user => user.PersonDocument == document );
            user.PersonDocument = null;
            _usersRepository.Update(user);
            return ("se elimino con exito",true);
        }
        catch(AuthException e)
        {
            return ("error",false);
        }
    }


}
