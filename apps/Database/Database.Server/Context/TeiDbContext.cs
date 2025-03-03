using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TEI.Database.Server.Context;

using TEI.Database.Data.Entities;

public partial class TeiDbContext : DbContext
{
    public TeiDbContext(DbContextOptions<TeiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alias> Aliases { get; set; }

    public virtual DbSet<Associationcode> Associationcodes { get; set; }

    public virtual DbSet<Bedrocktype> Bedrocktypes { get; set; }

    public virtual DbSet<Bgccode> Bgccodes { get; set; }

    public virtual DbSet<Bgcecocode> Bgcecocodes { get; set; }

    public virtual DbSet<Classcode> Classcodes { get; set; }

    public virtual DbSet<Cnwibc> Cnwibcs { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Commenttype> Commenttypes { get; set; }

    public virtual DbSet<Datagroup> Datagroups { get; set; }

    public virtual DbSet<Drainage> Drainages { get; set; }

    public virtual DbSet<Ecocode> Ecocodes { get; set; }

    public virtual DbSet<Ecocomponent> Ecocomponents { get; set; }

    public virtual DbSet<Ecoobject> Ecoobjects { get; set; }

    public virtual DbSet<Ecosystemsubtype> Ecosystemsubtypes { get; set; }

    public virtual DbSet<Ecosystemtype> Ecosystemtypes { get; set; }

    public virtual DbSet<Error> Errors { get; set; }

    public virtual DbSet<Expression> Expressions { get; set; }

    public virtual DbSet<Featurecode> Featurecodes { get; set; }

    public virtual DbSet<Flag> Flags { get; set; }

    public virtual DbSet<Geoline> Geolines { get; set; }

    public virtual DbSet<Geometry> Geometries { get; set; }

    public virtual DbSet<GeometryGeomorphicprocess> GeometryGeomorphicprocesses { get; set; }

    public virtual DbSet<Geometrytype> Geometrytypes { get; set; }

    public virtual DbSet<Geomorphicprocess> Geomorphicprocesses { get; set; }

    public virtual DbSet<Geopoint> Geopoints { get; set; }

    public virtual DbSet<Geopolygon> Geopolygons { get; set; }

    public virtual DbSet<Groupcode> Groupcodes { get; set; }

    public virtual DbSet<GroupcodeClasscode> GroupcodeClasscodes { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Interpretation> Interpretations { get; set; }

    public virtual DbSet<Interpretationtype> Interpretationtypes { get; set; }

    public virtual DbSet<Issue> Issues { get; set; }

    public virtual DbSet<Kindtype> Kindtypes { get; set; }

    public virtual DbSet<Layer> Layers { get; set; }

    public virtual DbSet<Layertype> Layertypes { get; set; }

    public virtual DbSet<Legacyproject> Legacyprojects { get; set; }

    public virtual DbSet<Mapcode> Mapcodes { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<Methodologycode> Methodologycodes { get; set; }

    public virtual DbSet<Nbeccode> Nbeccodes { get; set; }

    public virtual DbSet<Party> Parties { get; set; }

    public virtual DbSet<Partytype> Partytypes { get; set; }

    public virtual DbSet<Phasecode> Phasecodes { get; set; }

    public virtual DbSet<PointVeglayer> PointVeglayers { get; set; }

    public virtual DbSet<Pointtype> Pointtypes { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectParty> ProjectParties { get; set; }

    public virtual DbSet<Projectclass> Projectclasses { get; set; }

    public virtual DbSet<Projectrelation> Projectrelations { get; set; }

    public virtual DbSet<Projecttype> Projecttypes { get; set; }

    public virtual DbSet<Realmcode> Realmcodes { get; set; }

    public virtual DbSet<Relationdescription> Relationdescriptions { get; set; }

    public virtual DbSet<Scalecode> Scalecodes { get; set; }

    public virtual DbSet<Seralcode> Seralcodes { get; set; }

    public virtual DbSet<Sitecomponentcode> Sitecomponentcodes { get; set; }

    public virtual DbSet<Sitemodifiercode> Sitemodifiercodes { get; set; }

    public virtual DbSet<Siteseriescode> Siteseriescodes { get; set; }

    public virtual DbSet<Ssphasecode> Ssphasecodes { get; set; }

    public virtual DbSet<Statuscode> Statuscodes { get; set; }

    public virtual DbSet<Subclasscode> Subclasscodes { get; set; }

    public virtual DbSet<Subzonecode> Subzonecodes { get; set; }

    public virtual DbSet<Tercomponent> Tercomponents { get; set; }

    public virtual DbSet<Texture> Textures { get; set; }

    public virtual DbSet<Variantcode> Variantcodes { get; set; }

    public virtual DbSet<Variationcode> Variationcodes { get; set; }

    public virtual DbSet<Veglayercode> Veglayercodes { get; set; }

    public virtual DbSet<Vegspeciescode> Vegspeciescodes { get; set; }

    public virtual DbSet<Zonecode> Zonecodes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("en_US.UTF-8")
            .HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<Alias>(entity =>
        {
            entity.HasKey(e => e.AliasId).HasName("pk_alias");

            entity.ToTable("alias", "codes");

            entity.Property(e => e.AliasId).HasColumnName("alias_id");
            entity.Property(e => e.Active)
                .HasDefaultValue(true)
                .HasColumnName("active");
            entity.Property(e => e.AliasName).HasColumnName("alias_name");
            entity.Property(e => e.ProjectBapid).HasColumnName("project_bapid");

            entity.HasOne(d => d.ProjectBap).WithMany(p => p.Aliases)
                .HasForeignKey(d => d.ProjectBapid)
                .HasConstraintName("project_alias");
        });

        modelBuilder.Entity<Associationcode>(entity =>
        {
            entity.HasKey(e => e.AssociationCode).HasName("pk_associationcode");

            entity.ToTable("associationcode", "codes");

            entity.Property(e => e.AssociationCode)
                .HasMaxLength(2)
                .HasColumnName("association_code");
        });

        modelBuilder.Entity<Bedrocktype>(entity =>
        {
            entity.HasKey(e => e.BedrockType).HasName("pk_bedrocktype");

            entity.ToTable("bedrocktype", "codes");

            entity.Property(e => e.BedrockType)
                .HasMaxLength(4)
                .HasColumnName("bedrock_type");
        });

        modelBuilder.Entity<Bgccode>(entity =>
        {
            entity.HasKey(e => e.BgcCode).HasName("pk_bgccode");

            entity.ToTable("bgccode", "codes");

            entity.HasIndex(e => e.PhaseCode, "idx_bgccode_fk_phase_code");

            entity.HasIndex(e => e.SubZoneCode, "idx_bgccode_fk_sub_zone_code");

            entity.HasIndex(e => e.VariantCode, "idx_bgccode_fk_variant_code");

            entity.HasIndex(e => e.ZoneCode, "idx_bgccode_fk_zone_code");

            entity.Property(e => e.BgcCode)
                .HasMaxLength(10)
                .HasColumnName("bgc_code");
            entity.Property(e => e.Detail).HasColumnName("detail");
            entity.Property(e => e.PhaseCode)
                .HasMaxLength(1)
                .HasColumnName("phase_code");
            entity.Property(e => e.SubZoneCode)
                .HasMaxLength(3)
                .HasColumnName("sub_zone_code");
            entity.Property(e => e.VariantCode)
                .HasMaxLength(1)
                .HasColumnName("variant_code");
            entity.Property(e => e.ZoneCode)
                .HasMaxLength(4)
                .HasColumnName("zone_code");

            entity.HasOne(d => d.PhaseCodeNavigation).WithMany(p => p.Bgccodes)
                .HasForeignKey(d => d.PhaseCode)
                .HasConstraintName("phasecode_bgccode");

            entity.HasOne(d => d.SubZoneCodeNavigation).WithMany(p => p.Bgccodes)
                .HasForeignKey(d => d.SubZoneCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("subzonecode_bgccode");

            entity.HasOne(d => d.VariantCodeNavigation).WithMany(p => p.Bgccodes)
                .HasForeignKey(d => d.VariantCode)
                .HasConstraintName("variantcode_bgccode");

            entity.HasOne(d => d.ZoneCodeNavigation).WithMany(p => p.Bgccodes)
                .HasForeignKey(d => d.ZoneCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("zonecode_bgccode");
        });

        modelBuilder.Entity<Bgcecocode>(entity =>
        {
            entity.HasKey(e => e.BgcEcocodeId).HasName("pk_bgcecocode");

            entity.ToTable("bgcecocode", "codes");

            entity.HasIndex(e => e.BgcCode, "idx_bgcecocode_fk_bgc_code");

            entity.HasIndex(e => e.EcoCode, "idx_bgcecocode_fk_eco_code");

            entity.HasIndex(e => e.NbecCode, "idx_bgcecocode_fk_nbec_code");

            entity.HasIndex(e => e.SiteComponentCode, "idx_bgcecocode_fk_site_component_code");

            entity.HasIndex(e => e.SiteSeriesName, "idx_bgcecocode_site_series_name");

            entity.Property(e => e.BgcEcocodeId).HasColumnName("bgc_ecocode_id");
            entity.Property(e => e.Approved)
                .HasDefaultValue(true)
                .HasColumnName("approved");
            entity.Property(e => e.BgcCode)
                .HasMaxLength(10)
                .HasColumnName("bgc_code");
            entity.Property(e => e.DateAdded).HasColumnName("date_added");
            entity.Property(e => e.EcoCode)
                .HasMaxLength(10)
                .HasColumnName("eco_code");
            entity.Property(e => e.EcoSystemSubType)
                .HasMaxLength(2)
                .HasColumnName("eco_system_sub_type");
            entity.Property(e => e.EcoSystemType)
                .HasMaxLength(2)
                .HasColumnName("eco_system_type");
            entity.Property(e => e.Forested).HasColumnName("forested");
            entity.Property(e => e.KindType)
                .HasMaxLength(1)
                .HasColumnName("kind_type");
            entity.Property(e => e.NbecCode)
                .HasMaxLength(6)
                .HasColumnName("nbec_code");
            entity.Property(e => e.SiteComponentCode)
                .HasMaxLength(8)
                .HasColumnName("site_component_code");
            entity.Property(e => e.SiteSeriesName)
                .HasMaxLength(80)
                .HasColumnName("site_series_name");
            entity.Property(e => e.Source)
                .HasMaxLength(40)
                .HasColumnName("source");

            entity.HasOne(d => d.BgcCodeNavigation).WithMany(p => p.Bgcecocodes)
                .HasForeignKey(d => d.BgcCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("bgccode_bgcecocode");

            entity.HasOne(d => d.EcoCodeNavigation).WithMany(p => p.Bgcecocodes)
                .HasForeignKey(d => d.EcoCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ecocode_bgcecocode");

            entity.HasOne(d => d.EcoSystemSubTypeNavigation).WithMany(p => p.Bgcecocodes)
                .HasForeignKey(d => d.EcoSystemSubType)
                .HasConstraintName("ecosystemsubtype_bgcecocode");

            entity.HasOne(d => d.EcoSystemTypeNavigation).WithMany(p => p.Bgcecocodes)
                .HasForeignKey(d => d.EcoSystemType)
                .HasConstraintName("ecosystemtype_bgcecocode");

            entity.HasOne(d => d.KindTypeNavigation).WithMany(p => p.Bgcecocodes)
                .HasForeignKey(d => d.KindType)
                .HasConstraintName("kindtype_bgcecocode");

            entity.HasOne(d => d.NbecCodeNavigation).WithMany(p => p.Bgcecocodes)
                .HasForeignKey(d => d.NbecCode)
                .HasConstraintName("nbeccode_bgcecocode");

            entity.HasOne(d => d.SiteComponentCodeNavigation).WithMany(p => p.Bgcecocodes)
                .HasForeignKey(d => d.SiteComponentCode)
                .HasConstraintName("sitecomponentcode_bgcecocode");

            entity.HasMany(d => d.CnwiBcCodes).WithMany(p => p.BgcEcocodes)
                .UsingEntity<Dictionary<string, object>>(
                    "BgcecocodeCnwibc",
                    r => r.HasOne<Cnwibc>().WithMany()
                        .HasForeignKey("CnwiBcCode")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("cnwibc_bgcecocode_cnwibc"),
                    l => l.HasOne<Bgcecocode>().WithMany()
                        .HasForeignKey("BgcEcocodeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("bgcecocode_bgcecocode_cnwibc"),
                    j =>
                    {
                        j.HasKey("BgcEcocodeId", "CnwiBcCode").HasName("pk_bgcecocode_cnwibc");
                        j.ToTable("bgcecocode_cnwibc", "codes");
                        j.IndexerProperty<int>("BgcEcocodeId").HasColumnName("bgc_ecocode_id");
                        j.IndexerProperty<string>("CnwiBcCode")
                            .HasMaxLength(4)
                            .HasColumnName("cnwi_bc_code");
                    });
        });

        modelBuilder.Entity<Classcode>(entity =>
        {
            entity.HasKey(e => e.ClassCode).HasName("pk_classcode");

            entity.ToTable("classcode", "codes");

            entity.Property(e => e.ClassCode)
                .HasMaxLength(1)
                .HasColumnName("class_code");

            entity.HasMany(d => d.SubClassCodes).WithMany(p => p.ClassCodes)
                .UsingEntity<Dictionary<string, object>>(
                    "ClasscodeSubclasscode",
                    r => r.HasOne<Subclasscode>().WithMany()
                        .HasForeignKey("SubClassCode")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("subclasscode_classcode_subclasscode"),
                    l => l.HasOne<Classcode>().WithMany()
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

        modelBuilder.Entity<Cnwibc>(entity =>
        {
            entity.HasKey(e => e.CnwiBcCode).HasName("pk_cnwibc");

            entity.ToTable("cnwibc", "codes");

            entity.Property(e => e.CnwiBcCode)
                .HasMaxLength(4)
                .HasColumnName("cnwi_bc_code");
            entity.Property(e => e.CnwiCode)
                .HasMaxLength(40)
                .HasColumnName("cnwi_code");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("pk_comment");

            entity.ToTable("comment", "codes");

            entity.Property(e => e.CommentId).HasColumnName("comment_id");
            entity.Property(e => e.Comment1).HasColumnName("comment");
            entity.Property(e => e.CommentType)
                .HasMaxLength(4)
                .HasColumnName("comment_type");
            entity.Property(e => e.CreatedDt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_dt");
            entity.Property(e => e.ProjectBapid).HasColumnName("project_bapid");
            entity.Property(e => e.Url)
                .HasMaxLength(40)
                .HasColumnName("url");

            entity.HasOne(d => d.CommentTypeNavigation).WithMany(p => p.Comments)
                .HasForeignKey(d => d.CommentType)
                .HasConstraintName("commenttype_comment");

            entity.HasOne(d => d.ProjectBap).WithMany(p => p.Comments)
                .HasForeignKey(d => d.ProjectBapid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("project_comment");
        });

        modelBuilder.Entity<Commenttype>(entity =>
        {
            entity.HasKey(e => e.CommentType).HasName("pk_commenttype");

            entity.ToTable("commenttype", "codes");

            entity.Property(e => e.CommentType)
                .HasMaxLength(4)
                .HasColumnName("comment_type");
            entity.Property(e => e.Description)
                .HasMaxLength(40)
                .HasColumnName("description");
            entity.Property(e => e.Valid)
                .HasDefaultValue(true)
                .HasColumnName("valid");
        });

        modelBuilder.Entity<Datagroup>(entity =>
        {
            entity.HasKey(e => e.DataGroupId).HasName("pk_datagroup");

            entity.ToTable("datagroup", "codes");

            entity.HasIndex(e => e.ContractNumber, "idx_datagroup_fk_contract_number");

            entity.HasIndex(e => e.GroupName, "idx_datagroup_fk_group_name");

            entity.HasIndex(e => e.SrNumber, "idx_datagroup_fk_sr_number");

            entity.Property(e => e.DataGroupId).HasColumnName("data_group_id");
            entity.Property(e => e.Active)
                .HasDefaultValue(true)
                .HasColumnName("active");
            entity.Property(e => e.ContractNumber)
                .HasMaxLength(10)
                .HasColumnName("contract_number");
            entity.Property(e => e.ContractValue)
                .HasColumnType("money")
                .HasColumnName("contract_value");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedDt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_dt");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.GroupName).HasColumnName("group_name");
            entity.Property(e => e.SrNumber).HasColumnName("sr_number");

            entity.HasMany(d => d.ProjectBaps).WithMany(p => p.DataGroups)
                .UsingEntity<Dictionary<string, object>>(
                    "DatagroupProject",
                    r => r.HasOne<Project>().WithMany()
                        .HasForeignKey("ProjectBapid")
                        .HasConstraintName("project_datagroup_project"),
                    l => l.HasOne<Datagroup>().WithMany()
                        .HasForeignKey("DataGroupId")
                        .HasConstraintName("datagroup_datagroup_project"),
                    j =>
                    {
                        j.HasKey("DataGroupId", "ProjectBapid").HasName("pk_datagroup_project");
                        j.ToTable("datagroup_project", "codes");
                        j.IndexerProperty<int>("DataGroupId").HasColumnName("data_group_id");
                        j.IndexerProperty<int>("ProjectBapid").HasColumnName("project_bapid");
                    });
        });

        modelBuilder.Entity<Drainage>(entity =>
        {
            entity.HasKey(e => e.DrainageId).HasName("pk_drainage");

            entity.ToTable("drainage", "codes");

            entity.Property(e => e.DrainageId).HasColumnName("drainage_id");
        });

        modelBuilder.Entity<Ecocode>(entity =>
        {
            entity.HasKey(e => e.EcoCode).HasName("pk_ecocode");

            entity.ToTable("ecocode", "codes");

            entity.HasIndex(e => e.MapCode, "idx_ecocode_fk_map_code");

            entity.HasIndex(e => e.SeralCode, "idx_ecocode_fk_seral_code");

            entity.HasIndex(e => e.SiteSeriesCode, "idx_ecocode_fk_site_series_code");

            entity.HasIndex(e => e.SsPhaseCode, "idx_ecocode_fk_ss_phase_code");

            entity.HasIndex(e => e.VariationCode, "idx_ecocode_fk_variation_code");

            entity.Property(e => e.EcoCode)
                .HasMaxLength(10)
                .HasColumnName("eco_code");
            entity.Property(e => e.MapCode)
                .HasMaxLength(2)
                .HasColumnName("map_code");
            entity.Property(e => e.SeralCode)
                .HasMaxLength(6)
                .HasColumnName("seral_code");
            entity.Property(e => e.SiteSeriesCode)
                .HasMaxLength(4)
                .HasColumnName("site_series_code");
            entity.Property(e => e.SsPhaseCode)
                .HasMaxLength(1)
                .HasColumnName("ss_phase_code");
            entity.Property(e => e.VariationCode)
                .HasMaxLength(1)
                .HasColumnName("variation_code");

            entity.HasOne(d => d.MapCodeNavigation).WithMany(p => p.Ecocodes)
                .HasForeignKey(d => d.MapCode)
                .HasConstraintName("mapcode_ecocode");

            entity.HasOne(d => d.SeralCodeNavigation).WithMany(p => p.Ecocodes)
                .HasForeignKey(d => d.SeralCode)
                .HasConstraintName("seralcode_ecocode");

            entity.HasOne(d => d.SiteSeriesCodeNavigation).WithMany(p => p.Ecocodes)
                .HasForeignKey(d => d.SiteSeriesCode)
                .HasConstraintName("siteseriescode_ecocode");

            entity.HasOne(d => d.SsPhaseCodeNavigation).WithMany(p => p.Ecocodes)
                .HasForeignKey(d => d.SsPhaseCode)
                .HasConstraintName("ssphasecode_ecocode");

            entity.HasOne(d => d.VariationCodeNavigation).WithMany(p => p.Ecocodes)
                .HasForeignKey(d => d.VariationCode)
                .HasConstraintName("variationcode_ecocode");
        });

        modelBuilder.Entity<Ecocomponent>(entity =>
        {
            entity.HasKey(e => e.EcoComponentId).HasName("pk_ecocomponent");

            entity.ToTable("ecocomponent", "codes");

            entity.Property(e => e.EcoComponentId).HasColumnName("eco_component_id");
            entity.Property(e => e.BgcEcocodeId).HasColumnName("bgc_ecocode_id");
            entity.Property(e => e.Decile).HasColumnName("decile");
            entity.Property(e => e.Num).HasColumnName("num");
            entity.Property(e => e.PolygonId).HasColumnName("polygon_id");
            entity.Property(e => e.SiteModifierCode1)
                .HasMaxLength(40)
                .HasColumnName("site_modifier_code_1");
            entity.Property(e => e.SiteModifierCode2)
                .HasMaxLength(40)
                .HasColumnName("site_modifier_code_2");

            entity.HasOne(d => d.BgcEcocode).WithMany(p => p.Ecocomponents)
                .HasForeignKey(d => d.BgcEcocodeId)
                .HasConstraintName("bgcecocode_ecocomponent");

            entity.HasOne(d => d.Polygon).WithMany(p => p.Ecocomponents)
                .HasForeignKey(d => d.PolygonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("geopolygon_ecocomponent");

            entity.HasOne(d => d.SiteModifierCode1Navigation).WithMany(p => p.EcocomponentSiteModifierCode1Navigations)
                .HasForeignKey(d => d.SiteModifierCode1)
                .HasConstraintName("sitemodifiercode_ecocomponent_1");

            entity.HasOne(d => d.SiteModifierCode2Navigation).WithMany(p => p.EcocomponentSiteModifierCode2Navigations)
                .HasForeignKey(d => d.SiteModifierCode2)
                .HasConstraintName("sitemodifiercode_ecocomponent_2");
        });

        modelBuilder.Entity<Ecoobject>(entity =>
        {
            entity.HasKey(e => e.EcoObjectId).HasName("pk_ecoobject");

            entity.ToTable("ecoobject", "codes");

            entity.Property(e => e.EcoObjectId).HasColumnName("eco_object_id");
            entity.Property(e => e.BgcCode)
                .HasMaxLength(10)
                .HasColumnName("bgc_code");

            entity.HasOne(d => d.BgcCodeNavigation).WithMany(p => p.Ecoobjects)
                .HasForeignKey(d => d.BgcCode)
                .HasConstraintName("bgccode_ecoobject");
        });

        modelBuilder.Entity<Ecosystemsubtype>(entity =>
        {
            entity.HasKey(e => e.EcoSystemSubType).HasName("pk_ecosystemsubtype");

            entity.ToTable("ecosystemsubtype", "codes");

            entity.Property(e => e.EcoSystemSubType)
                .HasMaxLength(2)
                .HasColumnName("eco_system_sub_type");
            entity.Property(e => e.Detail).HasColumnName("detail");
        });

        modelBuilder.Entity<Ecosystemtype>(entity =>
        {
            entity.HasKey(e => e.EcoSystemType).HasName("pk_ecosystemtype");

            entity.ToTable("ecosystemtype", "codes");

            entity.Property(e => e.EcoSystemType)
                .HasMaxLength(2)
                .HasColumnName("eco_system_type");
            entity.Property(e => e.Detail).HasColumnName("detail");
        });

        modelBuilder.Entity<Error>(entity =>
        {
            entity.HasKey(e => e.ErrorId).HasName("pk_error");

            entity.ToTable("error", "codes");

            entity.Property(e => e.ErrorId).HasColumnName("error_id");
            entity.Property(e => e.GeometryId).HasColumnName("geometry_id");

            entity.HasOne(d => d.Geometry).WithMany(p => p.Errors)
                .HasForeignKey(d => d.GeometryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("geometry_error");
        });

        modelBuilder.Entity<Expression>(entity =>
        {
            entity.HasKey(e => e.ExpressionId).HasName("pk_expression");

            entity.ToTable("expression", "codes");

            entity.Property(e => e.ExpressionId).HasColumnName("expression_id");
        });

        modelBuilder.Entity<Featurecode>(entity =>
        {
            entity.HasKey(e => e.FeatureCode).HasName("pk_featurecode");

            entity.ToTable("featurecode", "codes");

            entity.Property(e => e.FeatureCode)
                .HasMaxLength(10)
                .HasColumnName("feature_code");
            entity.Property(e => e.Active)
                .HasDefaultValue(true)
                .HasColumnName("active");
            entity.Property(e => e.Attribute).HasColumnName("attribute");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Remark).HasColumnName("remark");
            entity.Property(e => e.ShortName)
                .HasMaxLength(40)
                .HasColumnName("short_name");
        });

        modelBuilder.Entity<Flag>(entity =>
        {
            entity.HasKey(e => e.FlagId).HasName("pk_flag");

            entity.ToTable("flag", "codes");

            entity.Property(e => e.FlagId)
                .HasMaxLength(4)
                .HasColumnName("flag_id");
        });

        modelBuilder.Entity<Geoline>(entity =>
        {
            entity.HasKey(e => e.GeoLineId).HasName("pk_geoline");

            entity.ToTable("geoline", "codes");

            entity.Property(e => e.GeoLineId).HasColumnName("geo_line_id");
            entity.Property(e => e.GeoLine).HasColumnName("geo_line");
        });

        modelBuilder.Entity<Geometry>(entity =>
        {
            entity.HasKey(e => e.GeometryId).HasName("pk_geometry");

            entity.ToTable("geometry", "codes");

            entity.Property(e => e.GeometryId).HasColumnName("geometry_id");
            entity.Property(e => e.CnwiBcCode)
                .HasMaxLength(4)
                .HasColumnName("cnwi_bc_code");
            entity.Property(e => e.DrainageId).HasColumnName("drainage_id");
            entity.Property(e => e.EcoObjectId).HasColumnName("eco_object_id");
            entity.Property(e => e.FeatureCode)
                .HasMaxLength(10)
                .HasColumnName("feature_code");
            entity.Property(e => e.FlagId)
                .HasMaxLength(4)
                .HasColumnName("flag_id");
            entity.Property(e => e.GeometryType)
                .HasMaxLength(4)
                .HasColumnName("geometry_type");
            entity.Property(e => e.InterpretationId).HasColumnName("interpretation_id");
            entity.Property(e => e.ScaleCode).HasColumnName("scale_code");

            entity.HasOne(d => d.CnwiBcCodeNavigation).WithMany(p => p.Geometries)
                .HasForeignKey(d => d.CnwiBcCode)
                .HasConstraintName("cnwibc_geometry");

            entity.HasOne(d => d.Drainage).WithMany(p => p.Geometries)
                .HasForeignKey(d => d.DrainageId)
                .HasConstraintName("drainage_geometry");

            entity.HasOne(d => d.EcoObject).WithMany(p => p.Geometries)
                .HasForeignKey(d => d.EcoObjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ecoobject_geometry");

            entity.HasOne(d => d.FeatureCodeNavigation).WithMany(p => p.Geometries)
                .HasForeignKey(d => d.FeatureCode)
                .HasConstraintName("featurecode_geometry");

            entity.HasOne(d => d.Flag).WithMany(p => p.Geometries)
                .HasForeignKey(d => d.FlagId)
                .HasConstraintName("flag_geometry");

            entity.HasOne(d => d.GeometryTypeNavigation).WithMany(p => p.Geometries)
                .HasForeignKey(d => d.GeometryType)
                .HasConstraintName("geometrytype_geometry");

            entity.HasOne(d => d.Interpretation).WithMany(p => p.Geometries)
                .HasForeignKey(d => d.InterpretationId)
                .HasConstraintName("interpretation_geometry");

            entity.HasOne(d => d.ScaleCodeNavigation).WithMany(p => p.Geometries)
                .HasForeignKey(d => d.ScaleCode)
                .HasConstraintName("scalecode_geometry");

            entity.HasMany(d => d.Images).WithMany(p => p.Geometries)
                .UsingEntity<Dictionary<string, object>>(
                    "GeometryImage",
                    r => r.HasOne<Image>().WithMany()
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("image_geometry_image"),
                    l => l.HasOne<Geometry>().WithMany()
                        .HasForeignKey("GeometryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("geometry_geometry_image"),
                    j =>
                    {
                        j.HasKey("GeometryId", "ImageId").HasName("pk_geometry_image");
                        j.ToTable("geometry_image", "codes");
                        j.IndexerProperty<int>("GeometryId").HasColumnName("geometry_id");
                        j.IndexerProperty<int>("ImageId").HasColumnName("image_id");
                    });

            entity.HasMany(d => d.MethodologyCodes).WithMany(p => p.Geometries)
                .UsingEntity<Dictionary<string, object>>(
                    "GeometryMethodology",
                    r => r.HasOne<Methodologycode>().WithMany()
                        .HasForeignKey("MethodologyCode")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("methodologycode_geometry_methodology"),
                    l => l.HasOne<Geometry>().WithMany()
                        .HasForeignKey("GeometryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("geometry_geometry_methodology"),
                    j =>
                    {
                        j.HasKey("GeometryId", "MethodologyCode").HasName("pk_geometry_methodology");
                        j.ToTable("geometry_methodology", "codes");
                        j.IndexerProperty<int>("GeometryId").HasColumnName("geometry_id");
                        j.IndexerProperty<string>("MethodologyCode")
                            .HasMaxLength(4)
                            .HasColumnName("methodology_code");
                    });
        });

        modelBuilder.Entity<GeometryGeomorphicprocess>(entity =>
        {
            entity.HasKey(e => new { e.GeometryId, e.GeoMorphicProcessId }).HasName("pk_geometry_geomorphicprocess");

            entity.ToTable("geometry_geomorphicprocess", "codes");

            entity.Property(e => e.GeometryId).HasColumnName("geometry_id");
            entity.Property(e => e.GeoMorphicProcessId).HasColumnName("geo_morphic_process_id");
            entity.Property(e => e.Active).HasColumnName("active");

            entity.HasOne(d => d.GeoMorphicProcess).WithMany(p => p.GeometryGeomorphicprocesses)
                .HasForeignKey(d => d.GeoMorphicProcessId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("geomorphicprocess_geometry_geomorphicprocess");

            entity.HasOne(d => d.Geometry).WithMany(p => p.GeometryGeomorphicprocesses)
                .HasForeignKey(d => d.GeometryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("geometry_geometry_geomorphicprocess");
        });

        modelBuilder.Entity<Geometrytype>(entity =>
        {
            entity.HasKey(e => e.GeometryType).HasName("pk_geometrytype");

            entity.ToTable("geometrytype", "codes");

            entity.Property(e => e.GeometryType)
                .HasMaxLength(4)
                .HasColumnName("geometry_type");
        });

        modelBuilder.Entity<Geomorphicprocess>(entity =>
        {
            entity.HasKey(e => e.GeoMorphicProcessId).HasName("pk_geomorphicprocess");

            entity.ToTable("geomorphicprocess", "codes");

            entity.Property(e => e.GeoMorphicProcessId).HasColumnName("geo_morphic_process_id");
            entity.Property(e => e.ActivityDefault).HasColumnName("activity_default");
        });

        modelBuilder.Entity<Geopoint>(entity =>
        {
            entity.HasKey(e => e.GeoPointId).HasName("pk_geopoint");

            entity.ToTable("geopoint", "codes");

            entity.Property(e => e.GeoPointId).HasColumnName("geo_point_id");
            entity.Property(e => e.BgcEcocodeId).HasColumnName("bgc_ecocode_id");
            entity.Property(e => e.GeoPoint).HasColumnName("geo_point");
            entity.Property(e => e.GeometryId).HasColumnName("geometry_id");
            entity.Property(e => e.PointType)
                .HasMaxLength(2)
                .HasColumnName("point_type");

            entity.HasOne(d => d.BgcEcocode).WithMany(p => p.Geopoints)
                .HasForeignKey(d => d.BgcEcocodeId)
                .HasConstraintName("bgcecocode_geopoint");

            entity.HasOne(d => d.Geometry).WithMany(p => p.Geopoints)
                .HasForeignKey(d => d.GeometryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("geometry_geopoint");

            entity.HasOne(d => d.PointTypeNavigation).WithMany(p => p.Geopoints)
                .HasForeignKey(d => d.PointType)
                .HasConstraintName("pointtype_geopoint");
        });

        modelBuilder.Entity<Geopolygon>(entity =>
        {
            entity.HasKey(e => e.GeoPolygonId).HasName("pk_geopolygon");

            entity.ToTable("geopolygon", "codes");

            entity.Property(e => e.GeoPolygonId).HasColumnName("geo_polygon_id");
            entity.Property(e => e.GeoPolygon).HasColumnName("geo_polygon");
            entity.Property(e => e.GeometryId).HasColumnName("geometry_id");

            entity.HasOne(d => d.Geometry).WithMany(p => p.Geopolygons)
                .HasForeignKey(d => d.GeometryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("geometry_geopolygon");

            entity.HasMany(d => d.Points).WithMany(p => p.Polygons)
                .UsingEntity<Dictionary<string, object>>(
                    "PolygonPoint",
                    r => r.HasOne<Geopoint>().WithMany()
                        .HasForeignKey("PointId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("geopoint_polygon_point"),
                    l => l.HasOne<Geopolygon>().WithMany()
                        .HasForeignKey("PolygonId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("geopolygon_polygon_point"),
                    j =>
                    {
                        j.HasKey("PolygonId", "PointId").HasName("pk_polygon_point");
                        j.ToTable("polygon_point", "codes");
                        j.IndexerProperty<int>("PolygonId").HasColumnName("polygon_id");
                        j.IndexerProperty<int>("PointId").HasColumnName("point_id");
                    });
        });

        modelBuilder.Entity<Groupcode>(entity =>
        {
            entity.HasKey(e => e.GroupCode).HasName("pk_groupcode");

            entity.ToTable("groupcode", "codes");

            entity.Property(e => e.GroupCode)
                .HasMaxLength(1)
                .HasColumnName("group_code");
            entity.Property(e => e.Detail).HasColumnName("detail");
            entity.Property(e => e.RealmCode)
                .HasMaxLength(1)
                .HasColumnName("realm_code");

            entity.HasOne(d => d.RealmCodeNavigation).WithMany(p => p.Groupcodes)
                .HasForeignKey(d => d.RealmCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("realmcode_groupcode");
        });

        modelBuilder.Entity<GroupcodeClasscode>(entity =>
        {
            entity.HasKey(e => new { e.GroupCode, e.ClassCode }).HasName("pk_groupcode_classcode");

            entity.ToTable("groupcode_classcode", "codes");

            entity.Property(e => e.GroupCode)
                .HasMaxLength(1)
                .HasColumnName("group_code");
            entity.Property(e => e.ClassCode)
                .HasMaxLength(1)
                .HasColumnName("class_code");
            entity.Property(e => e.Detail).HasColumnName("detail");

            entity.HasOne(d => d.ClassCodeNavigation).WithMany(p => p.GroupcodeClasscodes)
                .HasForeignKey(d => d.ClassCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("classcode_groupcode_classcode");

            entity.HasOne(d => d.GroupCodeNavigation).WithMany(p => p.GroupcodeClasscodes)
                .HasForeignKey(d => d.GroupCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("groupcode_groupcode_classcode");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("pk_image");

            entity.ToTable("image", "codes");

            entity.Property(e => e.ImageId).HasColumnName("image_id");
        });

        modelBuilder.Entity<Interpretation>(entity =>
        {
            entity.HasKey(e => e.InterpretationId).HasName("pk_interpretation");

            entity.ToTable("interpretation", "codes");

            entity.Property(e => e.InterpretationId).HasColumnName("interpretation_id");
            entity.Property(e => e.InterpretationType)
                .HasMaxLength(4)
                .HasColumnName("interpretation_type");

            entity.HasOne(d => d.InterpretationTypeNavigation).WithMany(p => p.Interpretations)
                .HasForeignKey(d => d.InterpretationType)
                .HasConstraintName("interpretationtype_interpretation");
        });

        modelBuilder.Entity<Interpretationtype>(entity =>
        {
            entity.HasKey(e => e.InterpretationType).HasName("pk_interpretationtype");

            entity.ToTable("interpretationtype", "codes");

            entity.Property(e => e.InterpretationType)
                .HasMaxLength(4)
                .HasColumnName("interpretation_type");
        });

        modelBuilder.Entity<Issue>(entity =>
        {
            entity.HasKey(e => e.IssueId).HasName("pk_issue");

            entity.ToTable("issue", "codes");

            entity.Property(e => e.IssueId).HasColumnName("issue_id");
            entity.Property(e => e.IssueDescription).HasColumnName("issue_description");
            entity.Property(e => e.ProjectBapid).HasColumnName("project_bapid");
            entity.Property(e => e.RecordedBy).HasColumnName("recorded_by");
            entity.Property(e => e.RecordedDt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("recorded_dt");
            entity.Property(e => e.ResolutionNotes).HasColumnName("resolution_notes");
            entity.Property(e => e.ResolvedBy).HasColumnName("resolved_by");
            entity.Property(e => e.ResolvedDt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("resolved_dt");

            entity.HasOne(d => d.ProjectBap).WithMany(p => p.Issues)
                .HasForeignKey(d => d.ProjectBapid)
                .HasConstraintName("project_issue");
        });

        modelBuilder.Entity<Kindtype>(entity =>
        {
            entity.HasKey(e => e.KindType).HasName("pk_kindtype");

            entity.ToTable("kindtype", "codes");

            entity.Property(e => e.KindType)
                .HasMaxLength(1)
                .HasColumnName("kind_type");
            entity.Property(e => e.Detail).HasColumnName("detail");
        });

        modelBuilder.Entity<Layer>(entity =>
        {
            entity.HasKey(e => e.LayerId).HasName("pk_layer");

            entity.ToTable("layer", "codes");

            entity.Property(e => e.LayerId).HasColumnName("layer_id");
            entity.Property(e => e.Expression1Id).HasColumnName("expression1_id");
            entity.Property(e => e.Expression2Id).HasColumnName("expression2_id");
            entity.Property(e => e.Expression3Id).HasColumnName("expression3_id");
            entity.Property(e => e.LayerType).HasColumnName("layer_type");
            entity.Property(e => e.MaterialId).HasColumnName("material_id");
            entity.Property(e => e.MaterialQualifier)
                .HasDefaultValue(false)
                .HasColumnName("material_qualifier");
            entity.Property(e => e.TerComponentId).HasColumnName("ter_component_id");
            entity.Property(e => e.Texture1Id).HasColumnName("texture1_id");
            entity.Property(e => e.Texture2Id).HasColumnName("texture2_id");
            entity.Property(e => e.Texture3Id).HasColumnName("texture3_id");

            entity.HasOne(d => d.Expression1).WithMany(p => p.LayerExpression1s)
                .HasForeignKey(d => d.Expression1Id)
                .HasConstraintName("expression_layer_1");

            entity.HasOne(d => d.Expression2).WithMany(p => p.LayerExpression2s)
                .HasForeignKey(d => d.Expression2Id)
                .HasConstraintName("expression_layer_2");

            entity.HasOne(d => d.Expression3).WithMany(p => p.LayerExpression3s)
                .HasForeignKey(d => d.Expression3Id)
                .HasConstraintName("expression_layer_3");

            entity.HasOne(d => d.LayerTypeNavigation).WithMany(p => p.Layers)
                .HasForeignKey(d => d.LayerType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("layertype_layer");

            entity.HasOne(d => d.Material).WithMany(p => p.Layers)
                .HasForeignKey(d => d.MaterialId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("material_layer");

            entity.HasOne(d => d.TerComponent).WithMany(p => p.Layers)
                .HasForeignKey(d => d.TerComponentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tercomponent_layer");

            entity.HasOne(d => d.Texture1).WithMany(p => p.LayerTexture1s)
                .HasForeignKey(d => d.Texture1Id)
                .HasConstraintName("texture_layer_1");

            entity.HasOne(d => d.Texture2).WithMany(p => p.LayerTexture2s)
                .HasForeignKey(d => d.Texture2Id)
                .HasConstraintName("texture_layer_2");

            entity.HasOne(d => d.Texture3).WithMany(p => p.LayerTexture3s)
                .HasForeignKey(d => d.Texture3Id)
                .HasConstraintName("texture_layer_3");
        });

        modelBuilder.Entity<Layertype>(entity =>
        {
            entity.HasKey(e => e.LayerType).HasName("pk_layertype");

            entity.ToTable("layertype", "codes");

            entity.Property(e => e.LayerType).HasColumnName("layer_type");
        });

        modelBuilder.Entity<Legacyproject>(entity =>
        {
            entity.HasKey(e => e.ProjectBapid).HasName("pk_legacyproject");

            entity.ToTable("legacyproject", "codes");

            entity.Property(e => e.ProjectBapid)
                .ValueGeneratedNever()
                .HasColumnName("project_bapid");
            entity.Property(e => e.AaComment)
                .HasMaxLength(40)
                .HasColumnName("aa_comment");
            entity.Property(e => e.AaLevel)
                .HasMaxLength(40)
                .HasColumnName("aa_level");
            entity.Property(e => e.Esil)
                .HasMaxLength(40)
                .HasColumnName("esil");
            entity.Property(e => e.MapshLst)
                .HasMaxLength(40)
                .HasColumnName("mapsh_lst");
            entity.Property(e => e.PackNbr)
                .HasMaxLength(40)
                .HasColumnName("pack_nbr");
            entity.Property(e => e.PhotoSc)
                .HasMaxLength(40)
                .HasColumnName("photo_sc");
            entity.Property(e => e.PhotoType)
                .HasMaxLength(40)
                .HasColumnName("photo_type");
            entity.Property(e => e.PhotoYr)
                .HasMaxLength(40)
                .HasColumnName("photo_yr");
            entity.Property(e => e.SlpUnit)
                .HasMaxLength(40)
                .HasColumnName("slp_unit");
            entity.Property(e => e.StbclsTp)
                .HasMaxLength(40)
                .HasColumnName("stbcls_tp");
            entity.Property(e => e.TerLegSc)
                .HasMaxLength(40)
                .HasColumnName("ter_leg_sc");
            entity.Property(e => e.TerLegTp)
                .HasMaxLength(40)
                .HasColumnName("ter_leg_tp");
            entity.Property(e => e.TrimNbr)
                .HasMaxLength(40)
                .HasColumnName("trim_nbr");
            entity.Property(e => e.TrsApprovalCondition)
                .HasMaxLength(40)
                .HasColumnName("trs_approval_condition");
            entity.Property(e => e.Tsil)
                .HasMaxLength(40)
                .HasColumnName("tsil");

            entity.HasOne(d => d.ProjectBap).WithOne(p => p.Legacyproject)
                .HasForeignKey<Legacyproject>(d => d.ProjectBapid)
                .HasConstraintName("project_legacyproject");
        });

        modelBuilder.Entity<Mapcode>(entity =>
        {
            entity.HasKey(e => e.MapCode).HasName("pk_mapcode");

            entity.ToTable("mapcode", "codes");

            entity.Property(e => e.MapCode)
                .HasMaxLength(2)
                .HasColumnName("map_code");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Detail).HasColumnName("detail");
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.MaterialId).HasName("pk_material");

            entity.ToTable("material", "codes");

            entity.Property(e => e.MaterialId).HasColumnName("material_id");
        });

        modelBuilder.Entity<Methodologycode>(entity =>
        {
            entity.HasKey(e => e.MethodologyCode).HasName("pk_methodologycode");

            entity.ToTable("methodologycode", "codes");

            entity.Property(e => e.MethodologyCode)
                .HasMaxLength(4)
                .HasColumnName("methodology_code");
        });

        modelBuilder.Entity<Nbeccode>(entity =>
        {
            entity.HasKey(e => e.NbecCode).HasName("pk_nbeccode");

            entity.ToTable("nbeccode", "codes");

            entity.Property(e => e.NbecCode)
                .HasMaxLength(6)
                .HasColumnName("nbec_code");
        });

        modelBuilder.Entity<Party>(entity =>
        {
            entity.HasKey(e => e.PartyId).HasName("pk_party");

            entity.ToTable("party", "codes");

            entity.Property(e => e.PartyId).HasColumnName("party_id");
            entity.Property(e => e.Active)
                .HasDefaultValue(true)
                .HasColumnName("active");
            entity.Property(e => e.CreatedDt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_dt");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.PartyName)
                .HasMaxLength(40)
                .HasColumnName("party_name");
            entity.Property(e => e.PartyType)
                .HasMaxLength(4)
                .HasColumnName("party_type");
            entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");

            entity.HasOne(d => d.PartyTypeNavigation).WithMany(p => p.Parties)
                .HasForeignKey(d => d.PartyType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("partytype_party");
        });

        modelBuilder.Entity<Partytype>(entity =>
        {
            entity.HasKey(e => e.PartyType).HasName("pk_partytype");

            entity.ToTable("partytype", "codes");

            entity.Property(e => e.PartyType)
                .HasMaxLength(4)
                .HasColumnName("party_type");
            entity.Property(e => e.Active)
                .HasDefaultValue(true)
                .HasColumnName("active");
            entity.Property(e => e.Description)
                .HasMaxLength(40)
                .HasColumnName("description");
        });

        modelBuilder.Entity<Phasecode>(entity =>
        {
            entity.HasKey(e => e.PhaseCode).HasName("pk_phasecode");

            entity.ToTable("phasecode", "codes");

            entity.Property(e => e.PhaseCode)
                .HasMaxLength(1)
                .HasColumnName("phase_code");
        });

        modelBuilder.Entity<PointVeglayer>(entity =>
        {
            entity.HasKey(e => new { e.PointId, e.VegLayerCode }).HasName("pk_point_veglayer");

            entity.ToTable("point_veglayer", "codes");

            entity.Property(e => e.PointId).HasColumnName("point_id");
            entity.Property(e => e.VegLayerCode)
                .HasMaxLength(4)
                .HasColumnName("veg_layer_code");

            entity.HasOne(d => d.Point).WithMany(p => p.PointVeglayers)
                .HasForeignKey(d => d.PointId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("geopoint_point_veglayer");

            entity.HasOne(d => d.VegLayerCodeNavigation).WithMany(p => p.PointVeglayers)
                .HasForeignKey(d => d.VegLayerCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("veglayercode_point_veglayer");

            entity.HasMany(d => d.VegSpeciesCodes).WithMany(p => p.PointVeglayers)
                .UsingEntity<Dictionary<string, object>>(
                    "PointVeglayerVegspecy",
                    r => r.HasOne<Vegspeciescode>().WithMany()
                        .HasForeignKey("VegSpeciesCode")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("vegspeciescode_point_veglayer_vegspecies"),
                    l => l.HasOne<PointVeglayer>().WithMany()
                        .HasForeignKey("PointId", "VegLayerCode")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("point_veglayer_point_veglayer_vegspecies"),
                    j =>
                    {
                        j.HasKey("PointId", "VegLayerCode", "VegSpeciesCode").HasName("pk_point_veglayer_vegspecies");
                        j.ToTable("point_veglayer_vegspecies", "codes");
                        j.IndexerProperty<int>("PointId").HasColumnName("point_id");
                        j.IndexerProperty<string>("VegLayerCode")
                            .HasMaxLength(4)
                            .HasColumnName("veg_layer_code");
                        j.IndexerProperty<string>("VegSpeciesCode")
                            .HasMaxLength(4)
                            .HasColumnName("veg_species_code");
                    });
        });

        modelBuilder.Entity<Pointtype>(entity =>
        {
            entity.HasKey(e => e.PointType).HasName("pk_pointtype");

            entity.ToTable("pointtype", "codes");

            entity.Property(e => e.PointType)
                .HasMaxLength(2)
                .HasColumnName("point_type");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.ProjectBapid).HasName("pk_project");

            entity.ToTable("project", "codes");

            entity.HasIndex(e => e.EndDate, "idx_project_end_date");

            entity.HasIndex(e => e.FeatureCode, "idx_project_fk_feature_code");

            entity.HasIndex(e => e.ProjectName, "idx_project_project_name");

            entity.HasIndex(e => e.StartDate, "idx_project_start_date");

            entity.Property(e => e.ProjectBapid)
                .ValueGeneratedNever()
                .HasColumnName("project_bapid");
            entity.Property(e => e.Active)
                .HasDefaultValue(true)
                .HasColumnName("active");
            entity.Property(e => e.BoundaryOnly)
                .HasDefaultValue(false)
                .HasColumnName("boundary_only");
            entity.Property(e => e.CreatedDt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_dt");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.EstimatedCost)
                .HasColumnType("money")
                .HasColumnName("estimated_cost");
            entity.Property(e => e.FeatureCode)
                .HasMaxLength(10)
                .HasColumnName("feature_code");
            entity.Property(e => e.LocationDescription).HasColumnName("location_description");
            entity.Property(e => e.ProjectCode)
                .HasMaxLength(8)
                .HasColumnName("project_code");
            entity.Property(e => e.ProjectName).HasColumnName("project_name");
            entity.Property(e => e.ProjectType)
                .HasMaxLength(8)
                .HasColumnName("project_type");
            entity.Property(e => e.SensitiveData)
                .HasDefaultValue(false)
                .HasColumnName("sensitive_data");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.StatusCode)
                .HasMaxLength(6)
                .HasColumnName("status_code");

            entity.HasOne(d => d.FeatureCodeNavigation).WithMany(p => p.Projects)
                .HasForeignKey(d => d.FeatureCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("featurecode_project");

            entity.HasOne(d => d.ProjectTypeNavigation).WithMany(p => p.Projects)
                .HasForeignKey(d => d.ProjectType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("projecttype_project");

            entity.HasOne(d => d.StatusCodeNavigation).WithMany(p => p.Projects)
                .HasForeignKey(d => d.StatusCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("statuscode_project");

            entity.HasMany(d => d.EcoObjects).WithMany(p => p.ProjectBaps)
                .UsingEntity<Dictionary<string, object>>(
                    "ProjectEcoobject",
                    r => r.HasOne<Ecoobject>().WithMany()
                        .HasForeignKey("EcoObjectId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("ecoobject_project_ecoobject"),
                    l => l.HasOne<Project>().WithMany()
                        .HasForeignKey("ProjectBapid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("project_project_ecoobject"),
                    j =>
                    {
                        j.HasKey("ProjectBapid", "EcoObjectId").HasName("pk_project_ecoobject");
                        j.ToTable("project_ecoobject", "codes");
                        j.IndexerProperty<int>("ProjectBapid").HasColumnName("project_bapid");
                        j.IndexerProperty<int>("EcoObjectId").HasColumnName("eco_object_id");
                    });
        });

        modelBuilder.Entity<ProjectParty>(entity =>
        {
            entity.HasKey(e => new { e.ProjectBapid, e.PartyId }).HasName("pk_project_party");

            entity.ToTable("project_party", "codes");

            entity.Property(e => e.ProjectBapid).HasColumnName("project_bapid");
            entity.Property(e => e.PartyId).HasColumnName("party_id");
            entity.Property(e => e.AssociateOrg)
                .HasDefaultValue(false)
                .HasColumnName("associate_org");
            entity.Property(e => e.Client)
                .HasDefaultValue(false)
                .HasColumnName("client");
            entity.Property(e => e.Contact)
                .HasDefaultValue(false)
                .HasColumnName("contact");
            entity.Property(e => e.DigCap)
                .HasDefaultValue(false)
                .HasColumnName("dig_cap");
            entity.Property(e => e.EcoMap)
                .HasDefaultValue(false)
                .HasColumnName("eco_map");
            entity.Property(e => e.FundingSrc)
                .HasDefaultValue(false)
                .HasColumnName("funding_src");
            entity.Property(e => e.GisSup)
                .HasDefaultValue(false)
                .HasColumnName("gis_sup");
            entity.Property(e => e.LeadProp)
                .HasDefaultValue(false)
                .HasColumnName("lead_prop");
            entity.Property(e => e.ProjSup)
                .HasDefaultValue(false)
                .HasColumnName("proj_sup");
            entity.Property(e => e.RecName)
                .HasDefaultValue(false)
                .HasColumnName("rec_name");
            entity.Property(e => e.SoilMap)
                .HasDefaultValue(false)
                .HasColumnName("soil_map");
            entity.Property(e => e.TerMap)
                .HasDefaultValue(false)
                .HasColumnName("ter_map");
            entity.Property(e => e.WildMap)
                .HasDefaultValue(false)
                .HasColumnName("wild_map");

            entity.HasOne(d => d.Party).WithMany(p => p.ProjectParties)
                .HasForeignKey(d => d.PartyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("party_project_party");

            entity.HasOne(d => d.ProjectBap).WithMany(p => p.ProjectParties)
                .HasForeignKey(d => d.ProjectBapid)
                .HasConstraintName("project_project_party");
        });

        modelBuilder.Entity<Projectclass>(entity =>
        {
            entity.HasKey(e => e.ProjectClass).HasName("pk_projectclass");

            entity.ToTable("projectclass", "codes");

            entity.Property(e => e.ProjectClass)
                .HasMaxLength(2)
                .HasColumnName("project_class");
            entity.Property(e => e.Active)
                .HasDefaultValue(true)
                .HasColumnName("active");
            entity.Property(e => e.Description)
                .HasMaxLength(40)
                .HasColumnName("description");
        });

        modelBuilder.Entity<Projectrelation>(entity =>
        {
            entity.HasKey(e => new { e.ProjectBapid1, e.ProjectBapid2 }).HasName("pk_projectrelation");

            entity.ToTable("projectrelation", "codes");

            entity.Property(e => e.ProjectBapid1).HasColumnName("project_bapid1");
            entity.Property(e => e.ProjectBapid2).HasColumnName("project_bapid2");
            entity.Property(e => e.RelationDescriptionId).HasColumnName("relation_description_id");

            entity.HasOne(d => d.ProjectBapid1Navigation).WithMany(p => p.ProjectrelationProjectBapid1Navigations)
                .HasForeignKey(d => d.ProjectBapid1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("project_projectrelation1");

            entity.HasOne(d => d.ProjectBapid2Navigation).WithMany(p => p.ProjectrelationProjectBapid2Navigations)
                .HasForeignKey(d => d.ProjectBapid2)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("project_projectrelation2");

            entity.HasOne(d => d.RelationDescription).WithMany(p => p.Projectrelations)
                .HasForeignKey(d => d.RelationDescriptionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("relationdescription_projectrelation");
        });

        modelBuilder.Entity<Projecttype>(entity =>
        {
            entity.HasKey(e => e.ProjectType).HasName("pk_projecttype");

            entity.ToTable("projecttype", "codes");

            entity.Property(e => e.ProjectType)
                .HasMaxLength(8)
                .HasColumnName("project_type");
            entity.Property(e => e.Active)
                .HasDefaultValue(true)
                .HasColumnName("active");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.PrimaryType)
                .HasMaxLength(8)
                .HasColumnName("primary_type");
            entity.Property(e => e.ProjectClass)
                .HasMaxLength(2)
                .HasColumnName("project_class");
            entity.Property(e => e.ShortName).HasColumnName("short_name");
            entity.Property(e => e.SubType)
                .HasMaxLength(6)
                .HasColumnName("sub_type");

            entity.HasOne(d => d.ProjectClassNavigation).WithMany(p => p.Projecttypes)
                .HasForeignKey(d => d.ProjectClass)
                .HasConstraintName("projectclass_projecttype");
        });

        modelBuilder.Entity<Realmcode>(entity =>
        {
            entity.HasKey(e => e.RealmCode).HasName("pk_realmcode");

            entity.ToTable("realmcode", "codes");

            entity.Property(e => e.RealmCode)
                .HasMaxLength(1)
                .HasColumnName("realm_code");
            entity.Property(e => e.Detail).HasColumnName("detail");
        });

        modelBuilder.Entity<Relationdescription>(entity =>
        {
            entity.HasKey(e => e.RelationDescriptionId).HasName("pk_relationdescription");

            entity.ToTable("relationdescription", "codes");

            entity.Property(e => e.RelationDescriptionId).HasColumnName("relation_description_id");
            entity.Property(e => e.Description).HasColumnName("description");
        });

        modelBuilder.Entity<Scalecode>(entity =>
        {
            entity.HasKey(e => e.ScaleCode).HasName("pk_scalecode");

            entity.ToTable("scalecode", "codes");

            entity.Property(e => e.ScaleCode)
                .ValueGeneratedNever()
                .HasColumnName("scale_code");
            entity.Property(e => e.Active)
                .HasDefaultValue(true)
                .HasColumnName("active");
            entity.Property(e => e.Description).HasColumnName("description");
        });

        modelBuilder.Entity<Seralcode>(entity =>
        {
            entity.HasKey(e => e.SeralCode).HasName("pk_seralcode");

            entity.ToTable("seralcode", "codes");

            entity.Property(e => e.SeralCode)
                .HasMaxLength(6)
                .HasColumnName("seral_code");
        });

        modelBuilder.Entity<Sitecomponentcode>(entity =>
        {
            entity.HasKey(e => e.SiteComponentCode).HasName("pk_sitecomponentcode");

            entity.ToTable("sitecomponentcode", "codes");

            entity.HasIndex(e => e.AssociationCode, "idx_sitecomponentcode_fk_association_code");

            entity.HasIndex(e => e.ClassCode, "idx_sitecomponentcode_fk_class_code");

            entity.HasIndex(e => e.GroupCode, "idx_sitecomponentcode_fk_group_code");

            entity.HasIndex(e => e.NbecCode, "idx_sitecomponentcode_fk_nbec_code");

            entity.HasIndex(e => e.RealmCode, "idx_sitecomponentcode_fk_realm_code");

            entity.HasIndex(e => e.SubClassCode, "idx_sitecomponentcode_fk_sub_class_code");

            entity.Property(e => e.SiteComponentCode)
                .HasMaxLength(8)
                .HasColumnName("site_component_code");
            entity.Property(e => e.AssociationCode)
                .HasMaxLength(2)
                .HasColumnName("association_code");
            entity.Property(e => e.ClassCode)
                .HasMaxLength(1)
                .HasColumnName("class_code");
            entity.Property(e => e.GroupCode)
                .HasMaxLength(1)
                .HasColumnName("group_code");
            entity.Property(e => e.NbecCode)
                .HasMaxLength(6)
                .HasColumnName("nbec_code");
            entity.Property(e => e.RealmCode)
                .HasMaxLength(1)
                .HasColumnName("realm_code");
            entity.Property(e => e.SubClassCode)
                .HasMaxLength(1)
                .HasColumnName("sub_class_code");

            entity.HasOne(d => d.AssociationCodeNavigation).WithMany(p => p.Sitecomponentcodes)
                .HasForeignKey(d => d.AssociationCode)
                .HasConstraintName("associationcode_sitecomponentcode");

            entity.HasOne(d => d.ClassCodeNavigation).WithMany(p => p.Sitecomponentcodes)
                .HasForeignKey(d => d.ClassCode)
                .HasConstraintName("classcode_sitecomponentcode");

            entity.HasOne(d => d.GroupCodeNavigation).WithMany(p => p.Sitecomponentcodes)
                .HasForeignKey(d => d.GroupCode)
                .HasConstraintName("groupcode_sitecomponentcode");

            entity.HasOne(d => d.NbecCodeNavigation).WithMany(p => p.Sitecomponentcodes)
                .HasForeignKey(d => d.NbecCode)
                .HasConstraintName("nbeccode_sitecomponentcode");

            entity.HasOne(d => d.RealmCodeNavigation).WithMany(p => p.Sitecomponentcodes)
                .HasForeignKey(d => d.RealmCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("realmcode_sitecomponentcode");

            entity.HasOne(d => d.SubClassCodeNavigation).WithMany(p => p.Sitecomponentcodes)
                .HasForeignKey(d => d.SubClassCode)
                .HasConstraintName("subclasscode_sitecomponentcode");
        });

        modelBuilder.Entity<Sitemodifiercode>(entity =>
        {
            entity.HasKey(e => e.SiteModifierCode).HasName("pk_sitemodifiercode");

            entity.ToTable("sitemodifiercode", "codes");

            entity.Property(e => e.SiteModifierCode)
                .HasMaxLength(40)
                .HasColumnName("site_modifier_code");
        });

        modelBuilder.Entity<Siteseriescode>(entity =>
        {
            entity.HasKey(e => e.SiteSeriesCode).HasName("pk_siteseriescode");

            entity.ToTable("siteseriescode", "codes");

            entity.Property(e => e.SiteSeriesCode)
                .HasMaxLength(4)
                .HasColumnName("site_series_code");
        });

        modelBuilder.Entity<Ssphasecode>(entity =>
        {
            entity.HasKey(e => e.SsPhaseCode).HasName("pk_ssphasecode");

            entity.ToTable("ssphasecode", "codes");

            entity.Property(e => e.SsPhaseCode)
                .HasMaxLength(1)
                .HasColumnName("ss_phase_code");
        });

        modelBuilder.Entity<Statuscode>(entity =>
        {
            entity.HasKey(e => e.StatusCode).HasName("pk_statuscode");

            entity.ToTable("statuscode", "codes");

            entity.Property(e => e.StatusCode)
                .HasMaxLength(6)
                .HasColumnName("status_code");
            entity.Property(e => e.Active)
                .HasDefaultValue(true)
                .HasColumnName("active");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.Description).HasColumnName("description");
        });

        modelBuilder.Entity<Subclasscode>(entity =>
        {
            entity.HasKey(e => e.SubClassCode).HasName("pk_subclasscode");

            entity.ToTable("subclasscode", "codes");

            entity.Property(e => e.SubClassCode)
                .HasMaxLength(1)
                .HasColumnName("sub_class_code");
        });

        modelBuilder.Entity<Subzonecode>(entity =>
        {
            entity.HasKey(e => e.SubZoneCode).HasName("pk_subzonecode");

            entity.ToTable("subzonecode", "codes");

            entity.Property(e => e.SubZoneCode)
                .HasMaxLength(3)
                .HasColumnName("sub_zone_code");

            entity.HasMany(d => d.PhaseCodes).WithMany(p => p.SubZoneCodes)
                .UsingEntity<Dictionary<string, object>>(
                    "SubzonecodePhasecode",
                    r => r.HasOne<Phasecode>().WithMany()
                        .HasForeignKey("PhaseCode")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("phasecode_subzonecode_phasecode"),
                    l => l.HasOne<Subzonecode>().WithMany()
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

            entity.HasMany(d => d.VariantCodes).WithMany(p => p.SubZoneCodes)
                .UsingEntity<Dictionary<string, object>>(
                    "SubzonecodeVariantcode",
                    r => r.HasOne<Variantcode>().WithMany()
                        .HasForeignKey("VariantCode")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("variantcode_subzonecode_variantcode"),
                    l => l.HasOne<Subzonecode>().WithMany()
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

        modelBuilder.Entity<Tercomponent>(entity =>
        {
            entity.HasKey(e => e.TerComponentId).HasName("pk_tercomponent");

            entity.ToTable("tercomponent", "codes");

            entity.Property(e => e.TerComponentId).HasColumnName("ter_component_id");
            entity.Property(e => e.BedrockType)
                .HasMaxLength(4)
                .HasColumnName("bedrock_type");
            entity.Property(e => e.Decile).HasColumnName("decile");
            entity.Property(e => e.DrainageId).HasColumnName("drainage_id");
            entity.Property(e => e.IceCovered).HasColumnName("ice_covered");
            entity.Property(e => e.InterpretationId).HasColumnName("interpretation_id");
            entity.Property(e => e.NotMapped).HasColumnName("not_mapped");
            entity.Property(e => e.PolygonId).HasColumnName("polygon_id");

            entity.HasOne(d => d.BedrockTypeNavigation).WithMany(p => p.Tercomponents)
                .HasForeignKey(d => d.BedrockType)
                .HasConstraintName("bedrocktype_tercomponent");

            entity.HasOne(d => d.Drainage).WithMany(p => p.Tercomponents)
                .HasForeignKey(d => d.DrainageId)
                .HasConstraintName("drainage_tercomponent");

            entity.HasOne(d => d.Interpretation).WithMany(p => p.Tercomponents)
                .HasForeignKey(d => d.InterpretationId)
                .HasConstraintName("interpretation_tercomponent");

            entity.HasOne(d => d.Polygon).WithMany(p => p.Tercomponents)
                .HasForeignKey(d => d.PolygonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("geopolygon_tercomponent");
        });

        modelBuilder.Entity<Texture>(entity =>
        {
            entity.HasKey(e => e.TextureId).HasName("pk_texture");

            entity.ToTable("texture", "codes");

            entity.Property(e => e.TextureId).HasColumnName("texture_id");
        });

        modelBuilder.Entity<Variantcode>(entity =>
        {
            entity.HasKey(e => e.VariantCode).HasName("pk_variantcode");

            entity.ToTable("variantcode", "codes");

            entity.Property(e => e.VariantCode)
                .HasMaxLength(1)
                .HasColumnName("variant_code");

            entity.HasMany(d => d.PhaseCodes).WithMany(p => p.VariantCodes)
                .UsingEntity<Dictionary<string, object>>(
                    "VariantcodePhasecode",
                    r => r.HasOne<Phasecode>().WithMany()
                        .HasForeignKey("PhaseCode")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("phasecode_variantcode_phasecode"),
                    l => l.HasOne<Variantcode>().WithMany()
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

        modelBuilder.Entity<Variationcode>(entity =>
        {
            entity.HasKey(e => e.VariationCode).HasName("pk_variationcode");

            entity.ToTable("variationcode", "codes");

            entity.Property(e => e.VariationCode)
                .HasMaxLength(1)
                .HasColumnName("variation_code");
        });

        modelBuilder.Entity<Veglayercode>(entity =>
        {
            entity.HasKey(e => e.VegLayerCode).HasName("pk_veglayercode");

            entity.ToTable("veglayercode", "codes");

            entity.Property(e => e.VegLayerCode)
                .HasMaxLength(4)
                .HasColumnName("veg_layer_code");
        });

        modelBuilder.Entity<Vegspeciescode>(entity =>
        {
            entity.HasKey(e => e.VegSpeciesCode).HasName("pk_vegspeciescode");

            entity.ToTable("vegspeciescode", "codes");

            entity.Property(e => e.VegSpeciesCode)
                .HasMaxLength(4)
                .HasColumnName("veg_species_code");

            entity.HasMany(d => d.VegLayerCodes).WithMany(p => p.VegSpeciesCodes)
                .UsingEntity<Dictionary<string, object>>(
                    "VegspeciesVeglayer",
                    r => r.HasOne<Veglayercode>().WithMany()
                        .HasForeignKey("VegLayerCode")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("veglayercode_vegspecies_veglayer"),
                    l => l.HasOne<Vegspeciescode>().WithMany()
                        .HasForeignKey("VegSpeciesCode")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("vegspeciescode_vegspecies_veglayer"),
                    j =>
                    {
                        j.HasKey("VegSpeciesCode", "VegLayerCode").HasName("pk_vegspecies_veglayer");
                        j.ToTable("vegspecies_veglayer", "codes");
                        j.IndexerProperty<string>("VegSpeciesCode")
                            .HasMaxLength(4)
                            .HasColumnName("veg_species_code");
                        j.IndexerProperty<string>("VegLayerCode")
                            .HasMaxLength(4)
                            .HasColumnName("veg_layer_code");
                    });
        });

        modelBuilder.Entity<Zonecode>(entity =>
        {
            entity.HasKey(e => e.ZoneCode).HasName("pk_zonecode");

            entity.ToTable("zonecode", "codes");

            entity.Property(e => e.ZoneCode)
                .HasMaxLength(4)
                .HasColumnName("zone_code");
            entity.Property(e => e.Detail).HasColumnName("detail");

            entity.HasMany(d => d.SubZoneCodes).WithMany(p => p.ZoneCodes)
                .UsingEntity<Dictionary<string, object>>(
                    "ZonecodeSubzonecode",
                    r => r.HasOne<Subzonecode>().WithMany()
                        .HasForeignKey("SubZoneCode")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("subzonecode_zonecode_subzonecode"),
                    l => l.HasOne<Zonecode>().WithMany()
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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
