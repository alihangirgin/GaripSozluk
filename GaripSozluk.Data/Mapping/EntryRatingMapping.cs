using GaripSozluk.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;


namespace GaripSozluk.Data.Mapping
{
    public class EntryRatingMapping : BaseMapping<EntryRating>
    {
        public override void Configure(EntityTypeBuilder<EntryRating> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.IsLiked)
                .IsRequired();



            builder.HasOne(x => x.Entry)
                .WithMany(x => x.Ratings)
                .HasForeignKey(x => x.EntryId)
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.Ratings)
                .HasForeignKey(x => x.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
