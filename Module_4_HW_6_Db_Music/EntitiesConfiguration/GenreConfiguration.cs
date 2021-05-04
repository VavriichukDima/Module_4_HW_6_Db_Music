using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module_4_HW_6_Db_Music.Entities;

namespace Module_4_HW_6_Db_Music.EntitiesConfiguration
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genre").HasKey(p => p.GenreId);
            builder.Property(p => p.Title).HasColumnName("Title");

            builder.HasMany(z => z.Songs)
                .WithOne(x => x.Genre)
                .HasForeignKey(z => z.GenreId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}