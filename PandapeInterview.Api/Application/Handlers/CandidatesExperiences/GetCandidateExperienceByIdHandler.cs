using MediatR;
using PandapeInterview.Application.DTOs;
using PandapeInterview.Infraestructure.Queries.CandidateExperiences;
using PandapeInterview.Infrastructure;

namespace PandapeInterview.Application.Handlers.CandidatesExperiences
{
    public class GetCandidateExperienceByIdHandler : IRequestHandler<GetCandidateExperienceByIdQuery, CandidateExperiencesDto>
    {
        private readonly ApplicationDbContext _Context;
        public GetCandidateExperienceByIdHandler(ApplicationDbContext context)
        {
            _Context = context;
        }

        public async Task<CandidateExperiencesDto> Handle(GetCandidateExperienceByIdQuery request, CancellationToken cancellationToken)
        {
            var Experience = await _Context.CandidateExperiences.FindAsync(new object[] { request.IdCandidateExperence }, cancellationToken);
            if (Experience == null)
            {
                return null;
            }
            return new CandidateExperiencesDto
            {
                IdCandidate = Experience.IdCandidate,
                IdCandidateExperience = Experience.IdCandidateExperience,
                Company = Experience.Company,
                Job = Experience.Job,
                BegindDate= Experience.BegindDate,
                Description = Experience.Description,
                EndDate = Experience.EndDate,
                InsertDate = Experience.InsertDate,
                ModifyDate = Experience.ModifyDate,
                Salary = Experience.Salary,
            };
        }
    }
}
