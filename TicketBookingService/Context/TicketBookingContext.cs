using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBookingService.Models;

namespace TicketBookingService.Context
{
    public class TicketBookingContext:DbContext
    {
        public TicketBookingContext()
        {
        }

        public TicketBookingContext(DbContextOptions<TicketBookingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FlightBookingDetail> details { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<FlightBookingDetail>(entity =>
            {
                //entity.HasNoKey();

                entity.ToTable("FLIGHT_BOOKING_DETAILS");

                entity.Property(e => e.Cost)
                    .HasColumnType("decimal(9, 9)")
                    .HasColumnName("COST");

                entity.Property(e => e.CreatedModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_MODIFIED_DATE");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.IsCanceled)
                    .HasColumnName("IS_CANCELED")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.MealPreferene)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MEAL_PREFERENE")
                    .IsFixedLength(true);

                entity.Property(e => e.PnrNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("PNR_NUMBER");

                entity.Property(e => e.ScheduedId).HasColumnName("SCHEDUED_ID");

                entity.Property(e => e.SeatNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("SEAT_NUMBER");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");
            });

        }
    }
}

