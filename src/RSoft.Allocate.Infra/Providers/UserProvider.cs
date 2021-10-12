using RSoft.Allocate.Core.Ports;
using RSoft.Allocate.Infra.Extensions;
using RSoft.Allocate.Infra.Tables;
using RSoft.Lib.Design.Infra.Data;
using System;
using UserDomain = RSoft.Allocate.Core.Entities.User;

namespace RSoft.Allocate.Infra.Providers
{

    /// <summary>
    /// User provider
    /// </summary>
    public class UserProvider : RepositoryBase<UserDomain, User, Guid>, IUserProvider
    {

        #region Constructors

        ///<inheritdoc/>
        public UserProvider(AllocateContext ctx) : base(ctx) { }

        #endregion

        #region Overrides

        ///<inheritdoc/>
        protected override UserDomain Map(User table)
            => table.Map();

        ///<inheritdoc/>
        protected override User MapForAdd(UserDomain entity)
            => entity.Map();

        ///<inheritdoc/>
        protected override User MapForUpdate(UserDomain entity, User table)
            => entity.Map(table);

        #endregion

    }
}
