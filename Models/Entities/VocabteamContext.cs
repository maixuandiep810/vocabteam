using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore;
using vocabteam.Models.Entities;

namespace vocabteam.Models
{
    public class VocabteamContext : DbContext
    {
        public VocabteamContext(DbContextOptions<VocabteamContext> options)
    : base(options)
        { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RolePermission> RolePermissions { get; set; }
        public virtual DbSet<UserPermission> UserPermissions { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region USER Entity
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
                      .HasColumnType("text");
                //   .IsRequired();
            });
            #endregion

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRoles")
                    .HasComment("This is the UserRoles Table")
                    .HasKey(e => e.Id);

                entity.Property(e => e.Id).UseMySqlIdentityColumn<int>();

                entity.Property(e => e.UserId)
                      .HasColumnName("UserId")
                      .HasColumnType("int");

                entity.Property(e => e.RoleId)
                      .HasColumnName("RoleId")
                      .HasColumnType("int");

                entity.HasOne(e => e.User)                      
                .WithMany(p => p.UserRoles)         
                .HasForeignKey("UserId")                
                .OnDelete(DeleteBehavior.SetNull)         
                .HasConstraintName("FK_UserRoles_Users");

                entity.HasOne(e => e.Role)                      
                .WithMany(p => p.UserRoles)         
                .HasForeignKey("RoleId")                
                .OnDelete(DeleteBehavior.SetNull)         
                .HasConstraintName("FK_UserRoles_Roles");
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

            modelBuilder.Entity<RolePermission>(entity =>
            {
                entity.ToTable("RolePermissions")
                    .HasComment("This is the RolePermissions Table")
                    .HasKey(e => e.Id);

                entity.Property(e => e.Id).UseMySqlIdentityColumn<int>();

                entity.Property(e => e.RoleId)
                      .HasColumnName("RoleId")
                      .HasColumnType("int");

                entity.Property(e => e.PermissionId)
                      .HasColumnName("PermissionId")
                      .HasColumnType("int");

                entity.HasOne(e => e.Role)                      
                .WithMany(p => p.RolePermissions)         
                .HasForeignKey("RoleId")                
                .OnDelete(DeleteBehavior.SetNull)         
                .HasConstraintName("FK_RolePermissions_Roles");

                entity.HasOne(e => e.Permission)                      
                .WithMany(p => p.RolePermissions)         
                .HasForeignKey("PermissionId")                
                .OnDelete(DeleteBehavior.SetNull)         
                .HasConstraintName("FK_RolePermissions_Permissions");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("Permissions")
                    .HasComment("This is the Permission Table")
                    .HasKey(e => e.Id);

                entity.Property(e => e.Id).UseMySqlIdentityColumn<int>();

                entity.Property(e => e.ObjectName)
                      .HasColumnName("ObjectName")
                      .HasColumnType("varchar(50)");

                entity.Property(e => e.Action)
                      .HasColumnName("Action")
                      .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<UserPermission>(entity =>
            {
                entity.ToTable("UserPermissions")
                    .HasComment("This is the UserPermissions Table")
                    .HasKey(e => e.Id);

                entity.Property(e => e.Id).UseMySqlIdentityColumn<int>();

                entity.Property(e => e.UserId)
                      .HasColumnName("UserId")
                      .HasColumnType("int");

                entity.Property(e => e.PermissionId)
                      .HasColumnName("PermissionId")
                      .HasColumnType("int");

                entity.HasOne(e => e.User)                      
                .WithMany(p => p.UserPermissions)         
                .HasForeignKey("UserId")                
                .OnDelete(DeleteBehavior.SetNull)         
                .HasConstraintName("FK_UserPermissions_Users");

                entity.HasOne(e => e.Permission)                      
                .WithMany(p => p.UserPermissions)         
                .HasForeignKey("PermissionId")                
                .OnDelete(DeleteBehavior.SetNull)         
                .HasConstraintName("FK_UserPermissions_Permissions");
            });

            // entity.Property(e => new {e.UserId, e.RoleId}).IsU();


            // entity.Property(e => e.UserId)
            //.HasColumnName("UserId")
            //.HasColumnType("int")
            //.HasColumnAnnotation(
            // IndexAnnotation.AnnotationName,
            //     new IndexAnnotation(
            //         new IndexAttribute("IX_FirstNameLastName", 1) { IsUnique = true }));


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