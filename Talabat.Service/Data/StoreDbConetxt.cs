using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Service.Data
{
    public class StoreDbConetxt : DbContext
    {
        public StoreDbConetxt(DbContextOptions<StoreDbConetxt> options) : base(options)
        {

        }
 /*       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }*/
    }
}
