using RSoft.Lib.Common.Dtos;
using RSoft.Lib.Common.Models;
using System;
using System.Diagnostics.CodeAnalysis;

namespace RSoft.Allocate.Contracts.Models
{

    /// <summary>
    /// Entry data transport object
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class EntryDto : AppDtoIdBase<Guid>
    {

        #region Properties

        /// <summary>
        /// Entity name value
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Indicate if entity is active
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Category data
        /// </summary>
        public SimpleIdentification<Guid> Category { get; set; }

        #endregion

    }

}
