using MediatR;
using PandapeInterview.Application.DTOs;
using PandapeInterview.Infrastructure;
using PandapeInterview.Infrastructure.Commands.Candidates;
using PandapeInterview.Domain;

namespace PandapeInterview.Application.Handlers.Candidates
{
    public class CreateCandidateHandler
        : IRequestHandler<CreateCandidateCommand, CandidateDto>
    {
        private readonly ApplicationDbContext _Context;
        public CreateCandidateHandler(ApplicationDbContext context)
        {
            _Context = context;
        }

        public async Task<CandidateDto> Handle(CreateCandidateCommand request, CancellationToken cancellationToken)
        {
            var Candidate = new Candidate()
            {
               Name= request.Name,
               Surname = request.Surname,
               Birthdate= request.Birthdate,
               Email= request.Email,        
               InsertDate = DateTime.Now,   
               ModifyDate=null
            };
            _Context.Candidates.Add(Candidate);
            await _Context.SaveChangesAsync(cancellationToken);
            return new CandidateDto
            {
                IdCandidate = Candidate.IdCandidate,
                Name = Candidate.Name,
                Surname= Candidate.Surname,
                Birthdate= Candidate.Birthdate,
                Email= Candidate.Email,
                InsertDate= DateTime.Now,   
                ModifyDate=null
            };
        }
    }
}
