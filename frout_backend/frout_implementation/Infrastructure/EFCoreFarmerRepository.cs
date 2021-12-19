using frout_implementation.Domain.Model;
using frout_implementation.Domain.Repositories;
using frout_implementation.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace frout_implementation.Infrastructure
{
    public class EFCoreFarmerRepository : IFarmerRepository
    {
        public FroutDbContext _context { get; set; }
        public EFCoreFarmerRepository(FroutDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Farmer> GetFarmerByIdAsync(int farmerid)
        {
            return await _context.Farmers.SingleOrDefaultAsync(f => f.Id == farmerid);
        }
    }
}
