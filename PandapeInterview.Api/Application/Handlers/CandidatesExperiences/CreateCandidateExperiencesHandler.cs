using MediatR;
using PandapeInterview.Application.DTOs;
using PandapeInterview.Domain;
using PandapeInterview.Infrastructure;
using PandapeInterview.Infrastructure.Commands.CandidatesExperiences;

namespace PandapeInterview.Application.Handlers.CandidatesExperiences
{
    public class CreateCandidateExperiencesHandler : IRequestHandler<CreateCandidateExperienceCommand, CandidateExperiencesDto>
    {
        private readonly ApplicationDbContext _Context;
        public CreateCandidateExperiencesHandler(ApplicationDbContext context)
        {
            _Context = context;
        }

        public async Task<CandidateExperiencesDto?> Handle(CreateCandidateExperienceCommand request, CancellationToken cancellationToken)
        {
            var Candidate = await _Context.Candidates.FindAsync(new object[] { request.idCandidate },cancellationToken);
            if (Candidate != null)
            {
                var Experience = new CandidateExperiences()
                {
                    IdCandidate= request.idCandidate,
                    Company = request.company,
                    Job = request.job,
                    Description = request.description,
                    BegindDate = request.beginDate,
                    EndDate = request.endDate,
                    Salary = request.salary,
                    Candidates = Candidate,
                    InsertDate = DateTime.Now,
                    ModifyDate = null
                };
                _Context.CandidateExperiences.Add(Experience);
                await _Context.SaveChangesAsync(cancellationToken);
                return new CandidateExperiencesDto
                {
                    IdCandidateExperience = Experience.IdCandidateExperience,
                    IdCandidate = Experience.IdCandidate,
                    Company = Experience.Company,
                    Job = Experience.Job, 
                    Description = Experience.Description,
                    BegindDate = Experience.BegindDate,
                    EndDate = Experience.EndDate,
                    Salary= Experience.Salary,
                    InsertDate = DateTime.Now,
                    ModifyDate = null
                };
            }
            return null;
        }
    }
}
