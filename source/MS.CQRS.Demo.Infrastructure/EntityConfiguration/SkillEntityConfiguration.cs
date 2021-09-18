using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MS.CQRS.Demo.Domain;

namespace MS.CQRS.Demo.Infrastructure.EntityConfiguration
{
    public class SkillEntityConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.Property(p => p.SkillName).HasColumnType("varchar(100)")
                .IsRequired();

            builder.ToTable("Skills", "candidate");
        }
    }
}
