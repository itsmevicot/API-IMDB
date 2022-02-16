using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));

            builder.HasKey(user => user.Id);

            builder.HasAlternateKey(user => user.Email);

            builder.Property(user => user.Password)
                .IsRequired();

            builder.Property(user => user.Role)
                .IsRequired();

            builder.Property(user => user.Nickname)
                .IsRequired();
        }
    }
}
