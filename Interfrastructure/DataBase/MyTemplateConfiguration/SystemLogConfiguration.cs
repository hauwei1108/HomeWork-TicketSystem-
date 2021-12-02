using ApplicationCore.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfrastructure.DataBase.MyTemplateConfiguration
{
    public class SystemLogConfiguration : IEntityTypeConfiguration<SystemLog>
    {
        public void Configure(EntityTypeBuilder<SystemLog> entity)
        {
            entity.HasKey(e => e.SlId);

            entity.ToTable("SYSTEM_LOG");

            entity.Property(e => e.SlId)
                .HasColumnName("SL_ID")
                .HasMaxLength(36)
                .IsUnicode(false);

            entity.Property(e => e.ClientIp)
                .IsRequired()
                .HasColumnName("CLIENT_IP")
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.CreateDtm)
                .HasColumnName("CREATE_DTM")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.CreateUser)
                .IsRequired()
                .HasColumnName("CREATE_USER")
                .HasMaxLength(20);

            entity.Property(e => e.LogLevel)
                .IsRequired()
                .HasColumnName("LOG_LEVEL")
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.Message)
                .IsRequired()
                .HasColumnName("MESSAGE")
                .HasMaxLength(4000);

            entity.Property(e => e.ServerIp)
                .IsRequired()
                .HasColumnName("SERVER_IP")
                .HasMaxLength(20)
                .IsUnicode(false);
        }
    }
}
