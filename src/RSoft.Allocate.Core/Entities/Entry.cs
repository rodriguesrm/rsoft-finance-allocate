using RSoft.Lib.Common.Contracts.Entities;
using RSoft.Lib.Design.Domain.Entities;
using System;

namespace RSoft.Allocate.Core.Entities
{

    /// <summary>
    /// Entry entity
    /// </summary>
    public class Entry : EntityIdBase<Guid, Entry>, IEntity, IActive
    {

        #region Constructors

        /// <summary>
        /// Create a new Entry instance
        /// </summary>
        public Entry() : base(Guid.NewGuid())
        {
            Initialize();
        }

        /// <summary>
        /// Create a new Entry instance
        /// </summary>
        /// <param name="id">Entry id value</param>
        public Entry(Guid id) : base(id)
        {
            Initialize();
        }

        /// <summary>
        /// Create a new Entry instance
        /// </summary>
        /// <param name="id">Entry id text</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public Entry(string id) : base()
        {
            Id = new Guid(id);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Entry name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Indicate if entity is active
        /// </summary>
        public bool IsActive { get; set; }

        #endregion

        #region Navigation/Lazy

        /// <summary>
        /// Category data
        /// </summary>
        public virtual Category Category { get; set; }

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

        ///<inheritdoc/>
        public override void Validate() { }

        #endregion

    }
}
