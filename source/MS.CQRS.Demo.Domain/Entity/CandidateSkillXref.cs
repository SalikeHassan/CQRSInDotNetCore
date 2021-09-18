using MS.CQRS.Demo.Domain.BaseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.CQRS.Demo.Domain
{
    public class CandidateSkillXref : Entity
    {
        public int CandidateId { get; set; }
        public int SkillId { get; set; }
        public virtual Candidate Candidate { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
