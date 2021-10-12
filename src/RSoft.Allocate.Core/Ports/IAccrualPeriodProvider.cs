﻿using RSoft.Allocate.Core.Entities;
using RSoft.Lib.Design.Infra.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RSoft.Allocate.Core.Ports
{

    /// <summary>
    /// Time course provider ports contract
    /// </summary>
    public interface IAccrualPeriodProvider : IRepositoryBase<AccrualPeriod, Guid>
    {

        /// <summary>
        /// Get row by key values
        /// </summary>
        /// <param name="year">Year number</param>
        /// <param name="month">Month number</param>
        /// <param name="cancellationToken">A System.Threading.CancellationToken to observe while waiting for the task to complete</param>
        Task<AccrualPeriod> GetByKeyAsync(int year, int month, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update entity on context
        /// </summary>
        /// <param name="year">Year number</param>
        /// <param name="month">Month number</param>
        /// <param name="entity">Entity to update</param>
        AccrualPeriod Update(int year, int month, AccrualPeriod entity);

        /// <summary>
        /// Delete entity from context
        /// </summary>
        /// <param name="year">Year number</param>
        /// <param name="month">Month number</param>
        void Delete(int year, int month);

    }
}