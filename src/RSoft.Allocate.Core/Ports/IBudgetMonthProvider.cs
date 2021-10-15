using RSoft.Allocate.Core.Entities;
using RSoft.Lib.Design.Infra.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RSoft.Allocate.Core.Ports
{

    /// <summary>
    /// BudgetMonth provider ports contract
    /// </summary>
    public interface IBudgetMonthProvider : IRepositoryBase<BudgetMonth, Guid>
    {

        /// <summary>
        /// Get row by key values
        /// </summary>
        /// <param name="budgetId">Budget id key value</param>
        /// <param name="month">Month number</param>
        /// <param name="cancellationToken">A System.Threading.CancellationToken to observe while waiting for the task to complete</param>
        Task<BudgetMonth> GetByKeyAsync(Guid budgetId, int month, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update entity on context
        /// </summary>
        /// <param name="budgetId">Budget id key value</param>
        /// <param name="month">Month number</param>
        /// <param name="entity">Entity to update</param>
        BudgetMonth Update(Guid budgetId, int month, BudgetMonth entity);

        /// <summary>
        /// Delete entity from context
        /// </summary>
        /// <param name="budget">Budget id key value</param>
        /// <param name="month">Month number</param>
        void Delete(Guid budget, int month);

    }
}