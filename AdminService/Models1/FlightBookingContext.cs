using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AdminService.Models1
{
    public partial class FlightBookingContext : DbContext
    {
        public FlightBookingContext()
        {
        }

        public FlightBookingContext(DbContextOptions<FlightBookingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AirlineDetail> AirlineDetails { get; set; }
        public virtual DbSet<FlightBookingDetail> FlightBookingDetails { get; set; }
        public virtual DbSet<ScheduleDetail> ScheduleDetails { get; set; }
        public virtual DbSet<UserDetail> UserDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=CTSDOTNET13;Database=FlightBooking;user id=sa;password=pass@word1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AirlineDetail>(entity =>
            {
                entity.HasNoKey();

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

            modelBuilder.Entity<FlightBookingDetail>(entity =>
            {
                entity.HasNoKey();

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

            modelBuilder.Entity<ScheduleDetail>(entity =>
            {
                entity.HasNoKey();

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

            modelBuilder.Entity<UserDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("USER_DETAILS");

                entity.Property(e => e.Age).HasColumnName("AGE");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GENDER")
                    .IsFixedLength(true);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.IsActive)
                    .HasColumnName("IS_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.MobileNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("MOBILE_NUMBER");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("NAME");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ROLE_NAME")
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
