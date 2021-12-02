using ApplicationCore.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfrastructure.DataBase.MyTemplateConfiguration
{
    public class UserMainConfiguration : IEntityTypeConfiguration<UserMain>
    {
        public void Configure(EntityTypeBuilder<UserMain> entity)
        {
            entity.HasKey(e => e.UmId);

            entity.ToTable("USER_MAIN");

            entity.HasIndex(e => new { e.UmId, e.UserAct })
                .HasName("IX_USER_MAIN_USER_ACT");

            entity.Property(e => e.UmId)
                .HasColumnName("UM_ID")
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

            entity.Property(e => e.ServerIp)
                .HasColumnName("SERVER_IP")
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.UserAct)
                .HasColumnName("USER_ACT")
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.UserName)
                .HasColumnName("USER_NAME")
                .HasMaxLength(10);

            entity.Property(e => e.UserPd)
                .HasColumnName("USER_PD")
                .HasMaxLength(100)
                .IsUnicode(false);
        }
    }
}
