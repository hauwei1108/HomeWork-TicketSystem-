using ApplicationCore.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfrastructure.DataBase.MyTemplateConfiguration
{
    public class TicketMainConfiguration : IEntityTypeConfiguration<TicketMain>
    {
        public void Configure(EntityTypeBuilder<TicketMain> entity)
        {
            entity.HasKey(e => e.TmId);

            entity.ToTable("TICKET_MAIN");

            entity.Property(e => e.TmId)
                .HasColumnName("TM_ID")
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

            entity.Property(e => e.Description)
                .HasColumnName("DESCRIPTION")
                .HasMaxLength(50)
                .IsUnicode(false);

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

            entity.Property(e => e.Summary)
                .HasColumnName("SUMMARY")
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.Property(e => e.TtId)
                .HasColumnName("TT_ID")
                .HasMaxLength(36)
                .IsUnicode(false);
        }
    }
}
