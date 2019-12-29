﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace P01_StudentSystem.Migrations
{
    public partial class SpellingCorrected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentsCourses_Courses_CourseId",
                table: "StudentsCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsCourses_Students_StudentId",
                table: "StudentsCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentsCourses",
                table: "StudentsCourses");

            migrationBuilder.RenameTable(
                name: "StudentsCourses",
                newName: "StudentCourses");

            migrationBuilder.RenameColumn(
                name: "Bithday",
                table: "Students",
                newName: "Birthday");

            migrationBuilder.RenameColumn(
                name: "RecourceId",
                table: "Resources",
                newName: "ResourceId");

            migrationBuilder.RenameColumn(
                name: "SunmissionTime",
                table: "Homeworks",
                newName: "SubmissionTime");

            migrationBuilder.RenameIndex(
                name: "IX_StudentsCourses_CourseId",
                table: "StudentCourses",
                newName: "IX_StudentCourses_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentCourses",
                table: "StudentCourses",
                columns: new[] { "StudentId", "CourseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Courses_CourseId",
                table: "StudentCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Students_StudentId",
                table: "StudentCourses",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Courses_CourseId",
                table: "StudentCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Students_StudentId",
                table: "StudentCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentCourses",
                table: "StudentCourses");

            migrationBuilder.RenameTable(
                name: "StudentCourses",
                newName: "StudentsCourses");

            migrationBuilder.RenameColumn(
                name: "Birthday",
                table: "Students",
                newName: "Bithday");

            migrationBuilder.RenameColumn(
                name: "ResourceId",
                table: "Resources",
                newName: "RecourceId");

            migrationBuilder.RenameColumn(
                name: "SubmissionTime",
                table: "Homeworks",
                newName: "SunmissionTime");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourses_CourseId",
                table: "StudentsCourses",
                newName: "IX_StudentsCourses_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentsCourses",
                table: "StudentsCourses",
                columns: new[] { "StudentId", "CourseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsCourses_Courses_CourseId",
                table: "StudentsCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsCourses_Students_StudentId",
                table: "StudentsCourses",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
