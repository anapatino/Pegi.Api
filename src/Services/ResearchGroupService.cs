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

    public ResearchGroup? SearchResearchGroup(string name)
    {
        return _researchGroupRepository.Find(group =>
            group.Name == name);
    }
}
