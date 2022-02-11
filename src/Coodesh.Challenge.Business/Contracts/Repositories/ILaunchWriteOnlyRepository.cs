using Coodesh.Challenge.Business.Models;
using System;

namespace Coodesh.Challenge.Business.Contracts.Repositories
{
    public interface ILaunchWriteOnlyRepository : IWriteOnlyRepository<Launch, Guid>
    {
    }
}