using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teleperformance.Context;

namespace Teleperformance.API.Helper
{
    public static class IntializerData
    {
      
        public static async Task Initialize(DBContext context, UserManager<IdentityUser> userManager)
        {
           

                if (!userManager.Users.Any())
                {

                    var user = new IdentityUser
                    {
                        Email = "pgalfred2014@hotmail.com",
                        UserName = "PeterGeorege"
                    };


                    await userManager.CreateAsync(user, "123456789");


                } // if There not  any User in DB Create Default 
                   
            
           
               
        }

        public static void CreateDateBase(DBContext context)
        {
            context.Database.Migrate(); 
        }
    }
}
