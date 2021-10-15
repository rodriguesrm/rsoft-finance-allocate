using RSoft.Allocate.Infra.Tables;
using System.Linq;
using BudgetDomain = RSoft.Allocate.Core.Entities.Budget;

namespace RSoft.Allocate.Infra.Extensions
{

    /// <summary>
    /// Budget extesions
    /// </summary>
    public static class BudgetExtension
    {

        /// <summary>
        /// Maps table to entity
        /// </summary>
        /// <param name="table">Table entity to map</param>
        public static BudgetDomain Map(this Budget table)
            => table.Map(true);

        /// <summary>
        /// Maps table to entity
        /// </summary>
        /// <param name="table">Table entity to map</param>
        /// <param name="useLazy">Load related data</param>
        public static BudgetDomain Map(this Budget table, bool useLazy)
        {
            BudgetDomain result = null;

            if (table != null)
            {
                result = new BudgetDomain(table.Id)
                {
                    TransactionType = table.TransactionType,
                    Amount = table.Amount,
                    IsRecurrent = table.IsRecurrent,
                    RevenueTaxType = table.RevenueTaxType,
                    Months = table.Months?.Map()
                };

                if (useLazy)
                    result.Entry = table.Entry.Map(false);
            }

            return result;

        }

        /// <summary>
        /// Maps entity to table
        /// </summary>
        /// <param name="entity">Domain entity to map</param>
        public static Budget Map(this BudgetDomain entity)
        {

            Budget result = null;

            if (entity != null)
            {
                result = new Budget(entity.Id)
                {
                    TransactionType = entity.TransactionType.Value,
                    Amount = entity.Amount,
                    IsRecurrent = entity.IsRecurrent,
                    RevenueTaxType = entity.RevenueTaxType,
                    Months = entity.Months?.Map().ToList()
                };
                result.Entry = entity.Entry.Map();
            }

            return result;

        }

        /// <summary>
        /// Maps entity to an existing table
        /// </summary>
        /// <param name="entity">Domain entity to map</param>
        /// <param name="table">Instance of existing table entity</param>
        public static Budget Map(this BudgetDomain entity, Budget table)
        {

            if (entity != null && table != null)
            {
                table.TransactionType = entity.TransactionType.Value;
                table.Amount = entity.Amount;
                table.IsRecurrent = entity.IsRecurrent;
                table.RevenueTaxType = entity.RevenueTaxType;
                table.EntryId = entity.Entry.Id;
            }

            return table;

        }

    }

}
