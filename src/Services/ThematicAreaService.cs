using Data.Repository;
using Entities;
using Entities.Exceptions;

namespace Services;

public class ThematicAreaService
{
    private readonly ThematicAreasRepository _thematicAreasRepository;

    public ThematicAreaService(ThematicAreasRepository thematicAreasRepository)
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
            throw new ThematicAreaExeption(
                $"Ha ocurrido un error al registrar la area tematica {e.Message}");
        }
    }

    public List<ThematicArea> GetLinesThematicAreas()
    {
        return _thematicAreasRepository.GetAll();
    }

    public List<ThematicArea> SearchThematicArea(string code)
    {
        return _thematicAreasRepository.Filter(area  =>
            area.ResearchSublineCode == code);
    }
}
