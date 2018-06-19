namespace ado_hw10.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataBase : DbContext
    {
        public DataBase()
            : base("name=DataBase")
        {
        }

        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<curs> curs { get; set; }
        public virtual DbSet<newEquipment> newEquipment { get; set; }
        public virtual DbSet<TableEvaluationPriority> TableEvaluationPriority { get; set; }
        public virtual DbSet<TableEvaluationSysStatus> TableEvaluationSysStatus { get; set; }
        public virtual DbSet<TableExchangeRate> TableExchangeRate { get; set; }
        public virtual DbSet<TablesCurrency> TablesCurrency { get; set; }
        public virtual DbSet<TablesManufacturer> TablesManufacturer { get; set; }
        public virtual DbSet<TablesModel> TablesModel { get; set; }
        public virtual DbSet<TablesSNPrefix> TablesSNPrefix { get; set; }
        public virtual DbSet<Timer> Timer { get; set; }
        public virtual DbSet<TrackEvaluation> TrackEvaluation { get; set; }
        public virtual DbSet<TrackEvaluationPart> TrackEvaluationPart { get; set; }
        public virtual DbSet<TrackMeter> TrackMeter { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>()
                .Property(e => e.IP)
                .IsUnicode(false);

            modelBuilder.Entity<curs>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<newEquipment>()
                .HasMany(e => e.TrackMeter)
                .WithRequired(e => e.newEquipment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TableEvaluationPriority>()
                .HasMany(e => e.TrackEvaluation)
                .WithOptional(e => e.TableEvaluationPriority)
                .HasForeignKey(e => e.intPriority);

            modelBuilder.Entity<TablesManufacturer>()
                .HasMany(e => e.newEquipment)
                .WithRequired(e => e.TablesManufacturer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TablesModel>()
                .HasMany(e => e.newEquipment)
                .WithRequired(e => e.TablesModel)
                .WillCascadeOnDelete(false);
        }
    }
}
