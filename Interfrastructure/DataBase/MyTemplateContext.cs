using ApplicationCore.Entities.Models;
using Interfrastructure.DataBase.MyTemplateConfiguration;
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

        #region Table
        public virtual DbSet<RoleMain> RoleMain { get; set; }
        public virtual DbSet<SystemLog> SystemLog { get; set; }
        public virtual DbSet<TicketMain> TicketMain { get; set; }
        public virtual DbSet<TicketType> TicketType { get; set; }
        public virtual DbSet<TypeRole> TypeRole { get; set; }
        public virtual DbSet<UserLoginData> UserLoginData { get; set; }
        public virtual DbSet<UserLoginLog> UserLoginLog { get; set; }
        public virtual DbSet<UserMain> UserMain { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Table

            modelBuilder.ApplyConfiguration(new RoleMainConfiguration());
            modelBuilder.ApplyConfiguration(new SystemLogConfiguration());
            modelBuilder.ApplyConfiguration(new TicketMainConfiguration());
            modelBuilder.ApplyConfiguration(new TicketTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TypeRoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserLoginDataConfiguration());
            modelBuilder.ApplyConfiguration(new UserLoginLogConfiguration());
            modelBuilder.ApplyConfiguration(new UserMainConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());

            #endregion
        }
    }
}
