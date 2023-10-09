using MediatR;
using Microsoft.AspNetCore.Mvc;
using PandapeInterview.Infraestructure.Queries;
using PandapeInterview.Infraestructure.Queries.CandidateExperiences;
using PandapeInterview.Infrastructure.Commands.Candidates;
using PandapeInterview.Infrastructure.Commands.CandidatesExperiences;
using PandapeInterview.Infrastructure.Queries.Candidates;
using System.Net;

namespace PandapeInterview.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CandidatesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CandidatesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region GetCommands 

        [HttpGet("GetAllCandidates", Name = "GetAllCandidates")]
        public async Task<IActionResult> GetAllCandidates()
        {
            var Candidates = await _mediator.Send(new GetAllCandidatesQuery());
            if (Candidates == null || Candidates.Count() <= 0)
            {
                return NotFound(new { Status = false, Code = HttpStatusCode.NotFound, Messagge = "No candidates were found in the database" });
            }
            return Ok(new { Status = true, Code = HttpStatusCode.OK, Candidates });
        }
        [HttpGet("GetCandidateById", Name = "GetCandidateById")]
        public async Task<IActionResult> GetCandidateById(int IdCandidate)
        {
            IdCandidate = IdCandidate < 0 ? (IdCandidate * (-1)) : IdCandidate;
            var Candidate = await _mediator.Send(new GetCandidateByIdQuery(IdCandidate));
            if (Candidate == null)
            {
                return NotFound(new { Status = false, Code = HttpStatusCode.NotFound, Messagge = $"No candidate were found in the database with {IdCandidate} ID" });
            }
            return Ok(new { Status = true, Code = HttpStatusCode.OK, Candidate });
        }
        [HttpGet("GetCandidateExperienceById", Name = "GetCandidateExperienceById")]
        public async Task<IActionResult> GetCandidateExperienceById(int IdCandidateExperience)
        {
            IdCandidateExperience = IdCandidateExperience < 0 ? (IdCandidateExperience * (-1)) : IdCandidateExperience;
            var Candidate = await _mediator.Send(new GetCandidateExperienceByIdQuery(IdCandidateExperience));
            if (Candidate == null)
            {
                return NotFound(new { Status = false, Code = HttpStatusCode.NotFound, Messagge = $"No candidate experience were found in the database with {IdCandidateExperience} ID" });
            }
            return Ok(new { Status = true, Code = HttpStatusCode.OK, Candidate });
        }
        [HttpGet("GetAllCandidatesExperiences", Name = "GetAllCandidatesExperiences")]
        public async Task<IActionResult> GetAllCandidatesExperiences()
        {
            var Experiences = await _mediator.Send(new GetAllCandidatesExperiencesQuery());
            if (Experiences == null || Experiences.Count() <= 0)
            {
                return NotFound(new { Status = false, Code = HttpStatusCode.NotFound, Messagge = "No candidates experiences were found in the database" });
            }
            return Ok(new { Status = true, Code = HttpStatusCode.OK, Experiences });
        }
        [HttpGet("GetCandidateProfile", Name = "GetCandidateProfile")]
        public async Task<IActionResult> GetCandidateProfile(int IdCandidate)
        {
            IdCandidate = IdCandidate < 0 ? (IdCandidate * (-1)) : IdCandidate;
            var Candidate = await _mediator.Send(new GetCandidateProfileQuery(IdCandidate));
            if (Candidate == null)
            {
                return NotFound(new { Status = false, Code = HttpStatusCode.NotFound, Messagge = $"No candidate were found in the database with {IdCandidate} ID" });
            }
            return Ok(new { Status = true, Code = HttpStatusCode.OK, Candidate });
        }

        #endregion

        #region PostCommands

        [HttpPost("CreateCandidate", Name = "CreateCandidate")]
        public async Task<IActionResult> CreateCandidate(CreateCandidateCommand candidate)
        {
            try
            {
                var Candidate = await _mediator.Send(candidate);
                var Action = CreatedAtAction(nameof(GetCandidateById), new { IdCandidate = Candidate.IdCandidate }, Candidate);
                return Ok(new { Status = true, Code = HttpStatusCode.OK, Candidate = Action.Value });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = true, Code = HttpStatusCode.BadRequest, Message = ex.Message });
            }

        }
        [HttpPost("CreateCandidateExperience", Name = "CreateCandidateExperience")]
        public async Task<IActionResult> CreateCandidateExperience(CreateCandidateExperienceCommand experience)
        {
            try
            {
                var Experience = await _mediator.Send(experience);
                if (Experience == null)
                {
                    return NotFound(new { Status = false, Code = HttpStatusCode.NotFound, Messagge = $"No candidate were found in the database with {experience.idCandidate} ID" });
                }
                var Action = CreatedAtAction(nameof(GetCandidateExperienceById), new { Experience.IdCandidateExperience }, Experience);
                return Ok(new { Status = true, Code = HttpStatusCode.OK, Experience = Action.Value });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = true, Code = HttpStatusCode.BadRequest, Message = ex.Message });
            }
        }

        #endregion

        #region PutCommands

        [HttpPut("UpdateCandidate", Name = "UpdateCandidate", Order = 4)]
        public async Task<IActionResult> UpdateCandidate(UpdateCandidateCommand candidate)
        {
            try
            {
                var Candidate = await _mediator.Send(candidate);
                if (Candidate == null)
                {
                    return NotFound(new { Status = false, Code = HttpStatusCode.NotFound, Messagge = $"No candidate were found in the database with {Candidate.IdCandidate} ID" });
                }
                return Ok(new { Status = true, Code = HttpStatusCode.OK, Candidate });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = true, Code = HttpStatusCode.BadRequest, Message = ex.Message });
            }

        }
        [HttpPut("UpdateCandidateExperience", Name = "UpdateCandidateExperience")]
        public async Task<IActionResult> UpdateCandidateExperience(UpdateCandidateExperienceCommand experience)
        {
            try
            {
                var Experience = await _mediator.Send(experience);
                if (Experience == null)
                {
                    return NotFound(new { Status = false, Code = HttpStatusCode.NotFound, Messagge = $"No candidate experience were found in the database with {Experience.IdCandidateExperience} ID" });
                }
                return Ok(new { Status = true, Code = HttpStatusCode.OK, Experience });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = true, Code = HttpStatusCode.BadRequest, Message = ex.Message });
            }

        }

        #endregion

        #region DeleteCommands

        [HttpDelete("DeleteCandidate", Name = "DeleteCandidate")]
        public async Task<IActionResult> DeleteCandidate(int IdCandidate)
        {
            try
            {
                var Candidate = await _mediator.Send(new DeleteCandidateCommand(IdCandidate));
                if (!Candidate)
                {
                    return BadRequest(new { Status = false, Code = HttpStatusCode.NotFound, Messagge = $"No candidate were found in the database with {IdCandidate} ID, or it can be a database error" });
                }
                return Ok(new { Status = true, Code = HttpStatusCode.OK, Message = "Candidate successfully eliminated" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = true, Code = HttpStatusCode.BadRequest, Message = ex.Message });
            }

        }
        [HttpDelete("DeleteCandidateExperience", Name = "DeleteCandidateExperience")]
        public async Task<IActionResult> DeleteCandidateExperience(int IdCandidateExperience)
        {
            try
            {
                var Candidate = await _mediator.Send(new DeleteCandidateExperienceCommand(IdCandidateExperience));
                if (!Candidate)
                {
                    return BadRequest(new { Status = false, Code = HttpStatusCode.NotFound, Messagge = $"No candidate experience were found in the database with {IdCandidateExperience} ID, or it can be a database error" });
                }
                return Ok(new { Status = true, Code = HttpStatusCode.OK, Message = "Candidate experience successfully eliminated" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = true, Code = HttpStatusCode.BadRequest, Message = ex.Message });
            }

        }

        #endregion
    }
}