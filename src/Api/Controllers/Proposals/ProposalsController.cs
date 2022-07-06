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

    [HttpGet("{title}")]
    public ActionResult GetProposal([FromBody] string title)
    {
        try
        {
            var proposal = _proposalsService.SearchProposal(title);
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

    [HttpGet]
    public ActionResult GetAllProposals()
    {
        try
        {
            var proposal = _proposalsService.AllProposal();
            if (proposal == null)
                return BadRequest(
                    new Response<Void>("No existen propuestas"));
            return Ok(
                new Response<ProposalResponse>(
                    proposal.Adapt<ProposalResponse>()));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    [HttpGet("{status}")]
    public ActionResult GetFilterProposalStatus([FromBody] string status)
    {
        try
        {
            var proposal = _proposalsService.FilterProposalStatus(status);
            if (proposal == null)
                return BadRequest(
                    new Response<Void>("No existe propuestas con este estado"));
            return Ok(
                new Response<ProposalResponse>(
                    proposal.Adapt<ProposalResponse>()));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    [HttpDelete("{title}")]
    public ActionResult DeleteProposal([FromRoute] string title)
    {
        try
        {
            var message = _proposalsService.DeleteProposal(title);
            return Ok(new Response<Void>(message, false));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }
}
