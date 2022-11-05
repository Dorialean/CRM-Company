﻿// <auto-generated />
using System;
using Company_CRM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Company_CRM.Migrations
{
    [DbContext(typeof(SneakerFactoryContext))]
    partial class SneakerFactoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "priority", new[] { "low", "medium", "high" });
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Company_CRM.Models.AvailableClient", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("client_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("ClientId"));

                    b.Property<string>("Address")
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<int?>("ContractId")
                        .HasColumnType("integer")
                        .HasColumnName("contract_id");

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("first_name");

                    b.Property<string>("OrganisationName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("organisation_name");

                    b.Property<string>("Phone")
                        .HasColumnType("text")
                        .HasColumnName("phone");

                    b.Property<string>("SecondName")
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("second_name");

                    b.HasKey("ClientId")
                        .HasName("available_clients_pkey");

                    b.HasIndex("ContractId");

                    b.ToTable("available_clients", (string)null);
                });

            modelBuilder.Entity("Company_CRM.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("client_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("ClientId"));

                    b.Property<string>("Address")
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("first_name");

                    b.Property<string>("OrganisationName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("organisation_name");

                    b.Property<string>("Phone")
                        .HasColumnType("text")
                        .HasColumnName("phone");

                    b.Property<string>("SecondName")
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("second_name");

                    b.HasKey("ClientId");

                    b.HasIndex(new[] { "Address" }, "client_address_index");

                    b.HasIndex(new[] { "FirstName" }, "client_name_index");

                    b.HasIndex(new[] { "OrganisationName" }, "client_org_name_index");

                    b.HasIndex(new[] { "ClientId" }, "clients_pk")
                        .IsUnique();

                    b.ToTable("clients", (string)null);
                });

            modelBuilder.Entity("Company_CRM.Models.Contract", b =>
                {
                    b.Property<int>("ContractId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("contract_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("ContractId"));

                    b.Property<int>("ClientId")
                        .HasColumnType("integer")
                        .HasColumnName("client_id");

                    b.Property<DateTime?>("Deadline")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("deadline");

                    b.Property<DateTime>("SignDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("sign_date");

                    b.Property<int>("SneakerId")
                        .HasColumnType("integer")
                        .HasColumnName("sneaker_id");

                    b.HasKey("ContractId");

                    b.HasIndex("ClientId");

                    b.HasIndex("SneakerId");

                    b.ToTable("contracts", (string)null);
                });

            modelBuilder.Entity("Company_CRM.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("employee_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("Address")
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("FactoryRole")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("factory_role");

                    b.Property<string>("FatherName")
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("father_name");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("first_name");

                    b.Property<DateTime>("Hired")
                        .HasColumnType("timestamp")
                        .HasColumnName("hired");

                    b.Property<string>("Login")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("login");

                    b.Property<byte[]>("Password")
                        .HasColumnType("bytea")
                        .HasColumnName("password");

                    b.Property<string>("Phone")
                        .HasColumnType("text")
                        .HasColumnName("phone");

                    b.Property<string>("SaltPass")
                        .HasColumnType("text")
                        .HasColumnName("salt_pass");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("second_name");

                    b.HasKey("EmployeeId");

                    b.ToTable("employee", (string)null);
                });

            modelBuilder.Entity("Company_CRM.Models.Job", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("job_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("JobId"));

                    b.Property<DateTime?>("Completed")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("completed");

                    b.Property<int?>("ContrId")
                        .HasColumnType("integer")
                        .HasColumnName("contr_id");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("CreatorEmplId")
                        .HasColumnType("integer")
                        .HasColumnName("creator_empl_id");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("deadline");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int>("ExecutorEmplId")
                        .HasColumnType("integer")
                        .HasColumnName("executor_empl_id");

                    b.Property<string>("Prior")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("JobId");

                    b.HasIndex("ContrId");

                    b.HasIndex("CreatorEmplId");

                    b.HasIndex("ExecutorEmplId");

                    b.ToTable("jobs", (string)null);
                });

            modelBuilder.Entity("Company_CRM.Models.PotentialClient", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("client_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("ClientId"));

                    b.Property<string>("Address")
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("first_name");

                    b.Property<DateTime?>("Meeting")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("meeting");

                    b.Property<string>("OrganisationName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("organisation_name");

                    b.Property<string>("Phone")
                        .HasColumnType("text")
                        .HasColumnName("phone");

                    b.Property<string>("SecondName")
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("second_name");

                    b.HasKey("ClientId")
                        .HasName("potential_clients_pkey");

                    b.ToTable("potential_clients", (string)null);
                });

            modelBuilder.Entity("Company_CRM.Models.Sneaker", b =>
                {
                    b.Property<int>("SneakerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("sneaker_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("SneakerId"));

                    b.Property<DateTime>("Arrived")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("arrived")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime?>("Leaved")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("leaved");

                    b.Property<string>("Model")
                        .HasColumnType("text")
                        .HasColumnName("model");

                    b.Property<string>("Size")
                        .HasMaxLength(4)
                        .HasColumnType("character varying(4)")
                        .HasColumnName("size");

                    b.Property<decimal?>("Weight")
                        .HasPrecision(5, 2)
                        .HasColumnType("numeric(5,2)")
                        .HasColumnName("weight");

                    b.HasKey("SneakerId");

                    b.ToTable("sneakers", (string)null);
                });

            modelBuilder.Entity("Company_CRM.Models.AvailableClient", b =>
                {
                    b.HasOne("Company_CRM.Models.Contract", "Contract")
                        .WithMany("AvailableClients")
                        .HasForeignKey("ContractId")
                        .HasConstraintName("contract_ref_constr");

                    b.Navigation("Contract");
                });

            modelBuilder.Entity("Company_CRM.Models.Contract", b =>
                {
                    b.HasOne("Company_CRM.Models.AvailableClient", "Client")
                        .WithMany("Contracts")
                        .HasForeignKey("ClientId")
                        .IsRequired()
                        .HasConstraintName("contracts_client_id_fkey");

                    b.HasOne("Company_CRM.Models.Sneaker", "Sneaker")
                        .WithMany("Contracts")
                        .HasForeignKey("SneakerId")
                        .IsRequired()
                        .HasConstraintName("contracts_sneaker_id_fkey");

                    b.Navigation("Client");

                    b.Navigation("Sneaker");
                });

            modelBuilder.Entity("Company_CRM.Models.Job", b =>
                {
                    b.HasOne("Company_CRM.Models.Contract", "Contr")
                        .WithMany("Jobs")
                        .HasForeignKey("ContrId")
                        .HasConstraintName("jobs_contr_id_fkey");

                    b.HasOne("Company_CRM.Models.Employee", "CreatorEmpl")
                        .WithMany("JobCreatorEmpls")
                        .HasForeignKey("CreatorEmplId")
                        .IsRequired()
                        .HasConstraintName("jobs_creator_empl_id_fkey");

                    b.HasOne("Company_CRM.Models.Employee", "ExecutorEmpl")
                        .WithMany("JobExecutorEmpls")
                        .HasForeignKey("ExecutorEmplId")
                        .IsRequired()
                        .HasConstraintName("jobs_executor_empl_id_fkey");

                    b.Navigation("Contr");

                    b.Navigation("CreatorEmpl");

                    b.Navigation("ExecutorEmpl");
                });

            modelBuilder.Entity("Company_CRM.Models.AvailableClient", b =>
                {
                    b.Navigation("Contracts");
                });

            modelBuilder.Entity("Company_CRM.Models.Contract", b =>
                {
                    b.Navigation("AvailableClients");

                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("Company_CRM.Models.Employee", b =>
                {
                    b.Navigation("JobCreatorEmpls");

                    b.Navigation("JobExecutorEmpls");
                });

            modelBuilder.Entity("Company_CRM.Models.Sneaker", b =>
                {
                    b.Navigation("Contracts");
                });
#pragma warning restore 612, 618
        }
    }
}
