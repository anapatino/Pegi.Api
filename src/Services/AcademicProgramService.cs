using Data.Repository;
using Entities;
using Entities.Exceptions;

namespace Services;

public class AcademicProgramService
{
    private readonly AcademicProgramsRepository _academicProgramsRepository;

    public AcademicProgramService(AcademicProgramsRepository academicProgramsRepository)
    {
        _academicProgramsRepository = academicProgramsRepository;
    }


    public AcademicProgram? SearchProfessorAcademicProgram(string code)
    {
        return _academicProgramsRepository.Find(AcademicProgram =>
            AcademicProgram.Code == code);
    }

    public List<AcademicProgram> GetAll()
    {
        return _academicProgramsRepository.GetAll();
    }


}
