using Entities.Exceptions;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers.Proyect;

[ApiController]
[Route("Proyect")]
public class ProyectController : ControllerBase
{
    private readonly ProyectService _proyectService;

    public ProyectController(ProyectService proyectService)
    {
        _proyectService = proyectService;
    }

    [HttpPost]
    [Authorize(Roles = ("Estudiante"))]
    public ActionResult RegisterProyect()
    {
        try
        {
            var personDocument = Request.Form["personDocument"];
            var status = Request.Form["status"];
            var score = Convert.ToInt32(Request.Form["score"]);
            var proposalCode = Request.Form["proposalCode"];
            var content = Request.Form.Files.GetFile("content");

            Entities.Proyect newProyect = new Entities.Proyect
            {
                Code = Random.Shared.Next().ToString(),
                PersonDocument1 = personDocument,
                Content = GetBytesFromStream(content.OpenReadStream()),
                Status = status,
                Score = score,
                ProposalCode = proposalCode
            };

            Entities.Proyect oldProyect = _proyectService.SearchProyect(newProyect.Code)!;
            if (newProyect.Code == oldProyect?.Code)
            {
                _proyectService.UpdateProyect(newProyect);
            }
            else
            {
                _proyectService.SaveProyect(newProyect);
            }

            return Ok(new Response<Void>("se ha guardado con éxito", false));
        }
        catch (PersonExeption exception)
        {
            return BadRequest(new Response<Void>(exception.Message));
        }
    }

    private byte[] GetBytesFromStream(Stream stream)
    {
        using (var memoryStream = new MemoryStream())
        {
            stream.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }



    [HttpGet("get-proyect-document{document}")]
    [Authorize(Roles = "Estudiante,Docente,Administrador")]
    public ActionResult GetProyects([FromRoute] string document)
    {
        try
        {
            List<Entities.Proyect> proyects =
                _proyectService.GetProyects(document);
            if (proyects.Count < 0)
            {
                return BadRequest(
                    new Response<Void>("no se encontro ninguna propuesta"));
            }

            return Ok(new Response<List<ProyectResponse>>(
                proyects?.Adapt<List<ProyectResponse>>()));
        }
        catch (PersonExeption e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    [HttpGet("get-proyect-professor/{document}")]
    [Authorize(Roles = "Docente,Administrador")]
    public ActionResult GetProyectsProfessorDocument([FromRoute] string document)
    {
        try
        {
            List<Entities.Proyect> proyects =
                _proyectService.GetProyectsProfessorDocument(document);
            if (proyects.Count < 0)
            {
                return BadRequest(
                    new Response<Void>("No existen propuestas registradas con ese documento"));
            }

            return Ok(new Response<List<ProyectResponse>>(
                proyects?.Adapt<List<ProyectResponse>>()));
        }
        catch (PersonExeption e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    [HttpGet("get-proyect-code/{code}")]
    [Authorize(Roles = "Estudiante,Docente,Administrador")]
    public ActionResult GetProyectCode([FromRoute] string code)
    {
        try
        {
            Entities.Proyect? proyect = _proyectService.GetProyectCode(code);
            if (proyect == null)
            {
                return BadRequest(new Response<Void>("no se encontro a la propuesta"));
            }

            string contentBase64 = Convert.ToBase64String(proyect.Content);

            var response = new ProyectResponse(
                proyect.Code,
                proyect.PersonDocument1,
                proyect.EvaluatorDocument,
                contentBase64, // Enviar el contenido del archivo como cadena Base64
                proyect.Status,
                proyect.Score,
                proyect.ProposalCode
            );

            return Ok(new Response<ProyectResponse>(response));
        }
        catch (PersonExeption e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }


    [HttpPut("update-professor-proyect/")]
    [Authorize(Roles = "Administrador")]
    public ActionResult UpdateProfessorProyect([FromBody] ProyectUpdateRequest proyectUpdateRequest)
    {
        try
        {
            var (message,response)= _proyectService.UpdateEvaluatorDocumentProyect(proyectUpdateRequest.code,proyectUpdateRequest.ProfessorDocument);
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
            List<Entities.Proyect> proyects =
                _proyectService.GetAll();
            if (proyects.Count < 0)
            {
                return BadRequest(
                    new Response<Void>("no se encontro ninguna propuesta"));
            }

            return Ok(new Response<List<ProyectResponse>>(
                proyects?.Adapt<List<ProyectResponse>>()));
        }
        catch (PersonExeption e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    [HttpDelete("{code}")]
    [Authorize(Roles = ("Estudiante"))]
    public ActionResult DeleteProyect([FromRoute] string code)
    {
        try
        {
            string message = _proyectService.DeleteProyect(code);
            return Ok(new Response<Void>(message, false));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    [HttpGet("general-statistics-proyect-professor/{document}")]
    [Authorize(Roles = "Docente,Administrador")]
    public ActionResult GetGeneralStatisticsProyectProfessor([FromRoute] string document)
    {
        try
        {
            object statistics =
                _proyectService.GeneralStatisticsProyectProfessor(document);
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

    [HttpGet("general-statistics-proyect-student/{document}")]
    [Authorize(Roles = "Estudiante,Administrador")]
    public ActionResult GetGeneralStatisticsProyectStudent([FromRoute] string document)
    {
        try
        {
            object statistics =
                _proyectService.GeneralStatisticsProyectStudent(document);
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

    [HttpGet("general-statistics-proyect")]
    [Authorize(Roles = "Administrador")]
    public ActionResult GetGeneralStatisticsProposals()
    {
        try
        {
            object statistics =
                _proyectService.GeneralStatisticsProyects();
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
}
