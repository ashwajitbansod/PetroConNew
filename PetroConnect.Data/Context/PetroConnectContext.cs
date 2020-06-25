using System;
using System.ComponentModel.Design;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PetroConnect.Data.Context
{
    public partial class PetroConnectContext : DbContext
    {

        public PetroConnectContext()
        {
        }
        public PetroConnectContext(DbContextOptions<PetroConnectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ExceptionLog> ExceptionLog { get; set; }
        public virtual DbSet<UserRoles> UserRoles { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Sp_ResultModals> TestData { get; set; }
        public virtual DbSet<spLogin_Result> spLogin { get; set; }
        public virtual DbSet<spLoginNext_Result> spLoginNext { get; set; }



        public virtual DbSet<spCommonResponse> spExceptionLog { get; set; }
        public virtual DbSet<spCommonResponse> spCustomerRegistration { get; set; }
        public virtual DbSet<spCommonResponse> spSetProductDetailOwner { get; set; }
        public virtual DbSet<spCommonResponse> spSetMachineRegistration { get; set; }
        public virtual DbSet<spCommonResponse> spSetPlaceOrder { get; set; }
        public virtual DbSet<spGetMachine_Result> spGetMachine { get; set; }
        public virtual DbSet<spGetProductDetailOwner_Result> spGetProductDetailOwner { get; set; }
        public virtual DbSet<spCommonResponse> spSetCustomerMapping { get; set; }
        public virtual DbSet<spSetNozzleRegistration_Result> spSetNozzleRegistration { get; set; }
        public virtual DbSet<spGetCity_Result> spGetCity { get; set; }
        public virtual DbSet<spGetStateList_Result> spGetStateList { get; set; }
        public virtual DbSet<spCommonResponse> spSetDailyUpdateFuelPrice { get; set; }
        public virtual DbSet<spCommonResponse> spSetShiftSchecdule { get; set; }
        public virtual DbSet<spCommonResponse> SetMappingNozzleShift { get; set; }

        public virtual DbSet<spCommonResponse> SetShiftSchecdule { get; set; }

        public virtual DbSet<spGetIndent_Result> spGetIndent { get; set; }
        public virtual DbSet<spCommonResponse> spSetConfirmOrder { get; set; }
        public virtual DbSet<spCommonResponse> spSetTankRegistration { get; set; }
        public virtual DbSet<spGetGlobalCode_Result> spGetGlobalCode { get; set; }
        public virtual DbSet<spGetTankMachineNozzle_Result> spGetTankMachineNozzle { get; set; }
        public virtual DbSet<spGetCustomerDetails_Result> spGetCustomerDetails { get; set; }
        public virtual DbSet<spGetTeamDetails_Result> spGetTeamDetails { get; set; }
        //User Activate Deactivate
        public virtual DbSet<spCommonResponse> spSetActivationDeActivationUser { get; set; }
        public virtual DbSet<spCommonResponse> spSetActivationDeActivationTeam { get; set; }

        //Tank details
        public virtual DbSet<spGetTank_Result> spGetTank { get; set; }

        //Customer details
        public virtual DbSet<spCommonResponse> spSetCustomerDetailEdit { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<spCommonResponse>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<spGetTeamDetails_Result>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<spGetTank_Result>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<spGetCustomerDetails_Result>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<ExceptionLog>(entity =>
            {
                entity.Property(e => e.Level)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnName("message")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserRoles>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__UserRole__8AFACE1AD96F5492");

                entity.Property(e => e.RoleDesc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<spLoginNext_Result>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<spSetNozzleRegistration_Result>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<spGetGlobalCode_Result>(entity =>
             {
                 entity.HasNoKey();
             });
            modelBuilder.Entity<spGetMachine_Result>(entity =>
            {
                entity.HasKey(e => e.MCN_UID_UserId).HasName("PK_Machine_123123UniqueId"); ;
            });

            modelBuilder.Entity<spGetCity_Result>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<spGetStateList_Result>(entity =>
            {
                entity.HasNoKey();
            });



            modelBuilder.Entity<spGetProductDetailOwner_Result>(entity =>
            {
                entity.HasNoKey();
            });



            modelBuilder.Entity<spGetTankMachineNozzle_Result>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<spGetIndent_Result>(entity =>
            {
                entity.HasKey(e => e.SBK_Id);
            });
            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Users__1788CC4C54A84F24");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_ToUserRoles");
            });

            OnModelCreatingPartial(modelBuilder);
            //Has no key Section

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {

        //        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //        optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings[""].ConnectionString);
        //    }
        //}
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
