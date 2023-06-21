using Entities;
using Entities.Exceptions;

namespace Services;

public class HistoryProyectService
{
    private readonly HistoryProyectRepository _historyProyectRepository;

    public HistoryProyectService(HistoryProyectRepository historyProyectRepository)
    {
        _historyProyectRepository = historyProyectRepository;
    }

    public (string, bool) SaveProyectlHistory(HistoryProyect historyProyect)
    {
        try
        {
            _historyProyectRepository.Save(historyProyect);
            return ("se ha guardado con exito", true);
        }
        catch (HistoryProyectExeption e)
        {
            return (e.Message, false);
        }
    }

    public List<HistoryProyect> SearchProyectHistory(string codeProyect)
    {
        return _historyProyectRepository.Filter(historyProyect =>
            historyProyect.ProyectCode == codeProyect);
    }


}
