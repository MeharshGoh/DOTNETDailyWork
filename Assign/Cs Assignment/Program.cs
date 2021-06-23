using System;
using Cs_Assignment.DAL;
using Cs_Assignment.Models;

namespace Cs_Assignment
{
    class Program
    {
        static IRole<Roles, int> roleServ = new RoleUserImp();
        static IUsers<Users, int> userServ = new UserRoleImp();

        static void Main(string[] args)
        {
            bool x = true;
            while (x == true)
            {
                Console.WriteLine("=======MENU===================");
                Console.WriteLine("1. Add User");
                Console.WriteLine("2. Add Role");

                Console.WriteLine("Enter your choice");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch(choice)
                {
                    case 1:
                        
                        Console.WriteLine("Enter User name");
                        string name =Console.ReadLine();
                        Console.WriteLine("Enter User Email");
                        string email = Console.ReadLine();
                        Console.WriteLine("Enter User Password");
                        string pwd = Console.ReadLine();
                        Console.WriteLine("Enter Role ID");
                        int rid = Convert.ToInt32(Console.ReadLine());

                       
                            userServ.CreateAsyncUser(new Users()
                            {
                                UserName = name,
                                Email = email,
                                Password = pwd,
                                RoleId = rid,
                            });
                            Console.WriteLine("User Added Successfully!!");
                        
                        break;

                    case 2:
                        
                        Console.WriteLine("Enter Role name");
                        string rname = Console.ReadLine();

                       

                            roleServ.CreateRoleAsync(new Roles()
                                {
                                    RoleName = rname,
                                });
                                Console.WriteLine("Role Added Successfully!!");
                           
                   
                            
                        
                        
                        break;
                }
            }
        }
    }
}
