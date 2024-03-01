// ApplicationDbContext.cs
using ActiveCamp;
using Microsoft.EntityFrameworkCore;

public class ApplicationContext : DbContext
{
    public ApplicationContext()
    {
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=testDB;Trusted_Connection=True;");
    }

    public DbSet<User> User { get; set; }
    /*public DbSet<Equipment> Equipments { get; set; }
    public DbSet<UserEquipment> UserEquipments { get; set; }
    public DbSet<DietaryPreference> DietaryPreferences { get; set; }
    public DbSet<Allergie> Allergies { get; set; }
    public DbSet<Dislike> Dislikes { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<GroupMember> GroupMembers { get; set; }
    public DbSet<UserDietaryPreferences> UserDietaryPreferences { get; set; }*/
}
