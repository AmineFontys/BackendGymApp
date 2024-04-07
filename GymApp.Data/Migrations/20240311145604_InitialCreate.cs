using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MuscleGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Reps = table.Column<long>(type: "bigint", nullable: false),
                    Sets = table.Column<long>(type: "bigint", nullable: false),
                    Weight = table.Column<long>(type: "bigint", nullable: false),
                    RestTime = table.Column<long>(type: "bigint", nullable: false),
                    DurationInSeconds = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsMale = table.Column<bool>(type: "bit", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingSchedule",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DurationInMinutes = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingSchedule", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TrainingSchedule_User_TrainerID",
                        column: x => x.TrainerID,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExerciseTrainingSchedule",
                columns: table => new
                {
                    ExercisesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainingSchedulesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseTrainingSchedule", x => new { x.ExercisesID, x.TrainingSchedulesID });
                    table.ForeignKey(
                        name: "FK_ExerciseTrainingSchedule_Exercise_ExercisesID",
                        column: x => x.ExercisesID,
                        principalTable: "Exercise",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseTrainingSchedule_TrainingSchedule_TrainingSchedulesID",
                        column: x => x.TrainingSchedulesID,
                        principalTable: "TrainingSchedule",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Training",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainingScheduleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaxParticipants = table.Column<long>(type: "bigint", nullable: false),
                    CurrentParticipants = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Training_TrainingSchedule_TrainingScheduleID",
                        column: x => x.TrainingScheduleID,
                        principalTable: "TrainingSchedule",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Training_User_TrainerID",
                        column: x => x.TrainerID,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainingID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MemberID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnrollmentCanceled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Enrollments_Training_TrainingID",
                        column: x => x.TrainingID,
                        principalTable: "Training",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_User_MemberID",
                        column: x => x.MemberID,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_MemberID",
                table: "Enrollments",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_TrainingID",
                table: "Enrollments",
                column: "TrainingID");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTrainingSchedule_TrainingSchedulesID",
                table: "ExerciseTrainingSchedule",
                column: "TrainingSchedulesID");

            migrationBuilder.CreateIndex(
                name: "IX_Training_TrainerID",
                table: "Training",
                column: "TrainerID");

            migrationBuilder.CreateIndex(
                name: "IX_Training_TrainingScheduleID",
                table: "Training",
                column: "TrainingScheduleID");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingSchedule_TrainerID",
                table: "TrainingSchedule",
                column: "TrainerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "ExerciseTrainingSchedule");

            migrationBuilder.DropTable(
                name: "Training");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "TrainingSchedule");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
