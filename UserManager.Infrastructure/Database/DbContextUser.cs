using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.Domain.Entities;

namespace UserManager.Infrastructure.Database;

public class DbContextUser : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=NomeDoBanco;Integrated Security=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.BirthDate).IsRequired();
            entity.Property(x => x.CPF).IsRequired();
            entity.Property(x => x.FullName).IsRequired();
            entity.Property(x => x.Email).IsRequired();
            entity.Property(x => x.Password).IsRequired();
            entity.Property(x => x.PhoneNumber).IsRequired();
            entity.Property(x => x.Address).HasMaxLength(100).HasDefaultValue("");
            entity.Property(x => x.Language).HasDefaultValue("pt-br");
            entity.Property(x => x.CreatedAt).IsRequired();
            entity.Property(x => x.IsActive).IsRequired();
        });
    }
}