using Data.Repositories;

namespace Services;

public class CVService
{
    private readonly CVRepository _cvRepository;

    public CVService(CVRepository cvRepository)
    {
        _cvRepository = cvRepository;
    }
}
