using RSoft.Allocate.Core.Entities;
using RSoft.Allocate.Core.Ports;
using RSoft.Lib.Common.Contracts.Web;
using RSoft.Lib.Design.Domain.Services;
using System;

namespace RSoft.Allocate.Core.Services
{

    /// <summary>
    /// User domain service operations
    /// </summary>
    public class UserDomainService : DomainServiceBase<User, Guid, IUserProvider>, IUserDomainService
    {

        #region Constructors

        /// <summary>
        /// Create a new scopde domain service instance
        /// </summary>
        /// <param name="provider">User provier</param>
        /// <param name="authenticatedUser">Authenticated user object</param>
        public UserDomainService(IUserProvider provider, IAuthenticatedUser authenticatedUser) : base(provider, authenticatedUser) { }

        #endregion

        #region Overrides

        ///<inheritdoc/>
        public override void PrepareSave(User entity, bool isUpdate) { }

        #endregion

    }
}
