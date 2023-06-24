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

    public (string, bool) SaveProjectlHistory(HistoryProject historyProject)
    {
        try
        {
            _historyProjectRepository.Save(historyProject);
            return ("se ha guardado con exito", true);
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
