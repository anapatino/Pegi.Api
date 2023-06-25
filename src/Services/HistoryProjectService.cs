using Entities;
using Entities.Exceptions;

namespace Services;

public class HistoryProjectService
{
    private readonly HistoryProjectRepository _historyProjectRepository;

    public HistoryProjectService(HistoryProjectRepository historyProjectRepository)
    {
        _historyProjectRepository = historyProjectRepository;
    }

    public (string, bool) SaveProjectHistory(HistoryProject historyProject)
    {
        try
        {
            _historyProjectRepository.Save(historyProject);
            return ("Se ha guardado con exito el historial de proyecto", true);
        }
        catch (HistoryProyectExeption e)
        {
            return (e.Message, false);
        }
    }

    public List<HistoryProject> SearchProjectHistory(string codeProject)
    {
        return _historyProjectRepository.Filter(historyProject =>
            historyProject.ProjectCode == codeProject);
    }


}
