using Microsoft.AspNetCore.Mvc;
using Services;
using Mapster;

namespace Api.Controllers.ResearchGroup
{
    [ApiController]
    [Route("research-group")]
    public class ResearchGroupController : ControllerBase
    {
        private readonly ResearchGroupService _researchGroupService;

        public ResearchGroupController(ResearchGroupService researchGroupService)
        {
            _researchGroupService = researchGroupService;
        }

        [HttpGet("{code}")]
        public ActionResult GetResearchGroup(string code)
        {
            Entities.ResearchGroup? group = _researchGroupService.SearchResearchGroup(code);
            if (group == null || group.Code == null)
            {
                return BadRequest(new Response<Void>("No se encontró un grupo de investigación con ese código."));
            }
            else
            {
                return Ok(new Response<ResearchGroupResponse>(group.Adapt<ResearchGroupResponse>()));
            }
        }

        [HttpGet("get-all-research-groups")]
        public ActionResult GetAllResearchGroups()
        {
            List<Entities.ResearchGroup> groups = _researchGroupService.GetResearchGroups();
            if (groups.Count == 0)
            {
                return BadRequest(new Response<Void>("No se encontraron grupos de investigación."));
            }

            return Ok(new Response<List<ResearchGroupResponse>>(groups.Adapt<List<ResearchGroupResponse>>()));
        }
    }
}
