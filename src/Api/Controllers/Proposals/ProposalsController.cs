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

    public ProposalsController(ProposalsService proposalsService)
    {
        _proposalsService = proposalsService;
    }

    [HttpPost]
    public ActionResult RegisterProposal(
        [FromBody] CreateProposalRequest createProposalRequest)
    {
        try
        {
            var    proposal = createProposalRequest.Adapt<Proposal>();
            string message  = _proposalsService.SaveProposal(proposal);
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
            Proposal? proposal = _proposalsService.SearchProposal(title);
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
            List<Proposal> proposal = _proposalsService.GetAllProposals();
            return Ok(
                new Response<List<ProposalResponse>>(
                    proposal.Adapt<List<ProposalResponse>>()));
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
            List<Proposal> proposal =
                _proposalsService.FilterProposalStatus(status);
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
            string message = _proposalsService.DeleteProposal(title);
            return Ok(new Response<Void>(message, false));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }
}
