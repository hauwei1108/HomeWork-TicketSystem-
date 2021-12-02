using ApplicationCore.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfrastructure.DataBase.MyTemplateConfiguration
{
    public class UserLoginDataConfiguration : IEntityTypeConfiguration<UserLoginData>
    {
        public void Configure(EntityTypeBuilder<UserLoginData> entity)
        {
            entity.HasKey(e => e.UldId);

            entity.ToTable("USER_LOGIN_DATA");

            entity.Property(e => e.UldId)
                .HasColumnName("ULD_ID")
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

            entity.Property(e => e.IsLogin)
                .HasColumnName("IS_LOGIN")
                .HasMaxLength(1)
                .IsUnicode(false);

            entity.Property(e => e.LastActionDtm)
                .HasColumnName("LAST_ACTION_DTM")
                .HasColumnType("datetime");

            entity.Property(e => e.LoginDtm)
                .HasColumnName("LOGIN_DTM")
                .HasColumnType("datetime");

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

            entity.Property(e => e.Token)
                .HasColumnName("TOKEN")
                .HasMaxLength(2000)
                .IsUnicode(false);

            entity.Property(e => e.UmId)
                .IsRequired()
                .HasColumnName("UM_ID")
                .HasMaxLength(36)
                .IsUnicode(false);
        }
    }
}
