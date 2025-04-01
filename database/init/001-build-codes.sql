SET search_path TO "codes";

/* ---------------------------------------------------------------------- */
/* Add tables                                                             */
/* ---------------------------------------------------------------------- */

/* ---------------------------------------------------------------------- */
/* Add table "RealmCode"                                                  */
/* ---------------------------------------------------------------------- */

CREATE TABLE RealmCode (
  realm_code VARCHAR(1)  NOT NULL,
  detail TEXT  NOT NULL,
  CONSTRAINT PK_RealmCode PRIMARY KEY (realm_code)
);

/* ---------------------------------------------------------------------- */
/* Add table "GroupCode"                                                  */
/* ---------------------------------------------------------------------- */

CREATE TABLE GroupCode (
  group_code VARCHAR(1)  NOT NULL,
  realm_code VARCHAR(1)  NOT NULL,
  detail TEXT  NOT NULL,
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
  detail TEXT  NOT NULL,
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
  detail TEXT  NOT NULL,
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
  detail TEXT  NOT NULL,
  description TEXT  NOT NULL,
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

CREATE INDEX IDX_EcoCode_FK_map_code ON EcoCode (map_code);

CREATE INDEX IDX_EcoCode_FK_site_series_code ON EcoCode (site_series_code);

CREATE INDEX IDX_EcoCode_FK_ss_phase_code ON EcoCode (ss_phase_code);

CREATE INDEX IDX_EcoCode_FK_seral_code ON EcoCode (seral_code);

CREATE INDEX IDX_EcoCode_FK_variation_code ON EcoCode (variation_code);

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
  detail TEXT  NOT NULL,
  CONSTRAINT PK_EcoSystemType PRIMARY KEY (eco_system_type)
);

/* ---------------------------------------------------------------------- */
/* Add table "EcoSystemSubType"                                           */
/* ---------------------------------------------------------------------- */

CREATE TABLE EcoSystemSubType (
  eco_system_sub_type VARCHAR(2)  NOT NULL,
  detail TEXT  NOT NULL,
  CONSTRAINT PK_EcoSystemSubType PRIMARY KEY (eco_system_sub_type)
);

/* ---------------------------------------------------------------------- */
/* Add table "KindType"                                                   */
/* ---------------------------------------------------------------------- */

CREATE TABLE KindType (
  kind_type VARCHAR(1)  NOT NULL,
  detail TEXT  NOT NULL,
  CONSTRAINT PK_KindType PRIMARY KEY (kind_type)
);

/* ---------------------------------------------------------------------- */
/* Add table "CNWIBC"                                                     */
/* ---------------------------------------------------------------------- */

CREATE TABLE CNWIBC (
  cnwi_bc_code VARCHAR(4)  NOT NULL,
  cnwi_code VARCHAR(40),
  CONSTRAINT PK_CNWIBC PRIMARY KEY (cnwi_bc_code)
);

/* ---------------------------------------------------------------------- */
/* Add table "Drainage"                                                   */
/* ---------------------------------------------------------------------- */

CREATE TABLE Drainage (
  drainage_id SERIAL  NOT NULL,
  CONSTRAINT PK_Drainage PRIMARY KEY (drainage_id)
);

/* ---------------------------------------------------------------------- */
/* Add table "InterpretationType"                                         */
/* ---------------------------------------------------------------------- */

CREATE TABLE InterpretationType (
  interpretation_type VARCHAR(4)  NOT NULL,
  CONSTRAINT PK_InterpretationType PRIMARY KEY (interpretation_type)
);

/* ---------------------------------------------------------------------- */
/* Add table "Material"                                                   */
/* ---------------------------------------------------------------------- */

CREATE TABLE Material (
  material_id SERIAL  NOT NULL,
  CONSTRAINT PK_Material PRIMARY KEY (material_id)
);

/* ---------------------------------------------------------------------- */
/* Add table "Expression"                                                 */
/* ---------------------------------------------------------------------- */

CREATE TABLE Expression (
  expression_id SERIAL  NOT NULL,
  CONSTRAINT PK_Expression PRIMARY KEY (expression_id)
);

/* ---------------------------------------------------------------------- */
/* Add table "Texture"                                                    */
/* ---------------------------------------------------------------------- */

CREATE TABLE Texture (
  texture_id SERIAL  NOT NULL,
  CONSTRAINT PK_Texture PRIMARY KEY (texture_id)
);

/* ---------------------------------------------------------------------- */
/* Add table "LayerType"                                                  */
/* ---------------------------------------------------------------------- */

CREATE TABLE LayerType (
  layer_type SERIAL  NOT NULL,
  CONSTRAINT PK_LayerType PRIMARY KEY (layer_type)
);

/* ---------------------------------------------------------------------- */
/* Add table "GeoMorphicProcess"                                          */
/* ---------------------------------------------------------------------- */

CREATE TABLE GeoMorphicProcess (
  geo_morphic_process_id SERIAL  NOT NULL,
  activity_default BOOLEAN  NOT NULL,
  CONSTRAINT PK_GeoMorphicProcess PRIMARY KEY (geo_morphic_process_id)
);

/* ---------------------------------------------------------------------- */
/* Add table "VegLayerCode"                                               */
/* ---------------------------------------------------------------------- */

CREATE TABLE VegLayerCode (
  veg_layer_code VARCHAR(4)  NOT NULL,
  CONSTRAINT PK_VegLayerCode PRIMARY KEY (veg_layer_code)
);

