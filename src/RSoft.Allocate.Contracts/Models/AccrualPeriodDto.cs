using RSoft.Lib.Common.Dtos;
using System.Diagnostics.CodeAnalysis;

namespace RSoft.Allocate.Contracts.Models
{

    /// <summary>
    /// AccrualPeriod data transport object
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class AccrualPeriodDto : AppDtoBase
    {

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
        /// Closed status flag
        /// </summary>
        public bool IsClosed { get; set; }

        #endregion

    }

}
