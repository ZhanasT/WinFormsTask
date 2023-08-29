using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsTask.Models;

namespace WinFormsTask
{
    public class CSVManager
    {
        public void ExportEmployeesToCSV(IList<Company> companies, string filePath)
        {
            StringBuilder csvContent = new StringBuilder();
            csvContent.AppendLine("Surname,FirstName,Patronymic,EmployeeIIN,CompanyId");

            string fullPath = $"{Environment.CurrentDirectory}\\{filePath}";
            foreach (Company company in companies)
            {
                foreach (Employee employee in company.Employees)
                {
                    string line = $"{employee.Surname},{employee.FirstName},{employee.Patronymic},{employee.EmployeeIIN},{company.Id}";
                    csvContent.AppendLine(line);
                }
            }
            using (StreamWriter writer = new StreamWriter(new FileStream(fullPath, FileMode.OpenOrCreate, FileAccess.Write)))
            {
                writer.WriteLine(csvContent.ToString());
            }

        }
        public List<Employee> ImportEmployeesFromCSV(string filePath)
        {
            List<Employee> employees = new List<Employee>();
            string[] lines = File.ReadAllLines(filePath);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] fields = lines[i].Split(',');
                if (fields.Length >= 5)
                {
                    Employee employee = new Employee
                    {
                        Surname = fields[0],
                        FirstName = fields[1],
                        Patronymic = fields[2],
                        EmployeeIIN = fields[3],
                        CompanyId = Convert.ToInt32(fields[4]),
                    };
                    employees.Add(employee);
                }
            }

            return employees;
        }
    }
}
