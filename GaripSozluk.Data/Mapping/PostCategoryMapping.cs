using GaripSozluk.Data.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;


namespace GaripSozluk.Data.Mapping
{
    public class PostCategoryMapping : BaseMapping<PostCategory>
    {
        public override void Configure(EntityTypeBuilder<PostCategory> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Title)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.NormalizedTitle)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
