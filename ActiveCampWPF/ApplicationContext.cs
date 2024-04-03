// ApplicationDbContext.cs
using ActiveCamp;
using Microsoft.EntityFrameworkCore;

public class ApplicationContext : DbContext
{
    public ApplicationContext()
    {
        //Database.EnsureCreated(); создает БД, если ее нет, по сути бесполезна
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Test;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /*modelBuilder.Entity<Equipment>()
            .HasOne(e => e.UserEquipment)  
            .WithOne(ue => ue.Equipment)   
            .HasForeignKey<UserEquipment>(ue => ue.UserEquipmentID);


        modelBuilder.Entity <User>()
            .HasMany(e => e.UserEquipment)
            .WithOne(ue => ue.User)
            .HasForeignKey(ue => ue.UserID);

        modelBuilder.Entity<User>()
            .HasMany(u => u.GroupMember)
            .WithOne(gm => gm.User)
            .HasForeignKey(gm => gm.UserID);


        modelBuilder.Entity<GroupMember>()
            .HasOne(ug => ug.Group)
            .WithMany(g => g.GroupMember)
            .HasForeignKey(ug => ug.GroupID);*/

        modelBuilder.Entity<Users>()
            .HasKey(u => new { u.UserID });

        modelBuilder.Entity<Equipment>()
            .HasKey(e => new { e.EquipmentID });

        modelBuilder.Entity<UserEquipment>()
            .HasKey(ue => new { ue.UserEquipmentID });

        modelBuilder.Entity<Group>()
            .HasKey(g => new { g.GroupID});

        modelBuilder.Entity<GroupMember>()
            .HasKey(gm => new { gm.GroupID, gm.UserID });
    }

    public DbSet<Users> Users { get; set; }
    public DbSet<Equipment> Equipment { get; set; }
    public DbSet<UserEquipment> UserEquipment { get; set; }
    //public DbSet<DietaryPreference> DietaryPreferences { get; set; }
    //public DbSet<Allergie> Allergies { get; set; }
    //public DbSet<Dislike> Dislikes { get; set; }
    //public DbSet<Group> Groups { get; set; }
    //public DbSet<GroupMember> GroupMembers { get; set; }
    //public DbSet<UserDietaryPreferences> UserDietaryPreferences { get; set; }
}
