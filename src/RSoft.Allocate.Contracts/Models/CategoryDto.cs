using RSoft.Lib.Common.Dtos;
using System;
using System.Diagnostics.CodeAnalysis;

namespace RSoft.Allocate.Contracts.Models
{

    /// <summary>
    /// Category data transport object
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CategoryDto : AppDtoIdBase<Guid>
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

        #endregion

    }

}
