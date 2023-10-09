using MediatR;
using PandapeInterview.Application.DTOs;
using PandapeInterview.Infrastructure;
using PandapeInterview.Infrastructure.Commands.CandidatesExperiences;

namespace PandapeInterview.Application.Handlers.CandidatesExperiences
{
    public class UpdateCandidateExperienceHandler : IRequestHandler<UpdateCandidateExperienceCommand, CandidateExperiencesDto>
    {
        private readonly ApplicationDbContext _Context;
        public UpdateCandidateExperienceHandler(ApplicationDbContext context)
        {
            _Context = context;
        }

        public async Task<CandidateExperiencesDto> Handle(UpdateCandidateExperienceCommand request, CancellationToken cancellationToken)
        {
            var Experience = await _Context.CandidateExperiences.FindAsync(new Object[] { request.idCandidateExperience }, cancellationToken);
            if (Experience != null)
            {
                Experience.ModifyDate = DateTime.UtcNow;
                Experience.EndDate = request.endDate;
                Experience.BegindDate = request.beginDate;
                Experience.Description = request.description;
                Experience.Company = request.company;
                Experience.Job = request.job;
                Experience.Salary= request.salary;
                await _Context.SaveChangesAsync(cancellationToken);
                return new CandidateExperiencesDto
                {
                    IdCandidateExperience = Experience.IdCandidateExperience,
                    IdCandidate = Experience.IdCandidate,
                    Description = Experience.Description,
                    BegindDate = Experience.BegindDate,
                    EndDate = Experience.EndDate,
                    Company  = Experience.Company,
                    Job = Experience.Job,
                    Salary = Experience.Salary,
                    InsertDate = Experience.InsertDate,
                    ModifyDate = DateTime.Now,
                };
            }
            return null;
        }
    }
}
