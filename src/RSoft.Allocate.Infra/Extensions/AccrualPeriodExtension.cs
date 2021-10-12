using RSoft.Allocate.Infra.Tables;
using AccrualPeriodDomain = RSoft.Allocate.Core.Entities.AccrualPeriod;

namespace RSoft.Allocate.Infra.Extensions
{

    /// <summary>
    /// AccrualPeriod extesions
    /// </summary>
    public static class AccrualPeriodExtension
    {

        /// <summary>
        /// Maps table to entity
        /// </summary>
        /// <param name="table">Table entity to map</param>
        public static AccrualPeriodDomain Map(this AccrualPeriod table)
            => table.Map(true);

        /// <summary>
        /// Maps table to entity
        /// </summary>
        /// <param name="table">Table entity to map</param>
        /// <param name="useLazy">Load related data</param>
        public static AccrualPeriodDomain Map(this AccrualPeriod table, bool useLazy)
        {
            AccrualPeriodDomain result = null;

            if (table != null)
            {

                result = new AccrualPeriodDomain()
                {
                    Year = table.Year,
                    Month = table.Month,
                    OpeningBalance = table.OpeningBalance,
                    IsClosed = table.IsClosed
                };
            }

            return result;

        }

        /// <summary>
        /// Maps entity to table
        /// </summary>
        /// <param name="entity">Domain entity to map</param>
        public static AccrualPeriod Map(this AccrualPeriodDomain entity)
        {

            AccrualPeriod result = null;

            if (entity != null)
            {
                result = new AccrualPeriod()
                {
                    Year = entity.Year,
                    Month = entity.Month,
                    OpeningBalance = entity.OpeningBalance,
                    IsClosed = entity.IsClosed
                };
            }

            return result;

        }

        /// <summary>
        /// Maps entity to an existing table
        /// </summary>
        /// <param name="entity">Domain entity to map</param>
        /// <param name="table">Instance of existing table entity</param>
        public static AccrualPeriod Map(this AccrualPeriodDomain entity, AccrualPeriod table)
        {

            if (entity != null && table != null)
            {
                table.Year = entity.Year;
                table.Month = entity.Month;
                table.OpeningBalance = entity.OpeningBalance;
                table.IsClosed = entity.IsClosed;
            }

            return table;

        }

    }

}
