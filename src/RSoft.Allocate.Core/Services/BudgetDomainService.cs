using RSoft.Allocate.Core.Entities;
using RSoft.Allocate.Core.Ports;
using RSoft.Lib.Common.Contracts.Web;
using RSoft.Lib.Common.ValueObjects;
using RSoft.Lib.Design.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSoft.Allocate.Core.Services
{

    /// <summary>
    /// Budget domain service operations
    /// </summary>
    public class BudgetDomainService : DomainServiceBase<Budget, Guid, IBudgetProvider>, IBudgetDomainService
    {

        #region Local objects/variables

        private readonly IBudgetMonthProvider _monthProvider;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new scopde domain service instance
        /// </summary>
        /// <param name="provider">Budget provider</param>
        /// <param name="monthProvider">Budget month provider</param>
        /// <param name="authenticatedBudget">Authenticated Budget object</param>
        public BudgetDomainService(IBudgetProvider provider, IBudgetMonthProvider monthProvider, IAuthenticatedUser authenticatedBudget) : base(provider, authenticatedBudget) 
        {
            _monthProvider = monthProvider;
        }

        #endregion

        #region Overrides

        ///<inheritdoc/>
        public override void PrepareSave(Budget entity, bool isUpdate) 
        {

            if (isUpdate)
            {
                if (entity.ChangedAuthor == null)
                {
                    entity.ChangedAuthor = new AuthorNullable<Guid>(_authenticatedUser.Id.Value, $"{_authenticatedUser.FirstName} {_authenticatedUser.LastName}");
                    entity.ChangedOn = DateTime.UtcNow;
                }
            }
            else
            {
                entity.CreatedAuthor = new Author<Guid>(_authenticatedUser.Id.Value, $"{_authenticatedUser.FirstName} {_authenticatedUser.LastName}");
                entity.CreatedOn = DateTime.UtcNow;
            }

        }

        #endregion

        #region Public methods

        ///<inheritdoc/>
        public Task AddMonth(Guid budgetId, int month)
            => _monthProvider.AddAsync(new BudgetMonth(budgetId) { Month = month });

        ///<inheritdoc/>
        public Task AddMonths(Guid budgetId, IEnumerable<int> months)
        {
            IList<Task> tasks = new List<Task>();
            foreach (int month in months)
            {
                tasks.Add(_monthProvider.AddAsync(new BudgetMonth(budgetId) { Month = month }));
            }
            return Task.WhenAll(tasks);
        }

        ///<inheritdoc/>
        public void RemoveMonth(Guid budgetId, int month)
            => _monthProvider.Delete(budgetId, month);

        ///<inheritdoc/>
        public void RemoveMonths(Guid budgetId, IEnumerable<int> months)
        {
            foreach (int month in months)
            {
                _monthProvider.Delete(budgetId, month);
            }
        } 

        ///<inheritdoc/>
        public void ClearMonths(Guid budgetId)
        {
            Budget budget = _repository.GetByKeyAsync(budgetId, default).Result;
            if (budget.Months.Any())
                foreach (BudgetMonth budgetMonth in budget.Months)
                {
                    _monthProvider.Delete(budgetId, budgetMonth.Month.Value);
                }
        }

        #endregion

    }
}
