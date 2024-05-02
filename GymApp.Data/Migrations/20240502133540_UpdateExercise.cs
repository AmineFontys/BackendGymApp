using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateExercise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Training_TrainingSchedule_TrainingScheduleID",
                table: "Training");

            migrationBuilder.DropForeignKey(
                name: "FK_Training_User_TrainerID",
                table: "Training");

            migrationBuilder.RenameColumn(
                name: "TrainingScheduleID",
                table: "Training",
                newName: "TrainingScheduleId");

            migrationBuilder.RenameColumn(
                name: "TrainerID",
                table: "Training",
                newName: "TrainerId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Training",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Training_TrainingScheduleID",
                table: "Training",
                newName: "IX_Training_TrainingScheduleId");

            migrationBuilder.RenameIndex(
                name: "IX_Training_TrainerID",
                table: "Training",
                newName: "IX_Training_TrainerId");

            migrationBuilder.RenameColumn(
                name: "DurationInSeconds",
                table: "Exercise",
                newName: "TotalDuration");

            migrationBuilder.AddColumn<long>(
                name: "DurationRep",
                table: "Exercise",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_Training_TrainingSchedule_TrainingScheduleId",
                table: "Training",
                column: "TrainingScheduleId",
                principalTable: "TrainingSchedule",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Training_User_TrainerId",
                table: "Training",
                column: "TrainerId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Training_TrainingSchedule_TrainingScheduleId",
                table: "Training");

            migrationBuilder.DropForeignKey(
                name: "FK_Training_User_TrainerId",
                table: "Training");

            migrationBuilder.DropColumn(
                name: "DurationRep",
                table: "Exercise");

            migrationBuilder.RenameColumn(
                name: "TrainingScheduleId",
                table: "Training",
                newName: "TrainingScheduleID");

            migrationBuilder.RenameColumn(
                name: "TrainerId",
                table: "Training",
                newName: "TrainerID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Training",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Training_TrainingScheduleId",
                table: "Training",
                newName: "IX_Training_TrainingScheduleID");

            migrationBuilder.RenameIndex(
                name: "IX_Training_TrainerId",
                table: "Training",
                newName: "IX_Training_TrainerID");

            migrationBuilder.RenameColumn(
                name: "TotalDuration",
                table: "Exercise",
                newName: "DurationInSeconds");

            migrationBuilder.AddForeignKey(
                name: "FK_Training_TrainingSchedule_TrainingScheduleID",
                table: "Training",
                column: "TrainingScheduleID",
                principalTable: "TrainingSchedule",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Training_User_TrainerID",
                table: "Training",
                column: "TrainerID",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
