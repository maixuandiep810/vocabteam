using Microsoft.EntityFrameworkCore;
using vocabteam.Models.Entities;

namespace vocabteam.Models
{
    public class VocabteamContext : DbContext
    {
        public VocabteamContext(DbContextOptions<VocabteamContext> options)
    : base(options)
        { }

        public virtual DbSet<User> Users { get; set; }
        // public virtual DbSet<UserRole> UserRoles { get; set; }
        // public virtual DbSet<Role> Roles { get; set; }
        // public virtual DbSet<RolePermission> RolePermissions { get; set; }
        // public virtual DbSet<Permission> Permissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users")
                    .HasComment("This is the User Table")
                    .HasKey(e => e.Id);

                entity.Property(e => e.Id).UseMySqlIdentityColumn<int>();
                entity.Property(e => e.Username)
                      .HasColumnName("Username")
                      .HasColumnType("varchar(50)")
                      .HasDefaultValue("account");
                //   .HasMaxLength(50);
                entity.HasIndex(p => p.Username)
                      .IsUnique(true);

                entity.Property(e => e.Password)
                      .HasColumnName("Password")
                      .HasColumnType("varchar(50)");
                //   .IsRequired();

                entity.Property(e => e.Email)
                      .HasColumnName("Email")
                      .HasColumnType("varchar(50)");
                //   .IsRequired();

                entity.Property(e => e.AvatarUrl)
                      .HasColumnName("AvatarUrl")
                      .HasColumnType("ntext");
                //   .IsRequired();
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRoles")
                    .HasComment("This is the UserRoles Table")
                    .HasKey(e => e.Id);

                entity.Property(e => e.Id).UseMySqlIdentityColumn<int>();

                entity.Property(e => e.UserId)
                      .HasColumnName("Name")
                      .HasColumnType("int")
                      .HasDefaultValue("guest");

                entity.Property(e => e.RoleId)
                      .HasColumnName("DisplayName")
                      .HasColumnType("int");

                entity.HasOne(e => e.UserId)                       // Chỉ ra Entity là phía một (bảng User)
                .WithMany(user => user.ProductsPost)         // Chỉ ra Collection tập Product lưu ở phía một
                .HasForeignKey("UserPostId")                 // Chỉ ra tên FK nếu muốn
                .OnDelete(DeleteBehavior.SetNull)            // Ứng xử khi User bị xóa (Hoặc chọn DeleteBehavior.Cascade)
                .HasConstraintName("FK_Products_user_1234");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Roles")
                    .HasComment("This is the Role Table")
                    .HasKey(e => e.Id);

                entity.Property(e => e.Id).UseMySqlIdentityColumn<int>();

                entity.Property(e => e.Name)
                      .HasColumnName("Name")
                      .HasColumnType("varchar(50)")
                      .HasDefaultValue("guest");

                entity.Property(e => e.DisplayName)
                      .HasColumnName("DisplayName")
                      .HasColumnType("varchar(50)");
            });


            // modelBuilder.Entity<Blog>(entity =>
            // {
            //     entity.ToTable("blogs");

            //     entity.Property(e => e.Id).HasColumnType("int(11)");
            // });

            // modelBuilder.Entity<Post>(entity =>
            // {
            //     entity.ToTable("posts");

            //     entity.Property(e => e.Id).HasColumnType("int(11)");

            //     entity.HasIndex(e => e.BlogId)
            //         .HasName("FK_Post_Blog_BlogId_idx");

            //     entity.HasOne(d => d.Blog)
            //         .WithMany(p => p.Posts)
            //         .HasForeignKey(d => d.Id)
            //         .HasConstraintName("FK_Post_Blog_BlogId");
            // });
        }
    }
}