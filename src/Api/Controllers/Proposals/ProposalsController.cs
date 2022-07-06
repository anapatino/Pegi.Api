using Entities;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers.Proposals;

[ApiController]
[Route("proposal")]
public class ProposalsController : ControllerBase
{
    private readonly ProposalsService _proposalsService;

    public ProposalsController(ProposalsService ProposalsService)
    {
        _proposalsService = ProposalsService;
    }

    [HttpPost]
    public ActionResult RegisterProposal(
        [FromBody] CreateProposalRequest createProposalRequest)
    {
        try
        {
            var proposal = createProposalRequest.Adapt<Proposal>();
            var message = _proposalsService.SaveProposal(proposal);
            return Ok(new Response<Void>(message, false));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    [HttpGet("{code-proposal}")]
    public ActionResult GetProposal([FromBody] string codeProposal)
    {
        try
        {
            var proposal = _proposalsService.SearchProposal(codeProposal);
            if (proposal == null)
                return BadRequest(
                    new Response<Void>("No existe propuesta"));
            return Ok(
                new Response<ProposalResponse>(
                    proposal.Adapt<ProposalResponse>()));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    [HttpDelete("{code-proposal}")]
    public ActionResult DeleteProposal([FromRoute] string codeProposal)
    {
        try
        {
            var message = _proposalsService.DeleteProposal(codeProposal);
            return Ok(new Response<Void>(message, false));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }
}
