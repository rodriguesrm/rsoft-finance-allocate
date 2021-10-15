using Microsoft.Extensions.Localization;
using Microsoft.Extensions.DependencyInjection;
using RSoft.Lib.Common.Abstractions;
using RSoft.Lib.Common.Contracts.Entities;
using RSoft.Lib.Design.Domain.Entities;
using System;
using RSoft.Lib.Common.Contracts;
using FluentValidator;

namespace RSoft.Allocate.Core.Entities
{

    /// <summary>
    /// Entity of months of budget item occurrence
    /// </summary>
    public class BudgetMonth : EntityBase<BudgetMonth>, IEntity
    {

        #region Constructors

        /// <summary>
        /// Create a new budget-month instance
        /// </summary>
        /// <param name="budgetId">Entity id value</param>
        public BudgetMonth(Guid budgetId) : base() 
        {
            BudgetId = budgetId;
        }

        /// <summary>
        /// Create a new budget-month instance
        /// </summary>
        /// <param name="budgetId">Entity id text</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public BudgetMonth(string budgetId) : base()
        {
            BudgetId = new Guid(budgetId);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Budget id key value
        /// </summary>
        public Guid BudgetId { get; protected set; }

        /// <summary>
        /// Budget item occurrence month
        /// </summary>
        public int? Month { get; set; }

        #endregion

        #region Public methods

        ///<inheritdoc/>
        public override void Validate()
        {

            IStringLocalizer<BudgetMonth> localizer = ServiceActivator.GetScope().ServiceProvider.GetService<IStringLocalizer<BudgetMonth>>();

            AddNotifications(new RequiredValidationContract<int?>(Month, nameof(Month), localizer["MONTH_REQUIRED"]).Contract.Notifications);
            if (Month.HasValue && (Month < 1 || Month > 12))
                AddNotification(new Notification(nameof(Month), localizer["INVALID_MONTH"]));

        }

        #endregion

    }
}
