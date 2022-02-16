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
    public class VoteMapping : IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> builder)
        {
            builder.ToTable(nameof(Vote));

            builder.HasKey(vote => vote.Id);

            builder.HasOne(vote => vote.User)
                .WithMany(user => user.Votes)
                .HasForeignKey(vote => vote.UserId);

            builder.HasOne(vote => vote.Movie)
                .WithMany(movie => movie.Votes)
                .HasForeignKey(vote => vote.MovieId);
        }
    }
}
