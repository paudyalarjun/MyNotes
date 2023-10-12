using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyNotes.Models;

namespace MyNotes.Data;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public DbSet<Note>? Notes { get; set; }
    public DbSet<Product>? Products { get; set; }
    public DbSet<Student>? Students { get; set; }
    public DbSet<Department>? Departments { get; set; }
    public DbSet<Teacher>? Teachers { get; set; }
    public DbSet<Lecture>? Lectures { get; set; }
    public DbSet<TeacherDepartment>? TeacherDepartments { get; set; }
    public DbSet<StudentLecture>? StudentLectures { get; set; }
    public DbSet<KycForm>? KycForms { get; set; }
    public DbSet<State>? State { get; set; }
    public DbSet<District>? District { get; set; }
    public DbSet<ImageForm>? ImageForms { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}

