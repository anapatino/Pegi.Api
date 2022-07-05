using Data.Repositories;
using Entities;
using Entities.Exceptions;

namespace Services;

public class LinesInvestigationService
{
    private readonly LinesInvestigationRepository _linesInvestigationRepository;

    public LinesInvestigationService(
        LinesInvestigationRepository linesInvestigationRepository)
    {
        _linesInvestigationRepository = linesInvestigationRepository;
    }

    public string SaveLine(LineInvestigation line)
    {
        try
        {
            _linesInvestigationRepository.Save(line);
            return "Registro realizado exitoso";
        }
        catch (Exception e)
        {
            throw new LineInvestigationException(
                $"Ha ocurrido un error al registrar {e.Message}");
        }
    }

    public LineInvestigation? SearchLine(string code)
    {
        return _linesInvestigationRepository.Find(line => line.Code == code);
    }

    public string DeleteLine(string code)
    {
        try
        {
            var foundLine = SearchLine(code);
            if (foundLine == null)
                throw new LineInvestigationException(
                    "linea de investigacion no encontrada");
            _linesInvestigationRepository.Delete(foundLine);
            return "Linea de investigacion eliminada";
        }
        catch (Exception e)
        {
            throw new LineInvestigationException(
                $"Ha ocurrido un error al eliminar {e.Message}");
        }
    }
}
