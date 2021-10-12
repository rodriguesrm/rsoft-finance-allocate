using EntryDomain = RSoft.Allocate.Core.Entities.Entry;
using EntryTable = RSoft.Allocate.Infra.Tables.Entry;
using CategoryDomain = RSoft.Allocate.Core.Entities.Category;

namespace RSoft.Allocate.Infra.Extensions
{

    /// <summary>
    /// Entry extesions
    /// </summary>
    public static class EntryExtension
    {

        /// <summary>
        /// Maps table to entity
        /// </summary>
        /// <param name="table">Table entity to map</param>
        public static EntryDomain Map(this EntryTable table)
            => table.Map(true);

        /// <summary>
        /// Maps table to entity
        /// </summary>
        /// <param name="table">Table entity to map</param>
        /// <param name="useLazy">Load related data</param>
        public static EntryDomain Map(this EntryTable table, bool useLazy)
        {
            EntryDomain result = null;

            if (table != null)
            {

                result = new EntryDomain(table.Id)
                {
                    Name = table.Name,
                    IsActive = table.IsActive,
                };

                if (useLazy)
                {
                    result.Category = table.Category?.Map(false);
                }
                else
                {
                    result.Category = new CategoryDomain(table.CategoryId);
                }

            }

            return result;

        }

        /// <summary>
        /// Maps entity to table
        /// </summary>
        /// <param name="entity">Domain entity to map</param>
        public static EntryTable Map(this EntryDomain entity)
        {

            EntryTable result = null;

            if (entity != null)
            {
                result = new EntryTable(entity.Id)
                {
                    Name = entity.Name,
                    CategoryId = entity.Category.Id,
                    IsActive = entity.IsActive
                };
            }

            return result;

        }

        /// <summary>
        /// Maps entity to an existing table
        /// </summary>
        /// <param name="entity">Domain entity to map</param>
        /// <param name="table">Instance of existing table entity</param>
        public static EntryTable Map(this EntryDomain entity, EntryTable table)
        {

            if (entity != null && table != null)
            {
                table.Name = entity.Name;
                table.CategoryId = entity.Category.Id;
                table.IsActive = entity.IsActive;
            }

            return table;

        }

    }

}
