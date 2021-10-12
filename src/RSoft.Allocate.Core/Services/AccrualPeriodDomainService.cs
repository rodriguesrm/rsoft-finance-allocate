﻿using Microsoft.Extensions.Localization;
using RSoft.Allocate.Core.Entities;
using RSoft.Allocate.Core.Ports;
using RSoft.Lib.Common.Contracts.Web;
using RSoft.Lib.Design.Domain.Services;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace RSoft.Allocate.Core.Services
{

    /// <summary>
    /// AccrualPeriod domain service operations
    /// </summary>
    public class AccrualPeriodDomainService : DomainServiceBase<AccrualPeriod, Guid, IAccrualPeriodProvider>, IAccrualPeriodDomainService
    {

        #region Local objects/variables

        private readonly IStringLocalizer<AccrualPeriodDomainService> _localizer;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new scopde domain service instance
        /// </summary>
        /// <param name="provider">AccrualPeriod provider</param>
        /// <param name="authenticatedAccrualPeriod">Authenticated AccrualPeriod object</param>
        /// <param name="localizer">String localizer object</param>
        public AccrualPeriodDomainService
        (
            IAccrualPeriodProvider provider,
            IAuthenticatedUser authenticatedAccrualPeriod,
            IStringLocalizer<AccrualPeriodDomainService> localizer
        ) : base(provider, authenticatedAccrualPeriod)
        {
            _localizer = localizer;
        }

        #endregion

        #region Overrides

        ///<inheritdoc/>
        public override void PrepareSave(AccrualPeriod entity, bool isUpdate) { }

#pragma warning disable CS0809 // Obsolete member overrides non-obsolete member

        ///<inheritdoc/>
        ///<see cref="GetByKeyAsync(int, int, CancellationToken)"/>
        [Obsolete("This method should not be used for composite primary key entities. Use GetByKeyAsync(int, int, CancellationToken)", true)]
        [ExcludeFromCodeCoverage(Justification = "Obsolete method")]
        public override Task<AccrualPeriod> GetByKeyAsync(Guid key, CancellationToken cancellationToken = default)
            => throw new InvalidOperationException("This method should not be used for composite primary key entities.");

        ///<inheritdoc/>
        ///<see cref="Update(int, int, AccrualPeriod)"/>
        [Obsolete("This method should not be used for composite primary key entities. Use Update(int, int, AccrualPeriod)", true)]
        [ExcludeFromCodeCoverage(Justification = "Obsolete method")]
        public override AccrualPeriod Update(Guid key, AccrualPeriod entity)
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
        public async Task<AccrualPeriod> GetByKeyAsync(int year, int month, CancellationToken cancellationToken = default)
            => await _repository.GetByKeyAsync(year, month, cancellationToken);


        /// <summary>
        /// Update entity on context
        /// </summary>
        /// <param name="year">Year number</param>
        /// <param name="month">Month number</param>
        /// <param name="entity">Entity to update</param>
        public AccrualPeriod Update(int year, int month, AccrualPeriod entity)
        {
            entity.Validate();
            if (entity.Invalid) return entity;
            PrepareSave(entity, true);
            AccrualPeriod savedEntity = _repository.Update(year, month, entity);
            return savedEntity;
        }

        ///<inheritdoc/>
        public void Delete(int year, int month)
            => _repository.Delete(year, month);

        #endregion

    }
}
