using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Module_4_HW_6_Db_Music.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstagramURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.ArtistId);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Song",
                columns: table => new
                {
                    SongId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SongTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    ReleasedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song", x => x.SongId);
                    table.ForeignKey(
                        name: "FK_Song_Genre_SongId",
                        column: x => x.SongId,
                        principalTable: "Genre",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Supply",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    SongId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supply", x => new { x.ArtistId, x.SongId });
                    table.ForeignKey(
                        name: "FK_Supply_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Supply_Song_SongId",
                        column: x => x.SongId,
                        principalTable: "Song",
                        principalColumn: "SongId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Supply_SongId",
                table: "Supply",
                column: "SongId");

            migrationBuilder.Sql(@"INSERT INTO Artist(Name, DateOfBirth, Phone, Email, InstagramURL) VALUES('Christopher Comstock', '1992-05-19', '+123456789', 'Marshmello@marshmello.com', 'https://www.instagram.com/marshmellomusic/?hl=ru')
                                   INSERT INTO Artist(Name, DateOfBirth, Phone, Email, InstagramURL) VALUES('Mikhail Gorshenev', '1973-08-07', '+987654321', 'Mikhail_Gorshenev@RIP.com', 'https://www.instagram.com/korol_i_shut_ru/?hl=ru')
                                   INSERT INTO Artist(Name, DateOfBirth, Phone, Email, InstagramURL) VALUES('Röyksopp', '1998-01-01', '+111111111', 'Röyksopp@gmail.com', 'https://www.instagram.com/_royksopp_/')
                                   INSERT INTO Artist(Name, DateOfBirth, Phone, Email, InstagramURL) VALUES('Chester Bennington', '1976-03-20', '+222222222', 'Chester_Bennington@RIP.com.com', 'https://www.instagram.com/chesterbe/')
                                   INSERT INTO Artist(Name, DateOfBirth, Phone, Email, InstagramURL) VALUES('Bob Marley', '1945-02-06', '+777777777', 'Bob_Marley@RIP.com', 'https://www.instagram.com/bobmarley/?hl=ru')");

            migrationBuilder.Sql(@"INSERT INTO Genre(Title) VALUES ('R&B')
                                   INSERT INTO Genre(Title) VALUES ('Electronic')
                                   INSERT INTO Genre(Title) VALUES ('Reggae')
                                   INSERT INTO Genre(Title) VALUES ('Rock')
                                   INSERT INTO Genre(Title) VALUES ('Pop')");

            migrationBuilder.Sql(@"INSERT INTO Song(SongTitle, Duration, ReleasedDate) VALUES('Alone', CAST('00:03:19' as TIME), '2016-01-01')
                                   INSERT INTO Song(SongTitle, Duration, ReleasedDate) VALUES('Forester', CAST('00:03:10' as TIME), '1996-01-01')
                                   INSERT INTO Song(SongTitle, Duration, ReleasedDate) VALUES('Monument', CAST('00:06:48' as TIME), '2014-01-01')
                                   INSERT INTO Song(SongTitle, Duration, ReleasedDate) VALUES('Numb', CAST('00:03:06' as TIME), '2003-01-01')
                                   INSERT INTO Song(SongTitle, Duration, ReleasedDate) VALUES('Buffalo Soldier', CAST('00:04:18' as TIME), '1983-01-01')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Artist");
            migrationBuilder.Sql("DELETE FROM Genre");
            migrationBuilder.Sql("DELETE FROM Song");

            migrationBuilder.DropTable(
                name: "Supply");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "Song");

            migrationBuilder.DropTable(
                name: "Genre");
        }
    }
}
