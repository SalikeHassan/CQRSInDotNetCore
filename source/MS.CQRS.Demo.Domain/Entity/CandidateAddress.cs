using MS.CQRS.Demo.Domain.BaseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.CQRS.Demo.Domain
{
    public class CandidateAddress : Entity
    {
        public string CityName { get; set; }

        public string StateName { get; set; }

        public string PinCode { get; set; }

        public int CandidateId { get; set; }

        public virtual Candidate Candidate { get; set; }
    }
}
