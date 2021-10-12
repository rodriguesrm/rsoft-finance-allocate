using RSoft.Allocate.Core.Ports;
using RSoft.Allocate.Infra.Extensions;
using RSoft.Lib.Design.Infra.Data;
using System;
using EntryDomain = RSoft.Allocate.Core.Entities.Entry;
using EntryTable = RSoft.Allocate.Infra.Tables.Entry;

namespace RSoft.Allocate.Infra.Providers
{

    /// <summary>
    /// Entry provider
    /// </summary>
    public class EntryProvider : RepositoryBase<EntryDomain, EntryTable, Guid>, IEntryProvider
    {

        #region Constructors

        ///<inheritdoc/>
        public EntryProvider(AllocateContext ctx) : base(ctx) { }

        #endregion

        #region Overrides

        ///<inheritdoc/>
        protected override EntryDomain Map(EntryTable table)
            => table.Map();

        ///<inheritdoc/>
        protected override EntryTable MapForAdd(EntryDomain entity)
            => entity.Map();

        ///<inheritdoc/>
        protected override EntryTable MapForUpdate(EntryDomain entity, EntryTable table)
            => entity.Map(table);

        #endregion

    }
}
