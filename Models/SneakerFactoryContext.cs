using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Company_CRM.Models
{
    public partial class SneakerFactoryContext : DbContext
    {
        public SneakerFactoryContext()
        {
        }

        public SneakerFactoryContext(DbContextOptions<SneakerFactoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AvailableClient> AvailableClients { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Contract> Contracts { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Job> Jobs { get; set; } = null!;
        public virtual DbSet<PotentialClient> PotentialClients { get; set; } = null!;
        public virtual DbSet<Sneaker> Sneakers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=sneaker_factory;Username=postgres;Password=B&k34RPvvB12F;");
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=sneaker_factory;Username=postgres;Password=JM12Pq33Mf;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum("priority", new[] { "low", "medium", "high" });

            modelBuilder.Entity<AvailableClient>(entity =>
            {
                entity.HasKey(e => e.ClientId)
                    .HasName("available_clients_pkey");

                entity.ToTable("available_clients");

                entity.Property(e => e.ClientId)
                    .HasColumnName("client_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.ContractId).HasColumnName("contract_id");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(15)
                    .HasColumnName("first_name");

                entity.Property(e => e.OrganisationName).HasColumnName("organisation_name");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.SecondName)
                    .HasMaxLength(15)
                    .HasColumnName("second_name");

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.AvailableClients)
                    .HasForeignKey(d => d.ContractId)
                    .HasConstraintName("contract_ref_constr");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("clients");

                entity.HasIndex(e => e.Address, "client_address_index");

                entity.HasIndex(e => e.FirstName, "client_name_index");

                entity.HasIndex(e => e.OrganisationName, "client_org_name_index");

                entity.HasIndex(e => e.ClientId, "clients_pk")
                    .IsUnique();

                entity.Property(e => e.ClientId)
                    .HasColumnName("client_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(15)
                    .HasColumnName("first_name");

                entity.Property(e => e.OrganisationName).HasColumnName("organisation_name");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.SecondName)
                    .HasMaxLength(15)
                    .HasColumnName("second_name");
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.ToTable("contracts");

                entity.Property(e => e.ContractId)
                    .HasColumnName("contract_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.Deadline)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("deadline");

                entity.Property(e => e.SignDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("sign_date");

                entity.Property(e => e.SneakerId).HasColumnName("sneaker_id");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("contracts_client_id_fkey");

                entity.HasOne(d => d.Sneaker)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.SneakerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("contracts_sneaker_id_fkey");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.FactoryRole)
                    .HasMaxLength(30)
                    .HasColumnName("factory_role");

                entity.Property(e => e.FatherName)
                    .HasMaxLength(15)
                    .HasColumnName("father_name");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(15)
                    .HasColumnName("first_name");

                entity.Property(e => e.Login)
                    .HasMaxLength(50)
                    .HasColumnName("login");

                entity.Property(e => e.Password).HasColumnName("password");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.SaltPass).HasColumnName("salt_pass");

                entity.Property(e => e.SecondName)
                    .HasMaxLength(15)
                    .HasColumnName("second_name");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("jobs");

                entity.Property(e => e.JobId)
                    .HasColumnName("job_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Completed)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("completed");

                entity.Property(e => e.ContrId).HasColumnName("contr_id");

                entity.Property(e => e.Created)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("created")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatorEmplId).HasColumnName("creator_empl_id");

                entity.Property(e => e.Deadline)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("deadline");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.ExecutorEmplId).HasColumnName("executor_empl_id");

                entity.HasOne(d => d.Contr)
                    .WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.ContrId)
                    .HasConstraintName("jobs_contr_id_fkey");

                entity.HasOne(d => d.CreatorEmpl)
                    .WithMany(p => p.JobCreatorEmpls)
                    .HasForeignKey(d => d.CreatorEmplId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("jobs_creator_empl_id_fkey");

                entity.HasOne(d => d.ExecutorEmpl)
                    .WithMany(p => p.JobExecutorEmpls)
                    .HasForeignKey(d => d.ExecutorEmplId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("jobs_executor_empl_id_fkey");
            });

            modelBuilder.Entity<PotentialClient>(entity =>
            {
                entity.HasKey(e => e.ClientId)
                    .HasName("potential_clients_pkey");

                entity.ToTable("potential_clients");

                entity.Property(e => e.ClientId)
                    .HasColumnName("client_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(15)
                    .HasColumnName("first_name");

                entity.Property(e => e.Meeting)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("meeting");

                entity.Property(e => e.OrganisationName).HasColumnName("organisation_name");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.SecondName)
                    .HasMaxLength(15)
                    .HasColumnName("second_name");
            });

            modelBuilder.Entity<Sneaker>(entity =>
            {
                entity.ToTable("sneakers");

                entity.Property(e => e.SneakerId)
                    .HasColumnName("sneaker_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Arrived)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("arrived")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Leaved)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("leaved");

                entity.Property(e => e.Model).HasColumnName("model");

                entity.Property(e => e.Size)
                    .HasMaxLength(4)
                    .HasColumnName("size");

                entity.Property(e => e.Weight)
                    .HasPrecision(5, 2)
                    .HasColumnName("weight");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
