using Microsoft.EntityFrameworkCore;
using RSoft.Allocate.Infra.Configurations;
using RSoft.Allocate.Infra.Tables;
using RSoft.Lib.Design.Infra.Data;
using System;
using System.Diagnostics.CodeAnalysis;

namespace RSoft.Allocate.Infra
{

    /// <summary>
    /// Allocate database context
    /// </summary>
    [ExcludeFromCodeCoverage(Justification = "DbContext does not contains rules")]
    public class AllocateContext : DbContextBase<Guid>
    {

        #region Constructors

        /// <summary>
        /// Create a new dbcontext instance
        /// </summary>
        /// <param name="options">Context options settings</param>
        public AllocateContext(DbContextOptions options) : base(options) { }

        #endregion

        #region Overrides

        protected override void SetTableConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EntryConfiguration());
            modelBuilder.ApplyConfiguration(new AccrualPeriodConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        #endregion

        #region DbSets

        /// <summary>
        /// Entry dbset
        /// </summary>
        public virtual DbSet<Entry> Entries { get; set; }

        /// <summary>
        /// Accrual periods dbset
        /// </summary>
        public virtual DbSet<AccrualPeriod> AccrualPeriods { get; set; }

        /// <summary>
        /// Categories dbset
        /// </summary>
        public virtual DbSet<Category> Categories { get; set; }

        /// <summary>
        /// User dbset
        /// </summary>
        public virtual DbSet<User> Users { get; set; }

        #endregion

    }

}
