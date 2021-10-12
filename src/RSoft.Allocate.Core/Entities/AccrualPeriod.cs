using RSoft.Lib.Common.Contracts.Entities;
using RSoft.Lib.Design.Domain.Entities;

namespace RSoft.Allocate.Core.Entities
{

    /// <summary>
    /// Accrual period posting record entity class
    /// </summary>
    public class AccrualPeriod : EntityBase<AccrualPeriod>, IEntity
    {

        #region Constructors

        /// <summary>
        /// Create a new Accrual Period instance
        /// </summary>
        public AccrualPeriod() : base() { }

        /// <summary>
        /// Create a new Accrual Period instance
        /// </summary>
        /// <param name="year">Year number</param>
        /// <param name="month">Month number</param>
        public AccrualPeriod(int year, int month)
        {
            Year = year;
            Month = month;
        }

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

        #region Public Methods

        ///<inheritdoc/>
        public override void Validate() { }

        #endregion
    }
}
