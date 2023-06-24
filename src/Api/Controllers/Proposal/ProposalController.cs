using Api.Controllers.People;
using Entities.Exceptions;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Services;
using Entities;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers.Proposal;

[ApiController]
[Route("Proposals")]
public class ProposalController : ControllerBase
{
    private readonly ProposalService _proposalService;

    public ProposalController(ProposalService proposalService)
    {
        _proposalService = proposalService;
    }

    [HttpPost]
    [Authorize(Roles = ("Estudiante"))]
    public ActionResult RegisterProposal(
        [FromBody] ProposalRequest proposalRequest)
    {
        try
        {
            Entities.Proposal? newProposal =
                proposalRequest.Adapt<Entities.Proposal>();
            newProposal.Code = Random.Shared.Next().ToString();
            Entities.Proposal oldProposal =
                _proposalService.GetProposalCode(newProposal.Code!)!;
            if (newProposal.Code == oldProposal?.Code)
            {
                _proposalService.UpdateProposal(newProposal);
            }
            else
            {
                _proposalService.SaveProposal(newProposal);
            }

            return Ok(new Response<Void>("Propuesta registrada con exito",
                false));
        }
        catch (PersonExeption exeption)
        {
            return BadRequest(new Response<Void>(exeption.Message));
        }
    }

    [HttpGet("get-proposals-document/{document}")]
    [Authorize(Roles = "Estudiante,Docente")]
    public ActionResult GetProposalsDocument([FromRoute] string document)
    {
        try
        {
            List<Entities.Proposal> proposals =
                _proposalService.GetProposalsDocument(document);
            if (proposals.Count < 0)
            {
                return BadRequest(
                    new Response<Void>("No existen propuestas registradas con ese documento"));
            }

            return Ok(new Response<List<ProposalResponse>>(
                proposals?.Adapt<List<ProposalResponse>>()));
        }
        catch (PersonExeption e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    [HttpGet("get-proposals-professor/{document}")]
    [Authorize(Roles = "Docente,Administrador")]
    public ActionResult GetProposalsProfessorDocument([FromRoute] string document)
    {
        try
        {
            List<Entities.Proposal> proposals =
                _proposalService.GetProposalsProfessorDocument(document);
            if (proposals.Count < 0)
            {
                return BadRequest(
                    new Response<Void>("No existen propuestas registradas con ese documento"));
            }

            return Ok(new Response<List<ProposalResponse>>(
                proposals?.Adapt<List<ProposalResponse>>()));
        }
        catch (PersonExeption e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    [HttpGet("general-statistics-proposal-professor/{document}")]
    [Authorize(Roles = "Docente,Administrador")]
    public ActionResult GetGeneralStatisticsProposalProfessor([FromRoute] string document)
    {
        try
        {
           object statistics =
                _proposalService.GeneralStatisticsProposalProfessor(document);
            if (statistics == null)
            {
                return BadRequest(
                    new Response<Void>("No hay estadisticas para este docente"));
            }

            return Ok(new Response<object>(statistics));
        }
        catch (PersonExeption e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    [HttpGet("general-statistics-proposal-student/{document}")]
    [Authorize(Roles = "Estudiante,Administrador")]
    public ActionResult GetGeneralStatisticsProposalStudent([FromRoute] string document)
    {
        try
        {
            object statistics =
                _proposalService.GeneralStatisticsProposalStudent(document);
            if (statistics == null)
            {
                return BadRequest(
                    new Response<Void>("No hay estadisticas para este docente"));
            }

            return Ok(new Response<object>(statistics));
        }
        catch (PersonExeption e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    [HttpGet("general-statistics-proposal")]
    [Authorize(Roles = "Administrador")]
    public ActionResult GetGeneralStatisticsProposals()
    {
        try
        {
            object statistics =
                _proposalService.GeneralStatisticsProposals();
            if (statistics == null)
            {
                return BadRequest(
                    new Response<Void>("No hay estadisticas"));
            }

            return Ok(new Response<object>(statistics));
        }
        catch (PersonExeption e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }


    [HttpGet("get-proposal-code/{code}")]
    [Authorize(Roles = "Estudiante,Docente,Administrador")]
    public ActionResult GetProposalCode([FromRoute] string code)
    {
        try
        {
            Entities.Proposal?
                proposal = _proposalService.GetProposalCode(code);
            if (proposal == null)
            {
                return BadRequest(
                    new Response<Void>("No existe propuesta registrada con ese codigo"));
            }

            return Ok(
                new Response<ProposalResponse>(
                    proposal.Adapt<ProposalResponse>()));
        }
        catch (PersonExeption e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    [HttpPut("update-professor-proposal/")]
    [Authorize(Roles = "Administrador")]
    public ActionResult UpdateProfessorProposal([FromBody] ProposalUpdateRequest proposalUpdateRequest)
    {
        try
        {
            var (message,response)= _proposalService.UpdateEvaluatorDocumentProposal(proposalUpdateRequest.code,proposalUpdateRequest.ProfessorDocument);
            if (response == false )
            {
                return BadRequest(
                    new Response<Void>(message));

            }

             return Ok(new Response<Void>(message));

        }
        catch (PersonExeption e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    [HttpPut("update-professor-tutor-proposal/")]
    [Authorize(Roles = "Administrador")]
    public ActionResult UpdateProfessorTutorProposal([FromBody] ProposalUpdateRequest proposalUpdateRequest)
    {
        try
        {
            var (message,response)= _proposalService.UpdateTutorDocumentProposal(proposalUpdateRequest.code,proposalUpdateRequest.ProfessorDocument);
            if (response == false )
            {
                return BadRequest(
                    new Response<Void>(message));

            }

            return Ok(new Response<Void>(message));

        }
        catch (PersonExeption e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    [HttpGet]
    public ActionResult GetAll()
    {
        try
        {
            List<Entities.Proposal> proposals =
                _proposalService.GetAll();
            if (proposals.Count < 0)
            {
                return BadRequest(
                    new Response<Void>("No se pudo retornar una lista de propuesta"));
            }

            return Ok(new Response<List<ProposalResponse>>(
                proposals?.Adapt<List<ProposalResponse>>()));
        }
        catch (PersonExeption e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    [HttpDelete("{code}")]
    [Authorize(Roles = ("Estudiante"))]
    public ActionResult DeleteProposal([FromRoute] string code)
    {
        try
        {
            string message = _proposalService.DeleteProposal(code);
            return Ok(new Response<Void>(message, false));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }
}
