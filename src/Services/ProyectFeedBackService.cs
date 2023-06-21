using Data.Repository;
using Entities;
using Entities.Exceptions;

namespace Services;

public class ProyectFeedBackService
{
    private readonly ProyectFeedBackRepository _proyectFeedBackRepository;

    public ProyectFeedBackService(ProyectFeedBackRepository proyectFeedBackRepository)
    {
        _proyectFeedBackRepository = proyectFeedBackRepository;
    }

    public (string, bool) SaveProyectFeedBack(ProyectFeedBack proyectFeedBack)
    {
        try
        {
            _proyectFeedBackRepository.Save(proyectFeedBack);
            return ("se ha guardado con exito", true);
        }
        catch (ProyectFeedBackExeption e)
        {
            return (e.Message, false);
        }
    }

    public ProyectFeedBack? GetProyectFeedBackCode(int? code)
    {
        return _proyectFeedBackRepository.Find(Proyectfeedback => Proyectfeedback.Code == code);
    }


}
