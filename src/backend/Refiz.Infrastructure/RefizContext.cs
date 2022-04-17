using Refiz.Domain;
using Refiz.Domain.AggregatesModel.EntityAggregate;
using Refiz.Domain.AggregatesModel.RegisterAggregate;
using Refiz.Domain.Views;

namespace Refiz.Infrastructure
{
    public partial class RefizContext : DbContext
    {
        public RefizContext()
        {
        }

        public RefizContext(DbContextOptions<RefizContext> options)
            : base(options)
        {
        }

        // public virtual DbSet<ActivateEntity> ActivateEntities { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Entity> Entities { get; set; } = null!;
        // public virtual DbSet<EntitySetting> EntitySettings { get; set; } = null!;
        // public virtual DbSet<Group> Groups { get; set; } = null!;
        public virtual DbSet<Language> Languages { get; set; } = null!;
        // public virtual DbSet<Log> Logs { get; set; } = null!;
        // public virtual DbSet<NotifyRecipient> NotifyRecipients { get; set; } = null!;
        // public virtual DbSet<NotifySource> NotifySources { get; set; } = null!;
        // public virtual DbSet<Organisation> Organisations { get; set; } = null!;
        // public virtual DbSet<Photo> Photos { get; set; } = null!;
        // public virtual DbSet<Preparation> Preparations { get; set; } = null!;
        // public virtual DbSet<Region> Regions { get; set; } = null!;
        // public virtual DbSet<Register> Registers { get; set; } = null!;
        // public virtual DbSet<RegisterHistory> RegisterHistories { get; set; } = null!;
        // public virtual DbSet<Role> Roles { get; set; } = null!;
        // public virtual DbSet<Setting> Settings { get; set; } = null!;
        // public virtual DbSet<State> States { get; set; } = null!;
        // public virtual DbSet<WEntity> WEntities { get; set; } = null!;
        // public virtual DbSet<WNotifyRecipient> WNotifyRecipients { get; set; } = null!;
        // public virtual DbSet<WPreparation> WPreparations { get; set; } = null!;
        // public virtual DbSet<WRegister> WRegisters { get; set; } = null!;
        // public virtual DbSet<WRegisterHistory> WRegisterHistories { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Czech_CI_AS");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RefizContext).Assembly);
            
            /* ------------------------ */
            

            modelBuilder.Entity<ActivateEntity>(entity =>
            {
                entity.HasKey(e => e.IdactivateEntity);

                entity.HasIndex(e => e.Code, "UK_ActivateEntities")
                    .IsUnique();

                entity.HasIndex(e => e.Identity, "UL_ActivateEntities_Entity")
                    .IsUnique();

                entity.Property(e => e.IdactivateEntity).HasColumnName("IDActivateEntity");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.DateCreate).HasColumnType("datetime");

                entity.Property(e => e.DateExpired).HasColumnType("datetime");

                entity.Property(e => e.Identity).HasColumnName("IDEntity");

                entity.HasOne(d => d.IdentityNavigation)
                    .WithOne(p => p.ActivateEntity)
                    .HasForeignKey<ActivateEntity>(d => d.Identity)
                    .HasConstraintName("FK_ActivateEntities_entities");
            });

