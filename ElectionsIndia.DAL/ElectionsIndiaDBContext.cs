using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ElectionsIndia.Models;

namespace ElectionsIndia.DAL
{
   public  class ElectionsIndiaDBContext : DbContext
    {
        public DbSet<Languages> Language;
    }
}
