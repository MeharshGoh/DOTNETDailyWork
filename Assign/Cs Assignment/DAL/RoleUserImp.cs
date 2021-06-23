using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cs_Assignment.Models;

namespace Cs_Assignment.DAL
{
    public class RoleUserImp : IRole<Roles,int>
    {
        DbContextClass context;
        public RoleUserImp()
        {
            context = new DbContextClass();
        }
        public async Task<Roles> CreateRoleAsync(Roles entity)
        {
            try
            {
                var res = await context.Roles.AddAsync(entity);
                await context.SaveChangesAsync();
                return res.Entity;
            }
            catch (Exception ex)
            {

                //  Console.WriteLine($"Exception occurred while adding the role {ex.Message}");
                throw ex;
            }
        }

        public static bool checkingRolesName(Roles role)
        {
            if(role.RoleName != null)
            {
                return true;
            }
            if (role.RoleName == "^[A-Z]")
            {
                return true;
            }
            return false;
        }

    }
}
