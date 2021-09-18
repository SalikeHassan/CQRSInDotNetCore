using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MS.CQRS.Demo.Domain;
using MS.CQRS.Demo.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using MS.CQRS.Demo.Contract.Dtos.Response;

namespace MS.CQRS.Demo.Infrastructure.Query
{
    public class GetCandidateSkillByIdQuery : IRequest<CandidateDetailsResponse>
    {
        public int CandidateId { get; set; }
        public class GetCandidateSkillByIdQueryHandler : IRequestHandler<GetCandidateSkillByIdQuery, CandidateDetailsResponse>
        {
            private readonly CandidateContext candidateContext;

            public GetCandidateSkillByIdQueryHandler(CandidateContext candidateContext)
            {
                this.candidateContext = candidateContext;
            }
            public async Task<CandidateDetailsResponse> Handle(GetCandidateSkillByIdQuery query, CancellationToken cancellationToken)
            {
                //return await this.candidateContext.CandidateSkillXrefs
                //    .Include(x => x.Skill)
                //    .Include(x => x.Candidate)
                //    .ThenInclude(x => x.CandidateAddress)
                //    .Include(x => x.Candidate)
                //    .ThenInclude(x => x.CandidateContacts)
                //    .AsNoTracking()
                //    .Where(x => x.CandidateId == query.CandidateId)
                //    .Select(x => new CandidateDetailsResponse()
                //    {
                //        FirstName = x.Candidate.FirstName,
                //        CityName = x.Candidate.CandidateAddress.CityName,
                //        CandidateContactResponses = x.Candidate.CandidateContacts.Select(m => new CandidateContactResponse() { Email = m.Email }).ToList(),
                //        CandidateSkills = x.Skill.CandidateSkillXrefs.Select(m => new CandidateSkill() { SkillName = m.Skill.SkillName }).ToList()
                //    }).FirstOrDefaultAsync();

                var data = await this.candidateContext.Candidates
                    .Include(x => x.CandidateAddress)
                    .Include(x => x.CandidateContacts)
                    .Include(x => x.CandidateSkillXrefs)
                    .ThenInclude(x => x.Skill)
                    .AsNoTracking()
                    .Where(x => x.Id == query.CandidateId)
                    .Select(obj => new CandidateDetailsResponse()
                    {
                        FirstName = obj.FirstName,
                        CityName = obj.CandidateAddress.CityName,
                        CandidateContactResponses = obj.CandidateContacts.Select(x => new CandidateContactResponse() { Email = x.Email }).ToList(),
                        CandidateSkills = obj.CandidateSkillXrefs.Select(m => new CandidateSkill() { SkillName = m.Skill.SkillName }).ToList()
                    }).FirstOrDefaultAsync();
                //.ThenInclude(x=>x.Skill)


                return data;

            }
        }
    }
}
