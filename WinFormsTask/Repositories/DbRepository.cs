using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections;
using WinFormsTask.Database;
using WinFormsTask.Models;
using System.Linq;

namespace WinFormsTask.Repositories
{
    public class DbRepository : IDbRepository
    {
        public async Task<IList> GetCompaniesWithEmployeesAsync()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var list =  await db.Companies.Include(c => c.Employees).ToListAsync();
                return ArrayList.FixedSize(list);
            }
 
        }
        public async Task<Company> GetCompanyByNameAsync(string IIN)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return await db.Companies.Where(c => c.CompanyIIN == IIN).Include(c => c.Employees).FirstOrDefaultAsync();

            }
        }
    }
}
