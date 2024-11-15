using Microsoft.EntityFrameworkCore;

namespace Warfighters.Models.Data;

public partial class HoyoverseContext : DbContext
{
    public HoyoverseContext()
    {
    }

    public HoyoverseContext(DbContextOptions<HoyoverseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Artifact> Artifacts { get; set; }

    public virtual DbSet<Character> Characters { get; set; }

    public virtual DbSet<Constellation> Constellations { get; set; }

    public virtual DbSet<RecommendedStat> RecommendedStats { get; set; }

    public virtual DbSet<SetArtifact> SetArtifacts { get; set; }

    public virtual DbSet<Stat> Stats { get; set; }

    public virtual DbSet<Talent> Talents { get; set; }

    public virtual DbSet<Weapon> Weapons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql("server=localhost;user=newroot;password=newroot228;database=hoyoverse", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.36-mysql"));
        }
    }
        //=> optionsBuilder.UseMySql("server=localhost;user=newroot;password=newroot228;database=hoyoverse", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.36-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Artifact>(entity =>
        {
            entity.HasKey(e => e.IdArtifact).HasName("PRIMARY");

            entity.ToTable("artifact");

            entity.Property(e => e.IdArtifact).HasColumnName("id_artifact");
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .HasColumnName("category");

            entity.HasMany(d => d.IdStats).WithMany(p => p.IdArtifacts)
                .UsingEntity<Dictionary<string, object>>(
                    "ArtifactStat",
                    r => r.HasOne<Stat>().WithMany()
                        .HasForeignKey("IdStat")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_as_s"),
                    l => l.HasOne<Artifact>().WithMany()
                        .HasForeignKey("IdArtifact")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_as_a"),
                    j =>
                    {
                        j.HasKey("IdArtifact", "IdStat")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("artifact_stats");
                        j.HasIndex(new[] { "IdStat" }, "fk_as_s");
                        j.IndexerProperty<int>("IdArtifact").HasColumnName("id_artifact");
                        j.IndexerProperty<int>("IdStat").HasColumnName("id_stat");
                    });
        });

        modelBuilder.Entity<Character>(entity =>
        {
            entity.HasKey(e => e.IdCharacter).HasName("PRIMARY");

            entity.ToTable("characters");

            entity.HasIndex(e => e.IdSignatureWepons, "fk_c_w");

            entity.HasIndex(e => e.IdCharacter, "id_character_UNIQUE").IsUnique();

            entity.HasIndex(e => e.ImageCharacter, "image_character_UNIQUE")
                .IsUnique()
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 255 });

            entity.HasIndex(e => e.NameCharacter, "name_character_UNIQUE").IsUnique();

            entity.Property(e => e.IdCharacter).HasColumnName("id_character");
            entity.Property(e => e.CountViews).HasColumnName("count_views");
            entity.Property(e => e.EyeGod)
                .HasMaxLength(10)
                .HasColumnName("eye_god");
            entity.Property(e => e.IdSignatureSetArtifact).HasColumnName("id_signature_set_artifact");
            entity.Property(e => e.IdSignatureWepons).HasColumnName("id_signature_wepons");
            entity.Property(e => e.ImageCharacter)
                .HasColumnType("text")
                .HasColumnName("image_character");
            entity.Property(e => e.MainDps)
                .HasMaxLength(2)
                .HasColumnName("main_dps");
            entity.Property(e => e.NameCharacter)
                .HasMaxLength(25)
                .HasColumnName("name_character");
            entity.Property(e => e.Rariry).HasColumnName("rariry");
            entity.Property(e => e.Region)
                .HasMaxLength(20)
                .HasColumnName("region");
            entity.Property(e => e.SubDps)
                .HasMaxLength(2)
                .HasColumnName("sub_dps");
            entity.Property(e => e.Support)
                .HasMaxLength(2)
                .HasColumnName("support");
            entity.Property(e => e.TypeWeapon)
                .HasMaxLength(40)
                .HasColumnName("type_weapon");

            entity.HasOne(d => d.IdSignatureWeponsNavigation).WithMany(p => p.Characters)
                .HasForeignKey(d => d.IdSignatureWepons)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_c_w");

            entity.HasMany(d => d.IdSets).WithMany(p => p.IdCharacters)
                .UsingEntity<Dictionary<string, object>>(
                    "CharactersSet",
                    r => r.HasOne<SetArtifact>().WithMany()
                        .HasForeignKey("IdSet")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_cs_s"),
                    l => l.HasOne<Character>().WithMany()
                        .HasForeignKey("IdCharacter")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_cs_c"),
                    j =>
                    {
                        j.HasKey("IdCharacter", "IdSet")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("characters_set");
                        j.HasIndex(new[] { "IdSet" }, "fk_cs_s");
                        j.IndexerProperty<int>("IdCharacter").HasColumnName("id_character");
                        j.IndexerProperty<int>("IdSet").HasColumnName("id_set");
                    });

            entity.HasOne(d => d.IdSignaturSetNavigation)
                .WithMany(p => p.Characters)
                .HasForeignKey(d => d.IdSignatureSetArtifact)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_c_s");
            entity.HasMany(c => c.RecommendedStats)
                .WithOne(rs => rs.IdCharacterNavigation)
                .HasForeignKey(rs => rs.IdCharacter)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasMany(d => d.IdWeapons).WithMany(p => p.IdCharacters)
                .UsingEntity<Dictionary<string, object>>(
                    "CharactersWeapon",
                    r => r.HasOne<Weapon>().WithMany()
                        .HasForeignKey("IdWeapon")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_cw_w"),
                    l => l.HasOne<Character>().WithMany()
                        .HasForeignKey("IdCharacter")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_cw_c"),
                    j =>
                    {
                        j.HasKey("IdCharacter", "IdWeapon")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("characters_weapon");
                        j.HasIndex(new[] { "IdWeapon" }, "fk_cw_w");
                        j.IndexerProperty<int>("IdCharacter").HasColumnName("id_character");
                        j.IndexerProperty<int>("IdWeapon").HasColumnName("id_weapon");
                    });
        });

        modelBuilder.Entity<Constellation>(entity =>
        {
            entity.HasKey(e => e.IdConstellation).HasName("PRIMARY");

            entity.ToTable("constellation");

            entity.HasIndex(e => e.DescriptionConstellation, "description_constellation_UNIQUE")
                .IsUnique()
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 255 });

            entity.HasIndex(e => e.IdCharacter, "fk_c_c");

            entity.HasIndex(e => e.NameConstellation, "name_constellation_UNIQUE").IsUnique();

            entity.Property(e => e.IdConstellation).HasColumnName("id_constellation");
            entity.Property(e => e.ConstellationLevel).HasColumnName("constellation_level");
            entity.Property(e => e.DescriptionConstellation)
                .HasColumnType("text")
                .HasColumnName("description_constellation");
            entity.Property(e => e.IdCharacter).HasColumnName("id_character");
            entity.Property(e => e.NameConstellation)
                .HasMaxLength(100)
                .HasColumnName("name_constellation");

            entity.HasOne(d => d.IdCharacterNavigation).WithMany(p => p.Constellations)
                .HasForeignKey(d => d.IdCharacter)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_c_c");
        });

        modelBuilder.Entity<RecommendedStat>(entity =>
        {
            entity.HasKey(e => new { e.IdCharacter, e.IdArtifact, e.IdStat })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("recommended_stats");

            entity.HasIndex(e => e.IdArtifact, "fk_rs_a");

            entity.HasIndex(e => e.IdStat, "fk_rs_s");

            entity.Property(e => e.IdCharacter).HasColumnName("id_character");
            entity.Property(e => e.IdArtifact).HasColumnName("id_artifact");
            entity.Property(e => e.IdStat).HasColumnName("id_stat");

            entity.HasOne(d => d.IdCharacterNavigation).WithMany(p => p.RecommendedStats)
                .HasForeignKey(d => d.IdCharacter)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_rs_c");

            entity.HasOne(d => d.IdStatNavigation).WithMany(p => p.RecommendedStats)
                .HasForeignKey(d => d.IdStat)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_rs_s");
        });

        modelBuilder.Entity<SetArtifact>(entity =>
        {
            entity.HasKey(e => e.IdSet).HasName("PRIMARY");

            entity.ToTable("set_artifact");

            entity.HasIndex(e => e.FullStatBonus, "full_stat_bonus_UNIQUE")
                .IsUnique()
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 255 });

            entity.HasIndex(e => e.ImageSet, "image_set_UNIQUE")
                .IsUnique()
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 255 });

            entity.HasIndex(e => e.NameSet, "name_set_UNIQUE").IsUnique();

            entity.Property(e => e.IdSet).HasColumnName("id_set");
            entity.Property(e => e.Dungeon)
                .HasMaxLength(40)
                .HasColumnName("dungeon");
            entity.Property(e => e.FullStatBonus)
                .HasColumnType("text")
                .HasColumnName("full_stat_bonus");
            entity.Property(e => e.ImageSet)
                .HasColumnType("text")
                .HasColumnName("image_set");
            entity.Property(e => e.IncompleteStatBonus)
                .HasColumnType("text")
                .HasColumnName("incomplete_stat_bonus");
            entity.Property(e => e.NameSet)
                .HasMaxLength(40)
                .HasColumnName("name_set");
        });

        modelBuilder.Entity<Stat>(entity =>
        {
            entity.HasKey(e => e.IdStat).HasName("PRIMARY");

            entity.ToTable("stats");

            entity.HasIndex(e => e.IdStat, "id_stat_UNIQUE").IsUnique();

            entity.Property(e => e.IdStat).HasColumnName("id_stat");
            entity.Property(e => e.MaxNumber)
                .HasPrecision(6, 2)
                .HasColumnName("max_number");
            entity.Property(e => e.NameStat)
                .HasMaxLength(60)
                .HasColumnName("name_stat");
            entity.Property(e => e.StartNumber)
                .HasPrecision(6, 2)
                .HasColumnName("start_number");
            entity.Property(e => e.TypeStat)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("type_stat");
        });

        modelBuilder.Entity<Talent>(entity =>
        {
            entity.HasKey(e => e.IdTalent).HasName("PRIMARY");

            entity.ToTable("talent");

            entity.HasIndex(e => e.IdCharacter, "fk_t_c");

            entity.HasIndex(e => e.NameTalent, "name_talent_UNIQUE").IsUnique();

            entity.Property(e => e.IdTalent).HasColumnName("id_talent");
            entity.Property(e => e.CategoryTalent)
                .HasMaxLength(20)
                .HasColumnName("category_talent");
            entity.Property(e => e.DescriptionTalent)
                .HasColumnType("text")
                .HasColumnName("description_talent");
            entity.Property(e => e.IdCharacter).HasColumnName("id_character");
            entity.Property(e => e.NameTalent)
                .HasMaxLength(100)
                .HasColumnName("name_talent");
            entity.Property(e => e.PriorityImprovement).HasColumnName("priority_improvement");

            entity.HasOne(d => d.IdCharacterNavigation).WithMany(p => p.Talents)
                .HasForeignKey(d => d.IdCharacter)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_t_c");
        });

        modelBuilder.Entity<Weapon>(entity =>
        {
            entity.HasKey(e => e.IdWeapon).HasName("PRIMARY");

            entity.ToTable("weapon");

            entity.HasIndex(e => e.IdWeapon, "id_weapon_UNIQUE").IsUnique();

            entity.HasIndex(e => e.ImageWeapon, "image_weapon_UNIQUE")
                .IsUnique()
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 255 });

            entity.HasIndex(e => e.NameWeapon, "name_weapon_UNIQUE").IsUnique();

            entity.Property(e => e.IdWeapon).HasColumnName("id_weapon");
            entity.Property(e => e.AdditionalStat)
                .HasMaxLength(60)
                .HasColumnName("additional_stat");
            entity.Property(e => e.BasicAttack).HasColumnName("basic_attack");
            entity.Property(e => e.ImageWeapon)
                .HasColumnType("text")
                .HasColumnName("image_weapon");
            entity.Property(e => e.NameWeapon)
                .HasMaxLength(60)
                .HasColumnName("name_weapon");
            entity.Property(e => e.PassiveEffect)
                .HasColumnType("text")
                .HasColumnName("passive_effect");
            entity.Property(e => e.RarityWeapon).HasColumnName("rarity_weapon");
            entity.Property(e => e.TypeWeapon)
                .HasMaxLength(40)
                .HasColumnName("type_weapon");
        });
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
