using RSoft.Lib.Design.Infra.Data.Tables;
using System;
using System.Diagnostics.CodeAnalysis;

namespace RSoft.Allocate.Infra.Tables
{

    /// <summary>
    /// BudgetMonth table entity
    /// </summary>
    [ExcludeFromCodeCoverage(Justification = "Class to map database table in EntityFramework")]
    public class BudgetMonth : TableBase<BudgetMonth>, ITable
    {

        #region Constructors

        /// <summary>
        /// Create a new table instance
        /// </summary>
        public BudgetMonth() : base() { }

        /// <summary>
        /// Create a new table instance
        /// </summary>
        /// <param name="budgetId">Budget id value</param>
        public BudgetMonth(Guid budgetId) : base()
        {
            BudgetId = budgetId;
        }

        /// <summary>
        /// Create a new table instance
        /// </summary>
        /// <param name="id">User id text</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public BudgetMonth(string id) : base()
        {
            BudgetId = new Guid(id);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Budget id key value
        /// </summary>
        public Guid BudgetId { get; set; }

        /// <summary>
        /// Budget item occurrence month
        /// </summary>
        public int? Month { get; set; }

        #endregion

    }
}
