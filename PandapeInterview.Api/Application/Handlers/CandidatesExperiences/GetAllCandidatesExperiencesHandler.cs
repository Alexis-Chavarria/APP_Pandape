using MediatR;
using Microsoft.EntityFrameworkCore;
using PandapeInterview.Application.DTOs;
using PandapeInterview.Infraestructure.Queries.CandidateExperiences;
using PandapeInterview.Infrastructure;

namespace PandapeInterview.Application.Handlers.CandidatesExperiences
{
    public class GetAllCandidatesExperiencesHandler : IRequestHandler<GetAllCandidatesExperiencesQuery, IEnumerable<CandidateExperiencesDto>>
    {
        private readonly ApplicationDbContext _Context;
        public GetAllCandidatesExperiencesHandler(ApplicationDbContext context)
        {
            _Context = context;
        }

        public async Task<IEnumerable<CandidateExperiencesDto>> Handle(GetAllCandidatesExperiencesQuery request, CancellationToken cancellationToken)
        {
            var Experiences = await _Context.CandidateExperiences.ToListAsync(cancellationToken);
            return Experiences.Select(experience => new CandidateExperiencesDto
            {
                IdCandidate = experience.IdCandidate,
                IdCandidateExperience = experience.IdCandidateExperience,
                BegindDate= experience.BegindDate,
                EndDate = experience.EndDate,
                Description= experience.Description,
                Job = experience.Job,
                Company = experience.Company,
                Salary = experience.Salary,
                InsertDate = experience.InsertDate,
                ModifyDate = experience.ModifyDate,
            });
        }
    }
}
