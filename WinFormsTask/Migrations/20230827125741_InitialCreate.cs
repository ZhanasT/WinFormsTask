using Microsoft.EntityFrameworkCore.Migrations;

namespace WinFormsTask.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(nullable: true),
                    CompanyIIN = table.Column<string>(nullable: true),
                    PhysicalAddress = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    Patronymic = table.Column<string>(nullable: true),
                    EmployeeIIN = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "CompanyIIN", "CompanyName", "PhysicalAddress", "Remark" },
                values: new object[,]
                {
                    { 1, "284017482912", "Microsoft", "5331 Rexford Court, Montgomery AL 36116", "Американская публичная транснациональная корпорация, один из крупнейших разработчиков в сфере проприетарного программного обеспечения для различного рода вычислительной техники." },
                    { 2, "5930285930581", "Google", "8642 Yule Street, Arvada CO 80007", "Американская многонациональная технологическая компания, специализирующаяся на искусственном интеллекте, онлайн-рекламе, технологиях поисковых систем, облачных вычислениях, компьютерном программном обеспечении." },
                    { 3, "918294757382", "Nissan", "4001 Anderson Road, Nashville TN 37217", "Японский автопроизводитель, один из крупнейших в мире." },
                    { 4, "283749104738", "Shell", "2436 Naples Avenue, Panama City FL 32405", " Британско-нидерландская нефтегазовая компания." },
                    { 5, "728394719472", "Siemens", "19141 Pine Ridge Circle, Anchorage AK 99516", "Немецкий конгломерат, работающий в области электротехники, электроники, энергетического оборудования" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CompanyId", "EmployeeIIN", "FirstName", "Patronymic", "Surname" },
                values: new object[,]
                {
                    { 1, 1, "981224472838", "Алексей", "Вавилович", "Иванов" },
                    { 6, 1, "890829574829", "Данил", "Карлович", "Петров" },
                    { 11, 1, "030208564738", "Леонид", "Николаевич", "Максимов" },
                    { 2, 2, "870312372849", "Артём", "Геннадиевич", "Смирнов" },
                    { 7, 2, "900523673927", "Денис", "Леонидович", "Соколов" },
                    { 12, 2, "991023574839", "Максим", "Олегович", "Сидоров" },
                    { 3, 3, "990807299374", "Вадим", "Данилович", "Кузнецов" },
                    { 8, 3, "860917574839", "Дмитрий", "Макарович", "Михайлов" },
                    { 13, 3, "880730564738", "Матвей", "Павлович", "Осипов" },
                    { 4, 4, "011119948293", "Владимир", "Егорович", "Попов" },
                    { 9, 4, "950722374860", "Егор", "Маркович", "Николаев" },
                    { 14, 4, "810524674839", "Никита", "Петрович", "Белоусов" },
                    { 5, 5, "780413243656", "Валентин", "Игоревич", "Васильев" },
                    { 10, 5, "791228473829", "Кирилл", "Нефёдович", "Крылов" },
                    { 15, 5, "020426576348", "Олег", "Робертович", "Федотов" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyId",
                table: "Employees",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
