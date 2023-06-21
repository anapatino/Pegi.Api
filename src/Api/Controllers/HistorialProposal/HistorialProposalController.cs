using Entities;
using Entities.Exceptions;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers.HistorialProposal;

[ApiController]
[Route("HistorialPropose")]
public class HistorialProposalController : ControllerBase
{
    private readonly HistoryProposalService _historyProposalService;
    private readonly ProposalFeedBackService _proposalFeedBackService;
    private readonly ProposalService _proposalService;

    public HistorialProposalController(
        HistoryProposalService historyProposalService,
        ProposalFeedBackService proposalFeedBackService,
        ProposalService proposalService)
    {
        _historyProposalService = historyProposalService;
        _proposalFeedBackService = proposalFeedBackService;
        _proposalService = proposalService;
    }

    [HttpPost("register-feedback")]
    [Authorize(Roles = "Docente")]
    public ActionResult RegisterFeedback(
        [FromBody] ProposalFeedBackRequest proposalFeedBackRequest)
    {
        try
        {
            var feedBack = proposalFeedBackRequest.Adapt<ProposalFeedBack>();
            feedBack.Code = Random.Shared.Next();
            _proposalFeedBackService.SaveProposalFeedBack(feedBack);
            HistoryProposals historialProposal =
                new HistoryProposals(feedBack.Code,
                    proposalFeedBackRequest.ProposalCode);
            historialProposal.Code = Random.Shared.Next();
            _historyProposalService.SaveProposalHistory(historialProposal);
            _proposalService.UpdateStatusProposal(
                historialProposal.ProposalCode,
                historialProposal.ProposalFeedBack.Status);
            return Ok(
                new Response<HisotrialProposalResponse>(
                    historialProposal.Adapt<HisotrialProposalResponse>()));
        }
        catch (PersonExeption exeption)
        {
            return BadRequest(new Response<Void>(exeption.Message));
        }
    }

    [HttpGet("{proposalCode}")]
    public ActionResult GetHistoryProposals([FromRoute] string proposalCode)
    {
        try
        {
            List<HistoryProposals> historyProposals =
                _historyProposalService.SearchHistoryProposal(proposalCode);
            foreach (var historyProposal in historyProposals)
            {
                historyProposal.ProposalFeedBack =
                    _proposalFeedBackService.GetProposalFeedBackCode(
                        historyProposal.PorposalFeedBackCode);
            }
            if (historyProposals.Count <= 0)
            {
                return BadRequest(
                    new Response<Void>(
                        "no tiene experiencias registradas en propuesta"));
            }

            return Ok(
                new Response<List<HisotrialProposalResponse>>(
                    historyProposals.Adapt<List<HisotrialProposalResponse>>()));
        }
        catch (ExperienceExeption e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }
}
