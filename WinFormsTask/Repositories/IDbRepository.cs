using System;
using System.Collections;
using WinFormsTask.Models;
using System.Threading.Tasks;

namespace WinFormsTask.Repositories
{
    public interface IDbRepository
    {
        Task<IList> GetCompaniesWithEmployeesAsync();
        Task<Company> GetCompanyByNameAsync(string IIN);
    }
}
