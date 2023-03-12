-- ----------------------------------------------------------------------------
-- MySQL Workbench Migration
-- Migrated Schemata: imatrade-registr
-- Source Schemata: imatrade-registr
-- Created: Sat Mar 11 18:40:23 2023
-- Workbench Version: 8.0.32
-- ----------------------------------------------------------------------------

SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------------------------------------------------------
-- Schema imatrade-registr
-- ----------------------------------------------------------------------------
DROP SCHEMA IF EXISTS `imatrade-registr` ;
CREATE SCHEMA IF NOT EXISTS `imatrade-registr` ;

-- ----------------------------------------------------------------------------
-- Table imatrade-registr.sysdiagrams
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `imatrade-registr`.`sysdiagrams` (
    `name` VARCHAR(160) NOT NULL,
    `principal_id` INT NOT NULL,
    `diagram_id` INT NOT NULL,
    `version` INT NULL,
    `definition` LONGBLOB NULL,
  PRIMARY KEY (`diagram_id`),
  UNIQUE INDEX `UK_principal_name` (`principal_id` ASC, `name` ASC) VISIBLE);

-- ----------------------------------------------------------------------------
-- Table imatrade-registr.__migration
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `imatrade-registr`.`__migration` (
    `IDMigration` INT NOT NULL,
    `CommandSql` VARCHAR(3000) CHARACTER SET 'utf8mb4' NOT NULL,
    `Version` VARCHAR(20) CHARACTER SET 'utf8mb4' NOT NULL,
    `DateApply` DATETIME NOT NULL,
  PRIMARY KEY (`IDMigration`),
  UNIQUE INDEX `UK_migration_version` (`Version` ASC) VISIBLE);

