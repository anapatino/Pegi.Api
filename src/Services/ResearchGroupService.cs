using Data.Repository;
using Entities;
using Entities.Exceptions;

namespace Services;

public class ResearchGroupService
{
    private readonly ResearchGroupRepository _researchGroupRepository;
    public ResearchGroupService(ResearchGroupRepository researchGroupRepository)
    {
        _researchGroupRepository = researchGroupRepository;
    }

    public List<ResearchGroup> GetResearchGroups()
    {
        return _researchGroupRepository.GetAll();
    }

    public ResearchGroup? SearchResearchGroup(string code)
    {
        return _researchGroupRepository.Find(group =>
            group.Code == code);
    }
}
