using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Common.Repository
{
    public interface IRepositoryContext
    {
        Task SaveChangesAsync();
    }
}
