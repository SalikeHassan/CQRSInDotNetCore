using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MS.CQRS.Demo.Domain;
using MS.CQRS.Demo.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace MS.CQRS.Demo.Infrastructure.Query
{
    public class GetCandidateByIdQuery : IRequest<Candidate>
    {
        public int Id { get; set; }
        public class GetCandidateByIdQueryHandler : IRequestHandler<GetCandidateByIdQuery, Candidate>
        {
            private readonly CandidateContext candidateContext;

            public GetCandidateByIdQueryHandler(CandidateContext candidateContext)
            {
                this.candidateContext = candidateContext;
            }
            public async Task<Candidate> Handle(GetCandidateByIdQuery query, CancellationToken cancellationToken)
            {
                return await this.candidateContext.Candidates.FirstOrDefaultAsync(x => x.Id == query.Id);
            }
        }
    }
}
