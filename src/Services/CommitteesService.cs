using Data.Repositories;
using Entities;
using Entities.Exceptions;

namespace Services;

public class CommitteesService
{
    private readonly CommitteesRepository _committeesRepository;

    public CommitteesService(CommitteesRepository committeesRepository)
    {
        _committeesRepository = committeesRepository;
    }

    public string SaveCommittee(Committee Committee)
    {
        try
        {
            _committeesRepository.Save(Committee);
            return "Registro realizado con exito";
        }
        catch (Exception e)
        {
            throw new CommitteesException(
                $"Ha ocurrido un error al registrar {e.Message}");
        }
    }

    public Committee? SearchCommittee(string document)
    {
        return _committeesRepository.Find(Committee =>
            Committee.Document == document);
    }

    public string DeleteCommittee(string document)
    {
        try
        {
            var foundCommittee = SearchCommittee(document);
            if (foundCommittee == null)
                throw new CommitteesException("Usuario del comite no encontrado");
            _committeesRepository.Delete(foundCommittee);
            return "Registro eliminado";
        }
        catch (Exception e)
        {
            throw new CommitteesException(
                $"Ha ocurrido un error al eliminar {e.Message}");
        }
    }
}
