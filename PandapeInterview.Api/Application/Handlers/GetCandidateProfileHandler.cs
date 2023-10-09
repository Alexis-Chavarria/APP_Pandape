using MediatR;
using Microsoft.EntityFrameworkCore;
using PandapeInterview.Application.DTOs;
using PandapeInterview.Domain;
using PandapeInterview.Infraestructure.Queries;
using PandapeInterview.Infrastructure;

namespace PandapeInterview.Application.Handlers
{
    public class GetCandidateProfileHandler : IRequestHandler<GetCandidateProfileQuery, CandidateProfileVm>
    {
        private readonly ApplicationDbContext _Context;
        public GetCandidateProfileHandler(ApplicationDbContext context)
        {
            _Context = context;
        }
        public async Task<CandidateProfileVm?> Handle(GetCandidateProfileQuery request, CancellationToken cancellationToken)
        {
            var query = from candidate in _Context.Candidates
            where candidate.IdCandidate == request.IdCandidate
                        select new CandidateProfileVm
                        {
                            candidate = new CandidateDto
                            {
                                IdCandidate = candidate.IdCandidate,
                                Name = candidate.Name,
                                Surname = candidate.Surname,
                                Birthdate = candidate.Birthdate,
                                Email = candidate.Email,
                                InsertDate = candidate.InsertDate,
                                ModifyDate = candidate.ModifyDate
                            },
                            experience = (from experience in _Context.CandidateExperiences
                                          where experience.IdCandidate == candidate.IdCandidate
                                          select new CandidateExperiencesDto
                                          {
                                              IdCandidateExperience = experience.IdCandidateExperience,
                                              IdCandidate = experience.IdCandidate,
                                              Company = experience.Company,
                                              Job = experience.Job,
                                              Description = experience.Description,
                                              Salary = experience.Salary,
                                              BegindDate = experience.BegindDate,
                                              EndDate = experience.EndDate,
                                              InsertDate = experience.InsertDate,
                                              ModifyDate = experience.ModifyDate
                                          }).ToList()
                        };
            return await query.FirstOrDefaultAsync();
           
        }
    }
}
