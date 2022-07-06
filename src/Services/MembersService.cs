using Data.Repositories;
using Entities;
using Entities.Exceptions;

namespace Services;

public class MembersService
{
    private readonly MembersRepository _membersRepository;

    public MembersService(MembersRepository membersRepository)
    {
        _membersRepository = membersRepository;
    }

    public string SaveMember(Member member)
    {
        try
        {
            _membersRepository.Save(member);
            return "Registro realizado con exito";
        }
        catch (Exception e)
        {
            throw new MemberException(
                $"Ha ocurrido un error al registrar {e.Message}");
        }
    }

    public Member? SearchMember(string document)
    {
        return _membersRepository.Find(member =>
            member.Document == document);
    }

    public string DeleteMember(string document)
    {
        try
        {
            var foundMember = SearchMember(document);
            if (foundMember == null)
                throw new MemberException("persona no encontrada");
            _membersRepository.Delete(foundMember);
            return "Registro eliminado";
        }
        catch (Exception e)
        {
            throw new MemberException(
                $"Ha ocurrido un error al eliminar {e.Message}");
        }
    }
}
