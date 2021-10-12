using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RSoft.Allocate.Infra.Tables;

namespace RSoft.Allocate.Infra.Configurations
{

    /// <summary>
    /// Category table configuration
    /// </summary>
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {

        ///<inheritdoc/>
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.ToTable(nameof(Category));

            #region PK

            builder.HasKey(k => k.Id);

            #endregion

            #region Columns

            builder.Property(c => c.Name)
                .HasColumnName(nameof(Category.Name))
                .HasMaxLength(80)
                .IsUnicode(false)
                .IsRequired();

            #endregion

            #region FKs

            #endregion

            #region Indexes

            builder
                .HasIndex(i => i.Name)
                .HasDatabaseName($"AK_{nameof(Category)}_{nameof(Category.Name)}")
                .IsUnique();

            #endregion

        }

    }
}
