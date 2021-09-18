using MS.CQRS.Demo.Domain.BaseEntity;

namespace MS.CQRS.Demo.Domain
{
    public class CandidateContact : Entity
    {
        public string Email { get; set; }

        public string Mobile { get; set; }

        public int CandidateId { get; set; }

        public virtual Candidate Candidate { get; set; }
    }
}
