using DomainEntry = RSoft.Allocate.Core.Entities.Entry;
using RSoft.Lib.Common.Contracts.Web;
using RSoft.Lib.Design.Domain.Services;
using System;
using RSoft.Allocate.Core.Ports;

namespace RSoft.Allocate.Core.Services
{

    /// <summary>
    /// Entry domain service operations
    /// </summary>
    public class EntryDomainService : DomainServiceBase<DomainEntry, Guid, IEntryProvider>, IEntryDomainService
    {

        #region Constructors

        /// <summary>
        /// Create a new scopde domain service instance
        /// </summary>
        /// <param name="provider">Entry provider</param>
        /// <param name="authenticatedUser">Authenticated user object</param>
        public EntryDomainService(IEntryProvider provider, IAuthenticatedUser authenticatedUser) : base(provider, authenticatedUser) { }

        #endregion

        #region Overrides

        ///<inheritdoc/>
        public override void PrepareSave(DomainEntry entity, bool isUpdate) { }

        #endregion

    }
}
