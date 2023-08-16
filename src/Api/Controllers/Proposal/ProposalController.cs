
using Entities.Exceptions;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Services;

using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers.Proposal;

[ApiController]
[Route("Proposals")]
public class ProposalController : ControllerBase
{
    private readonly ProposalService _proposalService;
    private readonly EmailService _emailService;
    private readonly PeopleService _peopleService;
    private readonly ResearchLineService _researchLine;
    private readonly ResearchSubLineService _researchSubline;
    private readonly ThematicAreaService _thematicArea;
    private readonly ResearchGroupService _researchGroupService;

    public ProposalController(ProposalService proposalService, EmailService emailService, PeopleService peopleService, ResearchLineService researchLine, ResearchSubLineService researchSubline, ThematicAreaService thematicArea, ResearchGroupService researchGroupService)
    {
        _proposalService = proposalService;
        _emailService = emailService;
        _peopleService = peopleService;
        _researchLine = researchLine;
        _researchSubline = researchSubline;
        _thematicArea = thematicArea;
        _researchGroupService = researchGroupService;
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

            Entities.Proposal oldProposal =
                _proposalService.GetProposalCode(newProposal.Code);
            if (oldProposal != null && oldProposal.Code != null && newProposal.Code == oldProposal.Code)
            {
                _proposalService.UpdateProposal(newProposal);
            }
            else
            {
                newProposal.Code = Random.Shared.Next().ToString();
                _proposalService.SaveProposal(newProposal);
            }
            var toAdresses = _peopleService.GetInstitutionalEmailMultiple(newProposal.PersonDocument1, newProposal.PersonDocument2);
            _emailService.SendEmailRegistration(toAdresses, "Propuesta", newProposal.Title);
            return Ok(new Response<Void>("Propuesta registrada con exito",
                false));
        }
        catch (PersonExeption exeption)
        {
            return BadRequest(new Response<Void>(exeption.Message));
        }
    }


    [HttpPut]
    [Authorize(Roles = ("Estudiante"))]
    public ActionResult UpdateProposal([FromBody] ProposalUpdate proposalRequest)
    {
        try
        {
            Entities.Proposal? existingProposal = _proposalService.GetProposalCode(proposalRequest.Code);
            Entities.Proposal? newProposal =
                proposalRequest.Adapt<Entities.Proposal>();

            if (existingProposal == null)
            {
                return NotFound(new Response<Void>("Propuesta no encontrada"));
            }

            newProposal.Status = existingProposal.Status;
            newProposal.TutorDocument = existingProposal.TutorDocument;
            newProposal.EvaluatorDocument = existingProposal.EvaluatorDocument;
            _proposalService.UpdateProposal(newProposal);

            return Ok(new Response<Void>("Propuesta actualizada con éxito", false));
        }
        catch (Exception exception)
        {
            return BadRequest(new Response<Void>(exception.Message));
        }
    }

    [HttpGet("get-proposals-document/{document}")]
    [Authorize(Roles = "Estudiante,Docente")]
    public ActionResult GetProposalsDocument([FromRoute] string document)
    {
        try
        {
            List<Entities.Proposal> proposals = _proposalService.GetProposalsDocument(document);

            if (proposals.Count < 0)
            {
                return BadRequest(new Response<Void>("No existen propuestas registradas con ese documento"));
            }

            List<ProposalResponse> proposalsResponse = MapProposalsToResponse(proposals);

            return Ok(new Response<List<ProposalResponse>>(proposalsResponse));
        }
        catch (PersonExeption e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    private List<ProposalResponse> MapProposalsToResponse(List<Entities.Proposal> proposals)
    {
        List<ProposalResponse> proposalsResponse = new List<ProposalResponse>();

        foreach (var proposal in proposals)
        {
            var investigationGroup = _researchGroupService.SearchResearchGroup(proposal.InvestigationGroup);
            var thematic = _thematicArea.SearchThematicAreaCode(proposal.ThematicAreaCode);
            var researchSubline = _researchSubline.SearchSubLineCode(thematic.ResearchSublineCode);
            var researchLine = _researchLine.SearchLine(researchSubline.ResearchLineCode);

            var newProposal = MapToProposalResponse(proposal, researchLine?.Name, researchSubline?.Name, thematic?.Name, investigationGroup?.Name);

            proposalsResponse.Add(newProposal);
        }

        return proposalsResponse;
    }

    private ProposalResponse MapToProposalResponse(Entities.Proposal proposal, string researchLine, string researchSubline, string areaThematic, string investigationGroup)
    {
        return new ProposalResponse
        (
            proposal.Code,
            proposal.PersonDocument1,
            proposal.PersonDocument2,
            proposal.EvaluatorDocument,
            proposal.TutorDocument,
            proposal.Title,
            proposal.Date,
            proposal.InvestigationGroup,
            proposal.Approach,
            proposal.Justification,
            proposal.GeneralObjective,
            proposal.SpecificObjective,
            proposal.Bibliographical,
            proposal.Status,
            researchLine,
            researchSubline,
            areaThematic,
            investigationGroup
        );
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

            List<ProposalResponse> proposalsResponse = MapProposalsToResponse(proposals);

            return Ok(new Response<List<ProposalResponse>>(proposalsResponse));
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

            var investigationGroup = _researchGroupService.SearchResearchGroup(proposal.InvestigationGroup);
            var thematic = _thematicArea.SearchThematicAreaCode(proposal.ThematicAreaCode);
            var researchSubline = _researchSubline.SearchSubLineCode(thematic.ResearchSublineCode);
            var researchLine = _researchLine.SearchLine(researchSubline.ResearchLineCode);

            var newProposal = MapToProposalResponse(proposal, researchLine?.Name, researchSubline?.Name, thematic?.Name, investigationGroup?.Name);

            return Ok(new Response<ProposalResponse>(newProposal));
        }
        catch (PersonExeption e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    [HttpGet("get-proposals-by-title/{title}")]
    [Authorize(Roles = "Estudiante,Docente,Administrador")]
    public ActionResult GetProposalByTitleProposal([FromRoute] string title)
    {
        try
        {
            List<Entities.Proposal> proposals = _proposalService.GetProposalsByTitle(title);

            if (proposals == null)
            {
                return BadRequest(
                    new Response<Void>("No existe propuesta registrada con esa palabra"));
            }

            List<ProposalResponse> proposalsResponse = MapProposalsToResponse(proposals);

            return Ok(new Response<List<ProposalResponse>>(proposalsResponse));
        }
        catch (PersonExeption e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    [HttpPut("update-evaluator-proposal/")]
    [Authorize(Roles = "Administrador")]
    public ActionResult UpdateEvaluatorProposal([FromBody] ProposalUpdateRequest proposalUpdateRequest)
    {
        try
        {
            var (message, response) = _proposalService.UpdateEvaluatorDocumentProposal(proposalUpdateRequest.code, proposalUpdateRequest.ProfessorDocument);
            if (response == false)
            {
                return BadRequest(
                    new Response<Void>(message));
            }
            var (toAdresses, toAdress, title) = GetAdressesEmailStudentsAndDocent(proposalUpdateRequest.code, true);
            _emailService.SendEmailAssignmentStudentProposal(toAdresses, "Evaluador", title);
            _emailService.SendEmailAssignmentEvaluatorProposal(toAdress, title);
            return Ok(new Response<Void>(message));

        }
        catch (PersonExeption e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    private (List<string>, string, string) GetAdressesEmailStudentsAndDocent(
        string code, bool type)
    {
        var proposal =
            _proposalService.GetProposalCode(code);
        var toAdresses = _peopleService.GetInstitutionalEmailMultiple(proposal.PersonDocument1, proposal.PersonDocument2);
        var toAdress =
            _peopleService.GetInstitutionalEmail(type ? proposal.EvaluatorDocument : proposal.TutorDocument);
        return (toAdresses, toAdress, proposal.Title);
    }

    [HttpPut("update-tutor-proposal/")]
    [Authorize(Roles = "Administrador")]
    public ActionResult UpdateTutorProposal([FromBody] ProposalUpdateRequest proposalUpdateRequest)
    {
        try
        {
            var (message, response) = _proposalService.UpdateTutorDocumentProposal(proposalUpdateRequest.code, proposalUpdateRequest.ProfessorDocument);
            if (response == false)
            {
                return BadRequest(
                    new Response<Void>(message));

            }
            var (toAdresses, toAdress, title) = GetAdressesEmailStudentsAndDocent(proposalUpdateRequest.code, false);
            _emailService.SendEmailAssignmentStudentProposal(toAdresses, "Tutor", title);
            _emailService.SendEmailAssignmentTutorProposal(toAdress, title);
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

            List<ProposalResponse> proposalsResponse = MapProposalsToResponse(proposals);

            return Ok(new Response<List<ProposalResponse>>(proposalsResponse));
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
