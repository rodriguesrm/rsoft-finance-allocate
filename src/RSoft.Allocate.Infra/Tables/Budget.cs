using RSoft.Finance.Contracts.Enum;
using RSoft.Lib.Common.Contracts.Entities;
using RSoft.Lib.Design.Infra.Data.Tables;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace RSoft.Allocate.Infra.Tables
{

    /// <summary>
    /// Budget table entity
    /// </summary>
    [ExcludeFromCodeCoverage(Justification = "Class to map database table in EntityFramework")]
    public class Budget : TableIdBase<Guid, Budget>, ITable
    {

        #region Constructors

        /// <summary>
        /// Create a new table instance
        /// </summary>
        public Budget() : base(Guid.NewGuid())
        {
            Initialize();
        }

        /// <summary>
        /// Create a new table instance
        /// </summary>
        /// <param name="id">User id value</param>
        public Budget(Guid id) : base(id)
        {
            Initialize();
        }

        /// <summary>
        /// Create a new table instance
        /// </summary>
        /// <param name="id">User id text</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public Budget(string id) : base()
        {
            Id = new Guid(id);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Transaction type
        /// </summary>
        public TransactionTypeEnum TransactionType { get; set; }

        /// <summary>
        /// Budget amount value
        /// </summary>
        public float Amount { get; set; }

        /// <summary>
        /// Indicates whether the commitment item is recurring
        /// </summary>
        public bool IsRecurrent { get; set; }

        /// <summary>
        /// Revenue tax type indicator
        /// </summary>
        public RevenueTaxTypeEnum? RevenueTaxType { get; set; }

        /// <summary>
        /// Entry id key value
        /// </summary>
        public Guid EntryId { get; set; }

        #endregion

        #region Navigation/Lazy

        /// <summary>
        /// Months of budget item occurrence
        /// </summary>
        public virtual ICollection<BudgetMonth> Months { get; set; }

        /// <summary>
        /// Entry data
        /// </summary>
        public Entry Entry { get; set; }

        #endregion

        #region Local methods

        /// <summary>
        /// Iniatialize objects/properties/fields with default values
        /// </summary>
        private void Initialize()
        {
            Months = new HashSet<BudgetMonth>();
        }

        #endregion

    }
}
