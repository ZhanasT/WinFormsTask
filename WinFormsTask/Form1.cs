using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsTask.Repositories;
using WinFormsTask.Models;


namespace WinFormsTask
{
    public partial class Form1 : Form
    {
        private readonly DbRepository repository;
        private CSVManager csvManager;
 
       
        public Form1()
        {
            InitializeComponent();
            repository = new DbRepository();
            csvManager = new CSVManager();
            listView1.View = View.Tile; 

            InitializeListView();
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
        }

        private async void InitializeListView()
        {
            await ShowList();
        }

        private async Task ShowList()
        {
            var companies = await repository.GetCompaniesWithEmployeesAsync();

            foreach (Company company in companies)
            {
                ListViewGroup companyGroup = new ListViewGroup(company.ToString());
                listView1.Groups.Add(companyGroup);
                foreach (Employee employee in company.Employees)
                {
                    ListViewItem employeeItem = new ListViewItem(employee.ToString());
                    employeeItem.Group = companyGroup;
                    listView1.Items.Add(employeeItem);
                }
            }
        }

        private async void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewGroup selectedGroup = listView1.SelectedItems[0].Group;
                if (selectedGroup != null)
                {
                    string IIN = selectedGroup.Header.Split(',')[1];
                    string trimmedIIN = IIN.Trim();
                    Company selectedCompany = await repository.GetCompanyByNameAsync(trimmedIIN);

                    listView1.BeginUpdate();

                    foreach (ListViewItem item in selectedGroup.Items.Cast<ListViewItem>().ToList())
                    {
                        selectedGroup.Items.Remove(item);
                        listView1.Items.Remove(item);
                    }

                    foreach (Employee employee in selectedCompany.Employees)
                    {
                        ListViewItem employeeItem = new ListViewItem(employee.ToString());
                        employeeItem.Group = selectedGroup;
                        listView1.Items.Add(employeeItem);
                    }

                    listView1.EndUpdate();
                }
            }
        }

        private async void button_export_click(object sender, EventArgs e)
        {
            var companies = await repository.GetCompaniesWithEmployeesAsync();

            List<Company> companiesList = new List<Company>();
            foreach (Company company in companies)
            {
                companiesList.Add(company);
            }
            string exportFilePath = "employees.csv";
            csvManager.ExportEmployeesToCSV(companiesList, exportFilePath);

            MessageBox.Show($"Данные экспортированы в {exportFilePath}");
        }

        private void button_import_click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string importFilePath = openFileDialog.FileName;
                    List<Employee> importedEmployees = csvManager.ImportEmployeesFromCSV(importFilePath);

                    UpdateEmployeeList(importedEmployees);
                    MessageBox.Show("Данные импортированы из " + importFilePath);
                }
            }
        }
        private void UpdateEmployeeList(List<Employee> employees)
        {

            foreach (ListViewGroup group in listView1.Groups)
            {
                foreach (ListViewItem item in group.Items.Cast<ListViewItem>().ToList())
                {
                    listView1.Items.Remove(item);
                }
            }
            foreach (Employee employee in employees)
            {
                ListViewItem employeeItem = new ListViewItem(new string[]
                {
                    employee.Surname,
                    employee.FirstName,
                    employee.Patronymic,
                    employee.EmployeeIIN,
                });
                employeeItem.Tag = employee;
                listView1.Items.Add(employeeItem);
            }

        }
    }
}
