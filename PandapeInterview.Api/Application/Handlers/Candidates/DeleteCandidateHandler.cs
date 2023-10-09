using MediatR;
using PandapeInterview.Infrastructure;
using PandapeInterview.Infrastructure.Commands.Candidates;

namespace PandapeInterview.Application.Handlers.Candidates
{
    public class DeleteCandidateHandler : IRequestHandler<DeleteCandidateCommand, bool>
    {
        private readonly ApplicationDbContext _Context;
        public DeleteCandidateHandler(ApplicationDbContext context)
        {
            _Context = context;
        }

        public async Task<bool> Handle(DeleteCandidateCommand request, CancellationToken cancellationToken)
        {
            var Candidate = await _Context.Candidates.FindAsync(new object[] { request.IdCandidate }, cancellationToken);
            if(Candidate != null)
            {
                _Context.Candidates.Remove(Candidate);
                await _Context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }
    }
}
