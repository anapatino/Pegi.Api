using Data.Repositories;
using Entities;
using Entities.Exceptions;

namespace Services;

public class ThematicAreasService
{
    private readonly ThematicAreasRepository _thematicAreasRepository;

    public ThematicAreasService(ThematicAreasRepository thematicAreasRepository)
    {
        _thematicAreasRepository = thematicAreasRepository;
    }

    public string SaveThematicArea(ThematicArea thematicArea)
    {
        try
        {
            _thematicAreasRepository.Save(thematicArea);
            return "Area tematica registrada con exito";
        }
        catch (Exception e)
        {
            throw new ThematicAreasException(
                $"Ha ocurrido un error al registrar la area tematica{e.Message}");
        }
    }

    public ThematicArea? SearchThematicArea(int code)
    {
        return _thematicAreasRepository.Find(thematicArea =>
            thematicArea.Code == code);
    }

    public List<ThematicArea> GetAllThematicAreas()
    {
        return _thematicAreasRepository.GetAll();
    }

    public List<ThematicArea> FilterBySubLine(int subLineCode)
    {
        return _thematicAreasRepository.Filter(area =>
            area.SubLineCode == subLineCode);
    }

    public string DeleteThematicArea(int code)
    {
        try
        {
            ThematicArea? foundThematicArea = SearchThematicArea(code);
            if (foundThematicArea == null)
                throw new ThematicAreasException(
                    "Area tematica  no encontrada");
            _thematicAreasRepository.Delete(foundThematicArea);
            return "Area tematica eliminada";
        }
        catch (Exception e)
        {
            throw new ThematicAreasException(
                $"Ha ocurrido un error al eliminar la area tematica {e.Message}");
        }
    }
}
