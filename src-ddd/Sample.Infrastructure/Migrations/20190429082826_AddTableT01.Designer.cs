﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sample.Infrastructure;

namespace Sample.Infrastructure.Migrations
{
    [DbContext(typeof(SampleContext))]
    [Migration("20190429082826_AddTableT01")]
    partial class AddTableT01
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("Sample.Domain.Entities.Log", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Action");

                    b.Property<string>("Application");

                    b.Property<string>("Callsite");

                    b.Property<string>("Exception");

                    b.Property<string>("Level");

                    b.Property<DateTime>("Logged");

                    b.Property<string>("Logger");

                    b.Property<string>("Message");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("Sample.Domain.Entities.T01", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("BooleanNullableValue");

                    b.Property<bool>("BooleanValue");

                    b.Property<DateTime?>("DateTimeNullableValue");

                    b.Property<DateTime>("DateTimeValue");

                    b.Property<int?>("IntNullableValue");

                    b.Property<int>("IntValue");

                    b.Property<string>("StringValue");

                    b.HasKey("Id");

                    b.ToTable("T01");
                });

            modelBuilder.Entity("Sample.Domain.Entities.TodoItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<short>("IsComplete");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("TodoItems");
                });
#pragma warning restore 612, 618
        }
    }
}
