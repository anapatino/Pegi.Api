using Data.Repository;
using Entities;
using Entities.Exceptions;

namespace Services;

public class ExperienceService
{
    private readonly ExperiencesRepository _experiencesRepository;

    public ExperienceService(ExperiencesRepository experiencesRepository)
    {
        _experiencesRepository = experiencesRepository;
    }

    public (string, bool)  saveExperience(Experience experience)
    {
        try
        {
            _experiencesRepository.Save(experience);
            return ("se ha guardado con exito", true);
        }
        catch (StudyExeption e)
        {
            return (e.Message, false);
        }
    }

    public List<Experience> SearchExperiences(string documentPerson)
    {
        return _experiencesRepository.Filter(experience => experience.PeopleCode == documentPerson);
    }
}