/* ---------------------------------------------------------------------- */
/* Add table "VegSpeciesCode"                                             */
/* ---------------------------------------------------------------------- */

CREATE TABLE VegSpeciesCode (
  veg_species_code VARCHAR(4)  NOT NULL,
  CONSTRAINT PK_VegSpeciesCode PRIMARY KEY (veg_species_code)
);

/* ---------------------------------------------------------------------- */
/* Add table "VegSpecies_VegLayer"                                        */
/* ---------------------------------------------------------------------- */

CREATE TABLE VegSpecies_VegLayer (
  veg_species_code VARCHAR(4)  NOT NULL,
  veg_layer_code VARCHAR(4)  NOT NULL,
  CONSTRAINT PK_VegSpecies_VegLayer PRIMARY KEY (veg_species_code, veg_layer_code)
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
/* Add table "BedrockType"                                                */
/* ---------------------------------------------------------------------- */

CREATE TABLE BedrockType (
  bedrock_type VARCHAR(4)  NOT NULL,
  CONSTRAINT PK_BedrockType PRIMARY KEY (bedrock_type)
);

/* ---------------------------------------------------------------------- */
/* Add table "SiteModifierCode"                                           */
/* ---------------------------------------------------------------------- */

CREATE TABLE SiteModifierCode (
  site_modifier_code VARCHAR(40)  NOT NULL,
  CONSTRAINT PK_SiteModifierCode PRIMARY KEY (site_modifier_code)
);

/* ---------------------------------------------------------------------- */
/* Add table "MethodologyCode"                                            */
/* ---------------------------------------------------------------------- */

CREATE TABLE MethodologyCode (
  methodology_code VARCHAR(4)  NOT NULL,
  CONSTRAINT PK_MethodologyCode PRIMARY KEY (methodology_code)
);

/* ---------------------------------------------------------------------- */
/* Add table "PointType"                                                  */
/* ---------------------------------------------------------------------- */

CREATE TABLE PointType (
  point_type VARCHAR(2)  NOT NULL,
  CONSTRAINT PK_PointType PRIMARY KEY (point_type)
);

/* ---------------------------------------------------------------------- */
/* Add table "GeometryType"                                               */
/* ---------------------------------------------------------------------- */

CREATE TABLE GeometryType (
  geometry_type VARCHAR(4)  NOT NULL,
  CONSTRAINT PK_GeometryType PRIMARY KEY (geometry_type)
);

/* ---------------------------------------------------------------------- */
/* Add table "Flag"                                                       */
/* ---------------------------------------------------------------------- */

CREATE TABLE Flag (
  flag_id VARCHAR(4)  NOT NULL,
  CONSTRAINT PK_Flag PRIMARY KEY (flag_id)
);

/* ---------------------------------------------------------------------- */
/* Add table "Image"                                                      */
/* ---------------------------------------------------------------------- */

CREATE TABLE Image (
  image_id SERIAL  NOT NULL,
  CONSTRAINT PK_Image PRIMARY KEY (image_id)
);

/* ---------------------------------------------------------------------- */
/* Add table "DataGroup"                                                  */
/* ---------------------------------------------------------------------- */

CREATE TABLE DataGroup (
  data_group_id SERIAL  NOT NULL,
  group_name TEXT  NOT NULL,
  description TEXT,
  contract_number VARCHAR(10),
  contract_value MONEY,
  sr_number SMALLINT,
  created_by TEXT,
  created_dt TIMESTAMP  NOT NULL,
  active BOOLEAN DEFAULT TRUE  NOT NULL,
  CONSTRAINT PK_DataGroup PRIMARY KEY (data_group_id)
);

CREATE INDEX IDX_DataGroup_FK_group_name ON DataGroup (group_name);

CREATE INDEX IDX_DataGroup_FK_contract_number ON DataGroup (contract_number);

CREATE INDEX IDX_DataGroup_FK_sr_number ON DataGroup (sr_number);

/* ---------------------------------------------------------------------- */
/* Add table "RelationDescription"                                        */
/* ---------------------------------------------------------------------- */

CREATE TABLE RelationDescription (
  relation_description_id SERIAL  NOT NULL,
  description TEXT  NOT NULL,
  CONSTRAINT PK_RelationDescription PRIMARY KEY (relation_description_id)
);

/* ---------------------------------------------------------------------- */
/* Add table "FeatureCode"                                                */
/* ---------------------------------------------------------------------- */

CREATE TABLE FeatureCode (
  feature_code VARCHAR(10)  NOT NULL,
  short_name VARCHAR(40)  NOT NULL,
  description TEXT,
  attribute TEXT,
  remark TEXT,
  active BOOLEAN DEFAULT TRUE  NOT NULL,
  CONSTRAINT PK_FeatureCode PRIMARY KEY (feature_code)
);

/* ---------------------------------------------------------------------- */
/* Add table "StatusCode"                                                 */
/* ---------------------------------------------------------------------- */

CREATE TABLE StatusCode (
  status_code VARCHAR(6)  NOT NULL,
  description TEXT  NOT NULL,
  comment TEXT,
  active BOOLEAN DEFAULT TRUE  NOT NULL,
  CONSTRAINT PK_StatusCode PRIMARY KEY (status_code)
);

/* ---------------------------------------------------------------------- */
/* Add table "GeoLine"                                                    */
/* ---------------------------------------------------------------------- */

CREATE TABLE GeoLine (
  geo_line_id SERIAL  NOT NULL,
  geo_line LINE  NOT NULL,
  CONSTRAINT PK_GeoLine PRIMARY KEY (geo_line_id)
);

/* ---------------------------------------------------------------------- */
/* Add table "ProjectClass"                                               */
/* ---------------------------------------------------------------------- */

CREATE TABLE ProjectClass (
  project_class VARCHAR(2)  NOT NULL,
  description VARCHAR(40)  NOT NULL,
  active BOOLEAN DEFAULT true  NOT NULL,
  CONSTRAINT PK_ProjectClass PRIMARY KEY (project_class)
);

/* ---------------------------------------------------------------------- */
/* Add table "ScaleCode"                                                  */
/* ---------------------------------------------------------------------- */

CREATE TABLE ScaleCode (
  scale_code SMALLINT  NOT NULL,
  description TEXT  NOT NULL,
  active BOOLEAN DEFAULT TRUE  NOT NULL,
  CONSTRAINT PK_ScaleCode PRIMARY KEY (scale_code)
);

/* ---------------------------------------------------------------------- */
/* Add table "CommentType"                                                */
/* ---------------------------------------------------------------------- */

CREATE TABLE CommentType (
  comment_type VARCHAR(4)  NOT NULL,
  description VARCHAR(40)  NOT NULL,
  valid BOOLEAN DEFAULT TRUE  NOT NULL,
  CONSTRAINT PK_CommentType PRIMARY KEY (comment_type)
);

/* ---------------------------------------------------------------------- */
/* Add table "PartyType"                                                  */
/* ---------------------------------------------------------------------- */

CREATE TABLE PartyType (
  party_type VARCHAR(4)  NOT NULL,
  description VARCHAR(40)  NOT NULL,
  active BOOLEAN DEFAULT TRUE  NOT NULL,
  CONSTRAINT PK_PartyType PRIMARY KEY (party_type)
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
  detail TEXT  NOT NULL,
  CONSTRAINT PK_BGCCode PRIMARY KEY (bgc_code)
);

CREATE INDEX IDX_BGCCode_FK_zone_code ON BGCCode (zone_code);

CREATE INDEX IDX_BGCCode_FK_sub_zone_code ON BGCCode (sub_zone_code);

CREATE INDEX IDX_BGCCode_FK_variant_code ON BGCCode (variant_code);

CREATE INDEX IDX_BGCCode_FK_phase_code ON BGCCode (phase_code);

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

CREATE INDEX IDX_SiteComponentCode_FK_realm_code ON SiteComponentCode (realm_code);

CREATE INDEX IDX_SiteComponentCode_FK_group_code ON SiteComponentCode (group_code);

CREATE INDEX IDX_SiteComponentCode_FK_class_code ON SiteComponentCode (class_code);

CREATE INDEX IDX_SiteComponentCode_FK_association_code ON SiteComponentCode (association_code);

CREATE INDEX IDX_SiteComponentCode_FK_sub_class_code ON SiteComponentCode (sub_class_code);

CREATE INDEX IDX_SiteComponentCode_FK_nbec_code ON SiteComponentCode (nbec_code);

/* ---------------------------------------------------------------------- */
/* Add table "Interpretation"                                             */
/* ---------------------------------------------------------------------- */

CREATE TABLE Interpretation (
  interpretation_id SERIAL  NOT NULL,
  interpretation_type VARCHAR(4),
  CONSTRAINT PK_Interpretation PRIMARY KEY (interpretation_id)
);

/* ---------------------------------------------------------------------- */
/* Add table "EcoObject"                                                  */
/* ---------------------------------------------------------------------- */

CREATE TABLE EcoObject (
  eco_object_id SERIAL  NOT NULL,
  bgc_code VARCHAR(10),
  CONSTRAINT PK_EcoObject PRIMARY KEY (eco_object_id)
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

CREATE INDEX IDX_BGCEcoCode_FK_bgc_code ON BGCEcoCode (bgc_code);

CREATE INDEX IDX_BGCEcoCode_FK_eco_code ON BGCEcoCode (eco_code);

CREATE INDEX IDX_BGCEcoCode_FK_nbec_code ON BGCEcoCode (nbec_code);

CREATE INDEX IDX_BGCEcoCode_FK_site_component_code ON BGCEcoCode (site_component_code);

CREATE INDEX IDX_BGCEcoCode_site_series_name ON BGCEcoCode (site_series_name);

/* ---------------------------------------------------------------------- */
/* Add table "BGCEcoCode_CNWIBC"                                          */
/* ---------------------------------------------------------------------- */

CREATE TABLE BGCEcoCode_CNWIBC (
  bgc_ecocode_id INTEGER  NOT NULL,
  cnwi_bc_code VARCHAR(4)  NOT NULL,
  CONSTRAINT PK_BGCEcoCode_CNWIBC PRIMARY KEY (bgc_ecocode_id, cnwi_bc_code)
);

/* ---------------------------------------------------------------------- */
/* Add table "ProjectType"                                                */
/* ---------------------------------------------------------------------- */

CREATE TABLE ProjectType (
  project_type VARCHAR(8)  NOT NULL,
  project_class VARCHAR(2),
  primary_type VARCHAR(8),
  sub_type VARCHAR(6),
  short_name TEXT,
  description TEXT  NOT NULL,
  notes TEXT,
  active BOOLEAN DEFAULT TRUE  NOT NULL,
  CONSTRAINT PK_ProjectType PRIMARY KEY (project_type)
);

/* ---------------------------------------------------------------------- */
/* Add table "Party"                                                      */
/* ---------------------------------------------------------------------- */

CREATE TABLE Party (
  party_id SERIAL  NOT NULL,
  party_type VARCHAR(4)  NOT NULL,
  party_name VARCHAR(40)  NOT NULL,
  description TEXT,
  email TEXT,
  phone_number TEXT,
  active BOOLEAN DEFAULT TRUE  NOT NULL,
  created_dt TIMESTAMP DEFAULT NOW()  NOT NULL,
  CONSTRAINT PK_Party PRIMARY KEY (party_id)
);

/* ---------------------------------------------------------------------- */
/* Add table "Project"                                                    */
/* ---------------------------------------------------------------------- */

CREATE TABLE Project (
  project_bapid INTEGER  NOT NULL,
  project_type VARCHAR(8)  NOT NULL,
  status_code VARCHAR(6)  NOT NULL,
  feature_code VARCHAR(10)  NOT NULL,
  project_name TEXT  NOT NULL,
  project_code VARCHAR(8),
  location_description TEXT,
  start_date DATE  NOT NULL,
  end_date DATE,
  description TEXT,
  estimated_cost MONEY,
  boundary_only BOOLEAN DEFAULT FALSE  NOT NULL,
  sensitive_data BOOLEAN DEFAULT FALSE  NOT NULL,
  active BOOLEAN DEFAULT TRUE  NOT NULL,
  created_dt TIMESTAMP DEFAULT NOW(),
  CONSTRAINT PK_Project PRIMARY KEY (project_bapid)
);

CREATE INDEX IDX_Project_FK_feature_code ON Project (feature_code);

CREATE INDEX IDX_Project_project_name ON Project (project_name);

CREATE INDEX IDX_Project_start_date ON Project (start_date);

CREATE INDEX IDX_Project_end_date ON Project (end_date);

/* ---------------------------------------------------------------------- */
/* Add table "Geometry"                                                   */
/* ---------------------------------------------------------------------- */

CREATE TABLE Geometry (
  geometry_id SERIAL  NOT NULL,
  eco_object_id INTEGER  NOT NULL,
  drainage_id INTEGER,
  interpretation_id INTEGER,
  geometry_type VARCHAR(4),
  flag_id VARCHAR(4),
  cnwi_bc_code VARCHAR(4),
  feature_code VARCHAR(10),
  scale_code SMALLINT,
  CONSTRAINT PK_Geometry PRIMARY KEY (geometry_id)
);

/* ---------------------------------------------------------------------- */
/* Add table "Geometry_GeoMorphicProcess"                                 */
/* ---------------------------------------------------------------------- */

CREATE TABLE Geometry_GeoMorphicProcess (
  geometry_id INTEGER  NOT NULL,
  geo_morphic_process_id INTEGER  NOT NULL,
  active BOOLEAN,
  CONSTRAINT PK_Geometry_GeoMorphicProcess PRIMARY KEY (geometry_id, geo_morphic_process_id)
);

/* ---------------------------------------------------------------------- */
/* Add table "Geometry_Methodology"                                       */
/* ---------------------------------------------------------------------- */

CREATE TABLE Geometry_Methodology (
  geometry_id INTEGER  NOT NULL,
  methodology_code VARCHAR(4)  NOT NULL,
  CONSTRAINT PK_Geometry_Methodology PRIMARY KEY (geometry_id, methodology_code)
);

/* ---------------------------------------------------------------------- */
/* Add table "Geometry_Image"                                             */
/* ---------------------------------------------------------------------- */

CREATE TABLE Geometry_Image (
  geometry_id INTEGER  NOT NULL,
  image_id INTEGER  NOT NULL,
  CONSTRAINT PK_Geometry_Image PRIMARY KEY (geometry_id, image_id)
);

/* ---------------------------------------------------------------------- */
/* Add table "Error"                                                      */
/* ---------------------------------------------------------------------- */

CREATE TABLE Error (
  error_id SERIAL  NOT NULL,
  geometry_id INTEGER  NOT NULL,
  CONSTRAINT PK_Error PRIMARY KEY (error_id)
);

/* ---------------------------------------------------------------------- */
/* Add table "Issue"                                                      */
/* ---------------------------------------------------------------------- */

CREATE TABLE Issue (
  issue_id SERIAL  NOT NULL,
  project_bapid INTEGER  NOT NULL,
  issue_description TEXT  NOT NULL,
  recorded_dt TIMESTAMP  NOT NULL,
  recorded_by TEXT,
  resolved_dt TIMESTAMP,
  resolved_by TEXT,
  resolution_notes TEXT,
  CONSTRAINT PK_Issue PRIMARY KEY (issue_id)
);

/* ---------------------------------------------------------------------- */
/* Add table "Project_EcoObject"                                          */
/* ---------------------------------------------------------------------- */

CREATE TABLE Project_EcoObject (
  project_bapid INTEGER  NOT NULL,
  eco_object_id INTEGER  NOT NULL,
  CONSTRAINT PK_Project_EcoObject PRIMARY KEY (project_bapid, eco_object_id)
);

/* ---------------------------------------------------------------------- */
/* Add table "DataGroup_Project"                                          */
/* ---------------------------------------------------------------------- */

CREATE TABLE DataGroup_Project (
  data_group_id INTEGER  NOT NULL,
  project_bapid INTEGER  NOT NULL,
  CONSTRAINT PK_DataGroup_Project PRIMARY KEY (data_group_id, project_bapid)
);

/* ---------------------------------------------------------------------- */
/* Add table "ProjectRelation"                                            */
/* ---------------------------------------------------------------------- */

CREATE TABLE ProjectRelation (
  project_bapid1 INTEGER  NOT NULL,
  project_bapid2 INTEGER  NOT NULL,
  relation_description_id INTEGER  NOT NULL,
  CONSTRAINT PK_ProjectRelation PRIMARY KEY (project_bapid1, project_bapid2)
);

/* ---------------------------------------------------------------------- */
/* Add table "Alias"                                                      */
/* ---------------------------------------------------------------------- */

CREATE TABLE Alias (
  alias_id SERIAL  NOT NULL,
  project_bapid INTEGER  NOT NULL,
  alias_name TEXT  NOT NULL,
  active BOOLEAN DEFAULT TRUE  NOT NULL,
  CONSTRAINT PK_Alias PRIMARY KEY (alias_id)
);

/* ---------------------------------------------------------------------- */
/* Add table "LegacyProject"                                              */
/* ---------------------------------------------------------------------- */

CREATE TABLE LegacyProject (
  project_bapid INTEGER  NOT NULL,
  esil VARCHAR(40),
  tsil VARCHAR(40),
  mapsh_lst VARCHAR(40),
  trim_nbr VARCHAR(40),
  photo_type VARCHAR(40),
  photo_sc VARCHAR(40),
  photo_yr VARCHAR(40),
  ter_leg_sc VARCHAR(40),
  ter_leg_tp VARCHAR(40),
  pack_nbr VARCHAR(40),
  stbcls_tp VARCHAR(40),
  slp_unit VARCHAR(40),
  trs_approval_condition VARCHAR(40),
  aa_level VARCHAR(40),
  aa_comment VARCHAR(40),
  CONSTRAINT PK_LegacyProject PRIMARY KEY (project_bapid)
);

/* ---------------------------------------------------------------------- */
/* Add table "Comment"                                                    */
/* ---------------------------------------------------------------------- */

CREATE TABLE Comment (
  comment_id SERIAL  NOT NULL,
  comment_type VARCHAR(4),
  project_bapid INTEGER,
  comment TEXT  NOT NULL,
  url VARCHAR(40),
  created_dt TIMESTAMP DEFAULT NOW(),
  CONSTRAINT PK_Comment PRIMARY KEY (comment_id)
);

/* ---------------------------------------------------------------------- */
/* Add table "Project_Party"                                              */
/* ---------------------------------------------------------------------- */

CREATE TABLE Project_Party (
  project_bapid INTEGER  NOT NULL,
  party_id INTEGER  NOT NULL,
  associate_org BOOLEAN DEFAULT FALSE  NOT NULL,
  proj_sup BOOLEAN DEFAULT FALSE  NOT NULL,
  eco_map BOOLEAN DEFAULT FALSE  NOT NULL,
  ter_map BOOLEAN DEFAULT FALSE  NOT NULL,
  soil_map BOOLEAN DEFAULT FALSE  NOT NULL,
  wild_map BOOLEAN DEFAULT FALSE  NOT NULL,
  dig_cap BOOLEAN DEFAULT FALSE  NOT NULL,
  gis_sup BOOLEAN DEFAULT FALSE  NOT NULL,
  rec_name BOOLEAN DEFAULT FALSE  NOT NULL,
  client BOOLEAN DEFAULT FALSE  NOT NULL,
  lead_prop BOOLEAN DEFAULT FALSE  NOT NULL,
  funding_src BOOLEAN DEFAULT False  NOT NULL,
  contact BOOLEAN DEFAULT FALSE  NOT NULL,
  CONSTRAINT PK_Project_Party PRIMARY KEY (project_bapid, party_id)
);

/* ---------------------------------------------------------------------- */
/* Add table "GeoPolygon"                                                 */
/* ---------------------------------------------------------------------- */

CREATE TABLE GeoPolygon (
  geo_polygon_id SERIAL  NOT NULL,
  geometry_id INTEGER  NOT NULL,
  geo_polygon POLYGON  NOT NULL,
  CONSTRAINT PK_GeoPolygon PRIMARY KEY (geo_polygon_id)
);

/* ---------------------------------------------------------------------- */
/* Add table "GeoPoint"                                                   */
/* ---------------------------------------------------------------------- */

CREATE TABLE GeoPoint (
  geo_point_id SERIAL  NOT NULL,
  point_type VARCHAR(2),
  geometry_id INTEGER  NOT NULL,
  bgc_ecocode_id INTEGER,
  geo_point POINT  NOT NULL,
  CONSTRAINT PK_GeoPoint PRIMARY KEY (geo_point_id)
);

/* ---------------------------------------------------------------------- */
/* Add table "EcoComponent"                                               */
/* ---------------------------------------------------------------------- */

CREATE TABLE EcoComponent (
  eco_component_id SERIAL  NOT NULL,
  polygon_id INTEGER  NOT NULL,
  bgc_ecocode_id INTEGER,
  site_modifier_code_1 VARCHAR(40),
  site_modifier_code_2 VARCHAR(40),
  num INTEGER,
  decile INTEGER,
  CONSTRAINT PK_EcoComponent PRIMARY KEY (eco_component_id)
);

/* ---------------------------------------------------------------------- */
/* Add table "Polygon_Point"                                              */
/* ---------------------------------------------------------------------- */

CREATE TABLE Polygon_Point (
  polygon_id INTEGER  NOT NULL,
  point_id INTEGER  NOT NULL,
  CONSTRAINT PK_Polygon_Point PRIMARY KEY (polygon_id, point_id)
);

/* ---------------------------------------------------------------------- */
/* Add table "TerComponent"                                               */
/* ---------------------------------------------------------------------- */

CREATE TABLE TerComponent (
  ter_component_id SERIAL  NOT NULL,
  polygon_id INTEGER  NOT NULL,
  drainage_id INTEGER,
  interpretation_id INTEGER,
  bedrock_type VARCHAR(4),
  decile SMALLINT,
  not_mapped BOOLEAN,
  ice_covered BOOLEAN,
  CONSTRAINT PK_TerComponent PRIMARY KEY (ter_component_id)
);

/* ---------------------------------------------------------------------- */
/* Add table "Layer"                                                      */
/* ---------------------------------------------------------------------- */

CREATE TABLE Layer (
  layer_id SERIAL  NOT NULL,
  layer_type INTEGER  NOT NULL,
  ter_component_id INTEGER  NOT NULL,
  material_id INTEGER  NOT NULL,
  texture1_id INTEGER,
  texture2_id INTEGER,
  texture3_id INTEGER,
  expression1_id INTEGER,
  expression2_id INTEGER,
  expression3_id INTEGER,
  material_qualifier BOOLEAN DEFAULT FALSE  NOT NULL,
  CONSTRAINT PK_Layer PRIMARY KEY (layer_id)
);

/* ---------------------------------------------------------------------- */
/* Add table "Point_VegLayer"                                             */
/* ---------------------------------------------------------------------- */

CREATE TABLE Point_VegLayer (
  point_id INTEGER  NOT NULL,
  veg_layer_code VARCHAR(4)  NOT NULL,
  CONSTRAINT PK_Point_VegLayer PRIMARY KEY (point_id, veg_layer_code)
);

/* ---------------------------------------------------------------------- */
/* Add table "Point_VegLayer_VegSpecies"                                  */
/* ---------------------------------------------------------------------- */

CREATE TABLE Point_VegLayer_VegSpecies (
  point_id INTEGER  NOT NULL,
  veg_layer_code VARCHAR(4)  NOT NULL,
  veg_species_code VARCHAR(4)  NOT NULL,
  CONSTRAINT PK_Point_VegLayer_VegSpecies PRIMARY KEY (point_id, veg_layer_code, veg_species_code)
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

ALTER TABLE GeoPolygon ADD CONSTRAINT Geometry_GeoPolygon
  FOREIGN KEY (geometry_id) REFERENCES Geometry (geometry_id);

ALTER TABLE GeoPoint ADD CONSTRAINT PointType_GeoPoint
  FOREIGN KEY (point_type) REFERENCES PointType (point_type);

ALTER TABLE GeoPoint ADD CONSTRAINT Geometry_GeoPoint
  FOREIGN KEY (geometry_id) REFERENCES Geometry (geometry_id);

ALTER TABLE GeoPoint ADD CONSTRAINT BGCEcoCode_GeoPoint
  FOREIGN KEY (bgc_ecocode_id) REFERENCES BGCEcoCode (bgc_ecocode_id);

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

ALTER TABLE EcoComponent ADD CONSTRAINT GeoPolygon_EcoComponent
  FOREIGN KEY (polygon_id) REFERENCES GeoPolygon (geo_polygon_id);

ALTER TABLE EcoComponent ADD CONSTRAINT SiteModifierCode_EcoComponent_1
  FOREIGN KEY (site_modifier_code_1) REFERENCES SiteModifierCode (site_modifier_code);

ALTER TABLE EcoComponent ADD CONSTRAINT SiteModifierCode_EcoComponent_2
  FOREIGN KEY (site_modifier_code_2) REFERENCES SiteModifierCode (site_modifier_code);

ALTER TABLE EcoComponent ADD CONSTRAINT BGCEcoCode_EcoComponent
  FOREIGN KEY (bgc_ecocode_id) REFERENCES BGCEcoCode (bgc_ecocode_id);

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

ALTER TABLE Polygon_Point ADD CONSTRAINT GeoPolygon_Polygon_Point
  FOREIGN KEY (polygon_id) REFERENCES GeoPolygon (geo_polygon_id);

ALTER TABLE Polygon_Point ADD CONSTRAINT GeoPoint_Polygon_Point
  FOREIGN KEY (point_id) REFERENCES GeoPoint (geo_point_id);

ALTER TABLE TerComponent ADD CONSTRAINT GeoPolygon_TerComponent
  FOREIGN KEY (polygon_id) REFERENCES GeoPolygon (geo_polygon_id);

ALTER TABLE TerComponent ADD CONSTRAINT Drainage_TerComponent
  FOREIGN KEY (drainage_id) REFERENCES Drainage (drainage_id);

ALTER TABLE TerComponent ADD CONSTRAINT Interpretation_TerComponent
  FOREIGN KEY (interpretation_id) REFERENCES Interpretation (interpretation_id);

ALTER TABLE TerComponent ADD CONSTRAINT BedrockType_TerComponent
  FOREIGN KEY (bedrock_type) REFERENCES BedrockType (bedrock_type);

ALTER TABLE Interpretation ADD CONSTRAINT InterpretationType_Interpretation
  FOREIGN KEY (interpretation_type) REFERENCES InterpretationType (interpretation_type);

ALTER TABLE Layer ADD CONSTRAINT LayerType_Layer
  FOREIGN KEY (layer_type) REFERENCES LayerType (layer_type);

ALTER TABLE Layer ADD CONSTRAINT TerComponent_Layer
  FOREIGN KEY (ter_component_id) REFERENCES TerComponent (ter_component_id);

ALTER TABLE Layer ADD CONSTRAINT Material_Layer
  FOREIGN KEY (material_id) REFERENCES Material (material_id);

ALTER TABLE Layer ADD CONSTRAINT Texture_Layer_1
  FOREIGN KEY (texture1_id) REFERENCES Texture (texture_id);

ALTER TABLE Layer ADD CONSTRAINT Texture_Layer_2
  FOREIGN KEY (texture2_id) REFERENCES Texture (texture_id);

ALTER TABLE Layer ADD CONSTRAINT Texture_Layer_3
  FOREIGN KEY (texture3_id) REFERENCES Texture (texture_id);

ALTER TABLE Layer ADD CONSTRAINT Expression_Layer_1
  FOREIGN KEY (expression1_id) REFERENCES Expression (expression_id);

ALTER TABLE Layer ADD CONSTRAINT Expression_Layer_2
  FOREIGN KEY (expression2_id) REFERENCES Expression (expression_id);

ALTER TABLE Layer ADD CONSTRAINT Expression_Layer_3
  FOREIGN KEY (expression3_id) REFERENCES Expression (expression_id);

ALTER TABLE VegSpecies_VegLayer ADD CONSTRAINT VegSpeciesCode_VegSpecies_VegLayer
  FOREIGN KEY (veg_species_code) REFERENCES VegSpeciesCode (veg_species_code);

ALTER TABLE VegSpecies_VegLayer ADD CONSTRAINT VegLayerCode_VegSpecies_VegLayer
  FOREIGN KEY (veg_layer_code) REFERENCES VegLayerCode (veg_layer_code);

ALTER TABLE Point_VegLayer ADD CONSTRAINT GeoPoint_Point_VegLayer
  FOREIGN KEY (point_id) REFERENCES GeoPoint (geo_point_id);

ALTER TABLE Point_VegLayer ADD CONSTRAINT VegLayerCode_Point_VegLayer
  FOREIGN KEY (veg_layer_code) REFERENCES VegLayerCode (veg_layer_code);

ALTER TABLE Point_VegLayer_VegSpecies ADD CONSTRAINT Point_VegLayer_Point_VegLayer_VegSpecies
  FOREIGN KEY (point_id, veg_layer_code) REFERENCES Point_VegLayer (point_id,veg_layer_code);

ALTER TABLE Point_VegLayer_VegSpecies ADD CONSTRAINT VegSpeciesCode_Point_VegLayer_VegSpecies
  FOREIGN KEY (veg_species_code) REFERENCES VegSpeciesCode (veg_species_code);

ALTER TABLE SubZoneCode_PhaseCode ADD CONSTRAINT SubZoneCode_SubZoneCode_PhaseCode
  FOREIGN KEY (sub_zone_code) REFERENCES SubZoneCode (sub_zone_code);

ALTER TABLE SubZoneCode_PhaseCode ADD CONSTRAINT PhaseCode_SubZoneCode_PhaseCode
  FOREIGN KEY (phase_code) REFERENCES PhaseCode (phase_code);

ALTER TABLE Project ADD CONSTRAINT ProjectType_Project
  FOREIGN KEY (project_type) REFERENCES ProjectType (project_type);

ALTER TABLE Project ADD CONSTRAINT FeatureCode_Project
  FOREIGN KEY (feature_code) REFERENCES FeatureCode (feature_code);

ALTER TABLE Project ADD CONSTRAINT StatusCode_Project
  FOREIGN KEY (status_code) REFERENCES StatusCode (status_code);

ALTER TABLE Geometry ADD CONSTRAINT Drainage_Geometry
  FOREIGN KEY (drainage_id) REFERENCES Drainage (drainage_id);

ALTER TABLE Geometry ADD CONSTRAINT Interpretation_Geometry
  FOREIGN KEY (interpretation_id) REFERENCES Interpretation (interpretation_id);

ALTER TABLE Geometry ADD CONSTRAINT GeometryType_Geometry
  FOREIGN KEY (geometry_type) REFERENCES GeometryType (geometry_type);

ALTER TABLE Geometry ADD CONSTRAINT Flag_Geometry
  FOREIGN KEY (flag_id) REFERENCES Flag (flag_id);

ALTER TABLE Geometry ADD CONSTRAINT CNWIBC_Geometry
  FOREIGN KEY (cnwi_bc_code) REFERENCES CNWIBC (cnwi_bc_code);

ALTER TABLE Geometry ADD CONSTRAINT EcoObject_Geometry
  FOREIGN KEY (eco_object_id) REFERENCES EcoObject (eco_object_id);

ALTER TABLE Geometry ADD CONSTRAINT FeatureCode_Geometry
  FOREIGN KEY (feature_code) REFERENCES FeatureCode (feature_code);

ALTER TABLE Geometry ADD CONSTRAINT ScaleCode_Geometry
  FOREIGN KEY (scale_code) REFERENCES ScaleCode (scale_code);

ALTER TABLE Geometry_GeoMorphicProcess ADD CONSTRAINT Geometry_Geometry_GeoMorphicProcess
  FOREIGN KEY (geometry_id) REFERENCES Geometry (geometry_id);

ALTER TABLE Geometry_GeoMorphicProcess ADD CONSTRAINT GeoMorphicProcess_Geometry_GeoMorphicProcess
  FOREIGN KEY (geo_morphic_process_id) REFERENCES GeoMorphicProcess (geo_morphic_process_id);

ALTER TABLE Geometry_Methodology ADD CONSTRAINT Geometry_Geometry_Methodology
  FOREIGN KEY (geometry_id) REFERENCES Geometry (geometry_id);

ALTER TABLE Geometry_Methodology ADD CONSTRAINT MethodologyCode_Geometry_Methodology
  FOREIGN KEY (methodology_code) REFERENCES MethodologyCode (methodology_code);

ALTER TABLE Geometry_Image ADD CONSTRAINT Geometry_Geometry_Image
  FOREIGN KEY (geometry_id) REFERENCES Geometry (geometry_id);

ALTER TABLE Geometry_Image ADD CONSTRAINT Image_Geometry_Image
  FOREIGN KEY (image_id) REFERENCES Image (image_id);

ALTER TABLE Error ADD CONSTRAINT Geometry_Error
  FOREIGN KEY (geometry_id) REFERENCES Geometry (geometry_id);

ALTER TABLE Issue ADD CONSTRAINT Project_Issue
  FOREIGN KEY (project_bapid) REFERENCES Project (project_bapid) ON DELETE CASCADE;

ALTER TABLE EcoObject ADD CONSTRAINT BGCCode_EcoObject
  FOREIGN KEY (bgc_code) REFERENCES BGCCode (bgc_code);

ALTER TABLE Project_EcoObject ADD CONSTRAINT Project_Project_EcoObject
  FOREIGN KEY (project_bapid) REFERENCES Project (project_bapid);

ALTER TABLE Project_EcoObject ADD CONSTRAINT EcoObject_Project_EcoObject
  FOREIGN KEY (eco_object_id) REFERENCES EcoObject (eco_object_id);

ALTER TABLE BGCEcoCode ADD CONSTRAINT BGCCode_BGCEcoCode
  FOREIGN KEY (bgc_code) REFERENCES BGCCode (bgc_code);

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

ALTER TABLE BGCEcoCode ADD CONSTRAINT EcoCode_BGCEcoCode
  FOREIGN KEY (eco_code) REFERENCES EcoCode (eco_code);

ALTER TABLE BGCEcoCode_CNWIBC ADD CONSTRAINT BGCEcoCode_BGCEcoCode_CNWIBC
  FOREIGN KEY (bgc_ecocode_id) REFERENCES BGCEcoCode (bgc_ecocode_id);

ALTER TABLE BGCEcoCode_CNWIBC ADD CONSTRAINT CNWIBC_BGCEcoCode_CNWIBC
  FOREIGN KEY (cnwi_bc_code) REFERENCES CNWIBC (cnwi_bc_code);

ALTER TABLE DataGroup_Project ADD CONSTRAINT DataGroup_DataGroup_Project
  FOREIGN KEY (data_group_id) REFERENCES DataGroup (data_group_id) ON DELETE CASCADE;

ALTER TABLE DataGroup_Project ADD CONSTRAINT Project_DataGroup_Project
  FOREIGN KEY (project_bapid) REFERENCES Project (project_bapid) ON DELETE CASCADE;

ALTER TABLE ProjectRelation ADD CONSTRAINT Project_ProjectRelation2
  FOREIGN KEY (project_bapid2) REFERENCES Project (project_bapid);

ALTER TABLE ProjectRelation ADD CONSTRAINT Project_ProjectRelation1
  FOREIGN KEY (project_bapid1) REFERENCES Project (project_bapid);

ALTER TABLE ProjectRelation ADD CONSTRAINT RelationDescription_ProjectRelation
  FOREIGN KEY (relation_description_id) REFERENCES RelationDescription (relation_description_id);

ALTER TABLE ProjectType ADD CONSTRAINT ProjectClass_ProjectType
  FOREIGN KEY (project_class) REFERENCES ProjectClass (project_class);

ALTER TABLE Alias ADD CONSTRAINT Project_Alias
  FOREIGN KEY (project_bapid) REFERENCES Project (project_bapid) ON DELETE CASCADE;

ALTER TABLE LegacyProject ADD CONSTRAINT Project_LegacyProject
  FOREIGN KEY (project_bapid) REFERENCES Project (project_bapid) ON DELETE CASCADE;

ALTER TABLE Party ADD CONSTRAINT PartyType_Party
  FOREIGN KEY (party_type) REFERENCES PartyType (party_type);

ALTER TABLE Comment ADD CONSTRAINT CommentType_Comment
  FOREIGN KEY (comment_type) REFERENCES CommentType (comment_type);

ALTER TABLE Comment ADD CONSTRAINT Project_Comment
  FOREIGN KEY (project_bapid) REFERENCES Project (project_bapid) ON DELETE CASCADE;

ALTER TABLE Project_Party ADD CONSTRAINT Project_Project_Party
  FOREIGN KEY (project_bapid) REFERENCES Project (project_bapid) ON DELETE CASCADE;

ALTER TABLE Project_Party ADD CONSTRAINT Party_Project_Party
  FOREIGN KEY (party_id) REFERENCES Party (party_id);