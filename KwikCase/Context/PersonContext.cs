﻿using System;
using System.Collections.Generic;
using KwikCase.Models;
using Microsoft.EntityFrameworkCore;

namespace KwikCase.Context;

public partial class PersonContext : DbContext
{
    public PersonContext()
    {
    }

    public PersonContext(DbContextOptions<PersonContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> PersonData => Set<Account>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=./DummyDB/PersonData.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.UserId);
            entity.Property(e => e.FirstName).HasColumnType("text");
            entity.Property(e => e.LastName).HasColumnType("text");
            entity.Property(e => e.Sex).HasColumnType("text");
            entity.Property(e => e.Email).HasColumnType("text");
            entity.Property(e => e.Phone).HasColumnType("text");
            entity.Property(e => e.DateOfBirth).HasColumnType("text");
            entity.Property(e => e.Profession).HasColumnType("text");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
