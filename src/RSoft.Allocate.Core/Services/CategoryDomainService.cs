using RSoft.Allocate.Core.Entities;
using RSoft.Allocate.Core.Ports;
using RSoft.Lib.Common.Contracts.Web;
using RSoft.Lib.Design.Domain.Services;
using System;

namespace RSoft.Allocate.Core.Services
{

    /// <summary>
    /// Category domain service operations
    /// </summary>
    public class CategoryDomainService : DomainServiceBase<Category, Guid, ICategoryProvider>, ICategoryDomainService
    {

        #region Constructors

        /// <summary>
        /// Create a new scopde domain service instance
        /// </summary>
        /// <param name="provider">Category provier</param>
        /// <param name="authenticatedCategory">Authenticated Category object</param>
        public CategoryDomainService(ICategoryProvider provider, IAuthenticatedUser authenticatedCategory) : base(provider, authenticatedCategory) { }

        #endregion

        #region Overrides

        ///<inheritdoc/>
        public override void PrepareSave(Category entity, bool isUpdate) { }

        #endregion

    }
}
