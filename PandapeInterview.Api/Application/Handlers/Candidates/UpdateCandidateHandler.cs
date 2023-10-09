using MediatR;
using PandapeInterview.Application.DTOs;
using PandapeInterview.Infrastructure;
using PandapeInterview.Infrastructure.Commands.Candidates;

namespace PandapeInterview.Application.Handlers.Candidates
{
    public class UpdateCandidateHandler : IRequestHandler<UpdateCandidateCommand, CandidateDto>
    {
        private readonly ApplicationDbContext _Context;
        public UpdateCandidateHandler(ApplicationDbContext Context)
        {
            _Context= Context;
        }
        public async Task<CandidateDto?> Handle(UpdateCandidateCommand request, CancellationToken cancellationToken)
        {
            var Candidate = await _Context.Candidates.FindAsync(new Object[] { request.IdCandidate }, cancellationToken);
            if(Candidate != null) { 
                Candidate.ModifyDate = DateTime.UtcNow;
                Candidate.Name = request.Name;
                Candidate.Surname = request.Surname;
                Candidate.Birthdate = request.Birthdate;
                Candidate.Email = request.Email;
                await _Context.SaveChangesAsync(cancellationToken);
                return new CandidateDto
                {
                    IdCandidate = Candidate.IdCandidate,
                    Name = Candidate.Name,
                    Surname = Candidate.Surname,
                    Birthdate = Candidate.Birthdate,    
                    Email = Candidate.Email,
                    InsertDate= Candidate.InsertDate,
                    ModifyDate= DateTime.Now,
                };
            }
            return null;
        }
    }
}
