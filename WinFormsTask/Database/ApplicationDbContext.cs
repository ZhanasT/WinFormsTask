using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using WinFormsTask.Models;

namespace WinFormsTask.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-4RRQGG4;Initial Catalog=WinFormsTaskDb;Integrated Security=True;Pooling=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Company)
                .WithMany(c => c.Employees)
                .HasForeignKey(e => e.CompanyId);

            modelBuilder.Entity<Company>()
                .HasData(
                    new Company { Id = 1, CompanyName = "Microsoft", CompanyIIN = "284017482912", PhysicalAddress = "5331 Rexford Court, Montgomery AL 36116", Remark = "Американская публичная транснациональная корпорация, один из крупнейших разработчиков в сфере проприетарного программного обеспечения для различного рода вычислительной техники." },
                    new Company { Id = 2, CompanyName = "Google", CompanyIIN = "5930285930581", PhysicalAddress = "8642 Yule Street, Arvada CO 80007", Remark = "Американская многонациональная технологическая компания, специализирующаяся на искусственном интеллекте, онлайн-рекламе, технологиях поисковых систем, облачных вычислениях, компьютерном программном обеспечении." },
                    new Company { Id = 3, CompanyName = "Nissan", CompanyIIN = "918294757382", PhysicalAddress = "4001 Anderson Road, Nashville TN 37217", Remark = "Японский автопроизводитель, один из крупнейших в мире." },
                    new Company { Id = 4, CompanyName = "Shell", CompanyIIN = "283749104738", PhysicalAddress = "2436 Naples Avenue, Panama City FL 32405", Remark = " Британско-нидерландская нефтегазовая компания." },
                    new Company { Id = 5, CompanyName = "Siemens", CompanyIIN = "728394719472", PhysicalAddress = "19141 Pine Ridge Circle, Anchorage AK 99516", Remark = "Немецкий конгломерат, работающий в области электротехники, электроники, энергетического оборудования" }
                );
            modelBuilder.Entity<Employee>()
                .HasData(
                    new Employee { Id = 1, Surname = "Иванов", FirstName = "Алексей", Patronymic = "Вавилович", EmployeeIIN = "981224472838", CompanyId = 1 },
                    new Employee { Id = 2, Surname = "Смирнов", FirstName = "Артём", Patronymic = "Геннадиевич", EmployeeIIN = "870312372849", CompanyId = 2 },
                    new Employee { Id = 3, Surname = "Кузнецов", FirstName = "Вадим", Patronymic = "Данилович", EmployeeIIN = "990807299374", CompanyId = 3 },
                    new Employee { Id = 4, Surname = "Попов", FirstName = "Владимир", Patronymic = "Егорович", EmployeeIIN = "011119948293", CompanyId = 4 },
                    new Employee { Id = 5, Surname = "Васильев", FirstName = "Валентин", Patronymic = "Игоревич", EmployeeIIN = "780413243656", CompanyId = 5 },
                    new Employee { Id = 6, Surname = "Петров", FirstName = "Данил", Patronymic = "Карлович", EmployeeIIN = "890829574829", CompanyId = 1 },
                    new Employee { Id = 7, Surname = "Соколов", FirstName = "Денис", Patronymic = "Леонидович", EmployeeIIN = "900523673927", CompanyId = 2 },
                    new Employee { Id = 8, Surname = "Михайлов", FirstName = "Дмитрий", Patronymic = "Макарович", EmployeeIIN = "860917574839", CompanyId = 3 },
                    new Employee { Id = 9, Surname = "Николаев", FirstName = "Егор", Patronymic = "Маркович", EmployeeIIN = "950722374860", CompanyId = 4 },
                    new Employee { Id = 10, Surname = "Крылов", FirstName = "Кирилл", Patronymic = "Нефёдович", EmployeeIIN = "791228473829", CompanyId = 5 },
                    new Employee { Id = 11, Surname = "Максимов", FirstName = "Леонид", Patronymic = "Николаевич", EmployeeIIN = "030208564738", CompanyId = 1 },
                    new Employee { Id = 12, Surname = "Сидоров", FirstName = "Максим", Patronymic = "Олегович", EmployeeIIN = "991023574839", CompanyId = 2 },
                    new Employee { Id = 13, Surname = "Осипов", FirstName = "Матвей", Patronymic = "Павлович", EmployeeIIN = "880730564738", CompanyId = 3 },
                    new Employee { Id = 14, Surname = "Белоусов", FirstName = "Никита", Patronymic = "Петрович", EmployeeIIN = "810524674839", CompanyId = 4 },
                    new Employee { Id = 15, Surname = "Федотов", FirstName = "Олег", Patronymic = "Робертович", EmployeeIIN = "020426576348", CompanyId = 5 }
                );
        }

    }
}
