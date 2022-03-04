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
    public class MovieMapping : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable(nameof(Movie));

            builder.HasKey(movie => movie.Id);
            builder.HasAlternateKey(movie => new { movie.Title, movie.ReleaseDate });

            builder.Property(movie => movie.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(movie => movie.Title)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(120);

            builder.Property(movie => movie.Duration)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(movie => movie.Description)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(1000);

            builder.Property(movie => movie.AverageVote)
                .HasColumnType("int");

            builder.Property(movie => movie.Director)
                .HasColumnType("string")
                .HasMaxLength(60);

            builder.Property(movie => movie.VoteCounter)
                .HasColumnType("int");

            builder.HasMany(movie => movie.Genre)
                .WithMany(genre => genre.Movies);

            builder.HasMany(movie => movie.Actors)
                .WithMany(movie => movie.Movies);

        }
    }
}
