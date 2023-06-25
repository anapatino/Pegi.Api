using Data.Repository;
using Entities;
using Entities.Exceptions;

namespace Services;

public class ProjectFeedBackService
{
    private readonly ProjectFeedBackRepository _projectFeedBackRepository;

    public ProjectFeedBackService(ProjectFeedBackRepository projectFeedBackRepository)
    {
        _projectFeedBackRepository = projectFeedBackRepository;
    }

    public (string, bool) SaveProjectFeedBack(ProjectFeedBack projectFeedBack)
    {
        try
        {
            _projectFeedBackRepository.Save(projectFeedBack);
            return ("Se ha guardado con exito la calificacionde su proyecto", true);
        }
        catch (ProyectFeedBackExeption e)
        {
            return (e.Message, false);
        }
    }

    public ProjectFeedBack? GetProjectFeedBackCode(int? code)
    {
        return _projectFeedBackRepository.Find(projectfeedback => projectfeedback.Code == code);
    }


}
