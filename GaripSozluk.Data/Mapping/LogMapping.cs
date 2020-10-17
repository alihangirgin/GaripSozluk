using GaripSozluk.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GaripSozluk.Data.Mapping
{
    public class LogMapping : BaseMapping<Log>
    {
        public override void Configure(EntityTypeBuilder<Log> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.TraceIdentifier)
                .HasMaxLength(100);
            builder.Property(x => x.ResponseStatusCode)
                .HasMaxLength(100);
            builder.Property(x => x.RequestMethod)
                .HasMaxLength(100);
            builder.Property(x => x.RequestPath)
                .HasMaxLength(100);
            builder.Property(x => x.UserAgent)
                .HasMaxLength(200);
            builder.Property(x => x.RoutePath)
                .HasMaxLength(100);
            builder.Property(x => x.IPAddress)
                .HasMaxLength(100);


        }


    }
}
