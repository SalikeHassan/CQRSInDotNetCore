using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using MS.CQRS.Demo.Domain;
using System.Threading.Tasks;
using System.Threading;
using MS.CQRS.Demo.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MS.CQRS.Demo.Infrastructure.Query
{
    public class GetCandidateContactsByIdQuery : IRequest<IEnumerable<CandidateContact>>
    {
        public int CandidateId { get; set; }

        public class GetCandidateContactsByIdQueryHandler : IRequestHandler<GetCandidateContactsByIdQuery, IEnumerable<CandidateContact>>
        {
            private readonly CandidateContext candidateContext;

            public GetCandidateContactsByIdQueryHandler(CandidateContext candidateContext)
            {
                this.candidateContext = candidateContext;
            }
            public async Task<IEnumerable<CandidateContact>> Handle(GetCandidateContactsByIdQuery query, CancellationToken cancellationToken)
            {
                return await this.candidateContext.CandidateContacts.Include(x => x.Candidate).Where(x => x.CandidateId == query.CandidateId).ToListAsync();
            }
        }
    }
}
