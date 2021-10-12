using RSoft.Allocate.Core.Entities;
using RSoft.Lib.Design.Infra.Data;
using System;

namespace RSoft.Allocate.Core.Ports
{

    /// <summary>
    /// User provider ports contract
    /// </summary>
    public interface IUserProvider : IRepositoryBase<User, Guid>
    {
    }
}