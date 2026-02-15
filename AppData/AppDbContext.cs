

using API.Intities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.AppData;

public class AppDbContext(DbContextOptions options) : IdentityDbContext<AppUser>(options)
{

    public DbSet<Photo> photo { get; set; }

    public DbSet<Members> members { get; set; }

    public DbSet<MemberLiked> memberLikes { get; set; }

    public DbSet<Message> messages { get; set; }

    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>().HasData(
    new IdentityRole
    {
        Id = "Admin-id",
        Name = "Admin",
        NormalizedName = "ADMIN",
        ConcurrencyStamp = "11111111-1111-1111-1111-111111111111"
    },
    new IdentityRole
    {
        Id = "Member-id",
        Name = "Member",
        NormalizedName = "MEMBER",
        ConcurrencyStamp = "22222222-2222-2222-2222-222222222222"
    },
    new IdentityRole
    {
        Id = "Moderator-id",
        Name = "Moderator",
        NormalizedName = "MODERATOR",
        ConcurrencyStamp = "33333333-3333-3333-3333-333333333333"
    }
);


        modelBuilder.Entity<Message>().HasOne(x => x.Sender).WithMany(x => x.MessageSent).HasForeignKey(x => x.SenderId);
        modelBuilder.Entity<Message>().HasOne(x => x.Reciever).WithMany(x => x.MessageRecieved).HasForeignKey(x => x.RecieverId);

        modelBuilder.Entity<MemberLiked>()
        .HasKey(k => new { k.SourceMemberId, k.TargetMemberId });

        modelBuilder.Entity<MemberLiked>()
        .HasOne(s => s.sourceMember)
        .WithMany(l => l.LikedMember)
        .HasForeignKey(s => s.SourceMemberId)
        .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<MemberLiked>()
        .HasOne(s => s.targetMember)
        .WithMany(l => l.LikedByMember)
        .HasForeignKey(s => s.TargetMemberId)
        .OnDelete(DeleteBehavior.NoAction);
    }

}

