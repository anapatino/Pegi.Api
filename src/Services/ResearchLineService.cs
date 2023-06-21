using Data.Repository;
using Entities;
using Entities.Exceptions;

namespace Services;

public class ResearchLineService
{
    private readonly ResearchLinesRepository _researchLinesRepository;


    public ResearchLineService(ResearchLinesRepository researchLinesRepository)
    {
        _researchLinesRepository = researchLinesRepository;
    }

    public string SaveLine(ResearchLine line)
    {
        try
        {
            _researchLinesRepository.Save(line);
            return "Linea de investigacion registrada con exito";
        }
        catch (Exception e)
        {
            throw new ResearchLineExcepion(
                $"Ha ocurrido un error al registrar la linea: {e.Message}");
        }
    }
    public List<ResearchLine> GetLines()
    {
        return _researchLinesRepository.GetAll();
    }

    public ResearchLine? SearchLine(string code)
    {
        return _researchLinesRepository.Find(line =>
            line.Code == code);
    }

}
