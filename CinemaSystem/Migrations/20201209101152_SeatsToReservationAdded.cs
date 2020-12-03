using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaSystem.Migrations
{
    public partial class SeatsToReservationAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           /* migrationBuilder.CreateTable(
                name: "Audithorium",
                columns: table => new
                {
                    AudithoriumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audithorium", x => x.AudithoriumId);
                });

            migrationBuilder.CreateTable(
                name: "Movie_Rating",
                columns: table => new
                {
                    RatingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RatingValue = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Movie_Ra__FCCDF87C45BE88B9", x => x.RatingId);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.PostId);
                });

            migrationBuilder.CreateTable(
                name: "Seat",
                columns: table => new
                {
                    SeatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Row = table.Column<int>(type: "int", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: true),
                    AudithoriumId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat", x => x.SeatId);
                    table.ForeignKey(
                        name: "FK_Seat_ToTable",
                        column: x => x.AudithoriumId,
                        principalTable: "Audithorium",
                        principalColumn: "AudithoriumId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Director = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Cast = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: true),
                    Movie_Rating = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_Movie_ToTable",
                        column: x => x.Movie_Rating,
                        principalTable: "Movie_Rating",
                        principalColumn: "RatingId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PostId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employee_ToTable",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Screening",
                columns: table => new
                {
                    ScreeningId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: true),
                    AudithoriumId = table.Column<int>(type: "int", nullable: true),
                    ScreeningStart = table.Column<TimeSpan>(type: "time", nullable: true),
                    Cost = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screening", x => x.ScreeningId);
                    table.ForeignKey(
                        name: "FK_Screening_ToTable",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Screening_ToTable_1",
                        column: x => x.AudithoriumId,
                        principalTable: "Audithorium",
                        principalColumn: "AudithoriumId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScreeningId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    SeatId = table.Column<int>(type: "int", nullable: true),
                    Reserved = table.Column<bool>(type: "bit", nullable: true),
                    Paid = table.Column<bool>(type: "bit", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservation_Seat_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seat",
                        principalColumn: "SeatId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservation_ToTable",
                        column: x => x.ScreeningId,
                        principalTable: "Screening",
                        principalColumn: "ScreeningId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservation_ToTable_1",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PostId",
                table: "Employee",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_Movie_Rating",
                table: "Movie",
                column: "Movie_Rating");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_EmployeeId",
                table: "Reservation",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_ScreeningId",
                table: "Reservation",
                column: "ScreeningId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_SeatId",
                table: "Reservation",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_Screening_AudithoriumId",
                table: "Screening",
                column: "AudithoriumId");

            migrationBuilder.CreateIndex(
                name: "IX_Screening_MovieId",
                table: "Screening",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_AudithoriumId",
                table: "Seat",
                column: "AudithoriumId");   */
           }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Seat");

            migrationBuilder.DropTable(
                name: "Screening");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "Audithorium");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Movie_Rating");
        }
    }
}
