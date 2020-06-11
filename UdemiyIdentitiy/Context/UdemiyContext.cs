using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemiyIdentitiy.Context
{
    public class UdemiyContext:IdentityDbContext<AppUser,AppRole,int>
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer(@"server=DESKTOP-NV0GSA0\SQLEXPRESS;database=udemyBlogToDo");
            optionsBuilder.UseSqlServer(@"Server = BESIRAYDEMIRM2\SQLEXPRESS; Database = UdemyIdentity; Trusted_Connection = True; MultipleActiveResultSets = true");
            ///optionsBuilder.UseSqlServer(@"Server = DESKTOP-NV0GSA0\SQLEXPRESS; Database = UdemyIdentity; Trusted_Connection = True; MultipleActiveResultSets = true");
        }

    


    }
}
