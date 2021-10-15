using RSoft.Allocate.Infra.Tables;
using System.Collections.Generic;
using System.Linq;
using BudgetMonthDomain = RSoft.Allocate.Core.Entities.BudgetMonth;

namespace RSoft.Allocate.Infra.Extensions
{

    /// <summary>
    /// BudgetMonth extesions
    /// </summary>
    public static class BudgetMonthExtension
    {

        /// <summary>
        /// Maps table to entity
        /// </summary>
        /// <param name="table">Table entity to map</param>
        public static BudgetMonthDomain Map(this BudgetMonth table)
        {
            BudgetMonthDomain result = null;

            if (table != null)
            {
                result = new BudgetMonthDomain(table.BudgetId)
                {
                    Month = table.Month
                };
            }

            return result;

        }

        /// <summary>
        /// Maps table list to entity list
        /// </summary>
        /// <param name="rows">Table lists</param>
        /// <returns></returns>
        public static IEnumerable<BudgetMonthDomain> Map(this IEnumerable<BudgetMonth> rows)
            => rows.Select(s => s.Map());

        /// <summary>
        /// Maps entity to table
        /// </summary>
        /// <param name="entity">Domain entity to map</param>
        public static BudgetMonth Map(this BudgetMonthDomain entity)
        {

            BudgetMonth result = null;

            if (entity != null)
            {
                result = new BudgetMonth(entity.BudgetId)
                {
                    Month = entity.Month
                };
            }

            return result;

        }

        /// <summary>
        /// Map entity list to table list
        /// </summary>
        /// <param name="entities">Entity list</param>
        public static IEnumerable<BudgetMonth> Map(this IEnumerable<BudgetMonthDomain> entities)
            => entities.Select(s => s.Map());

        /// <summary>
        /// Maps entity to an existing table
        /// </summary>
        /// <param name="entity">Domain entity to map</param>
        /// <param name="table">Instance of existing table entity</param>
        public static BudgetMonth Map(this BudgetMonthDomain entity, BudgetMonth table)
        {

            if (entity != null && table != null)
            {
                table.Month = entity.Month;
            }

            return table;

        }

    }

}
