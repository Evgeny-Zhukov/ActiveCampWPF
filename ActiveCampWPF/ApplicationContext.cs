// ApplicationDbContext.cs
using ActiveCamp;
using Microsoft.EntityFrameworkCore;

public class ApplicationContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=testDBB.db");
        //@"Server=(localdb)\MSSQLLocalDB;Database=testDBB;Trusted_Connection=True;"
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Allergie>().HasKey(a => a.AllergiesID);
        modelBuilder.Entity<DietaryPreference>().HasKey(dp => dp.DietaryPreferencesID);
        modelBuilder.Entity<Dislike>().HasKey(d => d.DislikeID);
        modelBuilder.Entity<Equipment>().HasKey(e => e.EquipmentID);
        modelBuilder.Entity<Group>().HasKey(g => g.GroupId);
        modelBuilder.Entity<GroupMember>().HasKey(gm => gm.GroupID);
        modelBuilder.Entity<GroupMember>().HasKey(gm => gm.UserID);
        modelBuilder.Entity<User>().HasKey(u => u.UserID);
        modelBuilder.Entity<UserDietaryPreferences>().HasKey(udp => udp.DietaryPreferencesID);
        modelBuilder.Entity<UserEquipment>().HasKey(ue => ue.UserEquipmentID);
        
    }
    public DbSet<User> User { get; set; }
    public DbSet<Equipment> Equipments { get; set; }
    public DbSet<UserEquipment> UserEquipments { get; set; }
    public DbSet<DietaryPreference> DietaryPreferences { get; set; }
    public DbSet<Allergie> Allergies { get; set; }
    public DbSet<Dislike> Dislikes { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<GroupMember> GroupMembers { get; set; }
    public DbSet<UserDietaryPreferences> UserDietaryPreferences { get; set; }
}
