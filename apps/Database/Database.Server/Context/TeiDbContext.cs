namespace TEI.Database.Server.Context;

using Microsoft.EntityFrameworkCore;
using TEI.Database.Data.Entities;

public partial class TeiDbContext : DbContext
{
    public TeiDbContext(DbContextOptions<TeiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Associationcode> Associationcodes { get; set; }

    public virtual DbSet<Bgccode> Bgccodes { get; set; }

    public virtual DbSet<Bgcecocode> Bgcecocodes { get; set; }

    public virtual DbSet<Classcode> Classcodes { get; set; }

    public virtual DbSet<Ecocode> Ecocodes { get; set; }

    public virtual DbSet<Ecosystemsubtype> Ecosystemsubtypes { get; set; }

    public virtual DbSet<Ecosystemtype> Ecosystemtypes { get; set; }

    public virtual DbSet<Groupcode> Groupcodes { get; set; }

    public virtual DbSet<Kindtype> Kindtypes { get; set; }

    public virtual DbSet<Mapcode> Mapcodes { get; set; }

    public virtual DbSet<Nbeccode> Nbeccodes { get; set; }

    public virtual DbSet<Phasecode> Phasecodes { get; set; }

    public virtual DbSet<Realmcode> Realmcodes { get; set; }

    public virtual DbSet<Seralcode> Seralcodes { get; set; }

    public virtual DbSet<Sitecomponentcode> Sitecomponentcodes { get; set; }

    public virtual DbSet<Siteseriescode> Siteseriescodes { get; set; }

    public virtual DbSet<Ssphasecode> Ssphasecodes { get; set; }

    public virtual DbSet<Subclasscode> Subclasscodes { get; set; }

    public virtual DbSet<Subzonecode> Subzonecodes { get; set; }

    public virtual DbSet<Variantcode> Variantcodes { get; set; }

    public virtual DbSet<Variationcode> Variationcodes { get; set; }

    public virtual DbSet<Zonecode> Zonecodes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("en_US.UTF-8")
            .HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<Associationcode>(entity => { entity.HasKey(e => e.AssociationCode).HasName("pk_associationcode"); });

        modelBuilder.Entity<Bgccode>(
            entity =>
            {
                entity.HasKey(e => e.BgcCode).HasName("pk_bgccode");

                entity.HasOne(d => d.PhaseCodeNavigation).WithMany(p => p.Bgccodes).HasConstraintName("phasecode_bgccode");

                entity.HasOne(d => d.SubZoneCodeNavigation)
                    .WithMany(p => p.Bgccodes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("subzonecode_bgccode");

                entity.HasOne(d => d.VariantCodeNavigation).WithMany(p => p.Bgccodes).HasConstraintName("variantcode_bgccode");

                entity.HasOne(d => d.ZoneCodeNavigation)
                    .WithMany(p => p.Bgccodes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("zonecode_bgccode");
            });

        modelBuilder.Entity<Bgcecocode>(
            entity =>
            {
                entity.HasKey(e => e.BgcEcocodeId).HasName("pk_bgcecocode");

                entity.Property(e => e.Approved).HasDefaultValue(true);

                entity.HasOne(d => d.BgcCodeNavigation)
                    .WithMany(p => p.Bgcecocodes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("bgccode_bgcecocode");

                entity.HasOne(d => d.EcoCodeNavigation)
                    .WithMany(p => p.Bgcecocodes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ecocode_bgcecocode");

                entity.HasOne(d => d.EcoSystemSubTypeNavigation).WithMany(p => p.Bgcecocodes).HasConstraintName("ecosystemsubtype_bgcecocode");

                entity.HasOne(d => d.EcoSystemTypeNavigation).WithMany(p => p.Bgcecocodes).HasConstraintName("ecosystemtype_bgcecocode");

                entity.HasOne(d => d.KindTypeNavigation).WithMany(p => p.Bgcecocodes).HasConstraintName("kindtype_bgcecocode");

                entity.HasOne(d => d.NbecCodeNavigation).WithMany(p => p.Bgcecocodes).HasConstraintName("nbeccode_bgcecocode");

                entity.HasOne(d => d.SiteComponentCodeNavigation).WithMany(p => p.Bgcecocodes).HasConstraintName("sitecomponentcode_bgcecocode");
            });

        modelBuilder.Entity<Classcode>(
            entity =>
            {
                entity.HasKey(e => e.ClassCode).HasName("pk_classcode");

                entity.HasMany(d => d.SubClassCodes)
                    .WithMany(p => p.ClassCodes)
                    .UsingEntity<Dictionary<string, object>>(
                        "ClasscodeSubclasscode",
                        r => r.HasOne<Subclasscode>()
                            .WithMany()
                            .HasForeignKey("SubClassCode")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("subclasscode_classcode_subclasscode"),
                        l => l.HasOne<Classcode>()
                            .WithMany()
                            .HasForeignKey("ClassCode")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("classcode_classcode_subclasscode"),
                        j =>
                        {
                            j.HasKey("ClassCode", "SubClassCode").HasName("pk_classcode_subclasscode");
                            j.ToTable("classcode_subclasscode", "codes");
                            j.IndexerProperty<string>("ClassCode")
                                .HasMaxLength(1)
                                .HasColumnName("class_code");
                            j.IndexerProperty<string>("SubClassCode")
                                .HasMaxLength(1)
                                .HasColumnName("sub_class_code");
                        });
            });

        modelBuilder.Entity<Ecocode>(
            entity =>
            {
                entity.HasKey(e => e.EcoCode).HasName("pk_ecocode");

                entity.HasOne(d => d.MapCodeNavigation).WithMany(p => p.Ecocodes).HasConstraintName("mapcode_ecocode");

                entity.HasOne(d => d.SeralCodeNavigation).WithMany(p => p.Ecocodes).HasConstraintName("seralcode_ecocode");

                entity.HasOne(d => d.SiteSeriesCodeNavigation).WithMany(p => p.Ecocodes).HasConstraintName("siteseriescode_ecocode");

                entity.HasOne(d => d.SsPhaseCodeNavigation).WithMany(p => p.Ecocodes).HasConstraintName("ssphasecode_ecocode");

                entity.HasOne(d => d.VariationCodeNavigation).WithMany(p => p.Ecocodes).HasConstraintName("variationcode_ecocode");
            });

        modelBuilder.Entity<Ecosystemsubtype>(entity => { entity.HasKey(e => e.EcoSystemSubType).HasName("pk_ecosystemsubtype"); });

        modelBuilder.Entity<Ecosystemtype>(entity => { entity.HasKey(e => e.EcoSystemType).HasName("pk_ecosystemtype"); });

        modelBuilder.Entity<Groupcode>(
            entity =>
            {
                entity.HasKey(e => e.GroupCode).HasName("pk_groupcode");

                entity.HasOne(d => d.RealmCodeNavigation)
                    .WithMany(p => p.Groupcodes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("realmcode_groupcode");

                entity.HasMany(d => d.ClassCodes)
                    .WithMany(p => p.GroupCodes)
                    .UsingEntity<Dictionary<string, object>>(
                        "GroupcodeClasscode",
                        r => r.HasOne<Classcode>()
                            .WithMany()
                            .HasForeignKey("ClassCode")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("classcode_groupcode_classcode"),
                        l => l.HasOne<Groupcode>()
                            .WithMany()
                            .HasForeignKey("GroupCode")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("groupcode_groupcode_classcode"),
                        j =>
                        {
                            j.HasKey("GroupCode", "ClassCode").HasName("pk_groupcode_classcode");
                            j.ToTable("groupcode_classcode", "codes");
                            j.IndexerProperty<string>("GroupCode")
                                .HasMaxLength(1)
                                .HasColumnName("group_code");
                            j.IndexerProperty<string>("ClassCode")
                                .HasMaxLength(1)
                                .HasColumnName("class_code");
                        });
            });

        modelBuilder.Entity<Kindtype>(entity => { entity.HasKey(e => e.KindType).HasName("pk_kindtype"); });

        modelBuilder.Entity<Mapcode>(entity => { entity.HasKey(e => e.MapCode).HasName("pk_mapcode"); });

        modelBuilder.Entity<Nbeccode>(entity => { entity.HasKey(e => e.NbecCode).HasName("pk_nbeccode"); });

        modelBuilder.Entity<Phasecode>(entity => { entity.HasKey(e => e.PhaseCode).HasName("pk_phasecode"); });

        modelBuilder.Entity<Realmcode>(entity => { entity.HasKey(e => e.RealmCode).HasName("pk_realmcode"); });

        modelBuilder.Entity<Seralcode>(entity => { entity.HasKey(e => e.SeralCode).HasName("pk_seralcode"); });

        modelBuilder.Entity<Sitecomponentcode>(
            entity =>
            {
                entity.HasKey(e => e.SiteComponentCode).HasName("pk_sitecomponentcode");

                entity.HasOne(d => d.AssociationCodeNavigation).WithMany(p => p.Sitecomponentcodes).HasConstraintName("associationcode_sitecomponentcode");

                entity.HasOne(d => d.ClassCodeNavigation).WithMany(p => p.Sitecomponentcodes).HasConstraintName("classcode_sitecomponentcode");

                entity.HasOne(d => d.GroupCodeNavigation).WithMany(p => p.Sitecomponentcodes).HasConstraintName("groupcode_sitecomponentcode");

                entity.HasOne(d => d.NbecCodeNavigation).WithMany(p => p.Sitecomponentcodes).HasConstraintName("nbeccode_sitecomponentcode");

                entity.HasOne(d => d.RealmCodeNavigation)
                    .WithMany(p => p.Sitecomponentcodes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("realmcode_sitecomponentcode");

                entity.HasOne(d => d.SubClassCodeNavigation).WithMany(p => p.Sitecomponentcodes).HasConstraintName("subclasscode_sitecomponentcode");
            });

        modelBuilder.Entity<Siteseriescode>(entity => { entity.HasKey(e => e.SiteSeriesCode).HasName("pk_siteseriescode"); });

        modelBuilder.Entity<Ssphasecode>(entity => { entity.HasKey(e => e.SsPhaseCode).HasName("pk_ssphasecode"); });

        modelBuilder.Entity<Subclasscode>(entity => { entity.HasKey(e => e.SubClassCode).HasName("pk_subclasscode"); });

        modelBuilder.Entity<Subzonecode>(
            entity =>
            {
                entity.HasKey(e => e.SubZoneCode).HasName("pk_subzonecode");

                entity.HasMany(d => d.PhaseCodes)
                    .WithMany(p => p.SubZoneCodes)
                    .UsingEntity<Dictionary<string, object>>(
                        "SubzonecodePhasecode",
                        r => r.HasOne<Phasecode>()
                            .WithMany()
                            .HasForeignKey("PhaseCode")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("phasecode_subzonecode_phasecode"),
                        l => l.HasOne<Subzonecode>()
                            .WithMany()
                            .HasForeignKey("SubZoneCode")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("subzonecode_subzonecode_phasecode"),
                        j =>
                        {
                            j.HasKey("SubZoneCode", "PhaseCode").HasName("pk_subzonecode_phasecode");
                            j.ToTable("subzonecode_phasecode", "codes");
                            j.IndexerProperty<string>("SubZoneCode")
                                .HasMaxLength(3)
                                .HasColumnName("sub_zone_code");
                            j.IndexerProperty<string>("PhaseCode")
                                .HasMaxLength(1)
                                .HasColumnName("phase_code");
                        });

                entity.HasMany(d => d.VariantCodes)
                    .WithMany(p => p.SubZoneCodes)
                    .UsingEntity<Dictionary<string, object>>(
                        "SubzonecodeVariantcode",
                        r => r.HasOne<Variantcode>()
                            .WithMany()
                            .HasForeignKey("VariantCode")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("variantcode_subzonecode_variantcode"),
                        l => l.HasOne<Subzonecode>()
                            .WithMany()
                            .HasForeignKey("SubZoneCode")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("subzonecode_subzonecode_variantcode"),
                        j =>
                        {
                            j.HasKey("SubZoneCode", "VariantCode").HasName("pk_subzonecode_variantcode");
                            j.ToTable("subzonecode_variantcode", "codes");
                            j.IndexerProperty<string>("SubZoneCode")
                                .HasMaxLength(3)
                                .HasColumnName("sub_zone_code");
                            j.IndexerProperty<string>("VariantCode")
                                .HasMaxLength(1)
                                .HasColumnName("variant_code");
                        });
            });

        modelBuilder.Entity<Variantcode>(
            entity =>
            {
                entity.HasKey(e => e.VariantCode).HasName("pk_variantcode");

                entity.HasMany(d => d.PhaseCodes)
                    .WithMany(p => p.VariantCodes)
                    .UsingEntity<Dictionary<string, object>>(
                        "VariantcodePhasecode",
                        r => r.HasOne<Phasecode>()
                            .WithMany()
                            .HasForeignKey("PhaseCode")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("phasecode_variantcode_phasecode"),
                        l => l.HasOne<Variantcode>()
                            .WithMany()
                            .HasForeignKey("VariantCode")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("variantcode_variantcode_phasecode"),
                        j =>
                        {
                            j.HasKey("VariantCode", "PhaseCode").HasName("pk_variantcode_phasecode");
                            j.ToTable("variantcode_phasecode", "codes");
                            j.IndexerProperty<string>("VariantCode")
                                .HasMaxLength(1)
                                .HasColumnName("variant_code");
                            j.IndexerProperty<string>("PhaseCode")
                                .HasMaxLength(1)
                                .HasColumnName("phase_code");
                        });
            });

        modelBuilder.Entity<Variationcode>(entity => { entity.HasKey(e => e.VariationCode).HasName("pk_variationcode"); });

        modelBuilder.Entity<Zonecode>(
            entity =>
            {
                entity.HasKey(e => e.ZoneCode).HasName("pk_zonecode");

                entity.HasMany(d => d.SubZoneCodes)
                    .WithMany(p => p.ZoneCodes)
                    .UsingEntity<Dictionary<string, object>>(
                        "ZonecodeSubzonecode",
                        r => r.HasOne<Subzonecode>()
                            .WithMany()
                            .HasForeignKey("SubZoneCode")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("subzonecode_zonecode_subzonecode"),
                        l => l.HasOne<Zonecode>()
                            .WithMany()
                            .HasForeignKey("ZoneCode")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("zonecode_zonecode_subzonecode"),
                        j =>
                        {
                            j.HasKey("ZoneCode", "SubZoneCode").HasName("pk_zonecode_subzonecode");
                            j.ToTable("zonecode_subzonecode", "codes");
                            j.IndexerProperty<string>("ZoneCode")
                                .HasMaxLength(4)
                                .HasColumnName("zone_code");
                            j.IndexerProperty<string>("SubZoneCode")
                                .HasMaxLength(3)
                                .HasColumnName("sub_zone_code");
                        });
            });

        this.OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
