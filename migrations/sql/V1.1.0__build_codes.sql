SET search_path TO "codes";

/* ---------------------------------------------------------------------- */
/* Script generated with: DeZign for Databases 12.3.1                     */
/* Target DBMS:           PostgreSQL 12                                   */
/* Project file:          TEI codes Phys_v15.dez                          */
/* Project name:                                                          */
/* Author:                                                                */
/* Script type:           Database creation script                        */
/* Created on:            2024-11-11 11:45                                */
/* ---------------------------------------------------------------------- */


/* ---------------------------------------------------------------------- */
/* Add tables                                                             */
/* ---------------------------------------------------------------------- */

/* ---------------------------------------------------------------------- */
/* Add table "RealmCode"                                                  */
/* ---------------------------------------------------------------------- */

CREATE TABLE RealmCode (
  realm_code VARCHAR(1)  NOT NULL,
  CONSTRAINT PK_RealmCode PRIMARY KEY (realm_code)
);

/* ---------------------------------------------------------------------- */
/* Add table "GroupCode"                                                  */
/* ---------------------------------------------------------------------- */

CREATE TABLE GroupCode (
  group_code VARCHAR(1)  NOT NULL,
  realm_code VARCHAR(1)  NOT NULL,
  CONSTRAINT PK_GroupCode PRIMARY KEY (group_code)
);

/* ---------------------------------------------------------------------- */
/* Add table "ClassCode"                                                  */
/* ---------------------------------------------------------------------- */

CREATE TABLE ClassCode (
  class_code VARCHAR(1)  NOT NULL,
  CONSTRAINT PK_ClassCode PRIMARY KEY (class_code)
);

/* ---------------------------------------------------------------------- */
/* Add table "SiteSeriesCode"                                             */
/* ---------------------------------------------------------------------- */

CREATE TABLE SiteSeriesCode (
  site_series_code VARCHAR(4)  NOT NULL,
  CONSTRAINT PK_SiteSeriesCode PRIMARY KEY (site_series_code)
);

/* ---------------------------------------------------------------------- */
/* Add table "SubClassCode"                                               */
/* ---------------------------------------------------------------------- */

CREATE TABLE SubClassCode (
  sub_class_code VARCHAR(1)  NOT NULL,
  CONSTRAINT PK_SubClassCode PRIMARY KEY (sub_class_code)
);

/* ---------------------------------------------------------------------- */
/* Add table "ZoneCode"                                                   */
/* ---------------------------------------------------------------------- */

CREATE TABLE ZoneCode (
  zone_code VARCHAR(4)  NOT NULL,
  CONSTRAINT PK_ZoneCode PRIMARY KEY (zone_code)
);

/* ---------------------------------------------------------------------- */
/* Add table "SSPhaseCode"                                                */
/* ---------------------------------------------------------------------- */

CREATE TABLE SSPhaseCode (
  ss_phase_code VARCHAR(1)  NOT NULL,
  CONSTRAINT PK_SSPhaseCode PRIMARY KEY (ss_phase_code)
);

/* ---------------------------------------------------------------------- */
/* Add table "SeralCode"                                                  */
/* ---------------------------------------------------------------------- */

CREATE TABLE SeralCode (
  seral_code VARCHAR(6)  NOT NULL,
  CONSTRAINT PK_SeralCode PRIMARY KEY (seral_code)
);

/* ---------------------------------------------------------------------- */
/* Add table "VariationCode"                                              */
/* ---------------------------------------------------------------------- */

CREATE TABLE VariationCode (
  variation_code VARCHAR(1)  NOT NULL,
  CONSTRAINT PK_VariationCode PRIMARY KEY (variation_code)
);

/* ---------------------------------------------------------------------- */
/* Add table "SubZoneCode"                                                */
/* ---------------------------------------------------------------------- */

CREATE TABLE SubZoneCode (
  sub_zone_code VARCHAR(3)  NOT NULL,
  CONSTRAINT PK_SubZoneCode PRIMARY KEY (sub_zone_code)
);

/* ---------------------------------------------------------------------- */
/* Add table "GroupCode_ClassCode"                                        */
/* ---------------------------------------------------------------------- */

CREATE TABLE GroupCode_ClassCode (
  group_code VARCHAR(1)  NOT NULL,
  class_code VARCHAR(1)  NOT NULL,
  CONSTRAINT PK_GroupCode_ClassCode PRIMARY KEY (group_code, class_code)
);

/* ---------------------------------------------------------------------- */
/* Add table "ClassCode_SubClassCode"                                     */
/* ---------------------------------------------------------------------- */

CREATE TABLE ClassCode_SubClassCode (
  class_code VARCHAR(1)  NOT NULL,
  sub_class_code VARCHAR(1)  NOT NULL,
  CONSTRAINT PK_ClassCode_SubClassCode PRIMARY KEY (class_code, sub_class_code)
);

