using Microsoft.Extensions.Localization;
using Microsoft.Extensions.DependencyInjection;
using RSoft.Finance.Contracts.Enum;
using RSoft.Lib.Common.Abstractions;
using RSoft.Lib.Common.Contracts;
using RSoft.Lib.Design.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using RSoft.Lib.Common.Contracts.Entities;

namespace RSoft.Allocate.Core.Entities
{

    /// <summary>
    /// Budget entity
    /// </summary>
    public class Budget : EntityIdAuditBase<Guid, Budget>, IEntity, IAuditAuthor<Guid>
    {

        #region Constructors

        /// <summary>
        /// Create a new budget instance
        /// </summary>
        public Budget() : base(Guid.NewGuid()) { }

        /// <summary>
        /// Create a new budget instance
        /// </summary>
        /// <param name="id">Budget id value</param>
        public Budget(Guid id) : base(id) { }

        /// <summary>
        /// Create a new budget instance
        /// </summary>
        /// <param name="id">Budget id text</param>
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
        public TransactionTypeEnum? TransactionType { get; set; }

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

        #endregion

        #region Navigation/Lazy

        /// <summary>
        /// Entry data
        /// </summary>
        public Entry Entry { get; set; }

        /// <summary>
        /// Months of budget item occurrence
        /// </summary>
        public IEnumerable<BudgetMonth> Months { get; set; }

        #endregion

        #region Local Methods

        #endregion

        #region Public methods

        ///<inheritdoc/>
        public override void Validate()
        {

            IStringLocalizer<Budget> localizer = ServiceActivator.GetScope().ServiceProvider.GetService<IStringLocalizer<Budget>>();

            if (CreatedAuthor != null) AddNotifications(CreatedAuthor.Notifications);
            if (ChangedAuthor != null) AddNotifications(ChangedAuthor.Notifications);

            if (Amount <= 0)
                AddNotification(nameof(Amount), localizer["GREATER_THAN_ZERO"]);

            int? transactionType = TransactionType.HasValue ? (int)TransactionType : null;
            AddNotifications(new EnumCastFromIntegerValidationContract<TransactionTypeEnum>(transactionType, nameof(transactionType), true).Contract.Notifications);

            AddNotifications(new RequiredValidationContract<Guid?>(Entry?.Id, nameof(Entry), localizer["ENTRY_REQUIRED"]).Contract.Notifications);

            if (IsRecurrent)
            {
                if (Months?.Count() == 0)
                    AddNotification(nameof(Months), localizer["INVALID_MONTHS"]);
                else
                    Months.ToList().ForEach(m => AddNotifications(m.Notifications));
            }
            else
            {
                if (Months.Any())
                    AddNotification(nameof(Months), localizer["BUDGET_IS_NOT_RECURRENT"]);
            }

            int? revenueTaxType = RevenueTaxType.HasValue ? (int)RevenueTaxType : null;
            bool revenuTaxTypeRequired = TransactionType == TransactionTypeEnum.Credit;
            AddNotifications(new EnumCastFromIntegerValidationContract<RevenueTaxTypeEnum>(revenueTaxType, nameof(RevenueTaxType), revenuTaxTypeRequired).Contract.Notifications);

        }

        #endregion

    }

}
