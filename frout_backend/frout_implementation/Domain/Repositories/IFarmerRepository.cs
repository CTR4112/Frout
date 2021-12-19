using frout_implementation.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace frout_implementation.Domain.Repositories
{
    public interface IFarmerRepository
    {
        Task<Farmer> GetFarmerByIdAsync(int farmerid);
    }
}
