using Microsoft.EntityFrameworkCore.Migrations;

namespace P03_FootballBetting.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username varchar(50)",
                table: "Users",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "Password nvarchar(50)",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "Name varchar(50)",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Email varchar(50)",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "Name varchar(40)",
                table: "Towns",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Name varchar(50)",
                table: "Teams",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "LogoUrl varchar(150)",
                table: "Teams",
                newName: "LogoUrl");

            migrationBuilder.RenameColumn(
                name: "Initials char(3)",
                table: "Teams",
                newName: "Initials");

            migrationBuilder.RenameColumn(
                name: "Name varchar(50)",
                table: "Positions",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Name varchar(50)",
                table: "Players",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Name varchar(40)",
                table: "Countries",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Name varchar(40)",
                table: "Colors",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Towns",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Towns",
                type: "varchar(40)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "TownId",
                table: "Teams",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SecondaryKitColorId",
                table: "Teams",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PrimaryKitColorId",
                table: "Teams",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Teams",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LogoUrl",
                table: "Teams",
                type: "varchar(150)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Initials",
                table: "Teams",
                type: "char(3)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Positions",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "Players",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PositionId",
                table: "Players",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Players",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "HomeTeamId",
                table: "Games",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AwayTeamId",
                table: "Games",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Countries",
                type: "varchar(40)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Colors",
                type: "varchar(40)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Bets",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "Bets",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "Username varchar(50)");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "Password nvarchar(50)");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "Name varchar(50)");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "Email varchar(50)");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Towns",
                newName: "Name varchar(40)");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Teams",
                newName: "Name varchar(50)");

            migrationBuilder.RenameColumn(
                name: "LogoUrl",
                table: "Teams",
                newName: "LogoUrl varchar(150)");

            migrationBuilder.RenameColumn(
                name: "Initials",
                table: "Teams",
                newName: "Initials char(3)");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Positions",
                newName: "Name varchar(50)");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Players",
                newName: "Name varchar(50)");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Countries",
                newName: "Name varchar(40)");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Colors",
                newName: "Name varchar(40)");

            migrationBuilder.AlterColumn<string>(
                name: "Username varchar(50)",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Password nvarchar(50)",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Name varchar(50)",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Email varchar(50)",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Towns",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Name varchar(40)",
                table: "Towns",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(40)");

            migrationBuilder.AlterColumn<int>(
                name: "TownId",
                table: "Teams",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "SecondaryKitColorId",
                table: "Teams",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PrimaryKitColorId",
                table: "Teams",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Name varchar(50)",
                table: "Teams",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "LogoUrl varchar(150)",
                table: "Teams",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)");

            migrationBuilder.AlterColumn<string>(
                name: "Initials char(3)",
                table: "Teams",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(3)");

            migrationBuilder.AlterColumn<string>(
                name: "Name varchar(50)",
                table: "Positions",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "Players",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PositionId",
                table: "Players",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Name varchar(50)",
                table: "Players",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<int>(
                name: "HomeTeamId",
                table: "Games",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AwayTeamId",
                table: "Games",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Name varchar(40)",
                table: "Countries",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(40)");

            migrationBuilder.AlterColumn<string>(
                name: "Name varchar(40)",
                table: "Colors",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(40)");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Bets",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "Bets",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