/* ---------------------------------------------------------------------- */
/* Add table "VariantCode"                                                */
/* ---------------------------------------------------------------------- */

CREATE TABLE VariantCode (
  variant_code VARCHAR(1)  NOT NULL,
  CONSTRAINT PK_VariantCode PRIMARY KEY (variant_code)
);

/* ---------------------------------------------------------------------- */
/* Add table "PhaseCode"                                                  */
/* ---------------------------------------------------------------------- */

CREATE TABLE PhaseCode (
  phase_code VARCHAR(1)  NOT NULL,
  CONSTRAINT PK_PhaseCode PRIMARY KEY (phase_code)
);

/* ---------------------------------------------------------------------- */
/* Add table "MapCode"                                                    */
/* ---------------------------------------------------------------------- */

CREATE TABLE MapCode (
  map_code VARCHAR(2)  NOT NULL,
  CONSTRAINT PK_MapCode PRIMARY KEY (map_code)
);

/* ---------------------------------------------------------------------- */
/* Add table "ZoneCode_SubZoneCode"                                       */
/* ---------------------------------------------------------------------- */

CREATE TABLE ZoneCode_SubZoneCode (
  zone_code VARCHAR(4)  NOT NULL,
  sub_zone_code VARCHAR(3)  NOT NULL,
  CONSTRAINT PK_ZoneCode_SubZoneCode PRIMARY KEY (zone_code, sub_zone_code)
);

/* ---------------------------------------------------------------------- */
/* Add table "SubZoneCode_VariantCode"                                    */
/* ---------------------------------------------------------------------- */

CREATE TABLE SubZoneCode_VariantCode (
  sub_zone_code VARCHAR(3)  NOT NULL,
  variant_code VARCHAR(1)  NOT NULL,
  CONSTRAINT PK_SubZoneCode_VariantCode PRIMARY KEY (sub_zone_code, variant_code)
);

/* ---------------------------------------------------------------------- */
/* Add table "VariantCode_PhaseCode"                                      */
/* ---------------------------------------------------------------------- */

CREATE TABLE VariantCode_PhaseCode (
  variant_code VARCHAR(1)  NOT NULL,
  phase_code VARCHAR(1)  NOT NULL,
  CONSTRAINT PK_VariantCode_PhaseCode PRIMARY KEY (variant_code, phase_code)
);

/* ---------------------------------------------------------------------- */
/* Add table "AssociationCode"                                            */
/* ---------------------------------------------------------------------- */

CREATE TABLE AssociationCode (
  association_code VARCHAR(2)  NOT NULL,
  CONSTRAINT PK_AssociationCode PRIMARY KEY (association_code)
);

/* ---------------------------------------------------------------------- */
/* Add table "nBECCode"                                                   */
/* ---------------------------------------------------------------------- */

CREATE TABLE nBECCode (
  nbec_code VARCHAR(6)  NOT NULL,
  CONSTRAINT PK_nBECCode PRIMARY KEY (nbec_code)
);

/* ---------------------------------------------------------------------- */
/* Add table "EcoSystemType"                                              */
/* ---------------------------------------------------------------------- */

CREATE TABLE EcoSystemType (
  eco_system_type VARCHAR(2)  NOT NULL,
  detail VARCHAR(40)  NOT NULL,
  CONSTRAINT PK_EcoSystemType PRIMARY KEY (eco_system_type)
);

/* ---------------------------------------------------------------------- */
/* Add table "EcoSystemSubType"                                           */
/* ---------------------------------------------------------------------- */

CREATE TABLE EcoSystemSubType (
  eco_system_sub_type VARCHAR(2)  NOT NULL,
  detail VARCHAR(40)  NOT NULL,
  CONSTRAINT PK_EcoSystemSubType PRIMARY KEY (eco_system_sub_type)
);

/* ---------------------------------------------------------------------- */
/* Add table "KindType"                                                   */
/* ---------------------------------------------------------------------- */

CREATE TABLE KindType (
  kind_type VARCHAR(1)  NOT NULL,
  detail VARCHAR(40)  NOT NULL,
  CONSTRAINT PK_KindType PRIMARY KEY (kind_type)
);

/* ---------------------------------------------------------------------- */
/* Add table "SubZoneCode_PhaseCode"                                      */
/* ---------------------------------------------------------------------- */

CREATE TABLE SubZoneCode_PhaseCode (
  sub_zone_code VARCHAR(3)  NOT NULL,
  phase_code VARCHAR(1)  NOT NULL,
  CONSTRAINT PK_SubZoneCode_PhaseCode PRIMARY KEY (sub_zone_code, phase_code)
);

/* ---------------------------------------------------------------------- */
/* Add table "EcoCode"                                                    */
/* ---------------------------------------------------------------------- */

