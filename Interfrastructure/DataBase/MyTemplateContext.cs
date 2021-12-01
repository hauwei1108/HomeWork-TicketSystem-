using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfrastructure.DataBase
{
    public partial class MyTemplateContext : DbContext
    {
        public MyTemplateContext() { }

        public MyTemplateContext(DbContextOptions<MyTemplateContext> options)
            : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
