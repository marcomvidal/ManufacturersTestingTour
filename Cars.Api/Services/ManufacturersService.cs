using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cars.Api.Infrastructure;
using Cars.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Cars.Api.Services
{
    public interface IManufacturersService
    {
        Task<IEnumerable<Manufacturer>> GetAll();
        Task<Manufacturer> GetById(int id);
        Task<int> Save(Manufacturer manufacturer);
    }

    public class ManufacturersService : IManufacturersService
    {
        readonly DatabaseContext db;

        public ManufacturersService(DatabaseContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Manufacturer>> GetAll() =>
            await this.db.Manufacturers
                .OrderBy(m => m.Name)
                .Include(m => m.Cars)
                .ToListAsync();

        public async Task<Manufacturer> GetById(int id) =>
            await this.db.Manufacturers
                .Where(m => m.Id == id)
                .Include(m => m.Cars)
                .FirstOrDefaultAsync();

        public async Task<int> Save(Manufacturer manufacturer)
        {
            await this.db.Manufacturers.AddAsync(manufacturer);
            return await this.db.SaveChangesAsync();
        }
    }
}