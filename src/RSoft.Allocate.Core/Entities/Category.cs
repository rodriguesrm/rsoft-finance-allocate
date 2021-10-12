using RSoft.Lib.Common.Contracts.Entities;
using RSoft.Lib.Design.Domain.Entities;
using System;

namespace RSoft.Allocate.Core.Entities
{

    /// <summary>
    /// Category entity
    /// </summary>
    public class Category : EntityIdBase<Guid, Category>, IEntity, IActive
    {

        #region Constructors

        /// <summary>
        /// Create a new category instance
        /// </summary>
        public Category() : base(Guid.NewGuid())
        {
            Initialize();
        }

        /// <summary>
        /// Create a new category instance
        /// </summary>
        /// <param name="id">Category id value</param>
        public Category(Guid id) : base(id)
        {
            Initialize();
        }

        /// <summary>
        /// Create a new category instance
        /// </summary>
        /// <param name="id">Category id text</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public Category(string id) : base()
        {
            Id = new Guid(id);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Category name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Indicate if entity is active
        /// </summary>
        public bool IsActive { get; set; }

        #endregion

        #region Local Methods

        /// <summary>
        /// Iniatialize objects/properties/fields with default values
        /// </summary>
        private void Initialize()
        {
            IsActive = true;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Validate entity
        /// </summary>
        public override void Validate() { }

        #endregion

    }
}