CREATE TABLE EcoCode (
  eco_code VARCHAR(10)  NOT NULL,
  map_code VARCHAR(2),
  site_series_code VARCHAR(4),
  ss_phase_code VARCHAR(1),
  seral_code VARCHAR(6),
  variation_code VARCHAR(1),
  CONSTRAINT PK_EcoCode PRIMARY KEY (eco_code)
);

/* ---------------------------------------------------------------------- */
/* Add table "BGCCode"                                                    */
/* ---------------------------------------------------------------------- */

CREATE TABLE BGCCode (
  bgc_code VARCHAR(10)  NOT NULL,
  zone_code VARCHAR(4)  NOT NULL,
  sub_zone_code VARCHAR(3)  NOT NULL,
  variant_code VARCHAR(1),
  phase_code VARCHAR(1),
  CONSTRAINT PK_BGCCode PRIMARY KEY (bgc_code)
);

/* ---------------------------------------------------------------------- */
/* Add table "SiteComponentCode"                                          */
/* ---------------------------------------------------------------------- */

CREATE TABLE SiteComponentCode (
  site_component_code VARCHAR(8)  NOT NULL,
  realm_code VARCHAR(1)  NOT NULL,
  group_code VARCHAR(1),
  class_code VARCHAR(1),
  association_code VARCHAR(2),
  sub_class_code VARCHAR(1),
  nbec_code VARCHAR(6),
  CONSTRAINT PK_SiteComponentCode PRIMARY KEY (site_component_code)
);

/* ---------------------------------------------------------------------- */
/* Add table "BGCEcoCode"                                                 */
/* ---------------------------------------------------------------------- */



CREATE TABLE BGCEcoCode (
  bgc_ecocode_id SERIAL  NOT NULL,
  bgc_code VARCHAR(10)  NOT NULL,
  eco_code VARCHAR(10)  NOT NULL,
  nbec_code VARCHAR(6),
  site_component_code VARCHAR(8),
  eco_system_type VARCHAR(2),
  eco_system_sub_type VARCHAR(2),
  kind_type VARCHAR(1),
  site_series_name VARCHAR(80),
  forested BOOLEAN  NOT NULL,
  source VARCHAR(40),
  date_added DATE,
  approved BOOLEAN DEFAULT TRUE  NOT NULL,
  CONSTRAINT PK_BGCEcoCode PRIMARY KEY (bgc_ecocode_id)
);



/* ---------------------------------------------------------------------- */
/* Add foreign key constraints                                            */
/* ---------------------------------------------------------------------- */

ALTER TABLE GroupCode ADD CONSTRAINT RealmCode_GroupCode
  FOREIGN KEY (realm_code) REFERENCES RealmCode (realm_code);

ALTER TABLE BGCCode ADD CONSTRAINT ZoneCode_BGCCode
  FOREIGN KEY (zone_code) REFERENCES ZoneCode (zone_code);

ALTER TABLE BGCCode ADD CONSTRAINT SubZoneCode_BGCCode
  FOREIGN KEY (sub_zone_code) REFERENCES SubZoneCode (sub_zone_code);

ALTER TABLE BGCCode ADD CONSTRAINT VariantCode_BGCCode
  FOREIGN KEY (variant_code) REFERENCES VariantCode (variant_code);

ALTER TABLE BGCCode ADD CONSTRAINT PhaseCode_BGCCode
  FOREIGN KEY (phase_code) REFERENCES PhaseCode (phase_code);

ALTER TABLE GroupCode_ClassCode ADD CONSTRAINT GroupCode_GroupCode_ClassCode
  FOREIGN KEY (group_code) REFERENCES GroupCode (group_code);

ALTER TABLE GroupCode_ClassCode ADD CONSTRAINT ClassCode_GroupCode_ClassCode
  FOREIGN KEY (class_code) REFERENCES ClassCode (class_code);

ALTER TABLE ClassCode_SubClassCode ADD CONSTRAINT ClassCode_ClassCode_SubClassCode
  FOREIGN KEY (class_code) REFERENCES ClassCode (class_code);

ALTER TABLE ClassCode_SubClassCode ADD CONSTRAINT SubClassCode_ClassCode_SubClassCode
  FOREIGN KEY (sub_class_code) REFERENCES SubClassCode (sub_class_code);

ALTER TABLE BGCEcoCode ADD CONSTRAINT BGCCode_BGCEcoCode
  FOREIGN KEY (bgc_code) REFERENCES BGCCode (bgc_code);

ALTER TABLE BGCEcoCode ADD CONSTRAINT EcoCode_BGCEcoCode
  FOREIGN KEY (eco_code) REFERENCES EcoCode (eco_code);

ALTER TABLE BGCEcoCode ADD CONSTRAINT SiteComponentCode_BGCEcoCode
  FOREIGN KEY (site_component_code) REFERENCES SiteComponentCode (site_component_code);

