using Gym.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gym.Web.Data;

public class GymDbContext : IdentityDbContext<ApplicationUser>
{
    public GymDbContext(DbContextOptions<GymDbContext> options) : base(options)
    {
    }

    public DbSet<Client> Clients { get; set; }
    public DbSet<Package> Packages { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Membership> Memberships { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<GymSession> GymSessions { get; set; }
    public DbSet<FaceEmbedding> FaceEmbeddings { get; set; }
    public DbSet<AccessLog> AccessLogs { get; set; }
    public DbSet<Admin> Admins { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Configure relationships
        builder.Entity<Membership>()
            .HasOne(m => m.Client)
            .WithMany(c => c.Memberships)
            .HasForeignKey(m => m.ClientId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Membership>()
            .HasOne(m => m.Package)
            .WithMany(p => p.Memberships)
            .HasForeignKey(m => m.PackageId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Membership>()
            .HasOne(m => m.Instructor)
            .WithMany(i => i.Memberships)
            .HasForeignKey(m => m.InstructorId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Payment>()
            .HasOne(p => p.Client)
            .WithMany(c => c.Payments)
            .HasForeignKey(p => p.ClientId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Session>()
            .HasOne(s => s.Instructor)
            .WithMany(i => i.Sessions)
            .HasForeignKey(s => s.InstructorId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Session>()
            .HasOne(s => s.Membership)
            .WithMany(m => m.Sessions)
            .HasForeignKey(s => s.MembershipId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Attendance>()
            .HasOne(a => a.Client)
            .WithMany(c => c.Attendances)
            .HasForeignKey(a => a.ClientId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Attendance>()
            .HasOne(a => a.Session)
            .WithMany(s => s.Attendances)
            .HasForeignKey(a => a.SessionId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<GymSession>()
            .HasOne(gs => gs.Client)
            .WithMany(c => c.GymSessions)
            .HasForeignKey(gs => gs.ClientId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Instructor>()
            .HasOne(i => i.Package)
            .WithMany(p => p.Instructors)
            .HasForeignKey(i => i.PackageId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<FaceEmbedding>()
            .HasOne(fe => fe.Client)
            .WithOne(c => c.FaceEmbedding)
            .HasForeignKey<FaceEmbedding>(fe => fe.ClientId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<AccessLog>()
            .HasOne(al => al.Client)
            .WithMany(c => c.AccessLogs)
            .HasForeignKey(al => al.ClientId)
            .OnDelete(DeleteBehavior.SetNull);

        // Configure indexes
        builder.Entity<GymSession>()
            .HasIndex(gs => gs.ClientId);

        builder.Entity<GymSession>()
            .HasIndex(gs => gs.EntranceTime);

        builder.Entity<GymSession>()
            .HasIndex(gs => gs.ExitTime);

        builder.Entity<Client>()
            .HasIndex(c => c.Locker)
            .HasFilter("\"Locker\" IS NOT NULL");

        builder.Entity<Membership>()
            .HasIndex(m => m.ClientId);

        builder.Entity<Membership>()
            .HasIndex(m => m.EndDate);

        builder.Entity<Membership>()
            .HasIndex(m => m.IsPaid);

        // Configure constraints
        builder.Entity<Client>()
            .HasIndex(c => c.SocialNumber)
            .IsUnique();

        builder.Entity<Client>()
            .HasIndex(c => c.PhoneNumber)
            .IsUnique();

        // Access logs indexes
        builder.Entity<AccessLog>()
            .HasIndex(al => al.ClientId);

        builder.Entity<AccessLog>()
            .HasIndex(al => al.Timestamp);

        builder.Entity<AccessLog>()
            .HasIndex(al => al.AccessGranted);
    }
}
