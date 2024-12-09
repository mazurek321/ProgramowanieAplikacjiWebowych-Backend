using projekt.src.Models.Users;
using Microsoft.EntityFrameworkCore;
using projekt.src.Models.Store;
using projekt.src.Models.ShoppingCart;

namespace projekt.src.Data;

public class ApiDbContext : DbContext 
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) 
        : base(options) {}

    public DbSet<User> Users { get; set; }
    public DbSet<Announcement> Announcements { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(builder =>
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(id => id.Value, value => new UserId(value));

            builder.HasIndex(x=>x.Email).IsUnique();
            builder.Property(x=>x.Email).HasConversion(email => email.Value, value => new Email(value));

            builder.Property(x=>x.Name).HasConversion(name => name.Value, value => new Name(value))
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x=>x.LastName).HasConversion(ln=>ln.Value, value=>new LastName(value))
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x=>x.Password).HasConversion(p => p.Value, value => new Password(value))
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x=>x.Address).HasConversion(a => a.Value, value => new Address(value));

            builder.Property(x=>x.Location).HasConversion(Location => Location.Value, value => new Address(value));

            builder.Property(x=>x.PostCode).HasConversion(PostCode => PostCode.Value, value => new PostCode(value));

            builder.Property(x=>x.Phone).HasConversion(Phone =>Phone.Value, value => new Phone(value));
        
            builder.Property(x=>x.Role).HasConversion(Role => Role.Value, value => new AccountType(value))
                .IsRequired();

            builder.Property(x=>x.CreatedAt).IsRequired();
        });

        var passwordForAdmin = new Password("admin");
        var hashedPasswordForAdmin = new Password(passwordForAdmin.CalculateMD5Hash(passwordForAdmin.Value));

        var admin = User.NewAdmin(
            email: new Email("admin@example.com"),
            name: new Name("Admin"),
            lastname: new LastName("Admin"),
            password: hashedPasswordForAdmin,
            address: null,
            location: null,
            postcode: null,
            phone: null,
            createdAt: DateTime.UtcNow
        );


        modelBuilder.Entity<User>().HasData(new
        {
            Id = admin.Id,                          
            Email = admin.Email,         
            Name = admin.Name,          
            LastName = admin.LastName,   
            Password = admin.Password,
            Address = admin.Address,
            Location = admin.Location,
            PostCode = admin.PostCode,
            Phone = admin.Phone,
            Role = admin.Role,
            CreatedAt = admin.CreatedAt    
        });

        modelBuilder.Entity<Announcement>(builder =>
        {
            builder.HasKey(x=>x.Id);

            builder.Property(x=>x.OwnerId)
                .HasConversion(id=>id.Value, value => new UserId(value))
                .IsRequired();
            
            builder.OwnsOne(x=>x.Item, ib=>
            {
                ib.WithOwner(); //owned by Announcement

                ib.Property(i=>i.Title)
                    .IsRequired()
                    .HasMaxLength(500);
                
                ib.Property(i=>i.Description)
                    .HasMaxLength(5000);

                ib.Property(i=>i.Amount)
                    .HasConversion(am=>am.Value, value => new ItemAmount(value))
                    .IsRequired();
                
                ib.Property(i=>i.Cost)
                    .HasConversion(c=>c.Value, value => new Cost(value))
                    .IsRequired();
                

            builder.Property(x=>x.CreatedAt)
                .IsRequired();
            });
        });

        modelBuilder.Entity<ShoppingCart>(builder =>
        {
            builder.HasKey(x=>x.Id);

            builder.Property(x=>x.OwnerId)
                .HasConversion(x=>x.Value, value => new UserId(value))
                .IsRequired();

            builder.Property(x=>x.UpdatedAt)
                .IsRequired();

            builder.HasMany(x=>x.Items)
                .WithOne()
                .HasForeignKey(y=>y.ShoppingCartId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x=>x.OwnerId);
        });

         modelBuilder.Entity<ShoppingCartItem>(builder =>
        {
            builder.Property(x => x.Id)
                .IsRequired();

            builder.Property(x => x.Quantity)
                .HasConversion(v => v.Value, value => new Quantity(value))
                .IsRequired();

            builder.Property(x => x.ShoppingCartId)
                .IsRequired();

            builder.Property(x=>x.AnnouncementId)
                .IsRequired();
        });
    }
}