using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MS.CQRS.Demo.Domain;

namespace MS.CQRS.Demo.Infrastructure.Context
{
    public class CandidateContext : DbContext
    {
        public virtual DbSet<Candidate> Candidates { get; set; }

        public virtual DbSet<CandidateContact> CandidateContacts { get; set; }
        public virtual DbSet<CandidateAddress> CandidateAddresse { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<CandidateSkillXref> CandidateSkillXrefs { get; set; }

        public CandidateContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
