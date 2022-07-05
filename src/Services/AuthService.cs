using Data.Repositories;
using Entities;
using Entities.Exceptions;
using Encryptor = BCrypt.Net.BCrypt;

namespace Services;

public class AuthService
{
    private readonly UsersRepository _repository;

    public AuthService(UsersRepository repository)
    {
        _repository = repository;
    }

    public string LogIn(string username, string password)
    {
        User? foundUser = _repository.Find(user => user.Name == username);

        if (foundUser == null) throw new AuthException("El usuario no existe");

        if (!Encryptor.Verify(password, foundUser.Password))
            throw new AuthException("Contraseña incorrecta");

        return "Haz ingresado con éxito";
    }
}
