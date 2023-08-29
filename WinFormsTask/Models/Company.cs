using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace WinFormsTask.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyIIN { get; set; }
        public string PhysicalAddress { get; set; }
        public string Remark { get; set; }
        public List<Employee> Employees { get; set; }
        public override string ToString()
        {
            return $"{CompanyName}, {CompanyIIN}, {PhysicalAddress}, {Remark}";
        }
    }
}
