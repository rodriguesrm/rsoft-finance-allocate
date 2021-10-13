using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RSoft.Allocate.Infra.Configurations
{

    /// <summary>
    /// Entry table configuration
    /// </summary>
    public class EntryConfiguration : IEntityTypeConfiguration<Tables.Entry>
    {

        ///<inheritdoc/>
        public void Configure(EntityTypeBuilder<Tables.Entry> builder)
        {

            builder.ToTable(nameof(Tables.Entry));

            #region PK

            builder.HasKey(k => k.Id);

            #endregion

            #region Columns

            builder.Property(c => c.Name)
                .HasColumnName(nameof(Tables.Entry.Name))
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(c => c.CategoryId)
                .IsRequired();

            #endregion

            #region FKs

            builder.HasOne(o => o.Category)
                .WithMany(d => d.Entries)
                .HasForeignKey(fk => fk.CategoryId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName($"FK_{nameof(Tables.Category)}_{nameof(Tables.Entry)}_{nameof(Tables.Entry.CategoryId)}");

            #endregion

            #region Indexes

            builder
                .HasIndex(i => i.Name)
                .HasDatabaseName($"AK_{nameof(Tables.Entry)}_{nameof(Tables.Entry.Name)}")
                .IsUnique();

            #endregion

        }

    }
}
