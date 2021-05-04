using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module_4_HW_6_Db_Music.Entities;

namespace Module_4_HW_6_Db_Music.EntitiesConfiguration
{
    public class SongConfihuration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.ToTable("Song").HasKey(p => p.SongId);
            builder.Property(p => p.SongTitle).HasColumnName("SongTitle");
            builder.Property(p => p.Duration).HasColumnName("Duration").HasColumnType("Time");
            builder.Property(p => p.ReleasedDate).HasColumnName("ReleasedDate");
            builder.Property(p => p.GenreId).HasColumnName("SongGenre");

            builder.HasMany(d => d.Artists)
                .WithMany(p => p.Songs)
                .UsingEntity<Dictionary<string, object>>(
                    "Supply",
                    j => j
                        .HasOne<Artist>()
                        .WithMany()
                        .HasForeignKey("ArtistId"),
                    j => j
                        .HasOne<Song>()
                        .WithMany()
                        .HasForeignKey("SongId"));
        }
    }
}