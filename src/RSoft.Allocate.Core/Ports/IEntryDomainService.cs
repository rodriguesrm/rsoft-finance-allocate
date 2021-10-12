using DomainEntry = RSoft.Allocate.Core.Entities.Entry;
using RSoft.Lib.Design.Domain.Services;
using System;

namespace RSoft.Allocate.Core.Ports
{

    /// <summary>
    /// Entry domain service interface
    /// </summary>
    public interface IEntryDomainService : IDomainServiceBase<DomainEntry, Guid>
    {
    }

}