using RSoft.Allocate.Core.Entities;
using RSoft.Lib.Design.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RSoft.Allocate.Core.Ports
{

    /// <summary>
    /// Budget domain service interface
    /// </summary>
    public interface IBudgetDomainService : IDomainServiceBase<Budget, Guid>
    {

        /// <summary>
        /// Add occurrence month to budget item
        /// </summary>
        /// <param name="budgetId">Budget id key value</param>
        /// <param name="month">Month number</param>
        /// <returns></returns>
        Task AddMonth(Guid budgetId, int month);

        /// <summary>
        /// Adds the occurrence months to the budget item
        /// </summary>
        /// <param name="budgetId">Budget id key value</param>
        /// <param name="months">Months number list</param>
        Task AddMonths(Guid budgetId, IEnumerable<int> months);

        /// <summary>
        /// Remove occurrence month from budget item
        /// </summary>
        /// <param name="budgetId">Budget id key value</param>
        /// <param name="month">Month number</param>
        void RemoveMonth(Guid budgetId, int month);

        /// <summary>
        /// Remove the occurrence months to the budget item
        /// </summary>
        /// <param name="budgetId">Budget id key value</param>
        /// <param name="months">Months number list</param>
        void RemoveMonths(Guid budgetId, IEnumerable<int> months);

        /// <summary>
        /// Remove all occurrence months from budget item
        /// </summary>
        /// <param name="budgetId">Budget id key value</param>
        void ClearMonths(Guid budgetId);

    }

}