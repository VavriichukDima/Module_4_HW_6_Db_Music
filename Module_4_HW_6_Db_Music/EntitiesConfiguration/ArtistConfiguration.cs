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
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.ToTable("Artist").HasKey(p => p.ArtistId);
            builder.Property(p => p.Name).HasColumnName("Name");
            builder.Property(p => p.DateOfBirth).HasColumnName("DateOfBirth").HasColumnType("date2");
            builder.Property(p => p.Phone).HasColumnName("Phone").IsRequired(false);
            builder.Property(p => p.Email).HasColumnName("Email").IsRequired(false);
            builder.Property(p => p.InstagramURL).HasColumnName("InstagramURL").IsRequired(false);
        }
    }
}
