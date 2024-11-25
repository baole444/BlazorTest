using Microsoft.EntityFrameworkCore;

namespace StaffServices.Models;



public partial class StaffContex : DbContext
{
    public StaffContex() { }

    public StaffContex(DbContextOptions<StaffContex> options) : base(options) { }

    public virtual DbSet<DepartmentModel> Department { get; set; }

    public virtual DbSet<EmployeeModel> Employee { get; set; }

    public virtual DbSet<GenderModel> Gender { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseMySQL(ConfigLoader.GetConfiguration().GetConnectionString("default"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DepartmentModel>(entity => {
            entity.HasKey(entity => entity.DepartmentID).HasName("PRIMARY");

            entity.ToTable("department");

            entity.Property(entity => entity.DepartmentID).HasColumnName("DepartmentID");

            entity.Property(entity => entity.DepartmentName).HasMaxLength(100);
        });

        modelBuilder.Entity<GenderModel>(entity => {
            entity.HasKey(entity => entity.GenderID).HasName("PRIMARY");

            entity.ToTable("gender");

            entity.Property(entity => entity.GenderID).HasColumnName("GenderID");
            entity.Property(entity => entity.GenderDescription).HasMaxLength(100);
        });

        modelBuilder.Entity<EmployeeModel>(entity => {
            entity.HasKey(entity => entity.EmployeeID).HasName("PRIMARY");

            entity.ToTable("employee");

            entity.HasIndex(entity => entity.DepartmentID, "DepartmentID");

            entity.HasIndex(entity => entity.GenderID, "GenderID");

            entity.Property(entity => entity.EmployeeID).HasColumnName("EmployeeID");

            entity.Property(entity => entity.DepartmentID).HasColumnName("DepartmentID");

            entity.Property(entity => entity.GenderID).HasColumnName("GenderID");

            entity.Property(em => em.FirstName).HasMaxLength(100);

            entity.Property(entity => entity.LastName).HasMaxLength(100);

            entity.Property(entity => entity.Email).HasMaxLength(100);

            entity.Property(entity => entity.DateOfBirth).HasColumnType("date");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees).
                HasForeignKey(d => d.DepartmentID).HasConstraintName("employee_ibfk_2");


            entity.HasOne(d => d.Gender).WithMany(p => p.Employees).HasForeignKey(d => d.GenderID).HasConstraintName("employee_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


}


