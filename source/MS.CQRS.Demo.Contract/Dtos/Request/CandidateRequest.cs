using System;
using System.Collections.Generic;
using System.Text;

namespace MS.CQRS.Demo.Contract.Dtos.Request
{
    public class CandidateRequest
    {
        public CandidateRequest()
        {
            this.CandidateContactRequests = new List<CandidateContactRequest>();
            this.SkillId = new List<int>();
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<CandidateContactRequest> CandidateContactRequests { get; set; }

        public string CityName { get; set; }

        public string StateName { get; set; }

        public string PinCode { get; set; }

        public List<int> SkillId { get; set; }
    }

    public class CandidateContactRequest
    {
        public string Email { get; set; }

        public string Mobile { get; set; }
    }
}
