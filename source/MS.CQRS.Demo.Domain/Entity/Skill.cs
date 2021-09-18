using MS.CQRS.Demo.Domain.BaseEntity;
using System.Collections.Generic;

namespace MS.CQRS.Demo.Domain
{
    public class Skill : Entity
    {
        public Skill()
        {
            this.CandidateSkillXrefs = new HashSet<CandidateSkillXref>();
        }
        public string SkillName { get; set; }

        public virtual ICollection<CandidateSkillXref> CandidateSkillXrefs { get; set; }
    }
}
