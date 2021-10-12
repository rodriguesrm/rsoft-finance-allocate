using RSoft.Lib.Design.Infra.Data;
using System;

namespace RSoft.Allocate.Core.Ports
{

    /// <summary>
    /// Entry provider ports contract
    /// </summary>
    public interface IEntryProvider : IRepositoryBase<Entities.Entry, Guid>
    {
    }
}