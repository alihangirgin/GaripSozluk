using GaripSozluk.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GaripSozluk.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.BirthDate);

            builder.HasMany(x => x.BlockedUsers)
                .WithOne(b => b.User)
                .HasForeignKey(c=> c.BlockedUserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
