using ApplicationCore.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfrastructure.DataBase.MyTemplateConfiguration
{
    public class UserLoginLogConfiguration : IEntityTypeConfiguration<UserLoginLog>
    {
        public void Configure(EntityTypeBuilder<UserLoginLog> entity)
        {
            entity.HasKey(e => e.UllId);

            entity.ToTable("USER_LOGIN_LOG");

            entity.Property(e => e.UllId)
                .HasColumnName("ULL_ID")
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

            entity.Property(e => e.IsSuccess)
                .HasColumnName("IS_SUCCESS")
                .HasMaxLength(1)
                .IsUnicode(false);

            entity.Property(e => e.LoginDtm)
                .HasColumnName("LOGIN_DTM")
                .HasColumnType("datetime");

            entity.Property(e => e.ServerIp)
                .HasColumnName("SERVER_IP")
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.UmId)
                .HasColumnName("UM_ID")
                .HasMaxLength(36)
                .IsUnicode(false);
        }
    }
}
