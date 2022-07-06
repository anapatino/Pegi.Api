using Data.Repositories;
using Entities;
using Entities.Exceptions;

namespace Services;

public class ProgramsService
{
    private readonly ProgramsRepository _programsRepository;

    public ProgramsService(ProgramsRepository programsRepository)
    {
        _programsRepository = programsRepository;
    }

    public string SaveProgram(AcademicProgram academicProgram)
    {
        try
        {
            _programsRepository.Save(academicProgram);
            return "Programa registrado con exito";
        }
        catch (Exception e)
        {
            throw new AcademicProgramException(
                $"Ha ocurrido un error al registrar {e.Message}");
        }
    }

    public AcademicProgram? SearchProgram(string code)
    {
        return _programsRepository.Find(program =>
            program.Code == code);
    }

    public string DeleteProgram(string code)
    {
        try
        {
            var foundProgram = SearchProgram(code);
            if (foundProgram == null)
                throw new AcademicProgramException("Programa no encontrado");
            _programsRepository.Delete(foundProgram);
            return "Programa eliminado";
        }
        catch (Exception e)
        {
            throw new AcademicProgramException(
                $"Ha ocurrido un error al eliminar {e.Message}");
        }
    }
}
