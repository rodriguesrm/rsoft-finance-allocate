using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RSoft.Allocate.Infra.Tables;

namespace RSoft.Allocate.Infra.Configurations
{

    /// <summary>
    /// AccrualPeriod table configuration
    /// </summary>
    public class AccrualPeriodConfiguration : IEntityTypeConfiguration<AccrualPeriod>
    {

        ///<inheritdoc/>
        public void Configure(EntityTypeBuilder<AccrualPeriod> builder)
        {

            builder.ToTable(nameof(AccrualPeriod));

            #region PK

            builder.HasKey(k => new { k.Year, k.Month });

            #endregion

            #region Columns

            builder.Property(c => c.Year)
                .HasColumnName(nameof(AccrualPeriod.Year))
                .HasColumnType("smallint")
                .IsRequired();

            builder.Property(c => c.Month)
                .HasColumnName(nameof(AccrualPeriod.Month))
                .HasColumnType("tinyint")
                .IsRequired();

            builder.Property(c => c.OpeningBalance)
                .HasColumnName(nameof(AccrualPeriod.OpeningBalance))
                .IsRequired();


            builder.Property(c => c.IsClosed)
                .HasColumnName(nameof(AccrualPeriod.IsClosed))
                .HasColumnType("bit")
                .HasDefaultValue(false)
                .IsRequired();

            #endregion

            #region FKs


            #endregion

            #region Indexes

            #endregion

        }

    }
}
