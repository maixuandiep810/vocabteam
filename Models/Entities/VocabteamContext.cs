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
        public virtual DbSet<UserSetting> UserSettings { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RolePermission> RolePermissions { get; set; }
        public virtual DbSet<UserPermission> UserPermissions { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<Vocabulary> Vocabularies { get; set; }
        public virtual DbSet<Question> Questions { get; set; }

        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<SM_Index> EF_Indexes { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region USER Entity
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users")
                        .HasComment("This is the User Table")
                        .HasKey(e => e.Id);

                entity.Property(e => e.Id).UseMySqlIdentityColumn<int>().ValueGeneratedOnAdd();

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

                entity.Property(e => e.Token)
                        .HasColumnName("Token")
                        .HasColumnType("text");
                //   .IsRequired();
            });
            #endregion

            modelBuilder.Entity<UserSetting>(entity =>
            {
                entity.ToTable("UserSettings")
                        .HasComment("This is the UserSettings Table")
                        .HasKey(e => e.Id);

                entity.Property(e => e.Id).UseMySqlIdentityColumn<int>().ValueGeneratedOnAdd();

                entity.Property(e => e.UserId)
                        .HasColumnName("UserId")
                        .HasColumnType("int");

                entity.Property(e => e.A1_ChangeInTime)
                        .HasColumnName("A1_ChangeInTime")
                        .HasColumnType("int");
                entity.Property(e => e.A2_ChangeInTime)
                        .HasColumnName("A2_ChangeInTime")
                        .HasColumnType("int");
                entity.Property(e => e.B1_ChangeInTime)
                        .HasColumnName("B1_ChangeInTime")
                        .HasColumnType("int");
                entity.Property(e => e.B2_ChangeInTime)
                        .HasColumnName("B2_ChangeInTime")
                        .HasColumnType("int");
                entity.Property(e => e.C1_ChangeInTime)
                        .HasColumnName("C1_ChangeInTime")
                        .HasColumnType("int");
                entity.Property(e => e.C2_ChangeInTime)
                        .HasColumnName("C2_ChangeInTime")
                        .HasColumnType("int");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRoles")
                        .HasComment("This is the UserRoles Table")
                        .HasKey(e => e.Id);

                entity.Property(e => e.Id).UseMySqlIdentityColumn<int>().ValueGeneratedOnAdd();

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

                entity.Property(e => e.Id).UseMySqlIdentityColumn<int>().ValueGeneratedOnAdd();

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

                entity.Property(e => e.Id).UseMySqlIdentityColumn<int>().ValueGeneratedOnAdd();

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

                entity.Property(e => e.Id).UseMySqlIdentityColumn<int>().ValueGeneratedOnAdd();

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

                entity.Property(e => e.Id).UseMySqlIdentityColumn<int>().ValueGeneratedOnAdd();

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

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Categories")
                        .HasComment("This is the Categories Table")
                        .HasKey(e => e.Id);

                entity.Property(e => e.Id).UseMySqlIdentityColumn<int>().ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                        .HasColumnName("Name")
                        .HasColumnType("varchar(50)");

                entity.Property(e => e.Description)
                        .HasColumnName("Description")
                        .HasColumnType("text");

                entity.Property(e => e.ImageUrl)
                        .HasColumnName("ImageUrl")
                        .HasColumnType("text");

                entity.Property(e => e.LevelId)
                        .HasColumnName("LevelId")
                        .HasColumnType("int");
                  // TODO: check BOOL in MYSQL
                entity.Property(e => e.IsCustomCategory)
                        .HasColumnName("IsCustomCategory")
                        .HasColumnType("bit");
                entity.Property(e => e.UserId)
                        .HasColumnName("UserId")
                        .HasColumnType("int");

                entity.HasOne(e => e.User)
                        .WithMany(p => p.Categories)
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("FK_Categories_Users");

                entity.HasOne(e => e.Level)
                        .WithMany(p => p.Categories)
                        .HasForeignKey("LevelId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("FK_Categories_Levels");
            });

            modelBuilder.Entity<Level>(entity =>
            {
                entity.ToTable("Level")
                        .HasComment("This is the Categories Table")
                        .HasKey(e => e.Id);

                entity.Property(e => e.Id).UseMySqlIdentityColumn<int>().ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                        .HasColumnName("Name")
                        .HasColumnType("varchar(50)");

                entity.Property(e => e.Description)
                        .HasColumnName("Description")
                        .HasColumnType("text");
            });

            modelBuilder.Entity<Vocabulary>(entity =>
            {
                entity.ToTable("Vocabularies")
                        .HasComment("This is the Vocabularies Table")
                        .HasKey(e => e.Id);

                entity.Property(e => e.Id).UseMySqlIdentityColumn<int>().ValueGeneratedOnAdd();

                entity.Property(e => e.Word)
                        .HasColumnName("Word")
                        .HasColumnType("varchar(50)");

                entity.Property(e => e.Meaning)
                        .HasColumnName("Meaning")
                        .HasColumnType("varchar(50)");

                entity.Property(e => e.Definition)
                        .HasColumnName("Definition")
                        .HasColumnType("text");

                entity.Property(e => e.Sentence)
                        .HasColumnName("Sentence")
                        .HasColumnType("text");

                entity.Property(e => e.AudioUrl)
                        .HasColumnName("AudioUrl")
                        .HasColumnType("text");

                entity.Property(e => e.ImageUrl)
                        .HasColumnName("ImageUrl")
                        .HasColumnType("text");

                entity.Property(e => e.CategoryId)
                        .HasColumnName("CategoryId")
                        .HasColumnType("int");

                entity.HasOne(e => e.Category)
                        .WithMany(p => p.Vocabularies)
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("FK_Vocabularies_Categories");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("Questions")
                        .HasComment("This is the Questions Table")
                        .HasKey(e => e.Id);

                entity.Property(e => e.Id).UseMySqlIdentityColumn<int>().ValueGeneratedOnAdd();

                entity.Property(e => e.FirstAnswer)
                        .HasColumnName("FirstAnswer")
                        .HasColumnType("varchar(50)");

                entity.Property(e => e.SecondAnswer)
                        .HasColumnName("SecondAnswer")
                        .HasColumnType("varchar(50)");

                entity.Property(e => e.ThirdAnswer)
                        .HasColumnName("ThirdAnswer")
                        .HasColumnType("varchar(50)");

                entity.Property(e => e.VocabularyId)
                        .HasColumnName("VocabularyId")
                        .HasColumnType("int");

                entity.HasOne(e => e.Vocabulary)
                        .WithMany(p => p.Questions)
                        .HasForeignKey("VocabularyId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("FK_Questions_Vocabularies");
            });


            modelBuilder.Entity<Test>(entity =>
            {
                entity.ToTable("Tests")
                        .HasComment("This is the Tests Table")
                        .HasKey(e => e.Id);

                entity.Property(e => e.Id).UseMySqlIdentityColumn<int>().ValueGeneratedOnAdd();

                entity.Property(e => e.UserId)
                        .HasColumnName("UserId")
                        .HasColumnType("int");

                entity.Property(e => e.CategoryId)
                        .HasColumnName("CategoryId")
                        .HasColumnType("int");

                entity.Property(e => e.Order)
                        .HasColumnName("Order")
                        .HasColumnType("int");

                entity.Property(e => e.Result)
                        .HasColumnName("Result")
                        .HasColumnType("float");

                entity.Property(e => e.I_Index)
                        .HasColumnName("I_Index")
                        .HasColumnType("float");

                entity.Property(e => e.EF_Index)
                        .HasColumnName("EF_Index")
                        .HasColumnType("float");

                entity.HasOne(e => e.User)
                        .WithMany(p => p.Tests)
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("FK_Tests_Users");

                entity.HasOne(e => e.Category)
                        .WithMany(p => p.Tests)
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("FK_Tests_Categories");
            });

            modelBuilder.Entity<SM_Index>(entity =>
            {
                entity.ToTable("EF_Indexes")
                        .HasComment("This is the EF_Indexes Table")
                        .HasKey(e => e.Id);

                entity.Property(e => e.Id).UseMySqlIdentityColumn<int>().ValueGeneratedOnAdd();

                entity.Property(e => e.UserId)
                        .HasColumnName("UserId")
                        .HasColumnType("int");

                entity.Property(e => e.LevelId)
                        .HasColumnName("LevelId")
                        .HasColumnType("int");

                entity.Property(e => e.Order)
                        .HasColumnName("Order")
                        .HasColumnType("int");

                entity.Property(e => e.I_Index)
                        .HasColumnName("I_Index")
                        .HasColumnType("float");

                entity.Property(e => e.EF_Index)
                        .HasColumnName("EF_Index")
                        .HasColumnType("float");

                entity.HasOne(e => e.User)
                        .WithMany(p => p.SM_Indexes)
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("FK_SM_Indexes_Users");
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