ALTER TABLE BGCEcoCode ADD CONSTRAINT nBECCode_BGCEcoCode
  FOREIGN KEY (nbec_code) REFERENCES nBECCode (nbec_code);

ALTER TABLE BGCEcoCode ADD CONSTRAINT EcoSystemType_BGCEcoCode
  FOREIGN KEY (eco_system_type) REFERENCES EcoSystemType (eco_system_type);

ALTER TABLE BGCEcoCode ADD CONSTRAINT EcoSystemSubType_BGCEcoCode
  FOREIGN KEY (eco_system_sub_type) REFERENCES EcoSystemSubType (eco_system_sub_type);

ALTER TABLE BGCEcoCode ADD CONSTRAINT KindType_BGCEcoCode
  FOREIGN KEY (kind_type) REFERENCES KindType (kind_type);

ALTER TABLE ZoneCode_SubZoneCode ADD CONSTRAINT ZoneCode_ZoneCode_SubZoneCode
  FOREIGN KEY (zone_code) REFERENCES ZoneCode (zone_code);

ALTER TABLE ZoneCode_SubZoneCode ADD CONSTRAINT SubZoneCode_ZoneCode_SubZoneCode
  FOREIGN KEY (sub_zone_code) REFERENCES SubZoneCode (sub_zone_code);

ALTER TABLE SubZoneCode_VariantCode ADD CONSTRAINT SubZoneCode_SubZoneCode_VariantCode
  FOREIGN KEY (sub_zone_code) REFERENCES SubZoneCode (sub_zone_code);

ALTER TABLE SubZoneCode_VariantCode ADD CONSTRAINT VariantCode_SubZoneCode_VariantCode
  FOREIGN KEY (variant_code) REFERENCES VariantCode (variant_code);

ALTER TABLE VariantCode_PhaseCode ADD CONSTRAINT VariantCode_VariantCode_PhaseCode
  FOREIGN KEY (variant_code) REFERENCES VariantCode (variant_code);

ALTER TABLE VariantCode_PhaseCode ADD CONSTRAINT PhaseCode_VariantCode_PhaseCode
  FOREIGN KEY (phase_code) REFERENCES PhaseCode (phase_code);

ALTER TABLE SiteComponentCode ADD CONSTRAINT RealmCode_SiteComponentCode
  FOREIGN KEY (realm_code) REFERENCES RealmCode (realm_code);

ALTER TABLE SiteComponentCode ADD CONSTRAINT GroupCode_SiteComponentCode
  FOREIGN KEY (group_code) REFERENCES GroupCode (group_code);

ALTER TABLE SiteComponentCode ADD CONSTRAINT ClassCode_SiteComponentCode
  FOREIGN KEY (class_code) REFERENCES ClassCode (class_code);

ALTER TABLE SiteComponentCode ADD CONSTRAINT SubClassCode_SiteComponentCode
  FOREIGN KEY (sub_class_code) REFERENCES SubClassCode (sub_class_code);

ALTER TABLE SiteComponentCode ADD CONSTRAINT AssociationCode_SiteComponentCode
  FOREIGN KEY (association_code) REFERENCES AssociationCode (association_code);

ALTER TABLE SiteComponentCode ADD CONSTRAINT nBECCode_SiteComponentCode
  FOREIGN KEY (nbec_code) REFERENCES nBECCode (nbec_code);

ALTER TABLE SubZoneCode_PhaseCode ADD CONSTRAINT SubZoneCode_SubZoneCode_PhaseCode
  FOREIGN KEY (sub_zone_code) REFERENCES SubZoneCode (sub_zone_code);

ALTER TABLE SubZoneCode_PhaseCode ADD CONSTRAINT PhaseCode_SubZoneCode_PhaseCode
  FOREIGN KEY (phase_code) REFERENCES PhaseCode (phase_code);

ALTER TABLE EcoCode ADD CONSTRAINT VariationCode_EcoCode
  FOREIGN KEY (variation_code) REFERENCES VariationCode (variation_code);

ALTER TABLE EcoCode ADD CONSTRAINT SeralCode_EcoCode
  FOREIGN KEY (seral_code) REFERENCES SeralCode (seral_code);

ALTER TABLE EcoCode ADD CONSTRAINT SSPhaseCode_EcoCode
  FOREIGN KEY (ss_phase_code) REFERENCES SSPhaseCode (ss_phase_code);

ALTER TABLE EcoCode ADD CONSTRAINT MapCode_EcoCode
  FOREIGN KEY (map_code) REFERENCES MapCode (map_code);

ALTER TABLE EcoCode ADD CONSTRAINT SiteSeriesCode_EcoCode
  FOREIGN KEY (site_series_code) REFERENCES SiteSeriesCode (site_series_code);