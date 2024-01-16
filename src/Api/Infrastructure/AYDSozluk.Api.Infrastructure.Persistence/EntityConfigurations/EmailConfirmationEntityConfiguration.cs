using AYDSozluk.Api.Domain.Models;
using AYDSozluk.Api.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYDSozluk.Api.Infrastructure.Persistence.EntityConfigurations
{
    public class EmailConfirmationEntityConfiguration : BaseEntityConfiguration<EmailConfirmation>
    {
        public override void Configure(EntityTypeBuilder<EmailConfirmation> builder)
        {
            base.Configure(builder);

            builder.ToTable("emailconfirmation", AYDSozlukContext.DEFAULT_SCHEMA);
            builder.Property(x => x.OldEmailAddress).HasMaxLength(100);
            builder.Property(x => x.NewEmailAddress).HasMaxLength(100);
        }
    }
}
