using RSoft.Allocate.Core.Ports;
using RSoft.Allocate.Infra.Extensions;
using RSoft.Allocate.Infra.Tables;
using RSoft.Lib.Design.Exceptions;
using RSoft.Lib.Design.Infra.Data;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using BudgetMonthDomain = RSoft.Allocate.Core.Entities.BudgetMonth;

namespace RSoft.Allocate.Infra.Providers
{

    /// <summary>
    /// BudgetMonth provider
    /// </summary>
    public class BudgetMonthProvider : RepositoryBase<BudgetMonthDomain, BudgetMonth, Guid>, IBudgetMonthProvider
    {

        #region Constructors

        ///<inheritdoc/>
        public BudgetMonthProvider(AllocateContext ctx) : base(ctx) { }

        #endregion

        #region Overrides

        ///<inheritdoc/>
        protected override BudgetMonthDomain Map(BudgetMonth table)
            => table.Map();

        ///<inheritdoc/>
        protected override BudgetMonth MapForAdd(BudgetMonthDomain entity)
            => entity.Map();

        ///<inheritdoc/>
        protected override BudgetMonth MapForUpdate(BudgetMonthDomain entity, BudgetMonth table)
            => entity.Map(table);

#pragma warning disable CS0809 // Obsolete member overrides non-obsolete member

        ///<inheritdoc/>
        ///<see cref="GetByKeyAsync(int, int, CancellationToken)"/>
        [Obsolete("This method should not be used for composite primary key entities. Use GetByKeyAsync(int, int, CancellationToken)", true)]
        [ExcludeFromCodeCoverage(Justification = "Obsolete method")]
        public override Task<BudgetMonthDomain> GetByKeyAsync(Guid key, CancellationToken cancellationToken = default)
            => throw new InvalidOperationException("This method should not be used for composite primary key entities.");

        ///<inheritdoc/>
        ///<see cref="Update(int, int, BudgetMonthDomain)"/>
        [Obsolete("This method should not be used for composite primary key entities. Use GetByKeyAsync(int, int, BudgetMonth)", true)]
        [ExcludeFromCodeCoverage(Justification = "Obsolete method")]
        public override BudgetMonthDomain Update(Guid key, BudgetMonthDomain entity)
            => throw new InvalidOperationException("This method should not be used for composite primary key entities.");

        ///<inheritdoc/>
        ///<see cref="Delete(int, int)"/>
        [Obsolete("This method should not be used for composite primary key entities. Use Delete(int, int)", true)]
        [ExcludeFromCodeCoverage(Justification = "Obsolete method")]
        public override void Delete(Guid key)
            => throw new InvalidOperationException("This method should not be used for composite primary key entities.");

#pragma warning restore CS0809 // Obsolete member overrides non-obsolete member

        #endregion

        #region Public methods

        ///<inheritdoc/>
        public async Task<BudgetMonthDomain> GetByKeyAsync(Guid budgetId, int month, CancellationToken cancellationToken = default)
        {
            BudgetMonth table = await Task.Run(() => _dbSet.Find(budgetId, month));
            BudgetMonthDomain entity = Map(table);
            return entity;
        }

        ///<inheritdoc/>
        public BudgetMonthDomain Update(Guid budgetId, int month, BudgetMonthDomain entity)
        {

            if (entity.Invalid)
                throw new InvalidEntityException(nameof(entity));

            BudgetMonth table = _dbSet.Find(budgetId, month);
            if (table == null)
                throw new InvalidOperationException($"[{budgetId},{month}] The data update operation cannot be completed because the entity does not exist in the database. The same may have been deleted.");

            table = MapForUpdate(entity, table);
            table = _dbSet.Update(table).Entity;

            entity = Map(table);
            return entity;

        }

        ///<inheritdoc/>
        public void Delete(Guid budgetid, int month)
        {
            BudgetMonth table = _dbSet.Find(budgetid, month);
            _dbSet.Remove(table);
        }

        #endregion

    }
}