-- ----------------------------------------------------------------------------
-- Table imatrade-registr.entities
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `imatrade-registr`.`entities` (
    `IDEntity` INT NOT NULL,
    `NameEntity` VARCHAR(50) CHARACTER SET 'utf8mb4' NOT NULL,
    `SurnameEntity` VARCHAR(250) CHARACTER SET 'utf8mb4' NOT NULL,
    `City` VARCHAR(50) CHARACTER SET 'utf8mb4' NOT NULL,
    `Street` VARCHAR(50) CHARACTER SET 'utf8mb4' NOT NULL,
    `Phone` VARCHAR(50) CHARACTER SET 'utf8mb4' NULL,
    `Email` VARCHAR(150) CHARACTER SET 'utf8mb4' NOT NULL,
    `IDRole` INT NOT NULL,
    `IsFirm` TINYINT(1) NOT NULL,
    `FirmName` VARCHAR(150) CHARACTER SET 'utf8mb4' NULL,
    `CIN` VARCHAR(15) CHARACTER SET 'utf8mb4' NULL,
    `Active` TINYINT(1) NOT NULL,
    `DateCreate` DATETIME NOT NULL,
    `Password` VARCHAR(150) CHARACTER SET 'utf8mb4' NOT NULL,
    `Zip` VARCHAR(10) CHARACTER SET 'utf8mb4' NULL,
    `DateActivated` DATETIME NULL,
    `IDCountry` INT NOT NULL,
    `IDRegion` INT NULL,
    `IDOrganisation` INT NULL,
    `Deleted` TINYINT(1) NOT NULL DEFAULT 0,
    `DateDeleted` DATETIME NULL,
  PRIMARY KEY (`IDEntity`),
  UNIQUE INDEX `UK_entities_email` (`Email` ASC) VISIBLE,
  CONSTRAINT `FK_entities_roles`
    FOREIGN KEY (`IDRole`)
    REFERENCES `imatrade-registr`.`roles` (`IDRole`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_entities_Countries`
    FOREIGN KEY (`IDCountry`)
    REFERENCES `imatrade-registr`.`Countries` (`IDCountry`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_entities_Regions`
    FOREIGN KEY (`IDRegion`)
    REFERENCES `imatrade-registr`.`Regions` (`IDRegion`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_entities_Organisations`
    FOREIGN KEY (`IDOrganisation`)
    REFERENCES `imatrade-registr`.`Organisations` (`IDOrganisation`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

-- ----------------------------------------------------------------------------
-- Table imatrade-registr.registers
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `imatrade-registr`.`registers` (
    `IDRegister` INT NOT NULL,
    `Code` VARCHAR(50) CHARACTER SET 'utf8mb4' NOT NULL,
    `DateReg` DATETIME NOT NULL,
    `Desc` VARCHAR(2000) CHARACTER SET 'utf8mb4' NULL,
    `IDEntity` INT NOT NULL,
    `IDState` TINYINT UNSIGNED NOT NULL,
    `NameSubject` VARCHAR(150) CHARACTER SET 'utf8mb4' NOT NULL,
    `CodeType` VARCHAR(30) CHARACTER SET 'utf8mb4' NOT NULL,
    `RegNumber` INT NULL,
    `DateChangeState` TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP,
    `SerialNumber` VARCHAR(100) CHARACTER SET 'utf8mb4' NULL,
    `IDGroup` INT NOT NULL,
  PRIMARY KEY (`IDRegister`),
  INDEX `FK_registers_entities` (`IDEntity` ASC) VISIBLE,
  INDEX `FK_registers_states` (`IDState` ASC) VISIBLE,
  UNIQUE INDEX `UK_registers` (`IDEntity` ASC, `RegNumber` ASC) VISIBLE,
  INDEX `IX_registers` (`SerialNumber` ASC, `Code` ASC, `IDState` ASC) VISIBLE,
  CONSTRAINT `FK_registers_states`
    FOREIGN KEY (`IDState`)
    REFERENCES `imatrade-registr`.`states` (`IDState`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_registers_entities`
    FOREIGN KEY (`IDEntity`)
    REFERENCES `imatrade-registr`.`entities` (`IDEntity`)
    ON DELETE CASCADE
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_registers_group`
    FOREIGN KEY (`IDGroup`)
    REFERENCES `imatrade-registr`.`Groups` (`IDGroup`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

-- ----------------------------------------------------------------------------
-- Table imatrade-registr.roles
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `imatrade-registr`.`roles` (
    `IDRole` INT NOT NULL,
    `NameRole` VARCHAR(20) CHARACTER SET 'utf8mb4' NOT NULL,
    `Note` VARCHAR(500) CHARACTER SET 'utf8mb4' NULL,
  PRIMARY KEY (`IDRole`));

-- ----------------------------------------------------------------------------
-- Table imatrade-registr.states
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `imatrade-registr`.`states` (
    `IDState` TINYINT UNSIGNED NOT NULL,
    `NameState` VARCHAR(50) CHARACTER SET 'utf8mb4' NOT NULL,
  PRIMARY KEY (`IDState`));

-- ----------------------------------------------------------------------------
-- Table imatrade-registr.settings
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `imatrade-registr`.`settings` (
    `Key` VARCHAR(50) CHARACTER SET 'utf8mb4' NOT NULL,
    `Value` text CHARACTER SET 'utf8mb4' NULL,
    `IDLanguage` TINYINT UNSIGNED NULL,
  UNIQUE INDEX `PK_settings` (`Key` ASC, `IDLanguage` ASC),
  CONSTRAINT `fk_settings_language`
    FOREIGN KEY (`IDLanguage`)
    REFERENCES `imatrade-registr`.`Languages` (`IDLanguage`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

-- ----------------------------------------------------------------------------
-- Table imatrade-registr.ActivateEntities
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `imatrade-registr`.`ActivateEntities` (
    `IDActivateEntity` INT NOT NULL,
    `IDEntity` INT NOT NULL,
    `DateExpired` DATETIME NOT NULL,
    `Code` VARCHAR(50) CHARACTER SET 'utf8mb4' NOT NULL,
    `DateCreate` DATETIME NOT NULL,
  PRIMARY KEY (`IDActivateEntity`),
  UNIQUE INDEX `UK_ActivateEntities` (`Code` ASC) VISIBLE,
  UNIQUE INDEX `UL_ActivateEntities_Entity` (`IDEntity` ASC) VISIBLE,
  CONSTRAINT `FK_ActivateEntities_entities`
    FOREIGN KEY (`IDEntity`)
    REFERENCES `imatrade-registr`.`entities` (`IDEntity`)
    ON DELETE CASCADE
    ON UPDATE NO ACTION);

-- ----------------------------------------------------------------------------
-- Table imatrade-registr.Countries
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `imatrade-registr`.`Countries` (
    `IDCountry` INT NOT NULL,
    `CountryCode` VARCHAR(3) CHARACTER SET 'utf8mb4' NOT NULL,
    `IDLanguage` TINYINT UNSIGNED NOT NULL,
  PRIMARY KEY (`IDCountry`),
  UNIQUE INDEX `UK_countries` (`CountryCode` ASC) VISIBLE,
  CONSTRAINT `FK_countries_language`
    FOREIGN KEY (`IDLanguage`)
    REFERENCES `imatrade-registr`.`Languages` (`IDLanguage`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

-- ----------------------------------------------------------------------------
-- Table imatrade-registr.Regions
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `imatrade-registr`.`Regions` (
    `IDRegion` INT NOT NULL,
    `IDCountry` INT NOT NULL,
    `RegionName` VARCHAR(120) CHARACTER SET 'utf8mb4' NOT NULL,
  PRIMARY KEY (`IDRegion`),
  CONSTRAINT `FK_Regions_Countries`
    FOREIGN KEY (`IDCountry`)
    REFERENCES `imatrade-registr`.`Countries` (`IDCountry`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

-- ----------------------------------------------------------------------------
-- Table imatrade-registr.Organisations
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `imatrade-registr`.`Organisations` (
    `IDOrganisation` INT NOT NULL,
    `Name` VARCHAR(250) CHARACTER SET 'utf8mb4' NOT NULL,
    `Code` VARCHAR(20) CHARACTER SET 'utf8mb4' NOT NULL,
    `TypeOrg` SMALLINT NOT NULL,
    `Active` TINYINT(1) NOT NULL,
    `City` VARCHAR(150) CHARACTER SET 'utf8mb4' NOT NULL,
    `Street` VARCHAR(150) CHARACTER SET 'utf8mb4' NOT NULL,
    `Zip` VARCHAR(10) CHARACTER SET 'utf8mb4' NOT NULL,
    `IDCountry` INT NOT NULL,
    `Phones` VARCHAR(250) CHARACTER SET 'utf8mb4' NULL,
    `Email` VARCHAR(150) CHARACTER SET 'utf8mb4' NOT NULL,
    `Description` VARCHAR(1000) CHARACTER SET 'utf8mb4' NULL,
    `DateCreate` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    `SecureKey` VARCHAR(50) CHARACTER SET 'utf8mb4' NOT NULL,
    `WebApi` TINYINT(1) NOT NULL DEFAULT 0,
    `SwVersion` VARCHAR(20) CHARACTER SET 'utf8mb4' NULL,
    `AllowRestore` TINYINT(1) NULL,
    `Deleted` TINYINT(1) NOT NULL DEFAULT 0,
    `DateDeleted` DATETIME NULL,
  PRIMARY KEY (`IDOrganisation`),
  UNIQUE INDEX `UK_Organisations_Name` (`Name` ASC) VISIBLE,
  UNIQUE INDEX `UK_Organisations_Email` (`Email` ASC) VISIBLE,
  UNIQUE INDEX `UK_Organisations_Code` (`Code` ASC) VISIBLE,
  CONSTRAINT `FK_Organisations_Countries`
    FOREIGN KEY (`IDCountry`)
    REFERENCES `imatrade-registr`.`Countries` (`IDCountry`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

-- ----------------------------------------------------------------------------
-- Table imatrade-registr.Pages
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `imatrade-registr`.`Pages` (
    `IDPage` INT NOT NULL,
    `PageType` TINYINT UNSIGNED NOT NULL,
    `IDLanguage` TINYINT UNSIGNED NOT NULL,
    `Title` VARCHAR(100) CHARACTER SET 'utf8mb4' NOT NULL,
    `Content` text CHARACTER SET 'utf8mb4' NOT NULL,
    `PublishedFrom` DATETIME NOT NULL,
    `PublishedTo` DATETIME NULL,
    `Created` DATETIME NOT NULL,
    `Edited` DATETIME NOT NULL,
    `CreatedBy` INT NOT NULL,
    `EditedBy` INT NOT NULL,
  PRIMARY KEY (`IDPage`),
  CONSTRAINT `FK_pages_languages`
    FOREIGN KEY (`IDLanguage`)
    REFERENCES `imatrade-registr`.`Languages` (`IDLanguage`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_pages_entities_createdby`
    FOREIGN KEY (`CreatedBy`)
    REFERENCES `imatrade-registr`.`entities` (`IDEntity`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_pages_entities_editedby`
    FOREIGN KEY (`EditedBy`)
    REFERENCES `imatrade-registr`.`entities` (`IDEntity`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

-- ----------------------------------------------------------------------------
-- Table imatrade-registr.Preparations
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `imatrade-registr`.`Preparations` (
    `IDPreparation` INT NOT NULL,
    `IDOrganisation` INT NOT NULL,
    `DateImport` DATETIME NOT NULL,
    `State` SMALLINT NOT NULL,
    `Data` TEXT NOT NULL,
    `DateStateChange` DATETIME NOT NULL,
    `GuidBatch` VARCHAR(64) NOT NULL,
    `Description` VARCHAR(1000) CHARACTER SET 'utf8mb4' NULL,
    `NrBatch` INT NOT NULL,
    `DataSync` TEXT NULL,
    `VersionXml` INT NOT NULL,
  PRIMARY KEY (`IDPreparation`),
  UNIQUE INDEX `UK_Preparations_Guid` (`GuidBatch` ASC) VISIBLE,
  CONSTRAINT `FK_Preparations_Organisations`
    FOREIGN KEY (`IDOrganisation`)
    REFERENCES `imatrade-registr`.`Organisations` (`IDOrganisation`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

-- ----------------------------------------------------------------------------
-- Table imatrade-registr.Photos
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `imatrade-registr`.`Photos` (
    `IDPhoto` INT NOT NULL,
    `IDRegister` INT NOT NULL,
    `ContentType` VARCHAR(30) CHARACTER SET 'utf8mb4' NOT NULL,
    `Note` VARCHAR(255) CHARACTER SET 'utf8mb4' NULL,
    `HashCode` VARCHAR(128) CHARACTER SET 'utf8mb4' NOT NULL,
    `Index` INT NOT NULL,
    `ToAzure` DATETIME NULL,
    `State` VARCHAR(10) CHARACTER SET 'utf8mb4' NULL,
    `FileSize` BIGINT NULL,
    `ToAzureThumb` DATETIME NULL,
  PRIMARY KEY (`IDPhoto`),
  CONSTRAINT `FK_Photos_Register`
    FOREIGN KEY (`IDRegister`)
    REFERENCES `imatrade-registr`.`registers` (`IDRegister`)
    ON DELETE CASCADE
    ON UPDATE NO ACTION);

-- ----------------------------------------------------------------------------
-- Table imatrade-registr.Logs
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `imatrade-registr`.`Logs` (
    `IDLog` BIGINT NOT NULL,
    `DateCreate` DATETIME NOT NULL,
    `LogLevel` TINYINT UNSIGNED NOT NULL,
    `Event` VARCHAR(50) CHARACTER SET 'utf8mb4' NULL,
    `IP` VARCHAR(30) CHARACTER SET 'utf8mb4' NULL,
    `UserAgent` VARCHAR(255) CHARACTER SET 'utf8mb4' NULL,
    `Msg` VARCHAR(500) CHARACTER SET 'utf8mb4' NOT NULL,
    `Data` VARCHAR(3000) CHARACTER SET 'utf8mb4' NULL,
    `IDEntity` INT NULL,
  PRIMARY KEY (`IDLog`),
  CONSTRAINT `FK_Logs_Entities`
    FOREIGN KEY (`IDEntity`)
    REFERENCES `imatrade-registr`.`entities` (`IDEntity`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

-- ----------------------------------------------------------------------------
-- Table imatrade-registr.EntitySettings
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `imatrade-registr`.`EntitySettings` (
    `IDEntitySetting` INT NOT NULL,
    `IDEntity` INT NOT NULL,
    `Key` VARCHAR(20) CHARACTER SET 'utf8mb4' NOT NULL,
    `Value` TEXT NULL,
  PRIMARY KEY (`IDEntitySetting`),
  CONSTRAINT `FK_EntitySettings_entities`
    FOREIGN KEY (`IDEntity`)
    REFERENCES `imatrade-registr`.`entities` (`IDEntity`)
    ON DELETE CASCADE
    ON UPDATE NO ACTION);

-- ----------------------------------------------------------------------------
-- Table imatrade-registr.RegisterHistories
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `imatrade-registr`.`RegisterHistories` (
    `IDRegisterHistory` INT NOT NULL,
    `IDLog` BIGINT NOT NULL,
    `IDRegister` INT NOT NULL,
  PRIMARY KEY (`IDRegisterHistory`),
  CONSTRAINT `FK_RegisterHistories_Logs`
    FOREIGN KEY (`IDLog`)
    REFERENCES `imatrade-registr`.`Logs` (`IDLog`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_RegisterHistories_Registers`
    FOREIGN KEY (`IDRegister`)
    REFERENCES `imatrade-registr`.`registers` (`IDRegister`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

-- ----------------------------------------------------------------------------
-- Table imatrade-registr.NotifySources
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `imatrade-registr`.`NotifySources` (
    `IDNotifySource` INT NOT NULL,
    `Name` VARCHAR(50) CHARACTER SET 'utf8mb4' NOT NULL,
    `Description` VARCHAR(500) CHARACTER SET 'utf8mb4' NULL,
    `Active` TINYINT(1) NOT NULL,
  PRIMARY KEY (`IDNotifySource`),
  UNIQUE INDEX `UK_NotifySources` (`Name` ASC) VISIBLE);

-- ----------------------------------------------------------------------------
-- Table imatrade-registr.NotifyRecipients
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `imatrade-registr`.`NotifyRecipients` (
    `IDNotifyRecipient` INT NOT NULL,
    `IDNotifySource` INT NOT NULL,
    `IDEntity` INT NOT NULL,
    `AsEmail` TINYINT(1) NOT NULL,
    `AsSms` TINYINT(1) NOT NULL,
    `LastDateNotified` DATETIME NULL,
  PRIMARY KEY (`IDNotifyRecipient`),
  UNIQUE INDEX `UK_NotifyRecipients` (`IDNotifySource` ASC, `IDEntity` ASC) VISIBLE,
  CONSTRAINT `FK_NotifyRecipients_NotifySources`
    FOREIGN KEY (`IDNotifySource`)
    REFERENCES `imatrade-registr`.`NotifySources` (`IDNotifySource`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_NotifyRecipients_Entities`
    FOREIGN KEY (`IDEntity`)
    REFERENCES `imatrade-registr`.`entities` (`IDEntity`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

-- ----------------------------------------------------------------------------
-- Table imatrade-registr.Groups
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `imatrade-registr`.`Groups` (
    `IDGroup` INT NOT NULL,
    `Code` VARCHAR(15) CHARACTER SET 'utf8mb4' NOT NULL,
    `KeyResource` VARCHAR(50) CHARACTER SET 'utf8mb4' NOT NULL,
    `Active` TINYINT(1) NOT NULL,
    `IndexOrder` TINYINT UNSIGNED NOT NULL,
    `Description` VARCHAR(1000) CHARACTER SET 'utf8mb4' NULL,
  PRIMARY KEY (`IDGroup`),
  UNIQUE INDEX `uk_groups_code` (`Code` ASC) VISIBLE);

-- ----------------------------------------------------------------------------
-- Table imatrade-registr.Languages
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `imatrade-registr`.`Languages` (
    `IDLanguage` TINYINT UNSIGNED NOT NULL,
    `Code` VARCHAR(3) CHARACTER SET 'utf8mb4' NOT NULL,
    `Active` TINYINT(1) NOT NULL,
  PRIMARY KEY (`IDLanguage`),
  UNIQUE INDEX `uk_languages_code` (`Code` ASC) VISIBLE);

-- ----------------------------------------------------------------------------
-- Trigger imatrade-registr.tr_Registers_Modified
-- ----------------------------------------------------------------------------
-- DELIMITER $$
-- USE `imatrade-registr`$$
-- 

-- CREATE TRIGGER tr_Registers_Modified

--    ON Registers

--    AFTER UPDATE

-- AS BEGIN

--     SET NOCOUNT ON;

--     IF UPDATE (IDState) 

--     begin           

--         UPDATE Registers 

--         SET DateChangeState = GETDATE()

--         FROM registers a 

--         INNER JOIN Inserted b ON a.IDRegister = b.IDRegister

--         INNER JOIN deleted c ON a.IDRegister = c.IDRegister

--         WHERE a.IDState <> c.IDState

--     end 

-- END

-- 

-- ;
SET FOREIGN_KEY_CHECKS = 1;





CREATE view wEntities as
select
    a.IDEntity,
    a.Active,
    a.IsFirm,
    concat(a.SurnameEntity, ' ', a.NameEntity) as FullName,
    a.FirmName,
    concat(a.Street, ', ', a.City, ' ', a.Zip) as `Address`,
        a.IDRole,
    a.DateCreate,
    a.DateActivated,
    a.Email,
    a.IDCountry,
    a.IDRegion,
    b.NameRole,
    c.CountryCode,
    RegionName,
    a.IDOrganisation,
    e.Name as OrganisationName
from entities a
         inner join roles b on a.IDRole = b.IDRole
         inner join Countries c on a.IDCountry = c.IDCountry
         left outer join Regions d on a.IDRegion = d.IDRegion
         left outer join Organisations e on a.IDOrganisation = e.IDOrganisation
where a.deleted <> 1;


create view wNotifyRecipients as
select a.*,
       b.Name as SourceName, b.Active as SourceActive,
       c.Active as EntityActive, c.Email as EntityEmail
from NotifyRecipients a
         inner join NotifySources b on a.IDNotifySource = b.IDNotifySource
         inner join entities c on a.IDEntity = c.IDEntity;

CREATE view wPhotos as
select p.IDPhoto, p.Index, p.State, p.ToAzure, p.FileSize,  r.IDRegister, r.NameSubject, r.RegNumber, r.SerialNumber, e.IDEntity,
       concat(e.SurnameEntity, ' ', e.NameEntity) as Entity,
       concat(e.SurnameEntity, ' ', e.NameEntity) as Name,
       p.ToAzureThumb,
       concat(e.`IDEntity`, '-', r.RegNumber, '-', p.`Index`, '.dat') as FileName
from Photos p
         inner join registers r on p.IDRegister = r.IDRegister
         INNER JOIN entities e on r.IDEntity = e.IDEntity
-- LEFT OUTER JOIN Organisations o on o.IDOrganisation  = e.IDOrganisation
;

CREATE view wPreparations as
select a.*, b.Name, b.Code, b.Active, b.TypeOrg
from Preparations a
         inner join Organisations b on a.IDOrganisation = b.IDOrganisation;

CREATE view wRegisterHistories
as
select
    a.IDRegisterHistory,
    a.IDLog,
    a.IDRegister,
    b.DateCreate,
    b.LogLevel,
    b.Event,
    b.Msg,
    b.Data,
    b.IDEntity,
    c.RegNumber,
    c.NameSubject,
    concat(d.SurnameEntity, ' ', d.NameEntity) as FullName,
    d.IDRole,
    e.Name as OrgName,
    f.Code as GroupCode,
    f.KeyResource as GroupResKey
from RegisterHistories a
         inner join Logs b on a.IDLog = b.IDLog
         inner join registers c on a.IDRegister = c.IDRegister
         inner join entities d on b.IDEntity = d.IDEntity
         inner join entities dd on c.IDEntity = dd.IDEntity
         left outer join Organisations e on dd.IDOrganisation = e.IDOrganisation
         inner join Groups f on c.IDGroup = f.IDGroup;

CREATE view wRegisters as
select
    a.IDRegister,
    a.Code,
    a.RegNumber,
    a.DateReg,
    a.Desc,
    a.IDEntity,
    a.IDState,
    a.NameSubject,
    a.CodeType,
    a.DateChangeState,
    a.SerialNumber,
    a.IDGroup,
    gr.Code as GroupCode,
    gr.Active as GroupActive,
    gr.KeyResource as GroupKeyResource,
    b.SurnameEntity + ' ' + b.NameEntity as Fullname,
    b.FirmName,
    concat(b.Street, ', ', b.City, ' ', b.Zip) as Address,
    b.City,
    b.IDCountry,
    b.IDRegion,
    c.CountryCode,
    RegionName,
    e.IDOrganisation,
    e.Name as OrgName,
    e.TypeOrg,
    (select IDPhoto from Photos where Photos.IDRegister = a.IDRegister order by Photos.`Index` limit 1) as IDPhoto
from registers a
         inner join entities b on a.IDEntity = b.IDEntity
         inner join Countries c on b.IDCountry = c.IDCountry
         inner join Groups gr on a.IDGroup = gr.IDGroup
         left outer join Regions d on b.IDRegion = d.IDRegion
         left outer join Organisations e on b.IDOrganisation = e.IDOrganisation;