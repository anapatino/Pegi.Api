using Data.Repository;
using Entities;
using Entities.Exceptions;

namespace Services;

public class ResearchSubLineService
{
    private readonly ResearchSubLinesRepository _researchSubLinesRepository;


    public ResearchSubLineService(ResearchSubLinesRepository researchSubLinesRepository)
    {
        _researchSubLinesRepository = researchSubLinesRepository;
    }

    public string SaveSubline(ResearchSubline subline)
    {
        try
        {
            _researchSubLinesRepository.Save(subline);
            return "Sublinea registrada con exito";
        }
        catch (Exception e)
        {
            throw new ResearchSubLineExeption(
                $"Ha ocurrido un error al registrar la sublinea {e.Message}");
        }
    }

    public List<ResearchSubline> GetLines()
    {
        return _researchSubLinesRepository.GetAll();
    }

    public List<ResearchSubline> SearchSubLine(string code)
    {
        return _researchSubLinesRepository.Filter(line =>
            line.ResearchLineCode == code);
    }


}
