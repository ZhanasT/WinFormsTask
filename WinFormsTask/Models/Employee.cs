using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsTask.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string EmployeeIIN { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public override string ToString()
        {
            return $"{Surname}, {FirstName}, {Patronymic}, {EmployeeIIN}";
        }
    }
}
