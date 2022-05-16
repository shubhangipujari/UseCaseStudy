using Microsoft.EntityFrameworkCore;
using ScheduleService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleService.Context
{
    public class ScheduleContext:DbContext
    {
        public ScheduleContext()
        {
        }

        public ScheduleContext(DbContextOptions<ScheduleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ScheduleDetail> details { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ScheduleDetail>(entity =>
            {
               // entity.HasNoKey();

                entity.ToTable("SCHEDULE_DETAILS");

                entity.Property(e => e.AirlineId).HasColumnName("AIRLINE_ID");

                entity.Property(e => e.ChooseWay)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHOOSE_WAY")
                    .HasDefaultValueSql("('O')")
                    .IsFixedLength(true);

                entity.Property(e => e.EndDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("END_DATE_TIME");

                entity.Property(e => e.FlightName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("FLIGHT_NAME");

                entity.Property(e => e.FlightNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("FLIGHT_NUMBER");

                entity.Property(e => e.FromPlace)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("FROM_PLACE");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.InstrumentUsed)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("INSTRUMENT_USED");

                entity.Property(e => e.Meal)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MEAL")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength(true);

                entity.Property(e => e.NumberOfRows).HasColumnName("NUMBER_OF_ROWS");

                entity.Property(e => e.ScheduledDays)
                    .HasMaxLength(50)
                    .HasColumnName("SCHEDULED_DAYS");

                entity.Property(e => e.StartDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("START_DATE_TIME");

                entity.Property(e => e.TicketCost)
                    .HasColumnType("decimal(9, 9)")
                    .HasColumnName("TICKET_COST");

                entity.Property(e => e.ToPlace)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("TO_PLACE");

                entity.Property(e => e.TotNumBuisSeat).HasColumnName("TOT_NUM_BUIS_SEAT");

                entity.Property(e => e.TotNumNonbuisSeat).HasColumnName("TOT_NUM_NONBUIS_SEAT");
            });


        }
    }
}

