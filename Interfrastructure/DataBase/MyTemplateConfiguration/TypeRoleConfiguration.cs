using ApplicationCore.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfrastructure.DataBase.MyTemplateConfiguration
{
    public class TypeRoleConfiguration : IEntityTypeConfiguration<TypeRole>
    {
        public void Configure(EntityTypeBuilder<TypeRole> entity)
        {
            entity.HasKey(e => e.TrId);

            entity.ToTable("TYPE_ROLE");

            entity.Property(e => e.TrId)
                .HasColumnName("TR_ID")
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

            entity.Property(e => e.RmId)
                .HasColumnName("RM_ID")
                .HasMaxLength(36)
                .IsUnicode(false);

            entity.Property(e => e.ServerIp)
                .HasColumnName("SERVER_IP")
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.TtId)
                .HasColumnName("TT_ID")
                .HasMaxLength(36)
                .IsUnicode(false);
        }
    }
}
