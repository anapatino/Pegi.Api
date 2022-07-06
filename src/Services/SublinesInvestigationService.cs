using Data.Repositories;
using Entities;
using Entities.Exceptions;

namespace Services;

public class SublinesInvestigationService
{
    private readonly SublinesInvestigationRepository
        _sublinesInvestigationRepository;

    public SublinesInvestigationService(
        SublinesInvestigationRepository SublinesInvestigationRepository)
    {
        _sublinesInvestigationRepository = SublinesInvestigationRepository;
    }

    public string SaveSubline(SublineInvestigation subline)
    {
        try
        {
            _sublinesInvestigationRepository.Save(subline);
            return "Sublinea registrada con exito";
        }
        catch (Exception e)
        {
            throw new SublineInvestigationException(
                $"Ha ocurrido un error al registrar la sublinea {e.Message}");
        }
    }

    public SublineInvestigation? SearchSubline(string code)
    {
        return _sublinesInvestigationRepository.Find(subline =>
            subline.Code == code);
    }

    public List<SublineInvestigation?> AllSublines()
    {
        return (List<SublineInvestigation?>)_sublinesInvestigationRepository
            .GetAll();
    }

    public string DeleteLine(string code)
    {
        try
        {
            var subline = SearchSubline(code);
            if (subline == null)
                throw new LineInvestigationException(
                    "Sublinea de investigacion no encontrada");
            _sublinesInvestigationRepository.Delete(subline);
            return "Sublinea de investigacion eliminada";
        }
        catch (Exception e)
        {
            throw new SublineInvestigationException(
                $"Ha ocurrido un error al eliminar  la sublinea{e.Message}");
        }
    }
}
