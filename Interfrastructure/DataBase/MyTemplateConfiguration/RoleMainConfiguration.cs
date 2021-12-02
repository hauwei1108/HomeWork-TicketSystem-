using ApplicationCore.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfrastructure.DataBase.MyTemplateConfiguration
{
    public class RoleMainConfiguration : IEntityTypeConfiguration<RoleMain>
    {
        public void Configure(EntityTypeBuilder<RoleMain> entity)
        {
            entity.HasKey(e => e.RmId);

            entity.ToTable("ROLE_MAIN");

            entity.Property(e => e.RmId)
                .HasColumnName("RM_ID")
                .HasMaxLength(36)
                .IsUnicode(false);

            entity.Property(e => e.ClientIp)
                .HasColumnName("CLIENT_IP")
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.CreateDtm)
                .HasColumnName("CREATE_DTM")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.CreateUser)
                .HasColumnName("CREATE_USER")
                .HasMaxLength(20);

            entity.Property(e => e.ModifyDtm)
                .HasColumnName("MODIFY_DTM")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.ModifyUser)
                .HasColumnName("MODIFY_USER")
                .HasMaxLength(20);

            entity.Property(e => e.RoleNm)
                .HasColumnName("ROLE_NM")
                .HasMaxLength(20);

            entity.Property(e => e.RoleType)
                .HasColumnName("ROLE_TYPE")
                .HasMaxLength(5)
                .IsUnicode(false);

            entity.Property(e => e.ServerIp)
                .HasColumnName("SERVER_IP")
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.SysType)
                .HasColumnName("SYS_TYPE")
                .HasMaxLength(1)
                .IsUnicode(false);
        }
    }
}
