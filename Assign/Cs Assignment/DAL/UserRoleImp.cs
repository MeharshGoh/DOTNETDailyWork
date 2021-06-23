using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cs_Assignment.Models;

namespace Cs_Assignment.DAL
{
    public class UserRoleImp : IUsers<Users, int>
    {
        DbContextClass context;
        public UserRoleImp()
        {
            context = new DbContextClass();
        }
        public async Task<Users> CreateAsyncUser(Users model)
        {
            var res = await context.Users.AddAsync(model);
            await context.SaveChangesAsync();
            return res.Entity;
        }

        public static bool RegisterUser(Users user)
        {
            if(user.UserName.Contains(" "))
            {
                return false;
            }
            if (user.UserName.Contains("~"))
            {
                return false;
            }
            if (user.UserName.Contains("_"))
            {
                return true;
            }
            if (user.UserName.Contains("^[0-9]"))
            {
                return false;
            }
            
            return true;
        }

        public static bool UsernameLengthChecking(Users user)
        {

            if(user.UserName.Length<8)
            {
                return false;
            }
            if(user.UserName.Length > 20)
            {
                return false;
            }
            return true;
        }

        
    }
}
