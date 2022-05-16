using AirLineService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineService.DBContext
{
    public class AirlineContext:DbContext
    {
        public AirlineContext()
        {
        }

        public AirlineContext(DbContextOptions<AirlineContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AirlineDetail> UserDetails { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AirlineDetail>(entity =>
            {
               // entity.HasNoKey();

                entity.ToTable("AIRLINE_DETAILS");

                entity.Property(e => e.AirlineName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("AIRLINE_NAME");

                entity.Property(e => e.ContactAddress)
                    .HasMaxLength(1024)
                    .HasColumnName("CONTACT_ADDRESS");

                entity.Property(e => e.ContactNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("CONTACT_NUMBER");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.IsBlocked)
                    .HasColumnName("IS_BLOCKED")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Logo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("LOGO");
            });
        }
        }
    }