            modelBuilder.Entity<EntitySetting>(entity =>
            {
                entity.HasKey(e => e.IdentitySetting);

                entity.Property(e => e.IdentitySetting).HasColumnName("IDEntitySetting");

                entity.Property(e => e.Identity).HasColumnName("IDEntity");

                entity.Property(e => e.Key).HasMaxLength(20);

                entity.Property(e => e.Value).HasColumnType("xml");

                entity.HasOne(d => d.IdentityNavigation)
                    .WithMany(p => p.EntitySettings)
                    .HasForeignKey(d => d.Identity)
                    .HasConstraintName("FK_EntitySettings_entities");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasKey(e => e.Idgroup)
                    .HasName("pk_groups");

                entity.HasIndex(e => e.Code, "uk_groups_code")
                    .IsUnique();

                entity.Property(e => e.Idgroup).HasColumnName("IDGroup");

                entity.Property(e => e.Code).HasMaxLength(15);

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.KeyResource).HasMaxLength(50);
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasKey(e => e.Idlog);

                entity.Property(e => e.Idlog).HasColumnName("IDLog");

                entity.Property(e => e.Data).HasMaxLength(3000);

                entity.Property(e => e.DateCreate).HasColumnType("datetime");

                entity.Property(e => e.Event).HasMaxLength(50);

                entity.Property(e => e.Identity).HasColumnName("IDEntity");

                entity.Property(e => e.Ip)
                    .HasMaxLength(30)
                    .HasColumnName("IP");

                entity.Property(e => e.Msg).HasMaxLength(500);

                entity.Property(e => e.UserAgent).HasMaxLength(255);

                entity.HasOne(d => d.IdentityNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Identity)
                    .HasConstraintName("FK_Logs_Entities");
            });

            modelBuilder.Entity<NotifyRecipient>(entity =>
            {
                entity.HasKey(e => e.IdnotifyRecipient);

                entity.HasIndex(e => new { e.IdnotifySource, e.Identity }, "UK_NotifyRecipients")
                    .IsUnique();

                entity.Property(e => e.IdnotifyRecipient).HasColumnName("IDNotifyRecipient");

                entity.Property(e => e.Identity).HasColumnName("IDEntity");

                entity.Property(e => e.IdnotifySource).HasColumnName("IDNotifySource");

                entity.Property(e => e.LastDateNotified).HasColumnType("datetime");

                entity.HasOne(d => d.IdentityNavigation)
                    .WithMany(p => p.NotifyRecipients)
                    .HasForeignKey(d => d.Identity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NotifyRecipients_Entities");

                entity.HasOne(d => d.IdnotifySourceNavigation)
                    .WithMany(p => p.NotifyRecipients)
                    .HasForeignKey(d => d.IdnotifySource)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NotifyRecipients_NotifySources");
            });

            modelBuilder.Entity<NotifySource>(entity =>
            {
                entity.HasKey(e => e.IdnotifySource);

                entity.HasIndex(e => e.Name, "UK_NotifySources")
                    .IsUnique();

                entity.Property(e => e.IdnotifySource).HasColumnName("IDNotifySource");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Organisation>(entity =>
            {
                entity.HasKey(e => e.Idorganisation);

                entity.HasIndex(e => e.Code, "UK_Organisations_Code")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UK_Organisations_Email")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "UK_Organisations_Name")
                    .IsUnique();

                entity.Property(e => e.Idorganisation).HasColumnName("IDOrganisation");

                entity.Property(e => e.City).HasMaxLength(150);

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.DateCreate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateDeleted).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.Idcountry).HasColumnName("IDCountry");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.Phones).HasMaxLength(250);

                entity.Property(e => e.SecureKey).HasMaxLength(50);

                entity.Property(e => e.Street).HasMaxLength(150);

                entity.Property(e => e.SwVersion).HasMaxLength(20);

                entity.Property(e => e.Zip).HasMaxLength(10);

                entity.HasOne(d => d.IdcountryNavigation)
                    .WithMany(p => p.Organisations)
                    .HasForeignKey(d => d.Idcountry)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Organisations_Countries");
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.HasKey(e => e.Idphoto);

                entity.Property(e => e.Idphoto).HasColumnName("IDPhoto");

                entity.Property(e => e.ContentType).HasMaxLength(30);

                entity.Property(e => e.HashCode).HasMaxLength(128);

                entity.Property(e => e.Idregister).HasColumnName("IDRegister");

                entity.Property(e => e.Note).HasMaxLength(255);

                entity.HasOne(d => d.IdregisterNavigation)
                    .WithMany(p => p.Photos)
                    .HasForeignKey(d => d.Idregister)
                    .HasConstraintName("FK_Photos_Register");
            });

            modelBuilder.Entity<Preparation>(entity =>
            {
                entity.HasKey(e => e.Idpreparation);

                entity.HasIndex(e => e.GuidBatch, "UK_Preparations_Guid")
                    .IsUnique();

                entity.Property(e => e.Idpreparation).HasColumnName("IDPreparation");

                entity.Property(e => e.Data).HasColumnType("xml");

                entity.Property(e => e.DataSync).HasColumnType("xml");

                entity.Property(e => e.DateImport).HasColumnType("datetime");

                entity.Property(e => e.DateStateChange).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.Idorganisation).HasColumnName("IDOrganisation");

                entity.HasOne(d => d.IdorganisationNavigation)
                    .WithMany(p => p.Preparations)
                    .HasForeignKey(d => d.Idorganisation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Preparations_Organisations");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasKey(e => e.Idregion)
                    .HasName("PK_regions");

                entity.Property(e => e.Idregion).HasColumnName("IDRegion");

                entity.Property(e => e.Idcountry).HasColumnName("IDCountry");

                entity.Property(e => e.RegionName).HasMaxLength(120);

                entity.HasOne(d => d.IdcountryNavigation)
                    .WithMany(p => p.Regions)
                    .HasForeignKey(d => d.Idcountry)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Regions_Countries");
            });

            modelBuilder.Entity<Register>(entity =>
            {
                entity.HasKey(e => e.Idregister);

                entity.ToTable("registers");

                entity.HasIndex(e => e.Identity, "FK_registers_entities");

                entity.HasIndex(e => e.Idstate, "FK_registers_states");

                entity.HasIndex(e => new { e.Identity, e.RegNumber }, "UK_registers")
                    .IsUnique();

                entity.Property(e => e.Idregister).HasColumnName("IDRegister");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CodeType).HasMaxLength(30);

                entity.Property(e => e.DateChangeState)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateReg).HasColumnType("datetime");

                entity.Property(e => e.Desc).HasMaxLength(2000);

                entity.Property(e => e.Identity).HasColumnName("IDEntity");

                entity.Property(e => e.Idgroup).HasColumnName("IDGroup");

                entity.Property(e => e.Idstate).HasColumnName("IDState");

                entity.Property(e => e.NameSubject).HasMaxLength(150);

                entity.Property(e => e.SerialNumber).HasMaxLength(100);

                entity.HasOne(d => d.IdentityNavigation)
                    .WithMany(p => p.Registers)
                    .HasForeignKey(d => d.Identity)
                    .HasConstraintName("FK_registers_entities");

                entity.HasOne(d => d.IdgroupNavigation)
                    .WithMany(p => p.Registers)
                    .HasForeignKey(d => d.Idgroup)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_registers_group");

                entity.HasOne(d => d.IdstateNavigation)
                    .WithMany(p => p.Registers)
                    .HasForeignKey(d => d.Idstate)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_registers_states");
            });

            modelBuilder.Entity<RegisterHistory>(entity =>
            {
                entity.HasKey(e => e.IdregisterHistory);

                entity.Property(e => e.IdregisterHistory).HasColumnName("IDRegisterHistory");

                entity.Property(e => e.Idlog).HasColumnName("IDLog");

                entity.Property(e => e.Idregister).HasColumnName("IDRegister");

                entity.HasOne(d => d.IdlogNavigation)
                    .WithMany(p => p.RegisterHistories)
                    .HasForeignKey(d => d.Idlog)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RegisterHistories_Logs");

                entity.HasOne(d => d.IdregisterNavigation)
                    .WithMany(p => p.RegisterHistories)
                    .HasForeignKey(d => d.Idregister)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RegisterHistories_Registers");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Idrole);

                entity.ToTable("roles");

                entity.Property(e => e.Idrole)
                    .ValueGeneratedNever()
                    .HasColumnName("IDRole");

                entity.Property(e => e.NameRole).HasMaxLength(20);

                entity.Property(e => e.Note).HasMaxLength(500);
            });

            modelBuilder.Entity<Setting>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("settings");

                entity.HasIndex(e => new { e.Key, e.Idlanguage }, "PK_settings")
                    .IsUnique();

                entity.Property(e => e.Idlanguage).HasColumnName("IDLanguage");

                entity.Property(e => e.Key).HasMaxLength(50);

                entity.HasOne(d => d.IdlanguageNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Idlanguage)
                    .HasConstraintName("fk_settings_language");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasKey(e => e.Idstate);

                entity.ToTable("states");

                entity.Property(e => e.Idstate).HasColumnName("IDState");

                entity.Property(e => e.NameState).HasMaxLength(50);
            });

            modelBuilder.Entity<WEntity>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("wEntities");

                entity.Property(e => e.Address).HasMaxLength(113);

                entity.Property(e => e.CountryCode).HasMaxLength(3);

                entity.Property(e => e.DateActivated).HasColumnType("datetime");

                entity.Property(e => e.DateCreate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.FirmName).HasMaxLength(150);

                entity.Property(e => e.FullName).HasMaxLength(301);

                entity.Property(e => e.Idcountry).HasColumnName("IDCountry");

                entity.Property(e => e.Identity).HasColumnName("IDEntity");

                entity.Property(e => e.Idorganisation).HasColumnName("IDOrganisation");

                entity.Property(e => e.Idregion).HasColumnName("IDRegion");

                entity.Property(e => e.Idrole).HasColumnName("IDRole");

                entity.Property(e => e.NameRole).HasMaxLength(20);

                entity.Property(e => e.OrganisationName).HasMaxLength(250);

                entity.Property(e => e.RegionName).HasMaxLength(120);
            });

            modelBuilder.Entity<WNotifyRecipient>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("wNotifyRecipients");

                entity.Property(e => e.EntityEmail).HasMaxLength(150);

                entity.Property(e => e.Identity).HasColumnName("IDEntity");

                entity.Property(e => e.IdnotifyRecipient).HasColumnName("IDNotifyRecipient");

                entity.Property(e => e.IdnotifySource).HasColumnName("IDNotifySource");

                entity.Property(e => e.LastDateNotified).HasColumnType("datetime");

                entity.Property(e => e.SourceName).HasMaxLength(50);
            });

            modelBuilder.Entity<WPreparation>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("wPreparations");

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Data).HasColumnType("xml");

                entity.Property(e => e.DataSync).HasColumnType("xml");

                entity.Property(e => e.DateImport).HasColumnType("datetime");

                entity.Property(e => e.DateStateChange).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.Idorganisation).HasColumnName("IDOrganisation");

                entity.Property(e => e.Idpreparation).HasColumnName("IDPreparation");

                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<WRegister>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("wRegisters");

                entity.Property(e => e.Address).HasMaxLength(113);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CodeType).HasMaxLength(30);

                entity.Property(e => e.CountryCode).HasMaxLength(3);

                entity.Property(e => e.DateChangeState).HasColumnType("datetime");

                entity.Property(e => e.DateReg).HasColumnType("datetime");

                entity.Property(e => e.Desc).HasMaxLength(1000);

                entity.Property(e => e.FirmName).HasMaxLength(150);

                entity.Property(e => e.Fullname).HasMaxLength(301);

                entity.Property(e => e.GroupCode).HasMaxLength(15);

                entity.Property(e => e.GroupKeyResource).HasMaxLength(50);

                entity.Property(e => e.Idcountry).HasColumnName("IDCountry");

                entity.Property(e => e.Identity).HasColumnName("IDEntity");

                entity.Property(e => e.Idgroup).HasColumnName("IDGroup");

                entity.Property(e => e.Idorganisation).HasColumnName("IDOrganisation");

                entity.Property(e => e.Idphoto).HasColumnName("IDPhoto");

                entity.Property(e => e.Idregion).HasColumnName("IDRegion");

                entity.Property(e => e.Idregister).HasColumnName("IDRegister");

                entity.Property(e => e.Idstate).HasColumnName("IDState");

                entity.Property(e => e.NameSubject).HasMaxLength(150);

                entity.Property(e => e.OrgName).HasMaxLength(250);

                entity.Property(e => e.RegionName).HasMaxLength(120);

                entity.Property(e => e.SerialNumber).HasMaxLength(100);
            });

            modelBuilder.Entity<WRegisterHistory>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("wRegisterHistories");

                entity.Property(e => e.Data).HasMaxLength(3000);

                entity.Property(e => e.DateCreate).HasColumnType("datetime");

                entity.Property(e => e.Event).HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(301);

                entity.Property(e => e.GroupCode).HasMaxLength(15);

                entity.Property(e => e.GroupResKey).HasMaxLength(50);

                entity.Property(e => e.Identity).HasColumnName("IDEntity");

                entity.Property(e => e.Idlog).HasColumnName("IDLog");

                entity.Property(e => e.Idregister).HasColumnName("IDRegister");

                entity.Property(e => e.IdregisterHistory).HasColumnName("IDRegisterHistory");

                entity.Property(e => e.Idrole).HasColumnName("IDRole");

                entity.Property(e => e.Msg).HasMaxLength(500);

                entity.Property(e => e.NameSubject).HasMaxLength(150);

                entity.Property(e => e.OrgName).HasMaxLength(250);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
