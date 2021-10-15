using RSoft.Allocate.Core.Ports;
using RSoft.Allocate.Infra.Extensions;
using RSoft.Allocate.Infra.Tables;
using RSoft.Lib.Design.Infra.Data;
using System;
using BudgetDomain = RSoft.Allocate.Core.Entities.Budget;

namespace RSoft.Allocate.Infra.Providers
{

    /// <summary>
    /// Budget provider
    /// </summary>
    public class BudgetProvider : RepositoryBase<BudgetDomain, Budget, Guid>, IBudgetProvider
    {

        #region Constructors

        ///<inheritdoc/>
        public BudgetProvider(AllocateContext ctx) : base(ctx) { }

        #endregion

        #region Overrides

        ///<inheritdoc/>
        protected override BudgetDomain Map(Budget table)
            => table.Map();

        ///<inheritdoc/>
        protected override Budget MapForAdd(BudgetDomain entity)
            => entity.Map();

        ///<inheritdoc/>
        protected override Budget MapForUpdate(BudgetDomain entity, Budget table)
            => entity.Map(table);

        #endregion

    }
}
