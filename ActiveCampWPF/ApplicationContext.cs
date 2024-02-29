// ApplicationDbContext.cs
using ActiveCamp;
using Microsoft.EntityFrameworkCore;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<User> Users { get; set; }
    /*public DbSet<Equipment> Equipments { get; set; }
    public DbSet<UserEquipment> UserEquipments { get; set; }
    public DbSet<DietaryPreference> DietaryPreferences { get; set; }
    public DbSet<Allergie> Allergies { get; set; }
    public DbSet<Dislike> Dislikes { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<GroupMember> GroupMembers { get; set; }
    public DbSet<UserDietaryPreferences> UserDietaryPreferences { get; set; }*/
}
