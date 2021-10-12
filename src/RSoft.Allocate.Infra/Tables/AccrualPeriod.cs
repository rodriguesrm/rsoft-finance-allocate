using RSoft.Lib.Design.Infra.Data.Tables;
using System.Diagnostics.CodeAnalysis;

namespace RSoft.Allocate.Infra.Tables
{

    /// <summary>
    /// Accrual period posting record table class
    /// </summary>
    [ExcludeFromCodeCoverage(Justification = "Class to map database table in EntityFramework")]
    public class AccrualPeriod : TableBase<AccrualPeriod>, ITable
    {


        #region Constructors

        /// <summary>
        /// Create a new table instance
        /// </summary>
        public AccrualPeriod() : base() { }

        #endregion

        #region Properties

        /// <summary>
        /// Time course year
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Time course month
        /// </summary>
        public int Month { get; set; }

        /// <summary>
        /// Opening balance for the period
        /// </summary>
        public float OpeningBalance { get; set; }

        /// <summary>
        /// Closed status flag
        /// </summary>
        public bool IsClosed { get; set; }

        #endregion

        #region Navigation/Lazy

        #endregion

    }
}
