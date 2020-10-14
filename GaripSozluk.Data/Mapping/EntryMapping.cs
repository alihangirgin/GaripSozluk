using GaripSozluk.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
namespace GaripSozluk.Data.Mapping
{
    public class EntryMapping : BaseMapping<Entry>
    {
        public override void Configure(EntityTypeBuilder<Entry> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Content)
                .IsRequired();



            builder.HasOne(x => x.Post)
                .WithMany(x => x.Entries)
                .HasForeignKey(x => x.PostId)
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.Entries)
                .HasForeignKey(x => x.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
