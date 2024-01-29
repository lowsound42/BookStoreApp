using System;
using System.Collections.Generic;
using BookStoreApp.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.API.Data;

public partial class BookStoreDbContext : IdentityDbContext<ApiUser>
{
    public BookStoreDbContext()
    {
    }

    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Authors__3214EC07CC5FC70F");

            entity.Property(e => e.Bio).HasMaxLength(250);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Books__3214EC07D52599F3");

            entity.HasIndex(e => e.Isbn, "UQ__Books__447D36EAC389E3F7").IsUnique();

            entity.Property(e => e.Image).HasMaxLength(50);
            entity.Property(e => e.Isbn)
                .HasMaxLength(50)
                .HasColumnName("ISBN");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Summary).HasMaxLength(250);
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK_Books_ToTable");
        });

        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Name = "User",
                NormalizedName = "USER",
                Id = "ac873ff7-da62-4bd5-ba57-c5b174812b0d"
            },
            new IdentityRole
            {
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                Id = "bcfd68cd-b1ee-4273-b185-3487a655459e"
            }
        );

        var hasher = new PasswordHasher<ApiUser>();

        modelBuilder.Entity<ApiUser>().HasData(
            new ApiUser
            {
                Id = "96873c6a-da0c-4fa3-b1ca-a1f37c32f8bf",
                Email = "admin@bookstore.com",
                NormalizedEmail = "ADMIN@BOOKSTORE.COM",
                UserName = "admin@bookstore.com",
                NormalizedUserName = "ADMIN@BOOKSTORE.COM",
                FirstName = "System",
                LastName = "Admin",
                PasswordHash = hasher.HashPassword(null, "P@ssword1")
            },
            new ApiUser
            {
                Id = "b896a1e7-8e4b-474b-a5ac-5c839d9a9d0b",
                Email = "user@bookstore.com",
                NormalizedEmail = "USER@BOOKSTORE.COM",
                UserName = "user@bookstore.com",
                NormalizedUserName = "USER@BOOKSTORE.COM",
                FirstName = "System",
                LastName = "USER",
                PasswordHash = hasher.HashPassword(null, "P@ssword1")
            }

            );

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "bcfd68cd-b1ee-4273-b185-3487a655459e",
                UserId = "96873c6a-da0c-4fa3-b1ca-a1f37c32f8bf"
            },
            new IdentityUserRole<string>
            {
                RoleId = "ac873ff7-da62-4bd5-ba57-c5b174812b0d",
                UserId = "b896a1e7-8e4b-474b-a5ac-5c839d9a9d0b"
            }
        ) ;

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
