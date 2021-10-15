using RSoft.Allocate.Core.Entities;
using RSoft.Lib.Design.Infra.Data;
using System;

namespace RSoft.Allocate.Core.Ports
{

    /// <summary>
    /// Budget provider ports contract
    /// </summary>
    public interface IBudgetProvider : IRepositoryBase<Budget, Guid>
    {
    }
}